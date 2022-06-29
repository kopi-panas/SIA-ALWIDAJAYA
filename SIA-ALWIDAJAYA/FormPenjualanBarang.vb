Imports System.Data.OleDb
Public Class FormPenjualanBarang
    Dim Tgl As String

    Sub KondisiAwal()
        lblTanggal.Text = Today
        'lblJam.Text = Form1.STLabel4.Text
        lblTotal.Text = "0"
        NomorOtomatis()
        BuatKolom()
        lblItem.Text = ""
        txtDibayar.Text = ""
        lblKembali.Text = ""
    End Sub

    Sub NomorOtomatis()
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
        Dim hitung As Integer = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            hitung = hitung + DataGridView1.Rows(i).Cells(4).Value
            lblTotal.Text = hitung
        Next
    End Sub

    Sub RumusCariItem()
        Dim HitungItem As Integer = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            HitungItem = HitungItem + DataGridView1.Rows(i).Cells(3).Value
            lblItem.Text = HitungItem
        Next
    End Sub

    Private Sub FormPenjualanBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KondisiAwal()
        PosisiGrid()
    End Sub

    Private Sub txtKodeBrg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKodeBrg.KeyPress
        If e.KeyChar = Chr(13) Then
            BukaKoneksi()
            Command = New OleDbCommand("Select *  from tbl_barang where KodeBarang= '" & txtKodeBrg.Text & "'", CONN)
            Rd = Command.ExecuteReader
            Rd.Read()
            If Not Rd.HasRows Then
                MsgBox("Kode barang Tidak Ada")
            Else
                txtKodeBrg.Text = Rd.Item("KodeBarang")
                lblNamaBrg.Text = Rd.Item("NamaBarang")
                lblHarga.Text = Rd.Item("HargaBarang")
                txtJumlah.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
        If lblNamaBrg.Text = "" Or txtJumlah.Text = "" Then
            MsgBox("Silahkan masukkan Kode Barang dan tekan ENTER!")
        Else
            DataGridView1.Rows.Add(New String() {txtKodeBrg.Text, lblNamaBrg.Text, lblHarga.Text, txtJumlah.Text, Val(lblHarga.Text) * Val(txtJumlah.Text)})
            Call RumusSubTotal()
            txtKodeBrg.Text = ""
            lblNamaBrg.Text = ""
            lblHarga.Text = ""
            txtJumlah.Text = ""
            txtJumlah.Enabled = False
            RumusCariItem()
            txtDibayar.Focus()
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If lblKembali.Text = "" Or lblTotal.Text = "" Then
                MsgBox("Transaksi Tidak Ada, Silahkan lakukan transaksi terlebih dahulu")
            Else
                Dim SimpanJual As String = "Insert into tbl_jual values ('" & lblNoJual.Text & "', '" & lblTanggal.Text & "', '" & lblJam.Text & "', '" & lblItem.Text & "', '" & lblTotal.Text & "' , '" & txtDibayar.Text & "', '" & lblKembali.Text & "')"
                Command = New OleDbCommand(SimpanJual, CONN)
                Command.ExecuteNonQuery()

                For Baris As Integer = 0 To DataGridView1.Rows.Count - 2
                    Dim SimpanDetail As String = "Insert into tbl_detailjual values ('" & lblNoJual.Text & "','" & DataGridView1.Rows(Baris).Cells(0).Value & "','" & DataGridView1.Rows(Baris).Cells(1).Value & "','" & DataGridView1.Rows(Baris).Cells(2).Value & "','" & DataGridView1.Rows(Baris).Cells(3).Value & "','" & DataGridView1.Rows(Baris).Cells(4).Value & "')"
                    Command = New OleDbCommand(SimpanDetail, CONN)
                    Command.ExecuteNonQuery()

                    Command = New OleDbCommand("select * from tbl_barang where KodeBarang= '" & DataGridView1.Rows(Baris).Cells(0).Value & "'", CONN)
                    Rd = Command.ExecuteReader
                    Rd.Read()
                    Dim KurangiStok As String = "Update tbl_barang set JumlahBarang = '" & Rd.Item("JumlahBarang") - DataGridView1.Rows(Baris).Cells(3).Value & "' where KodeBarang= '" & DataGridView1.Rows(Baris).Cells(0).Value & "'"
                    Command = New OleDbCommand(KurangiStok, CONN)
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

    Private Sub txtDibayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDibayar.KeyPress
        If e.KeyChar = Chr(13) Then
            If Val(txtDibayar.Text) < Val(lblTotal.Text) Then
                MsgBox("Pembayaran Kurang!")
            ElseIf Val(txtDibayar.Text) = Val(lblTotal.Text) Then
                lblKembali.Text = 0
            ElseIf Val(txtDibayar.Text) > Val(lblTotal.Text) Then
                lblKembali.Text = Val(txtDibayar.Text) - Val(lblItem.Text)
                btnSimpan.Focus()
            End If
        End If
    End Sub

    Private Sub txtKodeBrg_TextChanged(sender As Object, e As EventArgs) Handles txtKodeBrg.TextChanged

    End Sub
End Class