Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class pgSheet
    Public Event DataSelected As EventHandler(Of ClassData)
    Private dbConn As New ClassConnect
    Private jsonpa As New ClassJson
    Private Sub BtnLoad_Click(sender As Object, e As EventArgs) Handles BtnLoad.Click
        Dim Gsheet As New GoogleSheetsReader

        Dim sheedid As String = Txtspid.Text.Trim
        Dim sheetname As String = txtshname.Text.Trim
        Dim startcol As Integer = col0.Value
        Dim TotCol As Integer = col1.Value

        Dim rowdata1 As Integer = row1.Value
        Dim rowdata2 As Integer = row2.Value

        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\linkspreadsheet.json"

        Dim logParse As New JObject
        Dim Rlog As String = File.ReadAllText(FoldeQ)
        If Not (Rlog = "") Then
            logParse = JObject.Parse(Rlog)
        End If

        Dim ardata As JArray = logParse.SelectToken("linkdata")
        ardata.RemoveAll()

        ViewTabel.Rows.Clear()
        ViewTabel1.Rows.Clear()
        indexrow.Clear()

        ' column
        Dim a As Integer = 0

        For ix = startcol To TotCol
            Threading.Thread.Sleep(2000)
            Dim huruf As String = Gsheet.GetExcelColumnLetter(ix)

            Dim baris1 As String = huruf & 1
            Dim baris2 As String = huruf & rowdata2
            Dim sheetnameRange = $"{sheetname}!{baris1}:{baris2}"
            Dim darr As ArrayList = Gsheet.ReadDataFromSheet(sheedid, sheetnameRange)
            'datjson.Add("name", "")
            Dim NaHeader = darr(0).ToString()



            Dim Darrx As New ArrayList
            For dx = rowdata1 - 1 To darr.Count - 1
                Dim numx = darr(dx)
                If (Not (numx = "") And (numx.Length >= 8)) Then
                    Darrx.Add(darr(dx))
                End If
            Next

            Dim dajoin As String = Join(Darrx.ToArray, ",")
            Dim NewData As New JObject
            NewData.Add("name", NaHeader)
            NewData.Add("data", dajoin)
            ardata.Add(NewData)

            Dim row As String() = New String() {NaHeader, Darrx.Count}
            ViewTabel.Rows.Add(row)

        Next






        IO.File.WriteAllText(FoldeQ, logParse.ToString)

    End Sub

    Private Sub ViewTabel1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ViewTabel1.CellContentClick
        Dim columi As Integer = e.ColumnIndex
        Dim rowi As Integer = e.RowIndex
        Dim chk As Boolean = ViewTabel1.Rows(rowi).Cells("Chk").Value
        If (columi = 1) Then
            If (chk = False) Then
                ViewTabel1.Rows(rowi).Cells("Chk").Value = True
            Else
                ViewTabel1.Rows(rowi).Cells("Chk").Value = False
            End If
        End If
    End Sub

    Private Sub ChkAll_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAll.CheckedChanged
        Dim RowsC As Integer = ViewTabel1.Rows.Count
        Dim xk As Integer = 0
        If (ChkAll.Checked) Then
            If (RowsC > 0) Then
                For dx = 0 To RowsC - 1
                    xk = xk + 1
                    Dim chk As Boolean = ViewTabel1.Rows(dx).Cells("Chk").Value
                    If ((chk = False) And (xk <= 1000)) Then
                        ViewTabel1.Rows(dx).Cells("Chk").Value = True
                    End If
                Next
            End If
        Else
            If (RowsC > 0) Then
                For dx = 0 To RowsC - 1
                    Dim chk As Boolean = ViewTabel1.Rows(dx).Cells("Chk").Value
                    If (chk) Then
                        ViewTabel1.Rows(dx).Cells("Chk").Value = False
                    End If
                Next
            End If
        End If

    End Sub

    Private indexrow As New ArrayList
    Private Sub ViewTabel_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles ViewTabel.CellContentDoubleClick
        Dim Gsheet As New GoogleSheetsReader
        Dim columi As Integer = e.ColumnIndex
        Dim rowi As Integer = e.RowIndex
        Dim sheedid As String = Txtspid.Text.Trim
        Dim sheetname As String = txtshname.Text.Trim

        Dim rowdata1 As Integer = row1.Value
        Dim rowdata2 As Integer = row2.Value
        Dim TotCol As Integer = col1.Value

        If (indexrow.Contains(rowi)) Then
            MsgBox("Sebelumnya Sudah DiClick")
            Exit Sub
        End If

        If (ViewTabel1.RowCount > 1000) Then
            MsgBox("Data Sudah 1000 Silahkan Klik Pilih Data")
            Exit Sub
        End If

        ViewTabel.Rows(rowi).DefaultCellStyle.BackColor = Color.Orange
        indexrow.Add(rowi)


        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\linkspreadsheet.json"

        Dim logParse As New JObject
        Dim Rlog As String = File.ReadAllText(FoldeQ)

        Dim ObjLog = jsonpa.Json2aray(Rlog)
        Dim linkdata = ObjLog("linkdata")(rowi)("data").ToString
        Dim darrx = Split(linkdata, ",")

        For dx = 0 To darrx.Count - 1
            Dim number As String = darrx(dx)

            Dim row As String() = New String() {number, False}
            ViewTabel1.Rows.Add(row)

        Next


        lblTotNum.Text = "Total Data " & ViewTabel1.RowCount
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ViewTabel1.Rows.Clear()
        indexrow.Clear()
        lblTotNum.Text = "Total Data " & ViewTabel1.RowCount
    End Sub

    Private Sub BtnPilih_Click(sender As Object, e As EventArgs) Handles BtnPilih.Click
        Dim RowsC As Integer = ViewTabel1.Rows.Count
        Dim NeData, NClose As New JObject
        Dim xk As Integer = 0
        If (RowsC > 0) Then
            Dim arrx As New ArrayList

            For dx = 0 To RowsC - 1
                xk = xk + 1
                Dim chk As Boolean = ViewTabel1.Rows(dx).Cells("Chk").Value
                Dim number As String = ViewTabel1.Rows(dx).Cells("number").Value & vbNewLine

                If ((chk = True) And (xk <= 1000)) Then
                    arrx.Add(number)

                End If
            Next
            'hapus


            Dim JNomber As String = Join(arrx.ToArray, "")
            NeData.Add("fun", "lolistKontak")
            NeData.Add("number", JNomber)
            RaiseEvent DataSelected(Me, New ClassData(NeData.ToString))



            Dim msg = "Data Sudah Pilih, Apa Mau Diclose ? " + Environment.NewLine
            If (MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                NClose.Add("fun", "close")
                RaiseEvent DataSelected(Me, New ClassData(NClose.ToString))
            Else
                'loop through rows in datagrid
                'For Each Row As DataGridViewRow In ViewTabel1.Rows
                '    Dim chk As Boolean = Row.Cells("Chk").Value

                '    If (chk = True) Then
                '        ViewTabel1.Rows.Remove(Row)
                '    End If
                'Next

                For i As Integer = ViewTabel1.Rows.Count - 1 To 0 Step -1
                    Dim c As Boolean
                    c = ViewTabel1.Rows(i).Cells(1).Value
                    If c = True Then
                        ViewTabel1.Rows.RemoveAt(i)
                    End If
                Next i
            End If

        End If


    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim sheedid As String = Txtspid.Text.Trim
        Dim sheetname As String = txtshname.Text.Trim
        Dim rowheader As Integer = col0.Value
        Dim rowdata1 As Integer = row1.Value
        Dim rowdata2 As Integer = row2.Value
        Dim TotCol As Integer = col1.Value

        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\linkspreadsheet.json"

        If Not (IO.File.Exists(FoldeQ)) Then
            Dim ad = File.Create(FoldeQ)
            ad.Close()
            ad.Dispose()

        End If

        Dim NewData As New JObject
        Dim ardata As New JArray
        NewData.Add("sheedid", sheedid)
        NewData.Add("sheetname", sheetname)
        NewData.Add("rowheader", rowheader)
        NewData.Add("rowdata1", rowdata1)
        NewData.Add("rowdata2", rowdata2)
        NewData.Add("TotCol", TotCol)
        NewData.Add("linkdata", ardata)
        IO.File.WriteAllText(FoldeQ, NewData.ToString)
    End Sub

    Private Sub LoaData()
        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\linkspreadsheet.json"

        If Not (IO.File.Exists(FoldeQ)) Then
            IO.File.Create(FoldeQ)
        End If

        Dim b As String = File.ReadAllText(FoldeQ)
        Dim J2Obj = jsonpa.Json2aray(b)
        If Not (J2Obj Is Nothing) Then
            Dim spsheedid As String = J2Obj("sheedid")
            Dim sheetname As String = J2Obj("sheetname")
            Dim rowheader As Integer = J2Obj("rowheader")
            Dim rowdata1 As Integer = J2Obj("rowdata1")
            Dim rowdata2 As Integer = J2Obj("rowdata2")
            Dim TotCol As Integer = J2Obj("TotCol")

            Txtspid.Text = spsheedid
            txtshname.Text = sheetname
            col0.Value = rowheader
            row1.Value = rowdata1
            row2.Value = rowdata2
            col1.Value = TotCol
        End If

    End Sub
    Private Sub pgSheet_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoaData()
    End Sub

End Class