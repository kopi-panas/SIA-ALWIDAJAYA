Imports System.Data.OleDb
Public Class FormAJP

    Dim objJurnalPenyesuaian As New ClassAJP

    Public mPosted As String
    Public mDK As String
    Dim mNoTransaksi As String
    Dim mJumlah As Long

    Public Sub PosisiListGrid()
        With ListView1.Columns
            .Add("No.Transaksi", 0)
            .Add("No Akun", 68)
            .Add("Nama Akun", 360)
            .Add("DK", 0)
            .Add("Debet", 125, HorizontalAlignment.Right)
            .Add("Kredit", 125, HorizontalAlignment.Right)
        End With
    End Sub

    Public Sub IsiListGridDJurnal()
        Try
            Query = "SELECT tbl_detailajp.NoTransaksi, tbl_detailajp.NoAkun, tbl_coa.NamaAkun, tbl_detailajp.DK, tbl_detailajp.Debet, tbl_detailajp.Kredit FROM (tbl_detailajp LEFT JOIN tbl_jurnalajp ON tbl_detailajp.NoTransaksi = tbl_jurnalajp.NoTransaksi) LEFT JOIN tbl_coa ON tbl_detailajp.NoAkun = tbl_coa.NoAkun WHERE(((tbl_detailajp.NoTransaksi) = '" & txtNoTransaksi.Text & "'))"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            ListView1.Items.Clear()
            For a = 0 To Ds.Tables(0).Rows.Count - 1
                With ListView1
                    .Items.Add(Ds.Tables(0).Rows(a).Item(0))
                    .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(1))
                    .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(2))
                    .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(3))
                    .Items(a).SubItems.Add(Format(Ds.Tables(0).Rows(a).Item(4), "###,###"))
                    .Items(a).SubItems.Add(Format(Ds.Tables(0).Rows(a).Item(5), "###,###"))
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

    Private Sub NoTransaksi()
        Try
            Dim mMemoriNo As String
            Dim mTempNoTransaksi As String

            mMemoriNo = Format(Microsoft.VisualBasic.Right(Now.Year, 2)) & Format(Now.Month, "00") & Format(Now.Day, "00")
            txtNoTransaksi.Text = "JP-" & mMemoriNo & "000"
            Query = "SELECT Count(tbl_jurnalajp.NoTransaksi) AS CountOfNoTransaksi FROM(tbl_jurnalajp) HAVING ((Mid([tbl_jurnalajp].[NoTransaksi],4,6)='" & mMemoriNo & "'))"

            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            If Ds.Tables(0).Rows.Count = 0 Then
                txtNoTransaksi.Text = "JP-" & mMemoriNo + "000" + Ds.Tables(0).Rows(0).Item(0) + 1
                mTempNoTransaksi = "JP-" & mMemoriNo + "000" + Ds.Tables(0).Rows(0).Item(0) + 1
            Else
                txtNoTransaksi.Text = "JP-" & mMemoriNo + "000" + Ds.Tables(0).Rows(0).Item(0) + 1
                mTempNoTransaksi = "JP-" & mMemoriNo + "000" + Ds.Tables(0).Rows(0).Item(0) + 1
            End If

            Query = "SELECT tbl_jurnalajp.NoTransaksi, Count(tbl_jurnalajp.NoTransaksi) AS Jumlah FROM tbl_jurnalajp GROUP BY tbl_jurnalajp.NoTransaksi HAVING (((tbl_jurnalajp.NoTransaksi)='" & txtNoTransaksi.Text & "'))"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            If Ds.Tables(0).Rows.Count = 0 Then
                txtNoTransaksi.Text = mTempNoTransaksi
            Else
                txtNoTransaksi.Text = Microsoft.VisualBasic.Mid(txtNoTransaksi.Text, 1, 3) & Val(Microsoft.VisualBasic.Mid(txtNoTransaksi.Text, 4, 9)) + 1
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub TotalDebetKredit()
        Try
            QueryDebetKredit = "SELECT tbl_detailajp.NoTransaksi, Sum(tbl_detailajp.Debet) AS TotalDebet, Sum(tbl_detailajp.Kredit) AS TotalKredit FROM(tbl_detailajp) GROUP BY tbl_detailajp.NoTransaksi HAVING (((tbl_detailajp.NoTransaksi)= '" & txtNoTransaksi.Text & "'))"
            DaDebetKredit = New OleDbDataAdapter(QueryDebetKredit, CONN)
            DsDebetKredit = New DataSet
            DaDebetKredit.Fill(DsDebetKredit)

            With DsDebetKredit.Tables(0).Rows(0)
                lblDebet.Text = Format(.Item(1), "#,#")
                lblKredit.Text = Format(.Item(2), "#,#")
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AmbilData()
        Try
            With ListView1.SelectedItems
                mNoTransaksi = .Item(0).SubItems(0).Text
                txtNoAkun.Text = .Item(0).SubItems(1).Text
                lblNamaAkun.Text = .Item(0).SubItems(2).Text
                mDK = .Item(0).SubItems(3).Text
                If .Item(0).SubItems(4).Text = "" Then
                    txtDebet.Text = 0
                Else
                    txtDebet.Text = .Item(0).SubItems(4).Text
                End If

                If .Item(0).SubItems(5).Text = "" Then
                    txtKredit.Text = 0
                Else
                    txtKredit.Text = .Item(0).SubItems(5).Text
                End If
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub HapusIsiGrid()
        Try
            'Menghapus isi data grid
            Query = "DELETE FROM tbl_detailajp WHERE NoTransaksi = '" & txtNoTransaksi.Text & "' AND NoAkun= '" & txtNoAkun.Text & "' AND DK = '" & mDK & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CariDataNoTransaksi()
        Try
            Query = "SELECT tbl_jurnalajp.Periode, tbl_jurnalajp.TglTransaksi, tbl_jurnalajp.NoTransaksi, tbl_jurnalajp.Keterangan, tbl_jurnalajp.Status FROM(tbl_jurnalajp) GROUP BY tbl_jurnalajp.Periode, tbl_jurnalajp.TglTransaksi, tbl_jurnalajp.NoTransaksi, tbl_jurnalajp.Keterangan, tbl_jurnalajp.Status HAVING(((tbl_jurnalajp.NoTransaksi) = '" & txtNoTransaksi.Text & "')) ORDER BY tbl_jurnalajp.Periode, tbl_jurnalajp.TglTransaksi, tbl_jurnalajp.NoTransaksi, tbl_jurnalajp.Keterangan, tbl_jurnalajp.Status"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            If Ds.Tables(0).Rows.Count - 1 Then
                BersihkanIsian()
                txtTgl.Focus()
                ListView1.Clear()
                PosisiListGrid()
                IsiListGridDJurnal()
            Else
                lblPeriode.Text = Ds.Tables(0).Rows(0).Item(0)
                txtTgl.Text = Ds.Tables(0).Rows(0).Item(1)
                txtNoTransaksi.Text = Ds.Tables(0).Rows(0).Item(2)
                txtKeterangan.Text = Ds.Tables(0).Rows(0).Item(3)
                mPosted = Ds.Tables(0).Rows(0).Item(4)

                IsiListGridDJurnal()
                TotalDebetKredit()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PeriksaDataNoTransaksi()
        With objJurnalPenyesuaian
            Try
                Query = "SELECT tbl_jurnalajp.Periode, tbl_jurnalajp.TglTransaksi, tbl_jurnalajp.NoTransaksi, tbl_jurnalajp.Keterangan, tbl_jurnalajp.Status FROM(tbl_jurnalajp) GROUP BY tbl_jurnalajp.Periode, tbl_jurnalajp.TglTransaksi, tbl_jurnalajp.NoTransaksi, tbl_jurnalajp.Keterangan, tbl_jurnalajp.Status HAVING(((tbl_jurnalajp.NoTransaksi) = '" & txtNoTransaksi.Text & "')) ORDER BY tbl_jurnalajp.Periode, tbl_jurnalajp.TglTransaksi, tbl_jurnalajp.NoTransaksi, tbl_jurnalajp.Keterangan, tbl_jurnalajp.Status"
                Da = New OleDbDataAdapter(Query, CONN)
                Ds = New DataSet
                Da.Fill(Ds)

                If Ds.Tables(0).Rows.Count - 1 Then
                    .SimpanDataHJurnal()
                End If
            Catch ex As Exception
            End Try
        End With
    End Sub

    Private Sub AdaNoTransaksi()
        Try
            Query = "SELECT NoTransaksi FROM tbl_jurnalajp WHERE NoTransaksi = '" & txtNoTransaksi.Text & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            If Ds.Tables(0).Rows.Count - 1 Then
                MsgBox("Belum ada transksi jurnal....", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Pesan simpan data")
                txtNoAkun.Focus()
            Else
                PeriksaDataNoTransaksi()
                BersihkanIsian()
                BersihkanIsianGrid()
                NoTransaksi()
                ListView1.Clear()
                PosisiListGrid()
                IsiListGridDJurnal()
                btnEdit.Text = "&Edit"
                btnTambah.Text = "&Tambah"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CariNoAkun()
        Try
            Query = "SELECT tbl_coa.Akun, tbl_coa.NamaAkun FROM(tbl_coa) WHERE (((tbl_coa.NoAkun)='" & txtNoAkun.Text & "'))"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            If Ds.Tables(0).Rows.Count - 1 Then
                MsgBox("No Akun ini tidak ada", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Cari No Akun")
                BersihkanIsianGrid()
                txtNoAkun.Focus()
            Else
                txtNoAkun.Text = Ds.Tables(0).Rows(0).Item(0)
                lblNamaAkun.Text = Ds.Tables(0).Rows(0).Item(1)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub EditJurnalGrid()
        With objJurnalPenyesuaian
            Try
                .EditDataHJurnal() 'edit hJurnal

                If txtDebet.Text > 0 Then
                    mDK = "D"
                Else
                    mDK = "K"
                End If
                .EditData() 'edit dJurnal
                IsiListGridDJurnal()
                BersihkanIsianGrid()
                txtNoAkun.Enabled = True
                txtNoTransaksi.Enabled = True
                TotalDebetKredit()
            Catch ex As Exception
            End Try
        End With
    End Sub

    Private Sub CariPeriode()
        Try
            Query = "SELECT tbl_periode.Periode FROM(tbl_periode)WHERE(((tbl_periode.Keterangan) = '" & "UnPosted" & "')) ORDER BY tbl_periode.Periode"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            If Ds.Tables(0).Rows.Count - 1 Then
                MsgBox("Periode belum ada, silahkan buat periode di master periode...", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Pesan")
                Dispose()
            Else
                lblPeriode.Text = Ds.Tables(0).Rows(0).Item(0)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub BersihkanIsian()
        txtTgl.Text = txtTgl.Value
        txtKeterangan.Clear()
        txtNoAkun.Clear()
        lblNamaAkun.Text = ""
        txtDebet.Text = "0"
        txtKredit.Text = "0"
        lblDebet.Text = "0"
        lblKredit.Text = "0"
        txtTgl.Focus()
    End Sub

    Public Sub BersihkanIsianGrid()
        txtNoAkun.Clear()
        lblNamaAkun.Text = ""
        txtDebet.Text = "0"
        txtKredit.Text = "0"
        txtNoAkun.Focus()
    End Sub

    Private Sub FormAJP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            BukaKoneksi()

            txtDebet.Text = "0"
            txtKredit.Text = "0"
            lblDebet.Text = "0"
            lblKredit.Text = "0"

            CariPeriode()

            PosisiListGrid()
            IsiListGridDJurnal()
            NoTransaksi()

            btnTambah.Text = "&Tambah"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If txtNoTransaksi.Text = "" Then
                MessageBox.Show("No.Transaksi tidak boleh kosong", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtNoTransaksi.Focus()
            Else
                If txtKeterangan.Text = "" Then
                    MsgBox("Keterangan jurnal masih kosong, silahkan diisi", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Pesan")
                    txtKeterangan.Focus()
                Else
                    If lblDebet.Text <> lblKredit.Text Then
                        MsgBox("Jumlah debet dan kredit tidak seimbang, silahkan periksa", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Pesan")
                    Else
                        AdaNoTransaksi()
                    End If
                End If
            End If
        Catch 'ex As Exception
        End Try
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If lblDebet.Text <> lblKredit.Text Then
            MsgBox("Jumlah debet dan kredit tidak seimbang, silahkan periksa", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Pesan")
            txtNoAkun.Enabled = True
            txtNoAkun.Focus()
        Else
            Try
                Ds.Reset()
                IsiListGridDJurnal()
                BersihkanIsian()
                txtTgl.Focus()
                txtTgl.Text = Now
                NoTransaksi()
                ListView1.Clear()
                PosisiListGrid()
                txtNoAkun.Enabled = True
                txtNoTransaksi.Enabled = True
                btnEdit.Text = "&Edit"
                btnTambah.Text = "&Tambah"
                btnSimpan.Enabled = True
            Catch 'ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim A As String

        With objJurnalPenyesuaian
            If mPosted = "UnPosted" Then
                A = MsgBox("Benar akan di-Edit", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Informasi Edit")
                Select Case A
                    Case vbCancel
                        txtNoTransaksi.Focus()
                        btnEdit.Text = "&Edit"
                        BersihkanIsianGrid()
                        Exit Sub
                    Case vbOK
                        Try
                            If txtNoAkun.Text = "" Then
                                .EditDataHJurnal() 'EditHJurnal AJP
                                TotalDebetKredit()
                                btnEdit.Text = "&Edit"
                                btnSimpan.Enabled = True
                            Else
                                EditJurnalGrid()
                                btnEdit.Text = "&Edit"
                                btnSimpan.Enabled = True
                            End If
                        Catch ex As Exception
                            MsgBox("Terjadi kesalahan")
                        End Try
                End Select
            Else
                MsgBox("Data ini sudah diposting, tidak bisa di Edit", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Pesan edit")
                btnEdit.Text = "&Edit"
                BersihkanIsianGrid()
                btnSimpan.Enabled = True
            End If
        End With
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Dim A As String

        With objJurnalPenyesuaian
            If mPosted = "UnPosted" Then
                Try
                    If Len(txtNoTransaksi.Text) = 0 Then
                        MsgBox("Pilih data yang dihapus", MsgBoxStyle.Information, "Informasi hapus")
                        txtNoAkun.Enabled = True
                        txtNoAkun.Focus()
                        btnSimpan.Enabled = True
                        Exit Sub
                    Else
                        If txtNoAkun.Text = "" Then
                            'hapus semua transaksi dengan no transksi yang sesuai dengan no.transaksi
                            A = MsgBox("Benar akan dihapus...", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Informasi")
                            Select Case A
                                Case vbCancel
                                    txtNoAkun.Focus()
                                    btnEdit.Text = "&Edit"
                                    btnTambah.Text = "&Tambah"
                                    txtNoAkun.Enabled = True
                                    btnSimpan.Enabled = True
                                    Exit Sub
                                Case vbOK
                                    'Hapus hJurnal AJP
                                    .HapusDataHJurnal()
                                    'Hapus dJurnal AJP
                                    .HapusData()
                                    BersihkanIsian()
                                    BersihkanIsianGrid()
                                    ListView1.Clear()
                                    PosisiListGrid()
                                    IsiListGridDJurnal()
                                    txtTgl.Focus()
                                    NoTransaksi()
                                    TotalDebetKredit()
                                    btnEdit.Text = "&Edit"
                                    btnTambah.Text = "&Tambah"
                                    txtNoAkun.Enabled = True
                                    btnSimpan.Enabled = True
                            End Select
                        Else
                            'untuk menghapus record jurnal AJP
                            A = MsgBox("Benar akan dihapus...", MsgBoxStyle.OkCancel, "Informasi")
                            Select Case A
                                Case vbCancel
                                    txtNoAkun.Focus()
                                    btnEdit.Text = "&Edit"
                                    btnTambah.Text = "&Tambah"
                                    txtNoAkun.Enabled = True
                                    btnSimpan.Enabled = True
                                    Exit Sub
                                Case vbOK
                                    HapusIsiGrid()
                                    IsiListGridDJurnal()
                                    BersihkanIsianGrid()
                                    txtNoAkun.Focus()
                                    TotalDebetKredit()
                                    btnEdit.Text = "&Edit"
                                    btnTambah.Text = "&Tambah"
                                    txtNoAkun.Enabled = True
                                    btnSimpan.Enabled = True
                            End Select
                        End If
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Information, "Perhatian")
                End Try
            Else
                MsgBox("Data ini sudah diposting, tidak bisa dihapus...", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Hapus data")
                btnSimpan.Enabled = True
            End If
        End With
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        'Try
        '    frmCetakJurnalAJPRpt.CrystalReportViewer1.SelectionFormula = "{hJurnalAJP.Periode} = '" & lblPeriode.Text & "'"
        '    frmCetakJurnalAJPRpt.CrystalReportViewer1.Dock = DockStyle.Fill
        '    frmCetakJurnalAJPRpt.CrystalReportViewer1.RefreshReport()
        '    frmCetakJurnalAJPRpt.ShowDialog()
        '    btnEdit.Text = "&Edit"
        'Catch ex As Exception
        '    MsgBox("Mencetak jurnal gagal")
        'End Try
    End Sub

    Private Sub txtDebet_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDebet.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtDebet.Text = "" Then
                txtDebet.Text = 0
                txtKredit.Focus()
            Else
                txtKredit.Focus()
            End If
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtKredit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKredit.KeyPress
        With objJurnalPenyesuaian
            If e.KeyChar = Chr(13) Then
                If btnTambah.Text = "&Tambah" Then
                    Try
                        If txtNoAkun.Text = "" Then
                            MessageBox.Show("No.Perkiraan masih kosong", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            txtNoAkun.Focus()
                        Else
                            If btnEdit.Text = "&Edit" Then
                                If txtDebet.Text > 0 Then
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

                                PeriksaDataNoTransaksi()
                                .SimpanData() 'dJurnal AJP
                                mPosted = "UnPosted"
                                TotalDebetKredit()
                                IsiListGridDJurnal()
                                BersihkanIsianGrid()
                                txtNoAkun.Focus()
                            Else
                                btnEdit.Text = "&Edit"
                                EditJurnalGrid()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Else
                    If mPosted = "UnPosted" Then
                        Try
                            If txtNoAkun.Text = "" Then
                                MessageBox.Show("No.Perkiraan masih kosong", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                txtNoAkun.Focus()
                            Else
                                If btnEdit.Text = "&Edit" Then
                                    If txtDebet.Text > 0 Then
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

                                    .SimpanData() 'dJurnal AJP
                                    mPosted = "UnPosted"
                                    TotalDebetKredit()

                                    IsiListGridDJurnal()
                                    BersihkanIsianGrid()
                                    txtNoAkun.Focus()
                                Else
                                    btnEdit.Text = "&Edit"
                                    EditJurnalGrid()
                                End If
                            End If
                        Catch ex As Exception
                            MsgBox("Silahkan tekan tombol tambah data", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Pesan kesalahan")
                            BersihkanIsianGrid()
                        End Try
                    Else
                        MsgBox("Data ini sudah diposting, tidak bisa edit / tambah data", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Pesan Edit Data")
                        txtNoAkun.Focus()
                        BersihkanIsianGrid()
                    End If
                End If
            End If

        End With

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNoAkun_DoubleClick(sender As Object, e As EventArgs) Handles txtNoAkun.DoubleClick
        If txtKeterangan.Text = "" Then
            MsgBox("Keterangan masih kosong, silahkan isi", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Pesan")
            txtKeterangan.Focus()
        Else
            FormSubAkunAJP.ShowDialog()
            If Len(txtNoAkun.Text) <> 0 Then
                txtDebet.Focus()
            Else
                txtNoAkun.Focus()
            End If
        End If
    End Sub

    Private Sub txtNoAkun_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoAkun.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtKeterangan.Text = "" Then
                MsgBox("Keterangan tidak boleh kosong, silahkan isi", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Isi keterangan")
                txtKeterangan.Focus()
            Else
                If txtNoAkun.Text = "" Then
                    btnSimpan.Focus()
                Else
                    CariNoAkun()
                    txtDebet.Focus()
                End If
            End If
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNoTransaksi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoTransaksi.KeyPress
        If e.KeyChar = Chr(13) Then
            CariDataNoTransaksi()
        End If
    End Sub

    Private Sub txtTgl_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTgl.KeyPress
        If e.KeyChar = Chr(13) Then
            txtKeterangan.Focus()
        End If
    End Sub

    Private Sub txtKeterangan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKeterangan.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtKeterangan.Text = "" Then
                MsgBox("Keterangan masih kosong, silahkan isi", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Pesan")
                txtKeterangan.Focus()
            Else
                txtNoAkun.Focus()
            End If
        End If
    End Sub

    Private Sub txtNoAkun_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNoAkun.KeyUp
        If e.KeyCode = Keys.F1 Then
            If txtKeterangan.Text = "" Then
                MsgBox("Keterangan masih kosong, silahkan isi", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Pesan")
                txtKeterangan.Focus()
            Else
                FormSubAkunAJP.ShowDialog()
            End If
        End If

        If e.KeyCode = Keys.Escape Then
            BersihkanIsianGrid()
        End If
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        Try
            AmbilData()
            txtNoTransaksi.Enabled = False
            txtNoAkun.Enabled = False
            btnEdit.Text = "&Update"
            btnSimpan.Enabled = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ListView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView1.KeyPress
        If e.KeyChar = Chr(13) Then
            Try
                AmbilData()
                txtNoTransaksi.Enabled = False
                txtNoAkun.Enabled = False
                btnEdit.Text = "&Update"
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ListView1_KeyUp(sender As Object, e As KeyEventArgs) Handles ListView1.KeyUp
        Dim A As String

        If e.KeyCode = Keys.Escape Then
            BersihkanIsianGrid()
            txtNoAkun.Enabled = True
            txtNoAkun.Focus()
            btnEdit.Text = "&Edit"
            btnSimpan.Enabled = True
        End If

        If e.KeyCode = Keys.Delete Then
            AmbilData()
            A = MsgBox("Benar akan dihapus...", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Informasi")
            Select Case A
                Case vbCancel
                    txtNoAkun.Enabled = True
                    txtNoAkun.Focus()
                    BersihkanIsianGrid()
                    btnSimpan.Enabled = True
                    Exit Sub
                Case vbOK
                    If mPosted = "UnPosted" Then
                        HapusIsiGrid()
                        IsiListGridDJurnal()
                        BersihkanIsianGrid()
                        txtNoAkun.Enabled = True
                        txtNoAkun.Focus()
                        TotalDebetKredit()
                        btnSimpan.Enabled = True
                    Else
                        MsgBox("Data ini sudah diposting, tidak bisa dihapus", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Pesan")
                        BersihkanIsianGrid()
                        btnSimpan.Enabled = True
                    End If
            End Select
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If lblDebet.Text <> lblKredit.Text Then
            MsgBox("Jumlah debet dan kredit tidak seimbang, silahkan periksa", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Pesan")
            txtNoAkun.Enabled = True
            txtNoAkun.Focus()
        Else
            FormSubAJP.ShowDialog()
            btnEdit.Text = "&Edit"
            txtTgl.Focus()
            BersihkanIsianGrid()
            btnSimpan.Enabled = False
        End If
    End Sub

    Private Sub txtDebet_KeyUp(sender As Object, e As KeyEventArgs) Handles txtDebet.KeyUp
        If e.KeyCode = Keys.Escape Then
            BersihkanIsianGrid()
        End If
    End Sub

    Private Sub txtKredit_KeyUp(sender As Object, e As KeyEventArgs) Handles txtKredit.KeyUp
        If e.KeyCode = Keys.Escape Then
            BersihkanIsianGrid()
        End If
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Try
            If lblDebet.Text <> lblKredit.Text Then
                MsgBox("Jumlah debet dan kredit tidak seimbang, silahkan periksa", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Pesan")
            Else
                Me.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class