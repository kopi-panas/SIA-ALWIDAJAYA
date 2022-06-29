Imports System.Data.OleDb
Public Class FormMenuJualBeli

    Private Sub btnBeli_Click(sender As Object, e As EventArgs) Handles btnBeli.Click
        panelTerima.Show()
    End Sub

    Private Sub btnJual_Click(sender As Object, e As EventArgs) Handles btnJual.Click
        panelTerima.Hide()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub

    Private Sub FormMenuJualBeli_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            btnBeli.Focus()
            txtKodeBrgJ.Focus()
            KondisiAwalT()
            KondisiAwalJ()
        Catch ex As Exception
        End Try
        btnBeli.Focus()
    End Sub

    Sub KondisiAwalT()
        lblTanggalT.Text = Today
        lblAdminT.Text = FormMenuUtama.txtName.Text
        lblNamaSupp.Text = ""
        lblAlamat.Text = ""
        lblTelepon.Text = ""
        NomorOtomatisT()
        BuatKolomT()
        cbSupplier.Text = ""
        lblTotal.Text = "0"
        lblItemT.Text = ""
        MunculKodeSupplier()
        PosisiGridT()
    End Sub

    Sub MunculKodeSupplier()
        Call BukaKoneksi()
        cbSupplier.Items.Clear()
        Command = New OleDbCommand("Select * from tbl_supplier", CONN)
        Rd = Command.ExecuteReader
        Do While Rd.Read
            cbSupplier.Items.Add(Rd.Item(0))
        Loop
    End Sub

    Sub NomorOtomatisT()
        Try
            Call BukaKoneksi()
            Command = New OleDbCommand("Select * from tbl_terima where NoTerima in (select max(NoTerima) from tbl_terima)", CONN)
            Dim UrutanKode As String
            Dim Hitung As Long
            Rd = Command.ExecuteReader
            Rd.Read()
            If Not Rd.HasRows Then
                UrutanKode = "T" + Format(Now, "yyMMdd") + "001"
            Else
                Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 9) + 1
                UrutanKode = "T" + Format(Now, "yyMMdd") + Microsoft.VisualBasic.Right("000" & Hitung, 3)
            End If
            lblNoTerima.Text = UrutanKode
        Catch ex As Exception
        End Try
    End Sub

    Sub BuatKolomT()
        DataGridViewT.Columns.Clear()
        DataGridViewT.Columns.Add("KodeBarang", "Kode")
        DataGridViewT.Columns.Add("NamaBarang", "Nama Barang")
        DataGridViewT.Columns.Add("HargaBarang", "Harga")
        DataGridViewT.Columns.Add("JmlBarangTerima", "Jumlah")
        DataGridViewT.Columns.Add("TotalTerima", "SubTotal")
    End Sub

    Public Sub PosisiGridT()
        Try
            DataGridViewT.Columns(0).Width = 99
            DataGridViewT.Columns(1).Width = 250
            DataGridViewT.Columns(2).Width = 160
            DataGridViewT.Columns(3).Width = 120
            DataGridViewT.Columns(4).Width = 120
        Catch ex As Exception
        End Try
    End Sub

    Sub RumusSubTotalT()
        Try
            Dim hitung As Integer = 0
            For i As Integer = 0 To DataGridViewT.Rows.Count - 1
                hitung = hitung + DataGridViewT.Rows(i).Cells(4).Value
                lblTotal.Text = hitung
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub RumusCariItemT()
        Try
            Dim HitungItem As Integer = 0
            For i As Integer = 0 To DataGridViewT.Rows.Count - 1
                HitungItem = HitungItem + DataGridViewT.Rows(i).Cells(3).Value
                lblItemT.Text = HitungItem
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtKodeT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKodeT.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Call BukaKoneksi()
                Command = New OleDbCommand("Select *  from tbl_barang where KodeBarang= '" & txtKodeT.Text & "'", CONN)
                Rd = Command.ExecuteReader
                Rd.Read()
                If Not Rd.HasRows Then
                    MsgBox("Kode barang Tidak Ada")
                Else
                    txtKodeT.Text = Rd.Item("KodeBarang")
                    lblNamaBrgT.Text = Rd.Item("NamaBarang")
                    lblHargaBrgT.Text = Rd.Item("HargaBarang")
                    txtJumlahBrgT.Enabled = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cbSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSupplier.SelectedIndexChanged
        Try
            BukaKoneksi()
            Command = New OleDbCommand("Select * from tbl_supplier where KodeSupplier ='" & cbSupplier.Text & "'", CONN)
            Rd = Command.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                lblNamaSupp.Text = Rd!NamaSupplier
                lblAlamat.Text = Rd!AlamatSupplier
                lblTelepon.Text = Rd!TeleponSupplier
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnInputT_Click(sender As Object, e As EventArgs) Handles btnInputT.Click
        Try
            If lblNamaBrgT.Text = "" Or txtJumlahBrgT.Text = "" Then
                MsgBox("Silahkan masukkan Kode Barang dan tekan ENTER!")
            Else
                DataGridViewT.Rows.Add(New String() {txtKodeT.Text, lblNamaBrgT.Text, lblHargaBrgT.Text, txtJumlahBrgT.Text, Val(lblHargaBrgT.Text) * Val(txtJumlahBrgT.Text)})
                Call RumusSubTotalT()
                txtKodeT.Text = ""
                lblNamaBrgT.Text = ""
                lblHargaBrgT.Text = ""
                txtJumlahBrgT.Text = ""
                txtJumlahBrgT.Enabled = False
                Call RumusCariItemT()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If lblNamaSupp.Text = "" Or lblTotal.Text = "" Then
                MsgBox("Transaksi Tidak Ada, silahkan lakukan transaksi terlebih dahulu")
            Else
                Dim SimpanTerima As String = "Insert into tbl_terima values ('" & lblNoTerima.Text & "','" & lblTanggalT.Text & "', '" & lblJamT.Text & "', '" & lblItemT.Text & "','" & lblTotal.Text & "','" & cbSupplier.Text & "','" & lblAdminT.Text & "') "
                Command = New OleDbCommand(SimpanTerima, CONN)
                Command.ExecuteNonQuery()

                For Baris As Integer = 0 To DataGridViewT.Rows.Count - 2
                    Dim SimpanDetail As String = "Insert into tbl_detailterima values ('" & lblNoTerima.Text & "','" & DataGridViewT.Rows(Baris).Cells(0).Value & "','" & DataGridViewT.Rows(Baris).Cells(1).Value & "','" & DataGridViewT.Rows(Baris).Cells(2).Value & "','" & DataGridViewT.Rows(Baris).Cells(3).Value & "','" & DataGridViewT.Rows(Baris).Cells(4).Value & "')"
                    Command = New OleDbCommand(SimpanDetail, CONN)
                    Command.ExecuteNonQuery()

                    Command = New OleDbCommand("select * from tbl_barang where KodeBarang= '" & DataGridViewT.Rows(Baris).Cells(0).Value & "'", CONN)
                    Rd = Command.ExecuteReader
                    Rd.Read()
                    Dim TambahStok As String = "Update tbl_barang set JumlahBarang = '" & Rd.Item("JumlahBarang") + DataGridViewT.Rows(Baris).Cells(3).Value & "' where KodeBarang= '" & DataGridViewT.Rows(Baris).Cells(0).Value & "'"
                    Command = New OleDbCommand(TambahStok, CONN)
                    Command.ExecuteNonQuery()
                Next
                Call KondisiAwalT()
                MsgBox("Transaksi Telah Berhasil di Simpan")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        KondisiAwalT()
    End Sub

    Dim Tgl As String

    Sub KondisiAwalJ()
        lblTanggalJ.Text = Today
        lblAdminJ.Text = FormMenuUtama.txtName.Text
        lblTotalJ.Text = "0"
        NomorOtomatisJ()
        BuatKolomJ()
        lblItemJ.Text = ""
        txtDibayar.Text = ""
        lblKembali.Text = ""
        txtKodeBrgJ.Focus()
        PosisiGridJ()
    End Sub

    Sub NomorOtomatisJ()
        Try
            BukaKoneksi()
            Command = New OleDbCommand("Select * from tbl_jual where NoJual in (select max(NoJual) from tbl_jual)", CONN)
            Dim UrutanKode As String
            Dim Hitung As Long
            Rd = Command.ExecuteReader
            Rd.Read()
            If Not Rd.HasRows Then
                UrutanKode = "J" + Format(Now, "yyMMdd") + "001"
            Else
                Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 9) + 1
                UrutanKode = "J" + Format(Now, "yyMMdd") + Microsoft.VisualBasic.Right("000" & Hitung, 3)
            End If
            lblNoJual.Text = UrutanKode
        Catch ex As Exception
        End Try
    End Sub

    Sub BuatKolomJ()
        DataGridViewJ.Columns.Clear()
        DataGridViewJ.Columns.Add("KodeBarang", "Kode Barang")
        DataGridViewJ.Columns.Add("NamaBarang", "Nama Barang")
        DataGridViewJ.Columns.Add("HargaBarang", "Harga")
        DataGridViewJ.Columns.Add("JmlBarangJual", "Jumlah")
        DataGridViewJ.Columns.Add("TotalJual", "SubTotal")
    End Sub

    Public Sub PosisiGridJ()
        Try
            DataGridViewJ.Columns(0).Width = 93
            DataGridViewJ.Columns(1).Width = 220
            DataGridViewJ.Columns(2).Width = 170
            DataGridViewJ.Columns(3).Width = 120
            DataGridViewJ.Columns(4).Width = 120
        Catch ex As Exception
        End Try
    End Sub

    Sub RumusSubTotalJ()
        Dim hitung As Integer = 0
        For i As Integer = 0 To DataGridViewJ.Rows.Count - 1
            hitung = hitung + DataGridViewJ.Rows(i).Cells(4).Value
            lblTotalJ.Text = hitung
        Next
    End Sub

    Sub RumusCariItemJ()
        Dim HitungItem As Integer = 0
        For i As Integer = 0 To DataGridViewJ.Rows.Count - 1
            HitungItem = HitungItem + DataGridViewJ.Rows(i).Cells(3).Value
            lblItemJ.Text = HitungItem
        Next
    End Sub

    Private Sub txtKodeBrgJ_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKodeBrgJ.KeyPress
        If e.KeyChar = Chr(13) Then
            BukaKoneksi()
            Command = New OleDbCommand("Select * from tbl_barang where KodeBarang= '" & txtKodeBrgJ.Text & "'", CONN)
            Rd = Command.ExecuteReader
            Rd.Read()
            If Not Rd.HasRows Then
                MsgBox("Kode barang Tidak Ada")
            Else
                txtKodeBrgJ.Text = Rd.Item("KodeBarang")
                lblNamaBrgJ.Text = Rd.Item("NamaBarang")
                lblHargaJ.Text = Rd.Item("HargaBarang")
                txtJumlahJ.Enabled = True
                txtJumlahJ.Focus()
            End If
        End If
    End Sub

    Private Sub btnInputJ_Click(sender As Object, e As EventArgs) Handles btnInputJ.Click
        Try
            If lblNamaBrgJ.Text = "" Or txtJumlahJ.Text = "" Then
                MsgBox("Silahkan masukkan Kode Barang dan tekan ENTER!")
            Else
                DataGridViewJ.Rows.Add(New String() {txtKodeBrgJ.Text, lblNamaBrgJ.Text, lblHargaJ.Text, txtJumlahJ.Text, Val(lblHargaJ.Text) * Val(txtJumlahJ.Text)})
                RumusSubTotalJ()
                txtKodeBrgJ.Text = ""
                lblNamaBrgJ.Text = ""
                lblHargaJ.Text = ""
                txtJumlahJ.Text = ""
                txtJumlahJ.Enabled = False
                RumusCariItemJ()
                txtDibayar.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtDibayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDibayar.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                If Val(txtDibayar.Text) < Val(lblTotal.Text) Then
                    MsgBox("Pembayaran Kurang!")
                ElseIf Val(txtDibayar.Text) = Val(lblTotal.Text) Then
                    lblKembali.Text = 0
                ElseIf Val(txtDibayar.Text) > Val(lblTotal.Text) Then
                    lblKembali.Text = Val(txtDibayar.Text) - Val(lblTotalJ.Text)
                    txtKodeBrgJ.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnBatalJ_Click(sender As Object, e As EventArgs) Handles btnBatalJ.Click
        KondisiAwalJ()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblJamJ.Text = TimeOfDay
        lblJamT.Text = TimeOfDay
    End Sub

    Private Sub btnSimpanJ_Click(sender As Object, e As EventArgs) Handles btnSimpanJ.Click
        Try
            If lblKembali.Text = "" Or lblTotal.Text = "" Then
                MsgBox("Transaksi Tidak Ada, Silahkan lakukan transaksi terlebih dahulu")
            Else
                Dim SimpanJual As String = "Insert into tbl_jual values ('" & lblNoJual.Text & "', '" & lblTanggalJ.Text & "', '" & lblJamJ.Text & "', '" & lblItemJ.Text & "', '" & lblTotalJ.Text & "' , '" & txtDibayar.Text & "', '" & lblKembali.Text & "', '" & lblAdminJ.Text & "')"
                Command = New OleDbCommand(SimpanJual, CONN)
                Command.ExecuteNonQuery()

                For Baris As Integer = 0 To DataGridViewJ.Rows.Count - 2
                    Dim SimpanDetail As String = "Insert into tbl_detailjual values ('" & lblNoJual.Text & "','" & DataGridViewJ.Rows(Baris).Cells(0).Value & "','" & DataGridViewJ.Rows(Baris).Cells(1).Value & "','" & DataGridViewJ.Rows(Baris).Cells(2).Value & "','" & DataGridViewJ.Rows(Baris).Cells(3).Value & "','" & DataGridViewJ.Rows(Baris).Cells(4).Value & "')"
                    Command = New OleDbCommand(SimpanDetail, CONN)
                    Command.ExecuteNonQuery()

                    Command = New OleDbCommand("select * from tbl_barang where KodeBarang= '" & DataGridViewJ.Rows(Baris).Cells(0).Value & "'", CONN)
                    Rd = Command.ExecuteReader
                    Rd.Read()
                    Dim KurangiStok As String = "Update tbl_barang set JumlahBarang = '" & Rd.Item("JumlahBarang") - DataGridViewJ.Rows(Baris).Cells(3).Value & "' where KodeBarang= '" & DataGridViewJ.Rows(Baris).Cells(0).Value & "'"
                    Command = New OleDbCommand(KurangiStok, CONN)
                    Command.ExecuteNonQuery()
                Next
                KondisiAwalJ()
                MsgBox("Transaksi Telah Berhasil di Simpan")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class