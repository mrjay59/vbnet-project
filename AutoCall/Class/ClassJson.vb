




Imports System.IO
Imports System.Xml
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class ClassJson
    Public Sub DeleteInFile(ByVal Path As String, ByVal fkey As String)
        ' Load the JSON file into a JObject variable
        Dim json As JObject = JObject.Parse(File.ReadAllText(Path))

        ' Use SelectToken to locate the object to be deleted (replace "key" and "value" with your own criteria)
        Dim objToDelete As JToken = json.SelectToken($"{fkey}")

        ' If the object was found, delete it
        If objToDelete IsNot Nothing Then
            objToDelete.Parent.Remove()
        End If

        ' Save the modified JSON data back to the file
        File.WriteAllText(Path, json.ToString())

    End Sub

    Public Sub UpdateInFile()

    End Sub

    Public Sub AddInFile(ByVal Path As String, ByVal fkey As String, ByVal Key As String, ByVal value As String)
        ' Load the JSON file into a JObject variable
        Dim json As JObject = JObject.Parse(File.ReadAllText(Path))

        ' Use SelectToken to locate the object to be deleted (replace "key" and "value" with your own criteria)
        Dim objToADD As JObject = json.SelectToken($"{fkey}")

        objToADD.Add(Key, value)

        ' Save the modified JSON data back to the file
        File.WriteAllText(Path, json.ToString())
    End Sub

    Public Function dencode(dataJson As String, ByVal str As String)
        Dim obj As New JObject
        obj = JObject.Parse(dataJson)
        Return obj.SelectToken(str)
    End Function

    Public Function Json2aray(ByVal x As Object)
        'example Dim x = "{'books':[{'title':'HarryPotter','pages':'134'}]}"

        Dim result = JsonConvert.DeserializeObject(x)
        Return result
        'Console.WriteLine(result("books")(0)("title") & " - " & result("books")(0)("pages"))
    End Function

    Public Function Cnvert2dtable(ByVal dtjs As String)
        Dim data_v As DataTable
        data_v = JsonConvert.DeserializeObject(Of DataTable)(dtjs)

        Return data_v
    End Function

    Public Function Cnvert2dset(ByVal dtjs As String) As DataSet
        Dim data_v As DataSet
        data_v = JsonConvert.DeserializeObject(Of DataSet)(dtjs)

        Return data_v
    End Function

    Public Function DataSetToJSON(ds As DataSet) As String
        Dim dict As New Dictionary(Of String, Object)

        For Each dt As DataTable In ds.Tables
            Dim arr(dt.Rows.Count - 1) As Object

            For i As Integer = 0 To dt.Rows.Count - 1
                arr(i) = dt.Rows(i).ItemArray
            Next

            dict.Add(dt.TableName, arr)

        Next


        Return JsonConvert.SerializeObject(dict)

    End Function

    Public Function DataTableToJSON(ByVal dt As DataTable) As String

        If String.IsNullOrWhiteSpace(dt.TableName) Then
            dt.TableName = "Dummy"
        End If

        Dim dict As New Dictionary(Of String, Object)
        Dim RowData(dt.Rows.Count - 1) As Object

        For i As Integer = 0 To dt.Rows.Count - 1
            RowData(i) = dt.Rows(i).ItemArray
        Next

        dict.Add(dt.TableName, RowData)

        Return JsonConvert.SerializeObject(dict)
    End Function

    Public Function XMLTOJSON(ByVal Fxml As String) As String
        Dim XMLdoc As New XmlDocument()
        XMLdoc.LoadXml(Fxml)

        Dim Json As String = JsonConvert.SerializeXmlNode(XMLdoc)

        Return Json

    End Function

    Public Function FindIndex(ByVal DatJson As String, ByVal jselect As String, ByVal skey As String, ByVal svalue As String)
        Dim JObject As JObject
        JObject = JObject.Parse(DatJson)
        Dim japkx As JArray = JObject.SelectToken(jselect)
        ' Find the index of the item with a specific value
        Dim searchKey As String = skey
        Dim searchValue As String = svalue
        Dim index As Integer = -1

        For i As Integer = 0 To japkx.Count - 1
            Dim item As JObject = CType(japkx(i), JObject)
            Dim value As JToken = item(searchKey)

            If value IsNot Nothing AndAlso value.ToString() = searchValue Then
                index = i
                Exit For
            End If
        Next

        Return index

    End Function

    Public Function IsJson(data As String) As Boolean
        Try
            ' Deserialize untuk memeriksa JSON
            JsonConvert.DeserializeObject(data)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
