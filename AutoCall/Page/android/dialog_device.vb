Imports System.IO
Imports Newtonsoft.Json

Public Class dialog_device
    Public Event DataSelected As EventHandler(Of ClassData)
    Private dbConn As New ClassConnect
    Private jsonpa As New ClassJson
    Private Mjay59 As mrjay59
    Private WApp As New WhatsAppClass
    Private DatR As String = String.Empty
    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New System.Drawing.Point
    Private DatRec As String


    Private Sub LolocalAndroid(ByVal filter As String)
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & $"\{dbConn.ApkProfile("name")}\Devices\"

        Dim files As String() = IO.Directory.GetFiles(fodev)
        Dim ax = 0

        For Each filex As String In files
            Dim Datajson As String = File.ReadAllText(filex)

            ' Parse the JSON string into a JArray
            Dim soudb = JsonConvert.DeserializeObject(Datajson)
            If Not (soudb Is Nothing) Then
                Dim NameDev = soudb("name")
                Dim usedev = soudb("usedev")
                Dim connection = soudb("connection")

                If Not (soudb("apk") Is Nothing) Then
                    For Each item In soudb("apk")
                        Dim apkName = item.Name
                        Dim idwa = 0
                        For Each item1 In soudb("apk")(apkName)


                        Next
                    Next
                End If

            End If


        Next
    End Sub

End Class