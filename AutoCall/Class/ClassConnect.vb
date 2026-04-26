Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Xml

Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq


Public Class ClassConnect
    Private JsonC As New ClassJson

    Public Function ScanIPRange(ByVal baseIP As String, ByVal startPort As Integer, ByVal endPort As Integer)
        Dim arrip As New ArrayList
        For port As Integer = startPort To endPort
            Dim ipAddress As String = $"{baseIP}.{port}"
            Dim client As New TcpClient()

            Try
                client.Connect(ipAddress, port)
                ' If the connection is successful, the port is open
                Console.WriteLine($"Port {port} is open on IP {ipAddress}")
                arrip.Add(ipAddress)
            Catch ex As Exception
                ' Connection failed, the port is closed or the host is unreachable
                Console.WriteLine($"Port {port} is closed on IP {ipAddress}")
                arrip.Remove(ipAddress)
            Finally
                client.Close()
            End Try
        Next

        Return arrip
    End Function

    Function PingDomain(domain As String) As PingReply
        Try
            Using ping As New Ping()
                Return ping.Send(domain, 2000)
            End Using
        Catch
            Return Nothing
        End Try
    End Function

    Public Function CheckServerHealthy(domain As String,
                                  Optional timeoutMs As Integer = 3000,
                                  Optional useHttps As Boolean = True) As Tuple(Of Boolean, String)

        Dim message As String = ""

        ' 🔹 PING
        Try
            Using ping As New Ping()
                Dim reply = ping.Send(domain, timeoutMs)

                If reply IsNot Nothing AndAlso reply.Status = IPStatus.Success Then
                    Return Tuple.Create(True, "Ping OK")
                Else
                    message = "Ping gagal (" & If(reply IsNot Nothing, reply.Status.ToString(), "No Reply") & ")"
                End If
            End Using
        Catch ex As Exception
            message = "Ping error: " & ex.Message
        End Try

        ' 🔹 HTTP fallback
        Try
            Dim scheme As String = If(useHttps, "https://", "http://")
            Dim url As String = scheme & domain

            Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            request.Method = "GET"
            request.Timeout = timeoutMs

            Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                Return Tuple.Create(True, "HTTP OK (" & CInt(response.StatusCode) & ")")
            End Using

        Catch ex As Exception
            message &= " | HTTP error: " & ex.Message
        End Try

        Return Tuple.Create(False, message)
    End Function

    Public Function IsInternetAvailable() As Boolean
        Dim DbSource As String = SearchPATH()
        '   Dim Paths As String = JsonC.dencode(DbSource, "SERVICE." & ndomain & ".GET." & Path)

        Try
            ' Check if a network connection is available
            If My.Computer.Network.IsAvailable Then
                ' Check if we can ping a well-known server (e.g., Google's DNS server)
                Dim ping As New Ping()
                Dim reply As PingReply = ping.Send("1.1.1.1", 1000) ' Use a timeout of 1000 milliseconds (1 second)

                ' Return True if the ping was successful
                Return reply.Status = IPStatus.Success
            Else
                ' No network connection
                Return False
            End If
        Catch ex As Exception
            ' Handle exceptions as needed
            Console.WriteLine(ex.Message)
            Return False
        End Try
    End Function

    Public Function SearchPATH() As String
        Dim b As String = File.ReadAllText(Application.StartupPath & "\Application\setting.json")
        Return b
    End Function

    Public Function ApkProfile(ByVal Name As String)
        Dim apkname As String
        Dim myFileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)

        If (Name = "name") Then
            apkname = myFileVersionInfo.ProductName
        ElseIf (Name = "versi") Then
            apkname = myFileVersionInfo.FileVersion
        Else
            apkname = ""
        End If

        Return apkname
    End Function


    Public Function Connection(ByVal param As String) As String
        Dim a() As String = param.Split(".")

        Dim DbSource As String = SearchPATH()

        Dim ConDb As String = JsonC.dencode(DbSource, a(0) & ".ConnectString")


        If (a(0) = "MYSQL") Then
            Dim U, P, D, L As String
            Dim PO As Integer

            U = JsonC.dencode(DbSource, param & ".USER")
            P = JsonC.dencode(DbSource, param & ".PASW")
            D = JsonC.dencode(DbSource, param & ".DTBS")
            L = JsonC.dencode(DbSource, param & ".LINK")
            PO = JsonC.dencode(DbSource, param & ".PORT")
            ConDb = ConDb.Replace("{IP_SERVER}", L).Replace("{USERNAME}", U).Replace("{PASSWORD}", P).Replace("{DB_NAME}", D).Replace("{PORT}", PO)


        ElseIf (a(0) = "DBF") Then
            ConDb = ConDb
        ElseIf (a(0) = "EXCEL") Then
            ConDb = ConDb
        ElseIf (a(0) = "ACCESS") Then
            ConDb = ConDb
        ElseIf (a(0) = "CSV") Then
            ConDb = ConDb
        ElseIf (a(0) = "FTP") Then
            ConDb = ConDb
        ElseIf (a(0) = "ORACLE") Then
            ConDb = ConDb
        ElseIf (a(0) = "SERVICE") Then
            ConDb = ConDb
        Else
            ConDb = ConDb
        End If
        Return ConDb

    End Function


    Public Function ConnectString(ByVal StringConnet As String, ByVal DirFile As String, ByVal SqlQuery As String) As DataSet
        Dim a() As String = StringConnet.Split(".")
        Dim dll As New DataSet
        dll.Clear()
        If (a(0) = "MYSQL") Then
            Dim SConnection As MySqlConnection = New MySqlConnection(Connection(StringConnet))
            SConnection.Open()
            Dim MyCommad As MySqlCommand = New MySqlCommand(SqlQuery, SConnection)
            Dim MyAdapter As New MySqlDataAdapter
            MyAdapter.SelectCommand = MyCommad
            Dim st As String = Mid(SqlQuery, 1, 6)
            If (st = "insert") Or (st = "update") Or (st = "delete") Or (st = "CREATE") Then
                MyCommad.ExecuteNonQuery()
                SConnection.Close()
            Else
                MyCommad.ExecuteReader()
                SConnection.Close()
                MyAdapter.Fill(dll)
            End If
        ElseIf (a(0) = "EXCEL") Then
            Dim SConnection As OleDb.OleDbConnection = New OleDb.OleDbConnection(Connection(StringConnet).Replace("{FileName}", DirFile))
            SConnection.Open()
            Dim MyCommad As OleDb.OleDbCommand = New OleDb.OleDbCommand(SqlQuery, SConnection)
            Dim Myadapter As New OleDb.OleDbDataAdapter
            Myadapter.SelectCommand = MyCommad
            Dim st As String = Mid(SqlQuery, 1, 6)
            If (st = "insert") Or (st = "update") Or (st = "delete") Or (st = "CREATE") Then
                MyCommad.ExecuteNonQuery()
                SConnection.Close()
            Else
                MyCommad.ExecuteReader()
                SConnection.Close()
                Myadapter.Fill(dll)
            End If

        ElseIf (a(0) = "ORACLE") Then
            Dim SConnection As OleDb.OleDbConnection = New OleDb.OleDbConnection(Connection(StringConnet))
            SConnection.Open()
            Dim MyCommad As OleDb.OleDbCommand = New OleDb.OleDbCommand(SqlQuery, SConnection)
            Dim Myadapter As New OleDb.OleDbDataAdapter
            Myadapter.SelectCommand = MyCommad
            Dim st As String = Mid(SqlQuery, 1, 6)
            If (st = "insert") Or (st = "update") Or (st = "delete") Or (st = "CREATE") Then
                MyCommad.ExecuteNonQuery()
                SConnection.Close()
            Else
                MyCommad.ExecuteReader()
                SConnection.Close()
                Myadapter.Fill(dll)
            End If

        ElseIf (a(0) = "SQL") Then
            Dim SConnection As OleDb.OleDbConnection = New OleDb.OleDbConnection(Connection(StringConnet))
            SConnection.Open()
            Dim MyCommad As OleDb.OleDbCommand = New OleDb.OleDbCommand(SqlQuery, SConnection)
            Dim Myadapter As New OleDb.OleDbDataAdapter
            Myadapter.SelectCommand = MyCommad
            Dim st As String = Mid(SqlQuery, 1, 6)
            If (st = "insert") Or (st = "update") Or (st = "delete") Or (st = "CREATE") Then
                MyCommad.ExecuteNonQuery()
                SConnection.Close()
            Else
                MyCommad.ExecuteReader()
                SConnection.Close()
                Myadapter.Fill(dll)
            End If

        ElseIf (a(0) = "SQLITE") Then
            Dim SConnection As OleDb.OleDbConnection = New OleDb.OleDbConnection(Connection(StringConnet))
            SConnection.Open()
            Dim MyCommad As OleDb.OleDbCommand = New OleDb.OleDbCommand(SqlQuery, SConnection)
            Dim Myadapter As New OleDb.OleDbDataAdapter
            Myadapter.SelectCommand = MyCommad
            Dim st As String = Mid(SqlQuery, 1, 6)
            If (st = "insert") Or (st = "update") Or (st = "delete") Or (st = "CREATE") Then
                MyCommad.ExecuteNonQuery()
                SConnection.Close()
            Else
                MyCommad.ExecuteReader()
                SConnection.Close()
                Myadapter.Fill(dll)
            End If

        ElseIf (a(0) = "ACCESS") Then
            Dim SConnection As OleDb.OleDbConnection = New OleDb.OleDbConnection(Connection(StringConnet).Replace("{FileName}", DirFile))
            SConnection.Open()
            Dim MyCommad As OleDb.OleDbCommand = New OleDb.OleDbCommand(SqlQuery, SConnection)
            Dim Myadapter As New OleDb.OleDbDataAdapter
            Myadapter.SelectCommand = MyCommad
            Dim st As String = Mid(SqlQuery, 1, 6)
            If (st = "insert") Or (st = "update") Or (st = "delete") Or (st = "CREATE") Then
                MyCommad.ExecuteNonQuery()
                SConnection.Close()
            Else
                MyCommad.ExecuteReader()
                SConnection.Close()
                Myadapter.Fill(dll)
            End If

        ElseIf (a(0) = "CSV") Then
            Dim SConnection As OleDb.OleDbConnection = New OleDb.OleDbConnection(Connection(StringConnet).Replace("{FileName}", DirFile))
            SConnection.Open()
            Dim MyCommad As OleDb.OleDbCommand = New OleDb.OleDbCommand(SqlQuery, SConnection)
            Dim Myadapter As New OleDb.OleDbDataAdapter
            Myadapter.SelectCommand = MyCommad
            Dim st As String = Mid(SqlQuery, 1, 6)
            If (st = "insert") Or (st = "update") Or (st = "delete") Or (st = "CREATE") Then
                MyCommad.ExecuteNonQuery()
                SConnection.Close()
            Else
                MyCommad.ExecuteReader()
                SConnection.Close()
                Myadapter.Fill(dll)
            End If


        ElseIf (a(0) = "DBF") Then
            Dim SConnection As OleDb.OleDbConnection = New OleDb.OleDbConnection(Connection(StringConnet).Replace("{FileName}", DirFile))
            SConnection.Open()
            Dim MyCommad As OleDb.OleDbCommand = New OleDb.OleDbCommand(SqlQuery, SConnection)
            Dim Myadapter As New OleDb.OleDbDataAdapter
            Myadapter.SelectCommand = MyCommad
            Dim st As String = Mid(SqlQuery, 1, 6)
            If (st = "insert") Or (st = "update") Or (st = "delete") Or (st = "CREATE") Then
                MyCommad.ExecuteNonQuery()
                SConnection.Close()
            Else
                MyCommad.ExecuteReader()
                SConnection.Close()
                Myadapter.Fill(dll)
            End If


        Else
            Dim SConnection As MySqlConnection = New MySqlConnection(Connection(StringConnet))
            SConnection.Open()
            Dim MyCommad As MySqlCommand = New MySqlCommand(SqlQuery, SConnection)
            Dim MyAdapter As New MySqlDataAdapter
            MyAdapter.SelectCommand = MyCommad
            Dim st As String = Mid(SqlQuery, 1, 6)
            If (st = "insert") Or (st = "update") Or (st = "delete") Or (st = "CREATE") Then
                MyCommad.ExecuteNonQuery()
                SConnection.Close()
            Else
                MyCommad.ExecuteReader()
                SConnection.Close()
                MyAdapter.Fill(dll)
            End If

        End If

        Return dll


    End Function

    Public Function Count(ByVal TABLE As String, ByVal FILTER As String) As Integer
        Dim SqlQ As String
        SqlQ = "select count(*) as num from " & TABLE


        If (FILTER = "") Then
            SqlQ &= ""
        Else
            SqlQ &= " where " & FILTER
        End If

        Dim DsConn As DataSet = ConnectString("MYSQL", "", SqlQ)

        Return Int(DsConn.Tables(0).Rows(0).Item("num"))

    End Function


    Public Function Insertdb(ByVal Tabel As String, ByVal field As String, ByVal Value As String)
        Dim SqlQ, theField, theValues As String
        SqlQ = "insert into " & Tabel

        If (IsArray(field)) Then
            theField = String.Join(",", field)
        Else
            theField = field
        End If

        If (IsArray(Value)) Then
            theValues = String.Join(",", Value)
        Else
            theValues = Value
        End If
        theValues = theValues.Replace("'now()'", "now()")

        If Not (IsNothing(theField)) Then
            SqlQ += " (" & theField & ")"
        End If

        SqlQ += " values (" & theValues & ")"

        Return SqlQ
    End Function


    Public Function Updatedb(ByVal table As String, ByVal NewVal As String, ByVal Where As String)
        Dim SqlQ, theValues As String
        If (IsArray(NewVal)) Then
            theValues = String.Join(",", NewVal)
        Else
            theValues = NewVal
        End If

        SqlQ = "update " & table & " set " & theValues

        If (Where = "") Then
            SqlQ &= ""

        Else
            SqlQ &= " where " & Where
        End If

        Return SqlQ
    End Function

    Public Function Createdb(ByVal table As String, ByVal Field As String)
        Dim SqlQ, theValues As String
        If (IsArray(Field)) Then
            theValues = String.Join(",", Field)
        Else
            theValues = Field
        End If

        SqlQ = "CREATE TABLE " & table & " (" & theValues & ")"

        Return SqlQ

    End Function

    Public Function Deletedb(ByVal table As String, ByVal where As String)
        Dim SqlQ As String

        SqlQ = "delete from " & table
        If (where = "") Then
            SqlQ &= ""
        Else
            SqlQ &= " where " & where
        End If

        Return SqlQ
    End Function

    Public Function selectdb(ByVal Field As String, ByVal TableDB As String, ByVal where As String,
                              ByVal order_by As String, ByVal group_by As String, ByVal having As String, ByVal limit As String)
        Dim Query As String
        Query = "select " & Field & " from " & TableDB

        If (where = "") Then
            Query &= ""
        Else
            Query &= " where " & where
        End If

        If (order_by = "") Then
            Query &= ""
        Else
            Query &= " order by " & order_by
        End If

        If (group_by = "") Then
            Query &= ""
        Else
            Query &= " group by " & group_by
        End If

        If (having = "") Then
            Query &= ""
        Else
            Query &= " having " & having
        End If

        If (limit = "") Then
            Query &= ""
        Else
            Query &= " limit " & limit
        End If


        Return Query
    End Function

    Public Sub OpenCmd(ByVal DirApk As String, ByVal Argu As String, ByVal WT As String)
        Thread.Sleep(1000)
        Dim cmdProcess = New ProcessStartInfo()
        cmdProcess.FileName = DirApk
        cmdProcess.Arguments = Argu
        cmdProcess.UseShellExecute = False
        cmdProcess.RedirectStandardInput = True
        cmdProcess.CreateNoWindow = True

        If (WT = "Y") Then
            Process.Start(cmdProcess).WaitForExit()
        Else
            Process.Start(cmdProcess)
        End If


    End Sub



End Class
