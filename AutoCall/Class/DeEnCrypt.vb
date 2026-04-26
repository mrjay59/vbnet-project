
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Management



Public Class DeEnCrypt
    Public Function DecryptData(ByVal data As Byte(), ByVal key As Byte()) As String
        Dim aesAlg As New AesManaged()
        aesAlg.Key = key
        ' aesAlg.IV = iv
        aesAlg.Mode = CipherMode.ECB
        aesAlg.Padding = PaddingMode.PKCS7

        Dim decryptor As ICryptoTransform = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV)
        Dim decryptedData As Byte() = decryptor.TransformFinalBlock(data, 0, data.Length)

        Return Encoding.UTF8.GetString(decryptedData)
    End Function

    Public Function AESEncrypt(input As String, key As Byte()) As String
        Using aesAlg As New AesManaged()
            aesAlg.Mode = CipherMode.ECB
            aesAlg.Padding = PaddingMode.PKCS7
            aesAlg.Key = key

            Dim encryptor As ICryptoTransform = aesAlg.CreateEncryptor()
            Dim plainBytes As Byte() = Encoding.UTF8.GetBytes(input)
            Dim encrypted As Byte() = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length)
            Return Convert.ToBase64String(encrypted)
        End Using
    End Function


    Public Function GetUserName() As String
        If TypeOf My.User.CurrentPrincipal Is
        Security.Principal.WindowsPrincipal Then
            ' The application is using Windows authentication.
            ' The name format is DOMAIN\USERNAME.
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1)
            Return username
        Else
            ' The application is using custom authentication.
            Return My.User.Name
        End If
    End Function

    Public Function GenerateRandomString(ByRef iLength As Integer) As String
        Dim rdm As New Random()
        Dim allowChrs() As Char = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLOMNOPQRSTUVWXYZ0123456789".ToCharArray()
        Dim sResult As String = ""

        For i As Integer = 0 To iLength - 1
            sResult += allowChrs(rdm.Next(0, allowChrs.Length))
        Next

        Return sResult
    End Function

    Public Function GetWMI(className As String, propertyName As String) As String
        Try
            Dim searcher As New ManagementObjectSearcher("SELECT " & propertyName & " FROM " & className)
            For Each obj As ManagementObject In searcher.Get()
                If obj(propertyName) IsNot Nothing Then
                    Return obj(propertyName).ToString()
                End If
            Next
        Catch ex As Exception
            ' Abaikan jika gagal
        End Try
        Return ""
    End Function

    Public Function GetIdDevice() As String
        Dim cpuId As String = GetWMI("Win32_Processor", "ProcessorId")
        Dim baseboardSN As String = GetWMI("Win32_BaseBoard", "SerialNumber")
        Dim biosSN As String = GetWMI("Win32_BIOS", "SerialNumber").Replace(" ", "").Substring(0, 7)
        Dim uuid As String = GetWMI("Win32_ComputerSystemProduct", "UUID")
        Dim manufacturer As String = GetWMI("Win32_ComputerSystem", "Manufacturer").ToLower()
        Dim model As String = GetWMI("Win32_ComputerSystem", "Model").ToLower()

        ' Deteksi jika VM
        Dim isVM As Boolean = (manufacturer.Contains("vmware") OrElse
                           manufacturer.Contains("microsoft") OrElse
                           manufacturer.Contains("xen") OrElse
                           manufacturer.Contains("virtual") OrElse
                           model.Contains("virtual") OrElse
                           model.Contains("vmware") OrElse
                           model.Contains("kvm"))

        ' Gabungkan data untuk ID unik
        Dim rawId As String = cpuId & "|" & baseboardSN & "|" & biosSN & "|" & uuid

        ' Format output
        Dim info As New StringBuilder()
        info.AppendLine("IsVM: " & isVM.ToString())
        info.AppendLine("RawID: " & rawId)
        info.AppendLine("EncodedID: " & Convert.ToBase64String(Encoding.UTF8.GetBytes(rawId)))

        Return rawId.ToString
    End Function


    Private Function ComputeSHA256(input As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(input)
            Dim hashBytes As Byte() = sha256.ComputeHash(bytes)
            Return BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
        End Using
    End Function
End Class
