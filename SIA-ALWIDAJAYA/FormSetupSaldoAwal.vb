Imports System.Data.OleDb
Public Class FormSetupSaldoAwal

    Dim objSaldoBlnLalu As New ClassSetupsaldo

    Public mDK As String

    Private Sub PosisiList()
        With ListView.Columns
            .Add("Periode", 0)
            .Add("Tanggal", 0)
            .Add("Kode", 55)
            .Add("Nama Perkiraan", 250)
            .Add("D/K", 40)
            .Add("Debet", 120, HorizontalAlignment.Right)
            .Add("Kredit", 120, HorizontalAlignment.Right)
            .Add("Status", 0)
        End With
    End Sub

    Public Sub IsiList()
        Try
            Query = "SELECT tbl_saldoblnlalu.Periode, tbl_saldoblnlalu.TglTransaksi, tbl_saldoblnlalu.NoAkun, tbl_coa.NamaAkun, tbl_saldoblnlalu.DK, tbl_saldoblnlalu.Debet, tbl_saldoblnlalu.Kredit, tbl_saldoblnlalu.Status FROM (tbl_saldoblnlalu LEFT JOIN tbl_periode ON tbl_saldoblnlalu.Periode = tbl_periode.Periode) LEFT JOIN tbl_coa ON tbl_saldoblnlalu.NoAkun = tbl_coa.NoAkun WHERE (((tbl_saldoblnlalu.Periode)='" & cbPeriode.Text & "')) ORDER BY tbl_saldoblnlalu.Periode, tbl_saldoblnlalu.NoAkun"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            ListView.Items.Clear()
            For a = 0 To Ds.Tables(0).Rows.Count - 1
                With ListView
                    .Items.Add(Ds.Tables(0).Rows(a).Item(0))
                    .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(1))
                    .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(2))
                    .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(3))
                    .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(4))
                    .Items(a).SubItems.Add(Format(Ds.Tables(0).Rows(a).Item(5), "###,###"))
                    .Items(a).SubItems.Add(Format(Ds.Tables(0).Rows(a).Item(6), "###,###"))
                    .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(7))
                    If (a Mod 2 = 0) Then
                        .Items(a).BackColor = Color.LightSteelBlue
                    Else
                        .Items(a).BackColor = Color.LightBlue
                    End If
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub

    'Sub rutin ini digunakan untuk cek setup saldo awal.
    Private Sub CekSetUp()
        Dim Pesan As String

        Try
            Query = "SELECT * FROM tbl_setupsaldoawal"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            If Ds.Tables(0).Rows.Count = 0 Then
                txtTgl.Enabled = True
                txtDebet.Enabled = True
                txtKredit.Enabled = True
                txtNoAkun.Enabled = True
                btnTambah.Enabled = True
                btnSimpan.Enabled = True
                btnEdit.Enabled = True
                btnHapus.Enabled = True
            Else
                Pesan = MsgBox("Maaf anda tidak boleh memasukkan saldo awal lagi" & vbCrLf _
                    & "karena sudah melakukan proses posting, menu ini digunakan hanya untuk pertama kali menggunakan aplikasi ini. " & vbCrLf _
                    & "Saldo awal periode-periode berikunya dilakukan secara otomastis oleh sistem.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Pesan")

                txtTgl.Enabled = False
                txtDebet.Enabled = False
                txtKredit.Enabled = False
                txtNoAkun.Enabled = False
                btnTambah.Enabled = False
                btnSimpan.Enabled = False
                btnEdit.Enabled = False
                btnHapus.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AmbilData()
        Try
            With ListView.SelectedItems
                cbPeriode.Text = .Item(0).SubItems(0).Text
                txtTgl.Text = .Item(0).SubItems(1).Text
                txtNoAkun.Text = .Item(0).SubItems(2).Text
                lblNamaAkun.Text = .Item(0).SubItems(3).Text
                mDK = .Item(0).SubItems(4).Text
                txtDebet.Text = .Item(0).SubItems(5).Text
                txtKredit.Text = .Item(0).SubItems(6).Text
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Periode()
        Try
            Query = "SELECT tbl_periode.Periode FROM tbl_periode ORDER BY tbl_periode.Periode Desc"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            cbPeriode.Items.Clear()
            For a = 0 To Ds.Tables(0).Rows.Count - 1
                With cbPeriode
                    .Items.Add(Ds.Tables(0).Rows(a).Item(0))
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CariNoPerkiraan()
        Try
            Query = "SELECT tbl_coa.NoAkun, tbl_coa.NamaAkun FROM(tbl_coa) WHERE (((tbl_coa.NoAkun)='" & txtNoAkun.Text & "'))"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            If Ds.Tables(0).Rows.Count - 1 Then
                MsgBox("No.Perkiraan ini tidak ada", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Cari no perkiraan")
                txtNoAkun.Focus()
                txtNoAkun.Text = ""
                lblNamaAkun.Text = ""
            Else
                txtNoAkun.Text = Ds.Tables(0).Rows(0).Item(0)
                lblNamaAkun.Text = Ds.Tables(0).Rows(0).Item(1)
                txtDebet.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub BersihkanIsian()
        cbPeriode.Enabled = True
        txtTgl.Enabled = True
        txtNoAkun.Enabled = True
        txtNoAkun.Text = ""
        lblNamaAkun.Text = ""
        mDK = ""
        txtDebet.Text = "0"
        txtKredit.Text = "0"
    End Sub

    Private Sub txtDebet_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDebet.KeyPress
        If e.KeyChar = Chr(13) Then
            txtKredit.Focus()
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        With objSaldoBlnLalu
            .Keluar()
        End With
    End Sub

    Private Sub txtNoAkun_DoubleClick(sender As Object, e As EventArgs) Handles txtNoAkun.DoubleClick
        FormSubAkunSetup.ShowDialog()
    End Sub

    Private Sub txtNoAkun_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoAkun.KeyPress
        If e.KeyChar = Chr(13) Then
            If cbPeriode.Text = "" Then
                MsgBox("Periode tidak boleh kosong, silahkan isi", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Isi keterangan")
                cbPeriode.Focus()
            Else
                If txtTgl.Text = "" Then
                    txtTgl.Focus()
                Else
                    CariNoPerkiraan()
                End If
            End If
        End If
    End Sub

    Private Sub txtKredit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKredit.KeyPress
        If e.KeyChar = Chr(13) Then
            btnSimpan.Focus()

        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub FormSetupSaldoAwal_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        cbPeriode.Focus()
    End Sub

    Private Sub FormSetupSaldoAwal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            BukaKoneksi()
            PosisiList()
            IsiList()
            CekSetUp()
            Periode()
        Catch ex As Exception
            MsgBox("Koneksi ke database gagal")
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If Val(txtDebet.Text) > Val(txtKredit.Text) Then
                mDK = "D"
            Else
                mDK = "K"
            End If

            If txtDebet.Text = "" Then
                txtDebet.Text = 0
            Else
                txtDebet.Text = txtDebet.Text
            End If

            If txtKredit.Text = "" Then
                txtKredit.Text = 0
            Else
                txtKredit.Text = txtKredit.Text
            End If

            With objSaldoBlnLalu
                .SimpanData()
            End With
            IsiList()
            BersihkanIsian()
            txtNoAkun.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cbPeriode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbPeriode.KeyPress
        If e.KeyChar = Chr(13) Then
            If cbPeriode.Text = "" Then
                MsgBox("Periode masih kosong, silahkan diisi", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Pesan")
                cbPeriode.Focus()
            Else
                txtTgl.Focus()
            End If
        End If
    End Sub

    Private Sub cbPeriode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPeriode.SelectedIndexChanged
        IsiList()
    End Sub

    Private Sub txtTgl_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTgl.KeyPress
        If e.KeyChar = Chr(13) Then
            txtNoAkun.Focus()
        End If
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        With objSaldoBlnLalu
            .TambahData()
        End With
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Try
            If Len(txtNoAkun.Text) = 0 Then
                MsgBox("Pilih data yang dihapus", MsgBoxStyle.Information, "Perhatian")
                txtNoAkun.Focus()
                Exit Sub
            Else
                Dim A As String

                A = MsgBox("Benar akan dihapus...", MsgBoxStyle.OkCancel, "Informasi")
                Select Case A
                    Case vbCancel
                        txtNoAkun.Focus()
                        Exit Sub
                    Case vbOK
                        With objSaldoBlnLalu
                            .HapusData()
                        End With
                        IsiList()
                        BersihkanIsian()
                        txtNoAkun.Focus()
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Perhatian")
        End Try
    End Sub

    Private Sub ListView_DoubleClick(sender As Object, e As EventArgs) Handles ListView.DoubleClick
        AmbilData()
    End Sub

    Private Sub ListView_KeyUp(sender As Object, e As KeyEventArgs) Handles ListView.KeyUp
        If e.KeyCode = Keys.Escape Then
            cbPeriode.Enabled = True
            txtTgl.Enabled = True
            txtNoAkun.Enabled = True
            BersihkanIsian()
            cbPeriode.Focus()
        End If
    End Sub

    Private Sub ListView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView.SelectedIndexChanged
        AmbilData()
        cbPeriode.Enabled = False
        txtTgl.Enabled = False
        txtNoAkun.Enabled = False
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim A As String

        A = MsgBox("Benar akan di-Edit", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Informasi")
        Select Case A
            Case vbCancel
                BersihkanIsian()
                txtNoAkun.Focus()
                Exit Sub
            Case vbOK
                Try
                    With objSaldoBlnLalu
                        .EditData()
                    End With
                    IsiList()
                Catch ex As Exception
                End Try
        End Select
    End Sub

    Private Sub txtKredit_TextChanged(sender As Object, e As EventArgs) Handles txtKredit.TextChanged

    End Sub
End Class