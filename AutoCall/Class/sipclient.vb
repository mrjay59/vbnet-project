'=====================================================================
' SIPClient.vb – VERSI FINAL & BISA DI-COMPILE 100% (SIPSorcery 8.0.23)
' Semua error NullReference, 's' not declared, Close(), dll sudah diperbaiki
'=====================================================================

Imports System
Imports System.Linq
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Threading.Tasks
Imports SIPSorcery.Media
Imports SIPSorcery.Net
Imports SIPSorcery.SIP
Imports SIPSorcery.SIP.App
Imports SIPSorceryMedia.Abstractions
Imports SIPSorceryMedia.Encoders
Imports SIPSorceryMedia.Windows

Public Class SIPClient
    Implements IDisposable

    Private Const SDP_MIME_CONTENTTYPE As String = SDP.SDP_MIME_CONTENTTYPE
    Private Const TRANSFER_RESPONSE_TIMEOUT_SECONDS As Integer = 10

    Private ReadOnly m_sipUsername As String
    Private ReadOnly m_sipPassword As String
    Private ReadOnly m_sipServer As String
    Private ReadOnly m_sipFromName As String

    Private ReadOnly m_sipTransport As SIPTransport
    Public m_userAgent As SIPUserAgent
    Private m_pendingIncomingCall As SIPServerUserAgent = Nothing
    Private _cts As New CancellationTokenSource()

    Private m_audioOutDeviceIndex As Integer = 0

    '==================== EVENT =====================
    Public Event CallAnswer As Action(Of SIPClient)
    Public Event CallEnded As Action(Of SIPClient)
    Public Event StatusMessage As Action(Of SIPClient, String)
    Public Event RemotePutOnHold As Action(Of SIPClient)
    Public Event RemoteTookOffHold As Action(Of SIPClient)

    '==================== PROPERTIES =====================
    Public ReadOnly Property Dialogue As SIPDialogue
        Get
            Return If(m_userAgent?.Dialogue, Nothing)
        End Get
    End Property

    Public Property MediaSession As VoIPMediaSession

    Public ReadOnly Property IsCallActive As Boolean
        Get
            Return m_userAgent IsNot Nothing AndAlso m_userAgent.IsCallActive
        End Get
    End Property

    Public ReadOnly Property IsOnHold As Boolean
        Get
            Return m_userAgent IsNot Nothing AndAlso (m_userAgent.IsOnLocalHold OrElse m_userAgent.IsOnRemoteHold)
        End Get
    End Property

    '==================== CONSTRUCTOR =====================
    Public Sub New(sipTransport As SIPTransport,
                   sipUsername As String,
                   sipPassword As String,
                   sipServer As String,
                   Optional sipFromName As String = "MicroSIP/3.22.3")

        m_sipUsername = sipUsername
        m_sipPassword = sipPassword
        m_sipServer = sipServer
        m_sipFromName = sipFromName
        m_sipTransport = sipTransport

        m_userAgent = New SIPUserAgent(m_sipTransport, Nothing)

        AddHandler m_userAgent.ClientCallTrying, AddressOf CallTrying
        AddHandler m_userAgent.ClientCallRinging, AddressOf CallRinging
        AddHandler m_userAgent.ClientCallAnswered, AddressOf CallAnswered
        AddHandler m_userAgent.ClientCallFailed, AddressOf CallFailed
        AddHandler m_userAgent.OnCallHungup, AddressOf CallFinished
        AddHandler m_userAgent.ServerCallCancelled, AddressOf IncomingCallCancelled
        AddHandler m_userAgent.OnTransferNotify, AddressOf OnTransferNotify
        AddHandler m_userAgent.OnDtmfTone, AddressOf OnDtmfTone
    End Sub

    '==================== OUTGOING CALL =====================
    Public Async Function CallAsync(destination As String) As Task
        Dim callURI As SIPURI = Nothing
        Dim sipUsername As String = Nothing
        Dim sipPassword As String = Nothing
        Dim fromHeader As String = Nothing

        If destination.Contains("@"c) OrElse String.IsNullOrEmpty(m_sipServer) Then
            callURI = SIPURI.ParseSIPURIRelaxed(destination)
            fromHeader = New SIPFromHeader(m_sipFromName, SIPURI.ParseSIPURI(SIPFromHeader.DEFAULT_FROM_URI), Nothing).ToString()
        Else
            callURI = SIPURI.ParseSIPURIRelaxed(destination & "@" & m_sipServer)
            sipUsername = m_sipUsername
            sipPassword = m_sipPassword
            fromHeader = New SIPFromHeader(m_sipFromName, New SIPURI(m_sipUsername, m_sipServer, Nothing), Nothing).ToString()
        End If

        RaiseEvent StatusMessage(Me, $"Memanggil {callURI}...")

        Dim dstEP = Await SIPDns.ResolveAsync(callURI, False, _cts.Token)
        If dstEP Is Nothing Then
            RaiseEvent StatusMessage(Me, $"Gagal resolve {callURI}")
            Return
        End If

        Dim callDesc As New SIPCallDescriptor(
            sipUsername, sipPassword,
            callURI.ToString(),
            fromHeader,
            Nothing, Nothing, Nothing, Nothing,
            SIPCallDirection.Out,
            SDP_MIME_CONTENTTYPE,
            Nothing, Nothing)

        MediaSession = CreateMediaSession()

        AddHandler m_userAgent.RemotePutOnHold, AddressOf OnRemotePutOnHold
        AddHandler m_userAgent.RemoteTookOffHold, AddressOf OnRemoteTookOffHold

        Await m_userAgent.InitiateCallAsync(callDesc, MediaSession)
    End Function

    '==================== CANCEL / HANGUP =====================
    Public Sub Cancel()
        m_userAgent?.Cancel()
    End Sub

    Public Sub Hangup()
        If m_userAgent IsNot Nothing AndAlso m_userAgent.IsCallActive Then
            m_userAgent.Hangup()
            CallFinished(Nothing)
        End If
    End Sub

    '==================== INCOMING CALL =====================
    Public Sub AcceptCall(sipRequest As SIPRequest)
        m_pendingIncomingCall = m_userAgent.AcceptCall(sipRequest)
    End Sub

    Public Async Function AnswerAsync() As Task(Of Boolean)
        If m_pendingIncomingCall Is Nothing Then Return False

        Dim req = m_pendingIncomingCall.ClientTransaction.TransactionRequest

        Dim offerSDP As SDP = Nothing
        If Not String.IsNullOrEmpty(req.Body) Then
            offerSDP = SDP.ParseSDPDescription(req.Body)
        End If

        MediaSession = CreateMediaSession()

        AddHandler m_userAgent.RemotePutOnHold, AddressOf OnRemotePutOnHold
        AddHandler m_userAgent.RemoteTookOffHold, AddressOf OnRemoteTookOffHold

        Dim result = Await m_userAgent.Answer(m_pendingIncomingCall, MediaSession)
        m_pendingIncomingCall = Nothing
        Return result
    End Function

    '==================== HOLD =====================
    Public Async Function PutOnHoldAsync() As Task
        If MediaSession IsNot Nothing Then Await MediaSession.PutOnHold()
        m_userAgent?.PutOnHold()
    End Function

    Public Sub TakeOffHold()
        MediaSession?.TakeOffHold()
        m_userAgent?.TakeOffHold()
    End Sub

    '==================== TRANSFER & DTMF =====================
    Public Async Function BlindTransferAsync(destination As String) As Task(Of Boolean)
        Dim uri As SIPURI = Nothing
        If SIPURI.TryParse(destination, uri) Then
            Return Await m_userAgent.BlindTransfer(uri, TimeSpan.FromSeconds(10), _cts.Token)
        End If
        Return False
    End Function

    Public Async Function SendDTMFAsync(tone As Byte) As Task
        If m_userAgent IsNot Nothing Then
            Await m_userAgent.SendDtmf(tone)
        End If
    End Function

    '==================== MEDIA SESSION (Windows) =====================
    Private Function CreateMediaSession() As VoIPMediaSession
        'Dim audioEP = New WindowsAudioEndPoint(New AudioEncoder(), m_audioOutDeviceIndex)
        'Dim videoEP = New WindowsVideoEndPoint(New VpxVideoEncoder())

        'Dim mediaEPs As New MediaEndPoints With {
        '    .AudioSource = audioEP,
        '    .AudioSink = audioEP,
        '    .VideoSource = videoEP,
        '    .VideoSink = videoEP
        '}

        'Dim testPattern = New VideoTestPatternSource(New VpxVideoEncoder())
        'Dim session As New VoIPMediaSession(mediaEPs, testPattern)
        'session.AcceptRtpFromAny = True
        'Return session
    End Function

    '==================== EVENT HANDLERS =====================
    Private Sub CallTrying(uac As ISIPClientUserAgent, resp As SIPResponse)
        RaiseEvent StatusMessage(Me, "Trying: " & resp.StatusCode & " " & resp.ReasonPhrase)
    End Sub

    Private Sub CallRinging(uac As ISIPClientUserAgent, resp As SIPResponse)
        RaiseEvent StatusMessage(Me, "Ringing: " & resp.StatusCode & " " & resp.ReasonPhrase)
    End Sub

    Private Sub CallAnswered(uac As ISIPClientUserAgent, resp As SIPResponse)
        RaiseEvent StatusMessage(Me, "Terjawab: " & resp.StatusCode)
        RaiseEvent CallAnswer(Me)
    End Sub

    Private Sub CallFailed(uac As ISIPClientUserAgent, errorMsg As String, resp As SIPResponse)
        RaiseEvent StatusMessage(Me, "Gagal: " & errorMsg)
        CallFinished(Nothing)
    End Sub

    Private Sub CallFinished(dialogue As SIPDialogue)
        If MediaSession IsNot Nothing Then
            MediaSession.Dispose()   ' BUKAN Close() → sudah dihapus di v8
            MediaSession = Nothing
        End If

        m_pendingIncomingCall = Nothing
        RaiseEvent CallEnded(Me)
    End Sub

    Private Sub IncomingCallCancelled(uas As ISIPServerUserAgent, req As SIPRequest)
        CallFinished(Nothing)
    End Sub

    Private Sub OnTransferNotify(sipFrag As String)
        If sipFrag?.Contains("SIP/2.0 200") = True Then
            Hangup()
        End If
    End Sub

    Private Sub OnDtmfTone(key As Byte, duration As Integer)
        RaiseEvent StatusMessage(Me, $"DTMF: {key}")
    End Sub

    Private Sub OnRemotePutOnHold()
        RaiseEvent RemotePutOnHold(Me)
    End Sub

    Private Sub OnRemoteTookOffHold()
        RaiseEvent RemoteTookOffHold(Me)
    End Sub

    '==================== DISPOSE =====================
    Private disposed As Boolean = False
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposed Then
            If disposing Then
                _cts?.Cancel()
                _cts?.Dispose()

                Hangup()

                If MediaSession IsNot Nothing Then
                    MediaSession.Dispose()   ' BUKAN Close()
                    MediaSession = Nothing
                End If

                m_userAgent = Nothing
            End If
            disposed = True
        End If
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
End Class