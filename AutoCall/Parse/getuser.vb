

Public Class getuser
    Public Class user
        Public Property body As body
    End Class

    Public Class body
        Public Property apk_user As String
        Public Property apk_fullname As String
        Public Property apk_hp As String
        Public Property apk_stat As String
        Public Property apk_data As apkdata
        Public Property apk_produk As apkprod

    End Class

    Public Class apkdata
        Public Property apk_product As String
        Public Property apk_versi As String
        Public Property apk_lisensi As String
        Public Property apk_serial As String
        Public Property apk_key As String
        Public Property apk_mesinumber As String
        Public Property apk_referral As String
        Public Property apk_dial_count As Integer
        Public Property apk_subscribe As List(Of apksub)
        Public Property apk_exe As Dictionary(Of String, String)
        Public Property apk_price As Decimal
        Public Property apk_status As String
    End Class

    Public Class apkprod

    End Class

    Public Class apksub

    End Class

End Class
