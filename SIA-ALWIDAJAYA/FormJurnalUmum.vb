Imports System.Data.OleDb
Public Class FormJurnalUmum

    Dim objJurnal As New ClassJurnalUmum

    Public mPosted As String
    Public mDK As Char
    Dim mNoTransaksi As String
    Dim mJumlah As Long

    Sub KondisiAwal()
        txtTgl.Text = Today
        txtKeterangan.Text = ""
        txtNoAkun.Text = ""
        lblNamaAkun.Text = ""
        txtDebet.Text = "0"
        txtKredit.Text = "0"
        lblDebet.Text = "0"
        lblKredit.Text = "0"
        btnTambah.Enabled = True
        btnSimpan.Enabled = False
        btnHapus.Enabled = False
        btnPreview.Enabled = True
        btnKeluar.Enabled = True
        txtKeterangan.Focus()
        NoTransaksi()
        CariPeriode()
        BuatKolom()
        PosisiGrid()
    End Sub

    Public Sub PosisiGrid()
        'Try
        'DataGridView1.Columns(0).Width = 0
        DataGridView1.Columns(0).Width = 90
        DataGridView1.Columns(1).Width = 300
        DataGridView1.Columns(2).Width = 160
        DataGridView1.Columns(3).Width = 160
        DataGridView1.Columns(4).Width = 100
        'Catch ex As Exception
        'End Try
    End Sub

    Sub BuatKolom()
        DataGridView1.Columns.Clear()
        'DataGridView1.Columns.Add("NoTransaksi", "NoTransaksi")
        DataGridView1.Columns.Add("NoAkun", "No. Akun")
        DataGridView1.Columns.Add("NamaAkun", "Nama Akun")
        DataGridView1.Columns.Add("Debet", "Debet")
        DataGridView1.Columns.Add("Kredit", "Kredit")
        DataGridView1.Columns.Add("DK", "DK")

    End Sub

    Public Sub PosisiListGrid()
        With ListView1.Columns
            .Add("No.Transaksi", 0)
            .Add("No Akun", 68)
            .Add("Nama Akun", 360)
            .Add("Debet", 125, HorizontalAlignment.Right)
            .Add("Kredit", 125, HorizontalAlignment.Right)
            .Add("DK", 100)
        End With
    End Sub

    Public Sub IsiListGridDJurnal()
        Try
            Query = "SELECT tbl_detailjurnal.NoTransaksi, tbl_detailjurnal.NoAkun, tbl_coa.NamaAkun, tbl_detailjurnal.DK, tbl_detailjurnal.Debet, tbl_detailjurnal.Kredit FROM (tbl_detailjurnal LEFT JOIN tbl_jurnalumum ON tbl_detailjurnal.NoTransaksi = tbl_jurnalumum.NoTransaksi) LEFT JOIN tbl_coa ON tbl_detailjurnal.NoAkun = tbl_coa.NoAkun WHERE(((tbl_detailjurnal.NoTransaksi) = '" & lblNoTransaksi.Text & "'))"
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
            lblNoTransaksi.Text = "JU-" & mMemoriNo & "000"
            Query = "SELECT Count(tbl_jurnalumum.NoTransaksi) AS CountOfNoTransaksi FROM(tbl_jurnalumum) HAVING ((Mid([tbl_jurnalumum].[NoTransaksi],4,6)='" & mMemoriNo & "'))"

            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            If Ds.Tables(0).Rows.Count = 0 Then
                lblNoTransaksi.Text = "JU-" & mMemoriNo + "000" + Ds.Tables(0).Rows(0).Item(0) + 1
                mTempNoTransaksi = "JU-" & mMemoriNo + "000" + Ds.Tables(0).Rows(0).Item(0) + 1
            Else
                lblNoTransaksi.Text = "JU-" & mMemoriNo + "000" + Ds.Tables(0).Rows(0).Item(0) + 1
                mTempNoTransaksi = "JU-" & mMemoriNo + "000" + Ds.Tables(0).Rows(0).Item(0) + 1
            End If

            Query = "SELECT tbl_jurnalumum.NoTransaksi, Count(tbl_jurnalumum.NoTransaksi) AS Jumlah FROM tbl_jurnalumum GROUP BY tbl_jurnalumum.NoTransaksi HAVING (((tbl_jurnalumum.NoTransaksi)='" & lblNoTransaksi.Text & "'))"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            If Ds.Tables(0).Rows.Count = 0 Then
                lblNoTransaksi.Text = mTempNoTransaksi
            Else
                lblNoTransaksi.Text = Microsoft.VisualBasic.Mid(lblNoTransaksi.Text, 1, 3) & Val(Microsoft.VisualBasic.Mid(lblNoTransaksi.Text, 4, 9)) + 1
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub TotalDebetKredit()
        Try
            QueryDebetKredit = "SELECT tbl_detailjurnal.NoTransaksi, Sum(tbl_detailjurnal.Debet) AS TotalDebet, Sum(tbl_detailjurnal.Kredit) AS TotalKredit FROM(tbl_detailjurnal) GROUP BY tbl_detailjurnal.NoTransaksi HAVING (((tbl_detailjurnal.NoTransaksi)= '" & lblNoTransaksi.Text & "'))"
            DaDebetKredit = New OleDbDataAdapter(QueryDebetKredit, CONN)
            DsDebetKredit = New DataSet
            DaDebetKredit.Fill(DsDebetKredit)

            With DsDebetKredit.Tables(0).Rows(0)
                Dim i As Integer
                i = DataGridView1.CurrentRow.Index
                lblDebet.Text = DataGridView1.Rows(i).Cells(2).Value
                lblKredit.Text = DataGridView1.Rows(i).Cells(3).Value
                'lblDebet.Text = Format(.Item(1), "#,#")
                'lblKredit.Text = Format(.Item(2), "#,#")
            End With
        Catch ex As Exception
        End Try
    End Sub

    Sub RumusSubDebet()
        Dim hitungdeb As Integer = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            hitungdeb = hitungdeb + DataGridView1.Rows(i).Cells(2).Value
            lblDebet.Text = hitungdeb
        Next
    End Sub

    Sub RumusSubKredit()
        Dim hitungkre As Integer = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            hitungkre = hitungkre + DataGridView1.Rows(i).Cells(3).Value
            lblKredit.Text = hitungkre
        Next
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Try
            If txtKeterangan.Text = "" Or txtNoAkun.Text = "" Or lblNamaAkun.Text = "" Or txtDebet.Text = "" Or txtKredit.Text = "" Then
                MsgBox("Data Tidak Lengkap, Silahkan lengkapi terlebih dahulu!", MsgBoxStyle.Information, "")

                'ElseIf lblDebet.Text <> lblKredit.Text Then
                '    MsgBox("Jumlah debet dan kredit tidak seimbang, silahkan periksa", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Pesan")
                '    txtNoAkun.Enabled = True
                '    txtNoAkun.Focus()
            Else
                

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
                If txtDebet.Text > 0 Then
                    mDK = "D"
                Else
                    mDK = "K"
                End If
                DataGridView1.Rows.Add(New String() {txtNoAkun.Text, lblNamaAkun.Text, txtDebet.Text, txtKredit.Text, mDK})
                RumusSubDebet()
                RumusSubKredit()
                txtNoAkun.Text = ""
                lblNamaAkun.Text = ""
                txtDebet.Text = "0"
                txtKredit.Text = "0"
                'lblDebet.Text = "0"
                'lblKredit.Text = "0"
                btnSimpan.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
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
            Query = "DELETE FROM tbl_detailjurnal WHERE NoTransaksi = '" & lblNoTransaksi.Text & "' AND NoAkun= '" & txtNoAkun.Text & "' AND DK = '" & mDK & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CariDataNoTransaksi()
        Try
            Query = "SELECT tbl_jurnalumum.Periode, tbl_jurnalumum.TglTransaksi, tbl_jurnalumum.NoTransaksi, tbl_jurnalumum.Keterangan, tbl_jurnalumum.Status FROM(tbl_jurnalumum) GROUP BY tbl_jurnalumum.Periode, tbl_jurnalumum.TglTransaksi, tbl_jurnalumum.NoTransaksi, tbl_jurnalumum.Keterangan, tbl_jurnalumum.Status HAVING(((tbl_jurnalumum.NoTransaksi) = '" & lblNoTransaksi.Text & "')) ORDER BY tbl_jurnalumum.Periode, tbl_jurnalumum.TglTransaksi, tbl_jurnalumum.NoTransaksi, tbl_jurnalumum.Keterangan, tbl_jurnalumum.Status"
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
                lblNoTransaksi.Text = Ds.Tables(0).Rows(0).Item(2)
                txtKeterangan.Text = Ds.Tables(0).Rows(0).Item(3)
                mPosted = Ds.Tables(0).Rows(0).Item(4)

                IsiListGridDJurnal()
                TotalDebetKredit()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PeriksaDataNoTransaksi()
        With objJurnal
            Try
                Query = "SELECT tbl_jurnalumum.Periode, tbl_jurnalumum.TglTransaksi, tbl_jurnalumum.NoTransaksi, tbl_jurnalumum.Keterangan, tbl_jurnalumum.Status FROM(tbl_jurnalumum) GROUP BY tbl_jurnalumum.Periode, tbl_jurnalumum.TglTransaksi, tbl_jurnalumum.NoTransaksi, tbl_jurnalumum.Keterangan, tbl_jurnalumum.Status HAVING(((tbl_jurnalumum.NoTransaksi) = '" & lblNoTransaksi.Text & "')) ORDER BY tbl_jurnalumum.Periode, tbl_jurnalumum.TglTransaksi, tbl_jurnalumum.NoTransaksi, tbl_jurnalumum.Keterangan, tbl_jurnalumum.Status"
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
            Query = "SELECT NoTransaksi FROM tbl_jurnalumum WHERE NoTransaksi = '" & lblNoTransaksi.Text & "'"
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
                btnBatal.Text = "&Edit"
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
        With objJurnal
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
                lblNoTransaksi.Enabled = True
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

    Private Sub FormJurnalUmum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            
            BukaKoneksi()
            KondisiAwal()
            Dim band As DataGridViewBand = DataGridView1.Columns(4)
            band.Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Try
            Dim ans As String
            ans = MsgBox("Anda Yakin Ingin Keluar? Data Tidak Akan diSimpan!", MsgBoxStyle.YesNo, "Konfirmasi")
            If ans = vbYes Then
                Me.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If lblDebet.Text = "" Or lblKredit.Text = "" Then
                MsgBox("Data Tidak Lengkap, Silahkan lengkapi terlebih dahulu!", MsgBoxStyle.Information, "")
            ElseIf lblDebet.Text <> lblKredit.Text Then
                MsgBox("Jumlah debet dan kredit tidak seimbang, silahkan periksa", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Pesan")
            Else
                Dim SimpanJurnal As String = "Insert into tbl_jurnalumum values ('" & lblNoTransaksi.Text & "', '" & lblPeriode.Text & "', '" & txtTgl.Text & "', '" & txtKeterangan.Text & "', '" & mPosted & "')"
                Command = New OleDbCommand(SimpanJurnal, CONN)
                Command.ExecuteNonQuery()

                For Baris As Integer = 0 To DataGridView1.Rows.Count - 2
                    Dim SimpanDetail As String = "Insert into tbl_detailjurnal values ('" & lblNoTransaksi.Text & "','" & DataGridView1.Rows(Baris).Cells(0).Value & "','" & DataGridView1.Rows(Baris).Cells(4).Value & "','" & DataGridView1.Rows(Baris).Cells(2).Value & "','" & DataGridView1.Rows(Baris).Cells(3).Value & "')"
                    Command = New OleDbCommand(SimpanDetail, CONN)
                    Command.ExecuteNonQuery()
                Next
                KondisiAwal()
                MsgBox("Transaksi Telah Berhasil di Simpan")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

   
    Private Sub txtKredit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKredit.KeyPress
        With objJurnal
            If e.KeyChar = Chr(13) Then
                If btnTambah.Text = "&Tambah" Then
                    Try
                        If txtNoAkun.Text = "" Then
                            MessageBox.Show("No. Akun masih kosong", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            txtNoAkun.Focus()
                        Else
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
                            '.SimpanData() 'dJurnal
                                mPosted = "UnPosted"
                                TotalDebetKredit()
                                IsiListGridDJurnal()
                                BersihkanIsianGrid()
                                txtNoAkun.Focus()
                            'EditJurnalGrid()
                        End If
                    Catch ex As Exception
                    End Try
                Else
                    If mPosted = "UnPosted" Then
                        Try
                            If txtNoAkun.Text = "" Then
                                MessageBox.Show("No. Akun masih kosong", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                txtNoAkun.Focus()
                            Else
                                If btnBatal.Text = "&Edit" Then
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

                                    .SimpanData() 'dJurnal
                                    mPosted = "UnPosted"
                                    TotalDebetKredit()

                                    IsiListGridDJurnal()
                                    BersihkanIsianGrid()
                                    txtNoAkun.Focus()
                                Else
                                    btnBatal.Text = "&Edit"
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
            FormSubAkunJurnalUmum.ShowDialog()
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

    Private Sub txtNoTransaksi_KeyPress(sender As Object, e As KeyPressEventArgs)
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

    '    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
    '        Try
    '            frmCetakJurnalRpt.CrystalReportViewer1.SelectionFormula = "{HJurnal.Periode} = '" & lblPeriode.Text & "'"
    '            frmCetakJurnalRpt.CrystalReportViewer1.Dock = DockStyle.Fill
    '            frmCetakJurnalRpt.CrystalReportViewer1.RefreshReport()
    '            frmCetakJurnalRpt.ShowDialog()
    '            cmdEdit.Text = "&Edit"
    '        Catch ex As Exception
    '            MsgBox("Mencetak jurnal gagal")
    '        End Try
    '    End Sub

    Private Sub txtNoAkun_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNoAkun.KeyUp
        If e.KeyCode = Keys.F1 Then
            If txtKeterangan.Text = "" Then
                MsgBox("Keterangan masih kosong, silahkan isi", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Pesan")
                txtKeterangan.Focus()
            Else
                FormSubAkunJurnalUmum.ShowDialog()
            End If
        End If

        If e.KeyCode = Keys.Escape Then
            BersihkanIsianGrid()
        End If
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Dim A As String

        With objJurnal
            If mPosted = "UnPosted" Then
                Try
                    If Len(lblNoTransaksi.Text) = 0 Then
                        MsgBox("Pilih data yang dihapus", MsgBoxStyle.Information, "Informasi hapus")
                        txtNoAkun.Enabled = True
                        txtNoAkun.Focus()
                        btnSimpan.Enabled = True
                        Exit Sub
                    Else
                        If txtNoAkun.Text = "" Then
                            'hapus semua transaksi dengan no transaksi yang sesuai dengan no.transaksi
                            A = MsgBox("Benar akan dihapus...", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Informasi")
                            Select Case A
                                Case vbCancel
                                    txtNoAkun.Focus()
                                    btnBatal.Text = "&Edit"
                                    btnTambah.Text = "&Tambah"
                                    txtNoAkun.Enabled = True
                                    btnSimpan.Enabled = True
                                    Exit Sub
                                Case vbOK
                                    'Hapus hJurnal
                                    .HapusDataHJurnal()
                                    'Hapus dJurnal
                                    .HapusData()
                                    BersihkanIsian()
                                    BersihkanIsianGrid()
                                    ListView1.Clear()
                                    PosisiListGrid()
                                    IsiListGridDJurnal()
                                    txtTgl.Focus()
                                    NoTransaksi()
                                    TotalDebetKredit()
                                    btnBatal.Text = "&Edit"
                                    btnTambah.Text = "&Tambah"
                                    txtNoAkun.Enabled = True
                                    btnSimpan.Enabled = True
                            End Select
                        Else
                            'untuk menghapus record jurnal
                            A = MsgBox("Benar akan dihapus...", MsgBoxStyle.OkCancel, "Informasi")
                            Select Case A
                                Case vbCancel
                                    txtNoAkun.Focus()
                                    btnBatal.Text = "&Edit"
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
                                    btnBatal.Text = "&Edit"
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

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        Try
            AmbilData()
            lblNoTransaksi.Enabled = False
            txtNoAkun.Enabled = False
            btnBatal.Text = "&Update"
            btnSimpan.Enabled = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ListView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView1.KeyPress
        If e.KeyChar = Chr(13) Then
            Try
                AmbilData()
                lblNoTransaksi.Enabled = False
                txtNoAkun.Enabled = False
                btnBatal.Text = "&Update"
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
            btnBatal.Text = "&Edit"
            btnSimpan.Enabled = True
        End If

        If e.KeyCode = Keys.Delete Then
            AmbilData()
            A = MsgBox("Benar akan dihapus...", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Informasi")
            Select Case A
                Case vbCancel
                    txtNoAkun.Enabled = True
                    btnSimpan.Enabled = True
                    txtNoAkun.Focus()
                    BersihkanIsianGrid()
                    Exit Sub
                Case vbOK
                    If mPosted = "UnPosted" Then
                        HapusIsiGrid()
                        IsiListGridDJurnal()
                        BersihkanIsianGrid()
                        txtNoAkun.Enabled = True
                        btnSimpan.Enabled = True
                        txtNoAkun.Focus()
                        TotalDebetKredit()
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
            FormSubJurnalUmum.ShowDialog()
            btnBatal.Text = "&Edit"
            txtTgl.Focus()
            BersihkanIsianGrid()
            btnSimpan.Enabled = False
        End If
    End Sub

    Private Sub txtKredit_KeyUp(sender As Object, e As KeyEventArgs) Handles txtKredit.KeyUp
        If e.KeyCode = Keys.Escape Then
            BersihkanIsianGrid()
        End If
    End Sub

    Private Sub txtDebet_KeyUp(sender As Object, e As KeyEventArgs) Handles txtDebet.KeyUp
        If e.KeyCode = Keys.Escape Then
            BersihkanIsianGrid()
        End If
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        KondisiAwal()
    End Sub
End Class