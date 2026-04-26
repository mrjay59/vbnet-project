Imports System.IO

Imports Newtonsoft.Json


Public Class WhatsAppClass
    Public dbCon As ClassConnect
    Public mrJ59 As mrjay59
    Private Api As New ClassApi
    Private jsonpa As New ClassJson
    Protected nameapk As String = "MRJAY59"




    Public Function OnUpdateServer(ByVal data As Dictionary(Of String, String))
        Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("OnUpdateServer", parameters, nameapk)

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

    Public Function OnReceiveMessage(ByVal data As Dictionary(Of String, String))
        Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("OnReceiveMessage", parameters, nameapk)

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

    Public Function OnCreateServer(ByVal data As Dictionary(Of String, String))
        Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("OnCreateServer", parameters, nameapk)

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

    Public Function OnCreateWAScan(ByVal data As Dictionary(Of String, String))
        Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("OnCreateWAScan", parameters, nameapk)

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

    Public Function OnListServer(ByVal data As Dictionary(Of String, String))
        ' Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
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


    Public Function OnListMsg(ByVal data As Dictionary(Of String, String))
        ' Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.GetData("OnListMsg", data, nameapk)

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

    Public Function OnDetailMsg(ByVal data As Dictionary(Of String, String))
        ' Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.GetData("OnDetailMsg", data, nameapk)

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


    Public Function OnSendMessage(ByVal data As Dictionary(Of String, String))
        Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("OnSendMessage", parameters, nameapk)

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

    Public Function OnListWAScan(ByVal data As Dictionary(Of String, String))
        ' Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.GetData("OnListWAScan", data, nameapk)

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

    Public Function Onconversation(ByVal data As Dictionary(Of String, String))
        ' Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.GetData("OnConversation", data, nameapk)

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

    Public Function OnTemplate(ByVal data As Dictionary(Of String, String))
        Dim parameters As String = JsonConvert.SerializeObject(data, Formatting.None)
        Dim response = Api.PostData("OnTemplate", parameters, nameapk)

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
End Class
