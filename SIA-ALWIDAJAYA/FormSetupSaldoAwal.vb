Imports System.Data.OleDb
Public Class FormSetupSaldoAwal

    Private mPeriode As String
    Private mTgl As Date
    Private mKodeAkun As String
    Private tempDK As String
    Private mDebet As Long
    Private mKredit As Long
    Public mDK As String

    Sub KondisiAwal()
        cbPeriode.Text = ""
        txtTgl.Text = ""
        txtNoAkun.Text = ""
        lblNamaAkun.Text = ""
        txtDebet.Text = ""
        txtKredit.Text = ""
        txtNoAkun.Focus()
        btnTambah.Enabled = True
        btnSimpan.Enabled = False
        btnHapus.Enabled = False
        btnEdit.Enabled = False
        btnKeluar.Enabled = True
        btnCetak.Enabled = True
        btnKeluar.Text = "Keluar"
        btnEdit.Text = "Edit"
        btnHapus.Text = "Hapus"
        Tutup()
    End Sub

    Sub Tutup()
        cbPeriode.Enabled = False
        txtTgl.Enabled = False
        txtNoAkun.Enabled = False
        lblNamaAkun.Enabled = False
        txtDebet.Enabled = False
        txtKredit.Enabled = False
    End Sub

    Sub Buka()
        cbPeriode.Enabled = True
        txtTgl.Enabled = True
        txtNoAkun.Enabled = True
        lblNamaAkun.Enabled = True
        txtDebet.Enabled = True
        txtKredit.Enabled = True
    End Sub

    Private Sub PosisiList()
        With ListView1.Columns
            .Add("Periode", 0)
            .Add("Tanggal", 0)
            .Add("Kode", 55)
            .Add("Nama Akun", 250)
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

            ListView1.Items.Clear()
            For a = 0 To Ds.Tables(0).Rows.Count - 1
                With ListView1
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
                'btnSimpan.Enabled = True
                'btnEdit.Enabled = True
                'btnHapus.Enabled = True
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
            With ListView1.SelectedItems
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

    Private Sub CariNoAkun()
        Try
            Query = "SELECT tbl_coa.NoAkun, tbl_coa.NamaAkun FROM(tbl_coa) WHERE (((tbl_coa.NoAkun)='" & txtNoAkun.Text & "'))"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            If Ds.Tables(0).Rows.Count - 1 Then
                MsgBox("No.Akun ini tidak ada", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Cari no akun")
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

    'Public Sub BersihkanIsian()
    '    cbPeriode.Enabled = True
    '    txtTgl.Enabled = True
    '    txtNoAkun.Enabled = True
    '    txtNoAkun.Text = ""
    '    lblNamaAkun.Text = ""
    '    mDK = ""
    '    txtDebet.Text = "0"
    '    txtKredit.Text = "0"
    'End Sub

    'Public Sub TambahData()
    '    'BersihkanIsian()
    '    Try
    '        Buka()
    '        btnKeluar.Text = "Batal"
    '        txtNoAkun.Focus()
    '        btnEdit.Enabled = False
    '        btnHapus.Enabled = False
    '        btnSimpan.Enabled = True
    '        btnCetak.Enabled = False
    '    Catch ex As Exception
    '    End Try
    'End Sub

    'Public Function SimpanData()
    '    Try
    '        mPeriode = cbPeriode.Text
    '        mTgl = txtTgl.Value
    '        mKodeAkun = txtNoAkun.Text
    '        tempDK = mDK
    '        mDebet = txtDebet.Text
    '        mKredit = txtKredit.Text

    '        If cbPeriode.Text = "" Or txtTgl.Text = "" Or txtNoAkun.Text = "" Or lblNamaAkun.Text = "" Or txtDebet.Text = "" Or txtKredit.Text = "" Then
    '            MsgBox("Pastikan Data diisi Lengkap!")
    '        Else
    '            BukaKoneksi()
    '            Dim SimpanData As String = "Insert into tbl_supplier values ('" & txtKodeSupp.Text & "','" & txtNamaSupp.Text & "','" & txtAlamatSupp.Text & "','" & txtTelepon.Text & "')"
    '            Command = New OleDbCommand(SimpanData, CONN)
    '            Command.ExecuteNonQuery()
    '            MsgBox("Data berhasil ditambahkan")
    '            KondisiAwal()
    '            'ElseIf Query = "INSERT INTO tbl_saldoblnlalu VALUES('" & mPeriode & "', '" & mTgl & "', '" & mKodeAkun & "', '" & tempDK & "', '" & mDebet & "','" & mKredit & "', '" & "UnPosted" & "', '" & "Saldo bulan lalu" & "')" Then
    '            '    Da = New OleDbDataAdapter(Query, CONN)
    '            '    Ds = New DataSet
    '            '    Da.Fill(Ds)
    '            '    MsgBox("Data berhasil diSimpan!")
    '            '    Return Query
    '        End If
    '    Catch ex As Exception
    '        Return Query
    '    End Try
    'End Function

    Public Function EditData()
        Try
            mKodeAkun = txtNoAkun.Text
            mDebet = txtDebet.Text
            mKredit = txtKredit.Text

            Query = "UPDATE tbl_saldoblnlalu SET  Debet = '" & mDebet & "', Kredit = '" & mKredit & "'  WHERE NoAkun = '" & mKodeAkun & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
            MsgBox("Data berhasil diUpdate!")
            Return Query
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function HapusData()
        Try
            mPeriode = cbPeriode.Text
            mKodeAkun = txtNoAkun.Text

            Query = "DELETE FROM tbl_saldoblnlalu WHERE NoAkun = '" & mKodeAkun & "' AND Periode = '" & mPeriode & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
            MsgBox("Data berhasil diHapus!")
            Return Query
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub FormSetupSaldoAwal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            KondisiAwal()
            PosisiList()
            IsiList()
            CekSetUp()
            Periode()
        Catch ex As Exception
            MsgBox("Koneksi ke database gagal")
        End Try
    End Sub

    Private Sub txtDebet_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDebet.KeyPress
        If e.KeyChar = Chr(13) Then
            txtKredit.Focus()
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then
            e.Handled = True
        End If
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
                    CariNoAkun()
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

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            mPeriode = cbPeriode.Text
            mTgl = txtTgl.Value
            mKodeAkun = txtNoAkun.Text
            tempDK = mDK
            mDebet = txtDebet.Text
            mKredit = txtKredit.Text

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
            If cbPeriode.Text = "" Or txtTgl.Text = "" Or txtNoAkun.Text = "" Or lblNamaAkun.Text = "" Or txtDebet.Text = "" Or txtKredit.Text = "" Then
                MsgBox("Pastikan Data diisi Lengkap!")
            Else
                BukaKoneksi()
                Dim SimpanData As String = "Insert into tbl_saldoblnlalu values ('" & mPeriode & "', '" & mTgl & "', '" & mKodeAkun & "', '" & tempDK & "', '" & mDebet & "','" & mKredit & "', '" & "UnPosted" & "', '" & "Saldo bulan lalu" & "')"
                Command = New OleDbCommand(SimpanData, CONN)
                Command.ExecuteNonQuery()
                MsgBox("Data berhasil ditambahkan")
                KondisiAwal()
                'SimpanData()
                IsiList()
                KondisiAwal()
                'BersihkanIsian()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        'BersihkanIsian()
        Try
            Buka()
            btnKeluar.Text = "Batal"
            txtNoAkun.Focus()
            btnEdit.Enabled = False
            btnHapus.Enabled = False
            btnSimpan.Enabled = True
            btnCetak.Enabled = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
                Try
            '    ElseIf Dim A As String

            '        A = MsgBox("Benar akan di-Edit", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Informasi")
            'Select A
            '            Case vbCancel
            '                'BersihkanIsian()
            '                txtNoAkun.Focus()
            '                Exit Sub
            '            Case vbOK
            Buka()
            If btnEdit.Text = "Edit" Then
                btnEdit.Text = "Update"
                btnTambah.Enabled = False
                btnSimpan.Enabled = False
                btnHapus.Enabled = False
                btnCetak.Enabled = False
                btnKeluar.Text = "Batal"
                txtNoAkun.Focus()
            Else
                EditData()
                IsiList()
                KondisiAwal()
                'End Select
            End If

        Catch ex As Exception
        End Try
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
                        HapusData()
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Perhatian")
        End Try
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click

    End Sub

    'Private Sub btnCetak_Click(sender As Object, e As EventArgs) Handles btnCetak.Click
    '    If Len(cbPeriode.Text) = 0 Then
    '        MsgBox("Pilih periode yang akan dicetak", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Pesan")
    '        cbPeriode.Focus()
    '    Else
    '        Try
    '            frmCetakMutasiSaldo.CrystalReportViewer1.SelectionFormula = "{tmpSaldoBlnLalu.Periode} = '" & cbPeriode.Text & "'"
    '            frmCetakMutasiSaldo.CrystalReportViewer1.Dock = DockStyle.Fill
    '            frmCetakMutasiSaldo.CrystalReportViewer1.RefreshReport()
    '            frmCetakMutasiSaldo.ShowDialog()
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        AmbilData()
    End Sub

    Private Sub ListView1_KeyUp(sender As Object, e As KeyEventArgs) Handles ListView1.KeyUp
        If e.KeyCode = Keys.Escape Then
            cbPeriode.Enabled = True
            txtTgl.Enabled = True
            txtNoAkun.Enabled = True
            'BersihkanIsian()
            cbPeriode.Focus()
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        AmbilData()
        cbPeriode.Enabled = False
        txtTgl.Enabled = False
        txtNoAkun.Enabled = False
    End Sub

    Private Sub txtTgl_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTgl.KeyPress
        If e.KeyChar = Chr(13) Then
            txtNoAkun.Focus()
        End If
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

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        If btnKeluar.Text = "Batal" Then
            KondisiAwal()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class