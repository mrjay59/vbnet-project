Imports Google.Apis.Sheets.v4
Imports Google.Apis.Sheets.v4.Data
Imports Google.Apis.Services


Public Class GoogleSheetsReader

    Private Function GetSheetsService() As SheetsService
        Dim serviceInitializer As New BaseClientService.Initializer With {
            .ApiKey = "AIzaSyB7mscjdkY--IwOrp3vyaFV3KFPNyx9yfw", ' Add your API key here
            .ApplicationName = "MyDataContact"
        }

        Return New SheetsService(serviceInitializer)
    End Function

    Public Function ReadDataFromSheet(ByVal sheedid As String, ByVal sheetname As String) As ArrayList
        Dim sheetsService = GetSheetsService()

        Try

            ' Define request parameters
            Dim request As SpreadsheetsResource.ValuesResource.GetRequest = sheetsService.Spreadsheets.Values.[Get](sheedid, sheetname)

            ' Execute request
            Dim response As ValueRange = request.Execute()

            ' Process the response
            Dim values As IList(Of IList(Of Object)) = response.Values


            Dim arr As New ArrayList
            If values IsNot Nothing AndAlso values.Count > 0 Then
                For Each row In values ' baris

                    For Each col In row ' column 
                        arr.Add(col)

                    Next

                Next
            End If

            Return arr
        Catch ex As Google.GoogleApiException
            ' Handle the Google API Exception
            Dim msg = $"Google API Exception: {ex.Message}"
            Console.Write(msg)
        Catch ex As Exception

            Dim msg = $"An error occurred: {ex.Message}"

        End Try

        Return Nothing
    End Function

    Public Function GetExcelColumnLetter(columnIndex As Integer) As String
        If columnIndex <= 0 Then
            Throw New ArgumentOutOfRangeException("Column index must be greater than 0.")
        End If

        Dim columnLetter As String = ""

        While columnIndex > 0
            Dim remainder As Integer = (columnIndex - 1) Mod 26
            columnLetter = ChrW(AscW("A"c) + remainder) & columnLetter
            columnIndex = (columnIndex - 1) \ 26
        End While

        Return columnLetter
    End Function
End Class