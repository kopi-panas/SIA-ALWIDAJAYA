Imports System.Data.OleDb
Public Class ClassAktivaTetap

    Private KodeAkun As String
    Private KodeAkun2 As String
    Private KodeKelompok As Char
    Private TglPerolehan As Date
    Private HargaPerolehan As Long
    Private UmurEkonomis As Integer
    Private TglPensiun As Date
    Private NilaiResidu As Long
    Private Penyusutan As String
    Private NoSeri As String
    Private TglTerhitung As Date
    Private Akumulasi As Long
    Private Beban As Long
    Private NilaiBuku As Long
    Private BebanPerBulan As Long

    Public Sub TambahData()
        With formAktivaTetap
            .cboKelompok.Focus()
        End With
    End Sub

    Public Function SimpanData()
        Try
            KodeAkun = Microsoft.VisualBasic.Left(FormAktivaTetap.cboAkumulasi.Text, 5)
            KodeAkun2 = Microsoft.VisualBasic.Left(FormAktivaTetap.lblNama.Text, 5)
            KodeKelompok = Microsoft.VisualBasic.Left(FormAktivaTetap.cboKelompok.Text, 1)
            TglPerolehan = FormAktivaTetap.tglPerolehan.Text
            HargaPerolehan = FormAktivaTetap.txtHargaPerolehan.Text
            UmurEkonomis = FormAktivaTetap.txtUmur.Text
            TglPensiun = FormAktivaTetap.tglPensiun.Text
            NilaiResidu = FormAktivaTetap.txtNilaiResidu.Text
            Penyusutan = FormAktivaTetap.cboPenyusutan.Text
            If FormAktivaTetap.txtNoSeri.Text = "" Then
                NoSeri = "-"
            Else
                NoSeri = FormAktivaTetap.txtNoSeri.Text
            End If
            TglTerhitung = FormAktivaTetap.tglTerhitung.Text
            Akumulasi = FormAktivaTetap.txtAkumulasi.Text
            Beban = FormAktivaTetap.txtBeban.Text
            NilaiBuku = FormAktivaTetap.txtNilaiBuku.Text
            BebanPerBulan = FormAktivaTetap.lblBebanPerbulan.Text
            Query = "INSERT INTO tbl_aktiva VALUES('" & KodeAkun & "', '" & KodeAkun2 & "', '" & KodeKelompok & "', '" & TglPerolehan & "', '" & HargaPerolehan & "', '" & UmurEkonomis & "' , '" & TglPensiun & "', '" & NilaiResidu & "' , '" & Penyusutan & "' , '" & NoSeri & "' , '" & TglTerhitung & "' , '" & Akumulasi & "' , '" & Beban & "' , '" & NilaiBuku & "' , '" & BebanPerBulan & "')"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
            Return Query
        Catch ex As Exception
            MsgBox("Data tidak bisa tersimpan karena NoPerkiraan sudah ada...", MsgBoxStyle.Exclamation, "Error")
            FormAkun.txtNoAkun.Focus()
            Return Query
        End Try
    End Function

    Public Function EditData()
        Try
            KodeAkun = Microsoft.VisualBasic.Left(FormAktivaTetap.cboAkumulasi.Text, 5)
            KodeAkun2 = Microsoft.VisualBasic.Left(FormAktivaTetap.lblNama.Text, 5)
            KodeKelompok = Microsoft.VisualBasic.Left(FormAktivaTetap.cboKelompok.Text, 1)
            TglPerolehan = FormAktivaTetap.tglPerolehan.Text
            HargaPerolehan = FormAktivaTetap.txtHargaPerolehan.Text
            UmurEkonomis = FormAktivaTetap.txtUmur.Text
            TglPensiun = FormAktivaTetap.tglPensiun.Text
            NilaiResidu = FormAktivaTetap.txtNilaiResidu.Text
            Penyusutan = FormAktivaTetap.cboPenyusutan.Text
            NoSeri = FormAktivaTetap.txtNoSeri.Text
            TglTerhitung = FormAktivaTetap.tglTerhitung.Text
            Akumulasi = FormAktivaTetap.txtAkumulasi.Text
            Beban = FormAktivaTetap.txtBeban.Text
            NilaiBuku = FormAktivaTetap.txtNilaiBuku.Text
            BebanPerBulan = FormAktivaTetap.lblBebanPerbulan.Text
            Query = "UPDATE tbl_aktiva SET NoAkun = '" & Microsoft.VisualBasic.Left(FormAktivaTetap.cboAkumulasi.Text, 5) & "', KodeKelompok = '" & KodeKelompok & "', TglPerolehan = '" & TglPerolehan & "', HargaPerolehan = '" & HargaPerolehan & "', UmurEkonomis ='" & UmurEkonomis & "' , TglPensiun ='" & TglPensiun & "', NilaiResidu = '" & NilaiResidu & "' , Penyusutan = '" & Penyusutan & "' , NoSeri = '" & NoSeri & "' , TglTerhitung = '" & TglTerhitung & "' , Akumulasi = '" & Akumulasi & "' , Beban = '" & Beban & "' , NilaiBuku = '" & NilaiBuku & "', BebanPerbulan = '" & BebanPerBulan & "' WHERE NoAkun2 = '" & KodeAkun2 & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
            Return Query
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function HapusData()
        Try
            KodeAkun2 = Microsoft.VisualBasic.Left(FormAktivaTetap.lblNama.Text, 5)
            Query = "DELETE FROM tblAKtiva WHERE NoPerkiraan2 = '" & KodeAkun2 & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
            Return Query
        Catch ex As Exception
            Return 0
        End Try
    End Function

End Class
