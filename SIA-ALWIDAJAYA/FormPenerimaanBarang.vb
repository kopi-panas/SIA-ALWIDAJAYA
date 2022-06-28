Imports System.Data.OleDb
Public Class FormPenerimaanBarang
    Sub KondisiAwal()
        lblTanggal.Text = Today
        'lblAdmin.Text = Form1.STLabel4.Text
        lblNamaSupp.Text = ""
        lblAlamat.Text = ""
        lblTelepon.Text = ""
        Call NomorOtomatis()
        Call BuatKolom()
        cbSupplier.Text = ""
        lblTotal.Text = "0"
        lblItem.Text = ""
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

    Sub NomorOtomatis()
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

    Sub BuatKolom()
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add("Kode", "Kode")
        DataGridView1.Columns.Add("Nama", "Nama Barang")
        DataGridView1.Columns.Add("Harga", "Harga")
        DataGridView1.Columns.Add("Jumlah", "Jumlah")
        DataGridView1.Columns.Add("Subtotal", "SubTotal")
    End Sub

    Public Sub PosisiGrid()
        Try
            DataGridView1.Columns(0).Width = 70
            DataGridView1.Columns(1).Width = 200
            DataGridView1.Columns(2).Width = 150
            DataGridView1.Columns(3).Width = 100
            DataGridView1.Columns(4).Width = 100
        Catch ex As Exception
        End Try
    End Sub

    Sub RumusSubTotal()
        Try
            Dim hitung As Integer = 0
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                hitung = hitung + DataGridView1.Rows(i).Cells(4).Value
                lblTotal.Text = hitung
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub RumusCariItem()
        Try
            Dim HitungItem As Integer = 0
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                HitungItem = HitungItem + DataGridView1.Rows(i).Cells(3).Value
                lblItem.Text = HitungItem
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormPenerimaanBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            MunculKodeSupplier()
            KondisiAwal()
            PosisiGrid()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtKode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKode.KeyPress
        If e.KeyChar = Chr(13) Then
            Call BukaKoneksi()
            Command = New OleDbCommand("Select *  from tbl_barang where KodeBarang= '" & txtKode.Text & "'", CONN)
            Rd = Command.ExecuteReader
            Rd.Read()
            If Not Rd.HasRows Then
                MsgBox("Kode barang Tidak Ada")
            Else
                txtKode.Text = Rd.Item("KodeBarang")
                lblNamaBrg.Text = Rd.Item("NamaBarang")
                lblHargaBrg.Text = Rd.Item("HargaBarang")
                txtJumlahBrg.Enabled = True
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSupplier.SelectedIndexChanged
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

    Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
        Try
            If lblNamaBrg.Text = "" Or txtJumlahBrg.Text = "" Then
                MsgBox("Silahkan masukkan Kode Barang dan tekan ENTER!")
            Else
                DataGridView1.Rows.Add(New String() {txtKode.Text, lblNamaBrg.Text, lblHargaBrg.Text, txtJumlahBrg.Text, Val(lblHargaBrg.Text) * Val(txtJumlahBrg.Text)})
                Call RumusSubTotal()
                txtKode.Text = ""
                lblNamaBrg.Text = ""
                lblHargaBrg.Text = ""
                txtJumlahBrg.Text = ""
                txtJumlahBrg.Enabled = False
                Call RumusCariItem()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If lblNamaSupp.Text = "" Or lblTotal.Text = "" Then
                MsgBox("Transaksi Tidak Ada, silahkan lakukan transaksi terlebih dahulu")
            Else
                Dim SimpanTerima As String = "Insert into tbl_terima values ('" & lblNoTerima.Text & "','" & lblTanggal.Text & "', '" & lblJam.Text & "', '" & lblItem.Text & "','" & lblTotal.Text & "','" & cbSupplier.Text & "') "
                Command = New OleDbCommand(SimpanTerima, CONN)
                Command.ExecuteNonQuery()

                For Baris As Integer = 0 To DataGridView1.Rows.Count - 2
                    Dim SimpanDetail As String = "Insert into tbl_detailterima values ('" & lblNoTerima.Text & "','" & DataGridView1.Rows(Baris).Cells(0).Value & "','" & DataGridView1.Rows(Baris).Cells(1).Value & "','" & DataGridView1.Rows(Baris).Cells(2).Value & "','" & DataGridView1.Rows(Baris).Cells(3).Value & "','" & DataGridView1.Rows(Baris).Cells(4).Value & "')"
                    Command = New OleDbCommand(SimpanDetail, CONN)
                    Command.ExecuteNonQuery()

                    Command = New OleDbCommand("select * from tbl_barang where KodeBarang= '" & DataGridView1.Rows(Baris).Cells(0).Value & "'", CONN)
                    Rd = Command.ExecuteReader
                    Rd.Read()
                    Dim TambahStok As String = "Update tbl_barang set JumlahBarang = '" & Rd.Item("JumlahBarang") + DataGridView1.Rows(Baris).Cells(3).Value & "' where KodeBarang= '" & DataGridView1.Rows(Baris).Cells(0).Value & "'"
                    Command = New OleDbCommand(TambahStok, CONN)
                    Command.ExecuteNonQuery()
                Next
                Call KondisiAwal()
                MsgBox("Transaksi Telah Berhasil di Simpan")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub
End Class