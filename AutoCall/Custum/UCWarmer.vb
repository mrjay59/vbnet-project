Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class UCWarmer
    Private DatR As String = String.Empty

    ' Data asli yang akan dimuat ke ComboBox
    Private AllData As List(Of DataItem)

    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Public Sub LoadTema(ByVal DaTema As JArray)

        Tema.DataSource = Nothing ' Bersihkan dulu DataSource
        Tema.DataSource = DaTema

        Tema.DisplayMember = "aichat_tema"
        Tema.ValueMember = "aichat_text"

    End Sub
    Public Sub ServerLoad(ByVal Data As String)

        ' Data JSON Anda
        Dim jsonString As String = Data

        Try
            ' Deserialize JSON ke objek RootObject
            Dim root = JsonConvert.DeserializeObject(Of RootObject)(jsonString)

            ' Ambil data dari properti data
            Me.AllData = root?.body?.data

            ' --- Populate ComboBox1 dengan semua data ---
            CmNumber1.DataSource = Nothing ' Bersihkan dulu DataSource
            CmNumber1.DataSource = Me.AllData
            CmNumber1.SelectedIndex = -1 ' Tidak ada yang dipilih secara default

            ' --- Populate ComboBox2 juga dengan semua data awalnya ---
            ' Ini penting agar ComboBox2 memiliki referensi data untuk difilter nanti
            CmNumber2.DataSource = Nothing
            CmNumber2.DataSource = New List(Of DataItem)(Me.AllData) ' Buat salinan agar tidak berbagi referensi DataSource

            ' Jika ada item yang dipilih di ComboBox1, filter ComboBox2
            UpdateComboBox2()



        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memuat data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CmNumber1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmNumber1.SelectedIndexChanged

        ' Panggil metode untuk memperbarui ComboBox2 setiap kali pilihan di ComboBox1 berubah
        UpdateComboBox2()
    End Sub

    Private Sub UpdateComboBox2()
        ' Pastikan AllData sudah dimuat
        If AllData Is Nothing OrElse AllData.Count = 0 Then Return

        ' Dapatkan item yang saat ini dipilih di ComboBox1
        Dim selectedItem1 As DataItem = TryCast(CmNumber1.SelectedItem, DataItem)

        ' Buat daftar baru untuk ComboBox2
        Dim filteredListForComboBox2 As New List(Of DataItem)()

        For Each item As DataItem In Me.AllData
            ' Tambahkan item ke daftar filter jika bukan item yang dipilih di ComboBox1
            If selectedItem1 IsNot Nothing AndAlso item.aichat_number = selectedItem1.aichat_number Then
                ' Jangan tambahkan item yang dipilih di ComboBox1
            Else
                filteredListForComboBox2.Add(item)
            End If
        Next

        ' --- Perbarui ComboBox2 ---
        ' Simpan pilihan saat ini di ComboBox2 jika ada, agar bisa dikembalikan setelah update
        Dim currentSelected2 As DataItem = TryCast(CmNumber2.SelectedItem, DataItem)

        CmNumber2.DataSource = Nothing ' Penting untuk mengosongkan DataSource sebelum mengikat yang baru
        CmNumber2.DataSource = filteredListForComboBox2

        ' Coba kembalikan pilihan sebelumnya di ComboBox2 jika masih ada di daftar baru
        If currentSelected2 IsNot Nothing Then
            Dim indexToSelect As Integer = filteredListForComboBox2.FindIndex(Function(item) item.aichat_number = currentSelected2.aichat_number)
            If indexToSelect <> -1 Then
                CmNumber2.SelectedIndex = indexToSelect
            Else
                CmNumber2.SelectedIndex = -1 ' Tidak ada pilihan sebelumnya di daftar baru
            End If
        Else
            CmNumber2.SelectedIndex = -1 ' Tidak ada pilihan sebelumnya
        End If

        ' Jika tidak ada item yang tersisa untuk dipilih di ComboBox2, tampilkan pesan atau nonaktifkan
        If filteredListForComboBox2.Count = 0 Then
            CmNumber2.Text = "Tidak ada pilihan lain" ' Atau ComboBox2.Enabled = False
        Else
            ' ComboBox2.Enabled = True
        End If
    End Sub

    Private Sub UCWarmer_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Inisialisasi ComboBox
        CmNumber1.DisplayMember = "aichat_name" ' Menentukan properti yang akan ditampilkan
        CmNumber1.ValueMember = "aichat_number"     ' Menentukan properti nilai (opsional, tapi bagus untuk ID)

        CmNumber2.DisplayMember = "aichat_name"
        CmNumber2.ValueMember = "aichat_number"
    End Sub

    Public Class RootObject
        Public Property body As BodyData
    End Class

    Public Class BodyData
        Public Property totalpage As Integer
        Public Property data As List(Of DataItem)
    End Class
End Class
