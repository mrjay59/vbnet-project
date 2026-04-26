

Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class ClassApi
    Private dbcon As New ClassConnect
    Private JsonC As New ClassJson


    Public Function PostData(ByVal Path As String, ByVal dataToPost As Object, ByVal ndomain As String) As String
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Dim postDataAsByteArray As Byte()
        Dim DbSource As String = dbcon.SearchPATH()
        Dim Paths As String = JsonC.dencode(DbSource, "SERVICE." & ndomain & ".POST." & Path)
        Dim url As String = JsonC.dencode(DbSource, "SERVICE." & ndomain & ".DOMAIN") & Paths
        Dim Cookie As String = JsonC.dencode(DbSource, "SERVICE." & ndomain & ".HEADER.Cookie")
        Dim Auth As String = JsonC.dencode(DbSource, "SERVICE." & ndomain & ".HEADER.userToken.AutoCall")

        Dim returnValue As String = String.Empty

        Dim jsonString As String = ""

        ' 🔥 AUTO HANDLE TYPE
        If TypeOf dataToPost Is JObject Then
            jsonString = CType(dataToPost, JObject).ToString()
        ElseIf TypeOf dataToPost Is Dictionary(Of String, String) Then
            jsonString = JsonConvert.SerializeObject(dataToPost)
        ElseIf TypeOf dataToPost Is String Then
            jsonString = dataToPost.ToString()
        Else
            Throw New Exception("Unsupported data type for POST")
        End If



        Try
            Dim webRequest As HttpWebRequest = DirectCast(Net.WebRequest.Create(url), HttpWebRequest)  'change to: dim webRequest as var = DirectCast(WebRequest.Create(url), HttpWebRequest) if you are your .NET Version is lower than 4.5
            If (Not (webRequest) Is Nothing) Then
                webRequest.AllowAutoRedirect = False
                webRequest.Method = "POST"
                webRequest.ContentType = "application/json; charset=UTF-8"
                webRequest.Headers.Add("Cookie", Cookie)
                postDataAsByteArray = Encoding.UTF8.GetBytes(jsonString)
                webRequest.ContentLength = postDataAsByteArray.Length

                If Not String.IsNullOrEmpty(Auth) Then
                    webRequest.Headers.Add("Authorization", Auth)
                End If

                Dim requestDataStream As Stream = webRequest.GetRequestStream
                requestDataStream.Write(postDataAsByteArray, 0, postDataAsByteArray.Length)
                requestDataStream.Close()

                Dim response As HttpWebResponse = DirectCast(webRequest.GetResponse, HttpWebResponse)
                Dim responseDataStream As Stream = response.GetResponseStream
                If (Not (responseDataStream) Is Nothing) Then
                    Dim responseDataStreamReader As StreamReader = New StreamReader(responseDataStream)
                    returnValue = responseDataStreamReader.ReadToEnd
                    responseDataStreamReader.Close()
                    responseDataStream.Close()
                End If

                '' Get the cookies from the response
                'Dim cookies As CookieCollection = response.Cookies
                'Dim header = response.GetResponseHeader("set-cookie") ' set-cookie
                ''userToken=5212d322-c9c5-4684-b4bc-cbcc078893c9; Max-Age=261157; Expires=Tue, 31-Jan-2023 15:59:59 GMT; Path=/
                'For Each cookie As Cookie In cookies
                '    Console.WriteLine("Cookie Name: " & cookie.Name)
                '    Console.WriteLine("Cookie Value: " & cookie.Value)
                '    Console.WriteLine("Cookie Domain: " & cookie.Domain)
                '    Console.WriteLine("Cookie Path: " & cookie.Path)
                '    Console.WriteLine("Cookie Expires: " & cookie.Expires)
                '    Console.WriteLine("----------------------------")
                'Next
                response.Close()
                requestDataStream.Close()

            End If
        Catch ex As WebException
            If (ex.Status = WebExceptionStatus.ProtocolError) Then
                Dim response As HttpWebResponse = CType(ex.Response, HttpWebResponse)
                'handle this your own way.
                MsgBox("Webexception! Statuscode: " & CType(response.StatusCode, Integer) & " Description: " & response.StatusDescription)
                Console.WriteLine("Webexception! Statuscode: {0}, Description: {1}", CType(response.StatusCode, Integer), response.StatusDescription)
            End If
        Catch ex As Exception
            'handle this your own way, something serious happened here.
            Console.WriteLine(ex.Message)
        End Try
        Return returnValue
    End Function

    Public Function GetData(ByVal Path As String, ByVal dataGet As Dictionary(Of String, String), ByVal ndomain As String) As String
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Dim DbSource As String = dbcon.SearchPATH()
        Dim Paths As String = JsonC.dencode(DbSource, "SERVICE." & ndomain & ".GET." & Path)
        Dim Cookie As String = JsonC.dencode(DbSource, "SERVICE." & ndomain & ".HEADER.Cookie")
        Dim Auth As String = JsonC.dencode(DbSource, "SERVICE." & ndomain & ".HEADER.userToken.AutoCall")

        Dim encodedString As New StringBuilder()
        Dim finalString As String = Nothing
        If Not (dataGet Is Nothing) Then
            For Each kvp As KeyValuePair(Of String, String) In dataGet
                encodedString.Append(kvp.Key & "=" & kvp.Value & "&")
            Next

            'Remove the last "&" character
            encodedString.Remove(encodedString.Length - 1, 1)

            'final encoded string
            finalString = encodedString.ToString()
        End If


        Dim url As String = JsonC.dencode(DbSource, "SERVICE." & ndomain & ".DOMAIN") & Paths & finalString
        Dim returnValue As String = String.Empty
        Try
            Dim webRequest As HttpWebRequest = DirectCast(Net.WebRequest.Create(url), HttpWebRequest)  'change to: dim webRequest as var = DirectCast(WebRequest.Create(url), HttpWebRequest) if you are your .NET Version is lower than 4.5
            If (Not (webRequest) Is Nothing) Then
                webRequest.AllowAutoRedirect = False
                webRequest.Method = "GET"
                webRequest.ContentType = "application/json; charset=UTF-8"
                webRequest.Headers.Add("Cookie", Cookie)

                If Not String.IsNullOrEmpty(Auth) Then
                    webRequest.Headers.Add("Authorization", Auth)
                End If

                Dim response As HttpWebResponse = DirectCast(webRequest.GetResponse, HttpWebResponse)
                Dim responseDataStream As Stream = response.GetResponseStream
                If (Not (responseDataStream) Is Nothing) Then
                    Dim responseDataStreamReader As StreamReader = New StreamReader(responseDataStream)
                    returnValue = responseDataStreamReader.ReadToEnd
                    responseDataStreamReader.Close()
                    responseDataStream.Close()
                End If
                response.Close()

            End If
        Catch ex As WebException
            If (ex.Status = WebExceptionStatus.ProtocolError) Then
                Dim response As HttpWebResponse = CType(ex.Response, HttpWebResponse)
                'handle this your own way.
                MsgBox(response)
            End If
        Catch ex As Exception
            'handle this your own way, something serious happened here.
            MsgBox(ex.Message)
        End Try
        Return returnValue

    End Function

    Public Sub FtpUpload(ByVal fpath As String)
        Dim filenama As String = Path.GetFileName(fpath)
        ' Create an FtpWebRequest object
        Dim request As FtpWebRequest = DirectCast(WebRequest.Create("ftp://files.000webhost.com/" & filenama), FtpWebRequest)

        ' Set the login credentials
        request.Credentials = New NetworkCredential("list-col", "M1sterj@y59")

        ' Specify the request as an upload
        request.Method = WebRequestMethods.Ftp.UploadFile

        ' Create a stream to write the file to the FTP server
        Dim fileStream As Stream = request.GetRequestStream()

        ' Read the contents of the file into a byte array
        Dim fileBytes As Byte() = File.ReadAllBytes(fpath)

        ' Write the contents of the file to the FTP server
        fileStream.Write(fileBytes, 0, fileBytes.Length)

        ' Close the stream
        fileStream.Close()

    End Sub




End Class
