Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class mrjay59
    Private Api As New ClassApi
    Private dbConn As New ClassConnect
    Private EnDe As New DeEnCrypt
    Protected nameapk As String = "MRJAY59"
    'Dim dict As New Dictionary(Of String, String)
    '        dict.Add("hal", "db")
    '        dict.Add("conn", param)

    '        Dim parameters As String = JsonConvert.SerializeObject(dict, Formatting.None)
    Public Function inc(ByVal data As Dictionary(Of String, String))
        Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("setup", parameters, nameapk)
        Dim jsonObject As Object
        Dim jsonparse As String = String.Empty

        If (Not (response) Is Nothing) Then

            Try
                jsonObject = JsonConvert.DeserializeObject(response)

                If (jsonObject("status")("code") = 0) Then
                    jsonparse = jsonObject("body")("dataJson")
                ElseIf (jsonObject("status")("code") = 1001) Then
                    jsonparse = jsonObject("status")("detail")
                ElseIf (jsonObject("status")("code") = 114004) Then
                    jsonparse = jsonObject("status")("detail")
                End If
            Catch generatedExceptionName As JsonSerializationException
                Console.WriteLine("The string is not valid JSON.")
            End Try
        End If

        Return jsonparse
    End Function

    Public Function login(ByVal data As Dictionary(Of String, String))
        Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("login", parameters, nameapk)

        Dim jsonparse As String = String.Empty

        If (Not (response) Is Nothing) Then

            Try
                jsonparse = response
            Catch generatedExceptionName As JsonSerializationException
                Console.WriteLine("The string is not valid JSON.")
            End Try
        End If

        Return jsonparse


    End Function

    Public Function logout(ByVal data As Dictionary(Of String, String))
        Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("logout", parameters, nameapk)

        Dim jsonparse As String = String.Empty

        If (Not (response) Is Nothing) Then

            Try
                jsonparse = response
            Catch generatedExceptionName As JsonSerializationException
                Console.WriteLine("The string is not valid JSON.")
            End Try
        End If

        Return jsonparse


    End Function

    Public Function register(ByVal data As Dictionary(Of String, String))
        Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("register", parameters, nameapk)

        Dim jsonparse As String = String.Empty

        If (Not (response) Is Nothing) Then

            Try
                jsonparse = response
            Catch generatedExceptionName As JsonSerializationException
                Console.WriteLine("The string is not valid JSON.")
            End Try
        End If

        Return jsonparse
    End Function

    Public Function getoken(ByVal data As Dictionary(Of String, String))
        ' Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.GetData("getoken", data, nameapk)

        Dim jsonparse As String = String.Empty

        If (Not (response) Is Nothing) Then
            Try
                jsonparse = response
            Catch generatedExceptionName As JsonSerializationException
                Console.WriteLine("The string is not valid JSON.")
            End Try
        End If

        Return jsonparse
    End Function

    Public Function getAkunAkses(ByVal data As Dictionary(Of String, String))
        ' Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        'Dim response = Api.GetData("getuser", data, nameapk)
        Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("listdevice", parameters, nameapk)


        Dim jsonparse As String = String.Empty

        If (Not (response) Is Nothing) Then
            Try
                jsonparse = response
            Catch generatedExceptionName As JsonSerializationException
                Console.WriteLine("The string is not valid JSON.")
            End Try
        End If

        Return jsonparse
    End Function

    Public Function callsip(ByVal data As JObject)
        ' Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        'Dim response = Api.GetData("getuser", data, nameapk)
        'Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("callsip", data, nameapk)

        Dim jsonparse As String = String.Empty

        If (Not (response) Is Nothing) Then
            Try
                jsonparse = response
            Catch generatedExceptionName As JsonSerializationException
                Console.WriteLine("The string is not valid JSON.")
            End Try
        End If

        Return jsonparse
    End Function

    Public Function ws_receive(ByVal data As JObject)
        ' Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        'Dim response = Api.GetData("getuser", data, nameapk)
        'Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("ws_receive", data, nameapk)

        Dim jsonparse As String = String.Empty

        If (Not (response) Is Nothing) Then
            Try
                jsonparse = response
            Catch generatedExceptionName As JsonSerializationException
                Console.WriteLine("The string is not valid JSON.")
            End Try
        End If

        Return jsonparse
    End Function

    Public Function regapp(ByVal data As JObject)
        ' Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        'Dim response = Api.GetData("getuser", data, nameapk)
        'Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("regapp", data, nameapk)

        Dim jsonparse As String = String.Empty

        If (Not (response) Is Nothing) Then
            Try
                jsonparse = response
            Catch generatedExceptionName As JsonSerializationException
                Console.WriteLine("The string is not valid JSON.")
            End Try
        End If

        Return jsonparse
    End Function

    Public Function getuser(ByVal data As Dictionary(Of String, String))
        ' Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        'Dim response = Api.GetData("getuser", data, nameapk)
        Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("getuser", parameters, nameapk)

        Dim jsonparse As String = String.Empty

        If (Not (response) Is Nothing) Then
            Try
                jsonparse = response
            Catch generatedExceptionName As JsonSerializationException
                Console.WriteLine("The string is not valid JSON.")
            End Try
        End If

        Return jsonparse
    End Function

    Public Function userupdate(ByVal data As Dictionary(Of String, String))
        Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("userupdate", parameters, nameapk)

        Dim jsonparse As String = String.Empty

        If (Not (response) Is Nothing) Then
            Try
                jsonparse = response
            Catch generatedExceptionName As JsonSerializationException
                Console.WriteLine("The string is not valid JSON.")
            End Try
        End If

        Return jsonparse
    End Function

    Public Function inkontak(ByVal data As Dictionary(Of String, String))
        Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("inkontak", parameters, nameapk)

        Dim jsonparse As String = String.Empty

        If (Not (response) Is Nothing) Then
            Try
                jsonparse = response
            Catch generatedExceptionName As JsonSerializationException
                Console.WriteLine("The string is not valid JSON.")
            End Try
        End If

        Return jsonparse
    End Function

    Public Function gantipass(ByVal data As Dictionary(Of String, String))
        Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("gantipass", parameters, nameapk)

        Dim jsonparse As String = String.Empty

        If (Not (response) Is Nothing) Then
            Try
                jsonparse = response
            Catch generatedExceptionName As JsonSerializationException
                Console.WriteLine("The string is not valid JSON.")
            End Try
        End If

        Return jsonparse
    End Function

    Public Function getservnum(ByVal data As Dictionary(Of String, String))
        ' Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        ' Dim response = Api.GetData("OnListServer", parameters, nameapk)
        Dim response = Api.GetData("OnListServer", data, nameapk)
        Dim jsonparse As String = String.Empty

        If (Not (response) Is Nothing) Then
            Try
                jsonparse = response
            Catch generatedExceptionName As JsonSerializationException
                Console.WriteLine("The string is not valid JSON.")
            End Try
        End If

        Return jsonparse
    End Function

    Public Function getvalid(ByVal data As Dictionary(Of String, String))
        ' Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.GetData("getvalid", data, nameapk)

        Dim jsonparse As String = String.Empty

        If (Not (response) Is Nothing) Then
            Try
                jsonparse = response
            Catch generatedExceptionName As JsonSerializationException
                Console.WriteLine("The string is not valid JSON.")
            End Try
        End If

        Return jsonparse
    End Function

    Public Function gepaket(ByVal data As Dictionary(Of String, String))
        ' Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        'Dim response = Api.GetData("getuser", data, nameapk)
        Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("gepaket", parameters, nameapk)

        Dim jsonparse As String = String.Empty

        If (Not (response) Is Nothing) Then
            Try
                jsonparse = response
            Catch generatedExceptionName As JsonSerializationException
                Console.WriteLine("The string is not valid JSON.")
            End Try
        End If

        Return jsonparse
    End Function

    Public Function delLog(ByVal data As Dictionary(Of String, String))
        ' Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        'Dim response = Api.GetData("getuser", data, nameapk)
        Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("deletelog", parameters, nameapk)

        Dim jsonparse As String = String.Empty

        If (Not (response) Is Nothing) Then
            Try
                jsonparse = response
            Catch generatedExceptionName As JsonSerializationException
                Console.WriteLine("The string is not valid JSON.")
            End Try
        End If

        Return jsonparse
    End Function

    Public Function testDev(ByVal data As Dictionary(Of String, String))
        ' Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        'Dim response = Api.GetData("getuser", data, nameapk)
        'Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.GetData("OnTestDev", data, nameapk)

        Dim jsonparse As String = String.Empty

        If (Not (response) Is Nothing) Then
            Try
                jsonparse = response
            Catch generatedExceptionName As JsonSerializationException
                Console.WriteLine("The string is not valid JSON.")
            End Try
        End If

        Return jsonparse
    End Function

    Public Function dev_state(ByVal data As Dictionary(Of String, String))
        ' Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        'Dim response = Api.GetData("getuser", data, nameapk)
        Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("OnDevice-state", parameters, nameapk)

        Dim jsonparse As String = String.Empty

        If (Not (response) Is Nothing) Then
            Try
                jsonparse = response
            Catch generatedExceptionName As JsonSerializationException
                Console.WriteLine("The string is not valid JSON.")
            End Try
        End If

        Return jsonparse
    End Function

    Public Function DataUser() As String
        Try
            Dim DataRespon As String = String.Empty
            Dim userpc As String = EnDe.GetUserName.Trim
            Dim apkname = dbConn.ApkProfile("name")
            Dim apkvers = dbConn.ApkProfile("versi")
            Dim DbSource As String = dbConn.SearchPATH()
            Dim soudb = JsonConvert.DeserializeObject(DbSource)
            Dim getoken = soudb("SERVICE")("MRJAY59")("HEADER")("userToken")(apkname)
            '  Dim key As Byte() = Encoding.UTF8.GetBytes(EnDe.CpuId)
            Dim serial As String = EnDe.GetIdDevice
            ' Dim enmesin = EnDe.AESEncrypt(serial, key)
            'Console.WriteLine(apkvers)
            ' service data parameter

            Dim param As New Dictionary(Of String, String)
            param.Add("token", getoken)
            param.Add("prdname", apkname)
            param.Add("prdmsin", serial)
            param.Add("devname", userpc)
            param.Add("prdversi", apkvers.ToString)
            DataRespon = getuser(param)

            Return DataRespon


        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Public Async Function CheckSessionGlobal() As Task(Of Boolean)
        Try
            If Not dbConn.IsInternetAvailable() Then Return False

            Dim res As String = Await Task.Run(Function() DataUser())

            If String.IsNullOrWhiteSpace(res) Then Return False

            Dim json = JsonConvert.DeserializeObject(res)

            If json("status")("code") = 1 Then Return False

            Dim statoken As Boolean = json("body")("token")("statexp")

            Return statoken

        Catch
            Return False
        End Try
    End Function
End Class
