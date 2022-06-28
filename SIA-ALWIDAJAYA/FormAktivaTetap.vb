Imports System.Data.OleDb
Public Class FormAktivaTetap

    Dim objAktiva As New ClassAktivaTetap

    Private Sub setCbAkun()
        Try
            Query = "SELECT * FROM tbl_coa ORDER BY NoAkun"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            cboAkumulasi.Items.Clear()
            For a = 0 To Ds.Tables(0).Rows.Count - 1
                With cboAkumulasi
                    .Items.Add(Ds.Tables(0).Rows(a).Item(0) & " : " & Ds.Tables(0).Rows(a).Item(1))
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub

    Public Sub CariData()
        Query = "SELECT tbl_aktiva.NoAkun2, tbl_coa.NamaAkun, tbl_aktiva.KodeKelompok, IIf([KodeKelompok]='" & "A" & "','" & "Tanah" & "',IIf([KodeKelompok]= '" & "B" & "','" & "Bagunan" & "',IIf([KodeKelompok]='" & "C" & "','" & "Kendaraan" & "',IIf([KodeKelompok]= '" & "D" & "','" & "Peralatan" & "',IIf([KodeKelompok]= '" & "E" & "', '" & "Mebel" & "','" & "" & "'))))) AS Kelompok, tbl_aktiva.TglPerolehan, tbl_aktiva.HargaPerolehan, tbl_aktiva.UmurEkonomis, tbl_aktiva.TglPensiun, tbl_aktiva.NilaiResidu, tbl_aktiva.Penyusutan, tbl_aktiva.NoSeri, tbl_aktiva.TglTerhitung, tbl_aktiva.Akumulasi, tbl_aktiva.Beban, tbl_aktiva.NilaiBuku, tbl_aktiva.BebanPerbulan, tbl_aktiva.NoAkun, tbl_coa.NamaAkun FROM tbl_aktiva LEFT JOIN tbl_coa ON tbl_aktiva.NoAkun = tbl_coa.NoAkun WHERE (((tbl_aktiva.NoAkun2)='" & Microsoft.VisualBasic.Left(lblNama.Text, 5) & "'))"
        Da = New OleDbDataAdapter(Query, CONN)
        Ds = New DataSet
        Da.Fill(Ds)

        If Ds.Tables(0).Rows.Count > 0 Then
            cboKelompok.Text = Ds.Tables(0).Rows(0).Item(2) & " : " & Ds.Tables(0).Rows(0).Item(3)
            tglPerolehan.Text = Ds.Tables(0).Rows(0).Item(4)
            txtHargaPerolehan.Text = Format(Ds.Tables(0).Rows(0).Item(5), "#,#")
            txtUmur.Text = Ds.Tables(0).Rows(0).Item(6)
            tglPensiun.Text = Ds.Tables(0).Rows(0).Item(7)
            txtNilaiResidu.Text = Format(Ds.Tables(0).Rows(0).Item(8), "#,#")
            cboPenyusutan.Text = Ds.Tables(0).Rows(0).Item(9)
            txtNoSeri.Text = Ds.Tables(0).Rows(0).Item(10)
            tglTerhitung.Text = Ds.Tables(0).Rows(0).Item(11)
            txtAkumulasi.Text = Format(Ds.Tables(0).Rows(0).Item(12), "#,#")
            txtBeban.Text = Format(Ds.Tables(0).Rows(0).Item(13), "#,#")
            txtNilaiBuku.Text = Format(Ds.Tables(0).Rows(0).Item(14), "#,#")
            lblBebanPerbulan.Text = Format(Ds.Tables(0).Rows(0).Item(15), "#,#")
            cboAkumulasi.Text = Ds.Tables(0).Rows(0).Item(16) & " : " & Ds.Tables(0).Rows(0).Item(17)
        End If
    End Sub

    Private Sub BersihkanIsian()
        lblNama.Text = ""
        cboKelompok.Text = ""
        tglPerolehan.Text = Now()
        txtHargaPerolehan.Text = "0"
        txtUmur.Text = "0"
        tglPensiun.Text = Now()
        txtNilaiResidu.Text = "0"
        cboPenyusutan.Text = ""
        txtNoSeri.Text = ""
        tglTerhitung.Text = Now
        txtAkumulasi.Text = "0"
        txtBeban.Text = "0"
        txtNilaiBuku.Text = "0"
        lblBebanPerbulan.Text = "0"
        cboAkumulasi.Text = ""
    End Sub

    Private Sub FormAktiva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BukaKoneksi()
        setCbAkun()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        With objAktiva
            Try
                If cboAkumulasi.Text = "" Then
                    MsgBox("Kode tidak boleh kosong", MsgBoxStyle.Critical, "Error")
                    cboAkumulasi.Focus()
                Else
                    If cboKelompok.Text = "" Then
                        MsgBox("Kelompok aktiva tidak boleh kosong", MsgBoxStyle.Exclamation, "Error")
                        cboKelompok.Focus()
                    Else
                        If cboPenyusutan.Text = "" Then
                            MsgBox("Jenis penyusutan tidak boleh kosong", MsgBoxStyle.Information, "Error")
                            cboPenyusutan.Focus()
                        Else
                            .SimpanData()
                            BersihkanIsian()
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try
        End With
    End Sub

    Private Sub btnHitung_Click(sender As Object, e As EventArgs) Handles btnHitung.Click
        Dim mHargaPerolehan As Long
        Dim mUmurEkonomis As Integer
        Dim mBebanPerBulan As Long
        Dim mNilaiResidu As Long

        mHargaPerolehan = txtHargaPerolehan.Text
        mUmurEkonomis = txtUmur.Text
        mNilaiResidu = txtNilaiResidu.Text

        If cboPenyusutan.Text = "" Then
            MsgBox("Tentukan metode penyusutan", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Pesan")
            cboPenyusutan.Focus()
        Else
            If cboPenyusutan.Text = "Garis Lurus" Then
                mBebanPerBulan = (mHargaPerolehan - mNilaiResidu) / mUmurEkonomis
                lblBebanPerbulan.Text = mBebanPerBulan
            Else
                txtUmur.Text = "0"
                txtNilaiResidu.Text = "0"
                txtAkumulasi.Text = "0"
                txtBeban.Text = "0"
                txtNilaiBuku.Text = "0"
                lblBebanPerbulan.Text = "0"
            End If
        End If
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Try
            If Len(lblNama.Text) = 0 Then
                MsgBox("Pilih data yang dihapus", MsgBoxStyle.Information, "Perhatian")
                cboKelompok.Focus()
                Exit Sub
            Else
                Dim A As String

                A = MsgBox("Benar akan dihapus...", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Informasi")
                Select Case A
                    Case vbCancel
                        cboKelompok.Focus()
                        BersihkanIsian()
                        Exit Sub
                    Case vbOK
                        With objAktiva
                            .HapusData()
                            BersihkanIsian()
                        End With
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Perhatian")
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim A As String

        A = MsgBox("Benar akan di-Edit...", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Informasi")
        Select Case A
            Case vbCancel
                BersihkanIsian()
                Exit Sub
            Case vbOK
                Try
                    With objAktiva
                        .EditData()
                        BersihkanIsian()
                    End With
                Catch ex As Exception
                End Try
        End Select
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        'objAktiva.Keluar()
        Me.Close()
    End Sub

    Private Sub cboKelompok_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboKelompok.KeyPress
        If e.KeyChar = Chr(13) Then
            tglPerolehan.Focus()
        End If
    End Sub

    Private Sub txtHargaPerolehan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHargaPerolehan.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtHargaPerolehan.Text = "" Then
                txtHargaPerolehan.Text = 0
                txtHargaPerolehan.Focus()
            Else
                txtUmur.Focus()
            End If
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub tglPerolehan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tglPerolehan.KeyPress
        If e.KeyChar = Chr(13) Then
            txtHargaPerolehan.Focus()
        End If
    End Sub

    Private Sub txtUmur_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUmur.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtUmur.Text = "" Then
                txtUmur.Text = 0
                txtUmur.Focus()
            Else
                tglPensiun.Focus()
            End If
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub tglPensiun_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tglPensiun.KeyPress
        If e.KeyChar = Chr(13) Then
            txtNilaiResidu.Focus()
        End If
    End Sub

    Private Sub txtNilaiResidu_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNilaiResidu.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtNilaiResidu.Text = "" Then
                txtNilaiResidu.Text = 0
                txtNilaiResidu.Focus()
            Else
                cboPenyusutan.Focus()
            End If
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub cboPenyusutan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboPenyusutan.KeyPress
        If e.KeyChar = Chr(13) Then
            If cboPenyusutan.Text = "" Then
                MsgBox("Pilih metode penyusutan", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Informasi")
                cboPenyusutan.Focus()
            Else
                txtNoSeri.Focus()
            End If
        End If
    End Sub

    Private Sub txtNoSeri_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoSeri.KeyPress
        If e.KeyChar = Chr(13) Then
            tglTerhitung.Focus()
        End If
    End Sub

    Private Sub tglTerhitung_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tglTerhitung.KeyPress
        If e.KeyChar = Chr(13) Then
            txtAkumulasi.Focus()
        End If
    End Sub

    Private Sub txtAkumulasi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAkumulasi.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtAkumulasi.Text = "" Then
                txtAkumulasi.Text = 0
                txtAkumulasi.Focus()
            Else
                txtBeban.Focus()
            End If
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtBeban_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBeban.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtBeban.Text = "" Then
                txtBeban.Text = 0
                txtBeban.Focus()
            Else
                txtNilaiBuku.Focus()
            End If
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNilaiBuku_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNilaiBuku.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtNilaiBuku.Text = "" Then
                txtNilaiBuku.Text = 0
                txtNilaiBuku.Focus()
            Else
                btnHitung.Focus()
            End If
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

End Class