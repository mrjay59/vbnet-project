Imports System.IO

Public Class IniFileReader
    Private iniFilePath As String

    Public Sub New(filePath As String)
        iniFilePath = filePath
    End Sub

    Public Function ReadValue(section As String, key As String) As String
        Dim value As String = ""

        Try
            Dim lines As String() = File.ReadAllLines(iniFilePath)

            Dim inSection As Boolean = False

            For Each line As String In lines
                If line.Trim().StartsWith("[") AndAlso line.Trim().EndsWith("]") Then
                    inSection = line.Trim().Substring(1, line.Trim().Length - 2) = section
                ElseIf inSection AndAlso line.Contains("=") Then
                    Dim parts As String() = line.Split("="c)
                    If parts.Length = 2 AndAlso parts(0).Trim() = key Then
                        value = parts(1).Trim()
                        Exit For
                    End If
                End If
            Next
        Catch ex As Exception
            ' Handle exceptions as needed
            Console.WriteLine(ex.Message)
        End Try

        Return value
    End Function

    Public Sub WriteValue(section As String, key As String, value As String)
        Try
            Dim lines As List(Of String) = File.ReadAllLines(iniFilePath).ToList()

            Dim inSection As Boolean = False
            Dim keyExists As Boolean = False

            For i As Integer = 0 To lines.Count - 1
                If lines(i).Trim().StartsWith("[") AndAlso lines(i).Trim().EndsWith("]") Then
                    inSection = lines(i).Trim().Substring(1, lines(i).Trim().Length - 2) = section
                ElseIf inSection AndAlso lines(i).Contains("=") Then
                    Dim parts As String() = lines(i).Split("="c)
                    If parts.Length = 2 AndAlso parts(0).Trim() = key Then
                        lines(i) = $"{key}={value}"
                        keyExists = True
                        Exit For
                    End If
                End If
            Next

            If Not keyExists Then
                lines.Add($"{key}={value}")
            End If

            File.WriteAllLines(iniFilePath, lines)
        Catch ex As Exception
            ' Handle exceptions as needed
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub DeleteKey(section As String, key As String)
        Try
            ' Read all lines from the existing INI file
            Dim lines As List(Of String) = File.ReadAllLines(iniFilePath).ToList()

            ' Identify the section and key to be deleted
            Dim inSection As Boolean = False
            Dim keyFound As Boolean = False

            For i As Integer = 0 To lines.Count - 1
                If lines(i).Trim().StartsWith("[") AndAlso lines(i).Trim().EndsWith("]") Then
                    inSection = lines(i).Trim().Substring(1, lines(i).Trim().Length - 2) = section
                ElseIf inSection AndAlso lines(i).Contains("=") Then
                    Dim parts As String() = lines(i).Split("="c)
                    If parts.Length = 2 AndAlso parts(0).Trim() = key Then
                        ' Remove the line if the key is found
                        lines.RemoveAt(i)
                        keyFound = True
                        Exit For
                    End If
                End If
            Next

            ' Write the modified content back to the file
            File.WriteAllLines(iniFilePath, lines)
        Catch ex As Exception
            ' Handle exceptions as needed
            Console.WriteLine(ex.Message)
        End Try
    End Sub
End Class
