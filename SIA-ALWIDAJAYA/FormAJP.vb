Imports System.Data.OleDb
Public Class FormAJP

    Dim objJurnalPenyesuaian As New ClassAJP

    Public mPosted As String
    Public mDK As String
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
        dgv()
    End Sub

    Public Sub PosisiGrid()
        DataGridView1.Columns(0).Width = 90
        DataGridView1.Columns(1).Width = 300
        DataGridView1.Columns(2).Width = 160
        DataGridView1.Columns(3).Width = 160
        DataGridView1.Columns(4).Width = 100
    End Sub

    Sub BuatKolom()
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add("NoAkun", "No. Akun")
        DataGridView1.Columns.Add("NamaAkun", "Nama Akun")
        DataGridView1.Columns.Add("Debet", "Debet")
        DataGridView1.Columns.Add("Kredit", "Kredit")
        DataGridView1.Columns.Add("DK", "DK")
    End Sub

    'Public Sub IsiListGridDJurnal()
    '    Try
    '        Query = "SELECT tbl_detailajp.NoTransaksi, tbl_detailajp.NoAkun, tbl_coa.NamaAkun, tbl_detailajp.DK, tbl_detailajp.Debet, tbl_detailajp.Kredit FROM (tbl_detailajp LEFT JOIN tbl_jurnalajp ON tbl_detailajp.NoTransaksi = tbl_jurnalajp.NoTransaksi) LEFT JOIN tbl_coa ON tbl_detailajp.NoAkun = tbl_coa.NoAkun WHERE(((tbl_detailajp.NoTransaksi) = '" & txtNoTransaksi.Text & "'))"
    '        Da = New OleDbDataAdapter(Query, CONN)
    '        Ds = New DataSet
    '        Da.Fill(Ds)

    '        ListView1.Items.Clear()
    '        For a = 0 To Ds.Tables(0).Rows.Count - 1
    '            With ListView1
    '                .Items.Add(Ds.Tables(0).Rows(a).Item(0))
    '                .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(1))
    '                .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(2))
    '                .Items(a).SubItems.Add(Ds.Tables(0).Rows(a).Item(3))
    '                .Items(a).SubItems.Add(Format(Ds.Tables(0).Rows(a).Item(4), "###,###"))
    '                .Items(a).SubItems.Add(Format(Ds.Tables(0).Rows(a).Item(5), "###,###"))
    '                If (a Mod 2 = 0) Then
    '                    .Items(a).BackColor = Color.LightSteelBlue
    '                Else
    '                    .Items(a).BackColor = Color.LightBlue
    '                End If
    '            End With
    '        Next
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub NoTransaksi()
        Try
            Dim mMemoriNo As String
            Dim mTempNoTransaksi As String

            mMemoriNo = Format(Microsoft.VisualBasic.Right(Now.Year, 2)) & Format(Now.Month, "00") & Format(Now.Day, "00")
            lblNoTransaksi.Text = "JP-" & mMemoriNo & "000"
            Query = "SELECT Count(tbl_jurnalajp.NoTransaksi) AS CountOfNoTransaksi FROM(tbl_jurnalajp) HAVING ((Mid([tbl_jurnalajp].[NoTransaksi],4,6)='" & mMemoriNo & "'))"

            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            If Ds.Tables(0).Rows.Count = 0 Then
                lblNoTransaksi.Text = "JP-" & mMemoriNo + "000" + Ds.Tables(0).Rows(0).Item(0) + 1
                mTempNoTransaksi = "JP-" & mMemoriNo + "000" + Ds.Tables(0).Rows(0).Item(0) + 1
            Else
                lblNoTransaksi.Text = "JP-" & mMemoriNo + "000" + Ds.Tables(0).Rows(0).Item(0) + 1
                mTempNoTransaksi = "JP-" & mMemoriNo + "000" + Ds.Tables(0).Rows(0).Item(0) + 1
            End If

            Query = "SELECT tbl_jurnalajp.NoTransaksi, Count(tbl_jurnalajp.NoTransaksi) AS Jumlah FROM tbl_jurnalajp GROUP BY tbl_jurnalajp.NoTransaksi HAVING (((tbl_jurnalajp.NoTransaksi)='" & lblNoTransaksi.Text & "'))"
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

    Private Sub HapusIsiGrid()
        Try
            'Menghapus isi data grid
            Query = "DELETE FROM tbl_detailajp WHERE NoTransaksi = '" & lblNoTransaksi.Text & "' AND NoAkun= '" & txtNoAkun.Text & "' AND DK = '" & mDK & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CariDataNoTransaksi()
        Try
            Query = "SELECT tbl_jurnalajp.Periode, tbl_jurnalajp.TglTransaksi, tbl_jurnalajp.NoTransaksi, tbl_jurnalajp.Keterangan, tbl_jurnalajp.Status FROM(tbl_jurnalajp) GROUP BY tbl_jurnalajp.Periode, tbl_jurnalajp.TglTransaksi, tbl_jurnalajp.NoTransaksi, tbl_jurnalajp.Keterangan, tbl_jurnalajp.Status HAVING(((tbl_jurnalajp.NoTransaksi) = '" & lblNoTransaksi.Text & "')) ORDER BY tbl_jurnalajp.Periode, tbl_jurnalajp.TglTransaksi, tbl_jurnalajp.NoTransaksi, tbl_jurnalajp.Keterangan, tbl_jurnalajp.Status"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            If Ds.Tables(0).Rows.Count - 1 Then
                BersihkanIsian()
                txtTgl.Focus()
                'IsiListGridDJurnal()
            Else
                lblPeriode.Text = Ds.Tables(0).Rows(0).Item(0)
                txtTgl.Text = Ds.Tables(0).Rows(0).Item(1)
                lblNoTransaksi.Text = Ds.Tables(0).Rows(0).Item(2)
                txtKeterangan.Text = Ds.Tables(0).Rows(0).Item(3)
                mPosted = Ds.Tables(0).Rows(0).Item(4)

                'IsiListGridDJurnal()
                'TotalDebetKredit()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PeriksaDataNoTransaksi()
        With objJurnalPenyesuaian
            Try
                Query = "SELECT tbl_jurnalajp.Periode, tbl_jurnalajp.TglTransaksi, tbl_jurnalajp.NoTransaksi, tbl_jurnalajp.Keterangan, tbl_jurnalajp.Status FROM(tbl_jurnalajp) GROUP BY tbl_jurnalajp.Periode, tbl_jurnalajp.TglTransaksi, tbl_jurnalajp.NoTransaksi, tbl_jurnalajp.Keterangan, tbl_jurnalajp.Status HAVING(((tbl_jurnalajp.NoTransaksi) = '" & lblNoTransaksi.Text & "')) ORDER BY tbl_jurnalajp.Periode, tbl_jurnalajp.TglTransaksi, tbl_jurnalajp.NoTransaksi, tbl_jurnalajp.Keterangan, tbl_jurnalajp.Status"
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
            Query = "SELECT NoTransaksi FROM tbl_jurnalajp WHERE NoTransaksi = '" & lblNoTransaksi.Text & "'"
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
                'IsiListGridDJurnal()
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

    Sub dgv()
        Dim band As DataGridViewBand = DataGridView1.Columns(4)
        band.Visible = False
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

    Private Sub FormAJP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            BukaKoneksi()
            KondisiAwal()
            'IsiListGridDJurnal()
            NoTransaksi()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs)
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

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Try
            If txtKeterangan.Text = "" Or txtNoAkun.Text = "" Or lblNamaAkun.Text = "" Or txtDebet.Text = "" Or txtKredit.Text = "" Then
                MsgBox("Data Tidak Lengkap, Silahkan lengkapi terlebih dahulu!", MsgBoxStyle.Information, "")
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
                mPosted = "UnPosted"
                btnSimpan.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSimpan_Click_1(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If lblDebet.Text = "" Or lblKredit.Text = "" Then
                MsgBox("Data Tidak Lengkap, Silahkan lengkapi terlebih dahulu!", MsgBoxStyle.Information, "")
            ElseIf lblDebet.Text <> lblKredit.Text Then
                MsgBox("Jumlah debet dan kredit tidak seimbang, silahkan periksa", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Pesan")
            Else
                Dim SimpanJurnal As String = "Insert into tbl_jurnalajp values ('" & lblNoTransaksi.Text & "', '" & lblPeriode.Text & "', '" & txtTgl.Text & "', '" & txtKeterangan.Text & "', '" & mPosted & "')"
                Command = New OleDbCommand(SimpanJurnal, CONN)
                Command.ExecuteNonQuery()

                For Baris As Integer = 0 To DataGridView1.Rows.Count - 2
                    Dim SimpanDetail As String = "Insert into tbl_detailajp values ('" & lblNoTransaksi.Text & "','" & DataGridView1.Rows(Baris).Cells(0).Value & "','" & DataGridView1.Rows(Baris).Cells(4).Value & "','" & DataGridView1.Rows(Baris).Cells(2).Value & "','" & DataGridView1.Rows(Baris).Cells(3).Value & "')"
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

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        KondisiAwal()
    End Sub

    Private Sub btnHapus_Click_1(sender As Object, e As EventArgs) Handles btnHapus.Click
        Dim A As String

        With objJurnalPenyesuaian
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
                            'hapus semua transaksi dengan no transksi yang sesuai dengan no.transaksi
                            A = MsgBox("Benar akan dihapus...", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Informasi")
                            Select Case A
                                Case vbCancel
                                    txtNoAkun.Focus()
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
                                    'IsiListGridDJurnal()
                                    txtTgl.Focus()
                                    NoTransaksi()
                                    'TotalDebetKredit()
                                    'btnEdit.Text = "&Edit"
                                    'btnTambah.Text = "&Tambah"
                                    txtNoAkun.Enabled = True
                                    btnSimpan.Enabled = True
                            End Select
                        Else
                            'untuk menghapus record jurnal AJP
                            A = MsgBox("Benar akan dihapus...", MsgBoxStyle.OkCancel, "Informasi")
                            Select Case A
                                Case vbCancel
                                    txtNoAkun.Focus()
                                    txtNoAkun.Enabled = True
                                    btnSimpan.Enabled = True
                                    Exit Sub
                                Case vbOK
                                    HapusIsiGrid()
                                    'IsiListGridDJurnal()
                                    BersihkanIsianGrid()
                                    txtNoAkun.Focus()
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

    Private Sub btnKeluar_Click_1(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        FormSubAJP.ShowDialog()
    End Sub
End Class