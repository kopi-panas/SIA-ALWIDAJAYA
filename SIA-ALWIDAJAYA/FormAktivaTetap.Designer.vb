<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAktivaTetap
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboAkumulasi = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblBebanPerbulan = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnHitung = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtNilaiBuku = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtBeban = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtAkumulasi = New System.Windows.Forms.TextBox()
        Me.tglTerhitung = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtNoSeri = New System.Windows.Forms.TextBox()
        Me.cboPenyusutan = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNilaiResidu = New System.Windows.Forms.TextBox()
        Me.tglPensiun = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtUmur = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHargaPerolehan = New System.Windows.Forms.TextBox()
        Me.tglPerolehan = New System.Windows.Forms.DateTimePicker()
        Me.cboKelompok = New System.Windows.Forms.ComboBox()
        Me.lblNama = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboAkumulasi)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Location = New System.Drawing.Point(21, 311)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(735, 95)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Kode Perkiraan:"
        '
        'cboAkumulasi
        '
        Me.cboAkumulasi.FormattingEnabled = True
        Me.cboAkumulasi.Location = New System.Drawing.Point(183, 42)
        Me.cboAkumulasi.Name = "cboAkumulasi"
        Me.cboAkumulasi.Size = New System.Drawing.Size(462, 21)
        Me.cboAkumulasi.TabIndex = 24
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(35, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(142, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Akumulasi Penyusutan :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblBebanPerbulan)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnHitung)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtNilaiBuku)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtBeban)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtAkumulasi)
        Me.GroupBox1.Controls.Add(Me.tglTerhitung)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtNoSeri)
        Me.GroupBox1.Controls.Add(Me.cboPenyusutan)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtNilaiResidu)
        Me.GroupBox1.Controls.Add(Me.tglPensiun)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtUmur)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtHargaPerolehan)
        Me.GroupBox1.Controls.Add(Me.tglPerolehan)
        Me.GroupBox1.Controls.Add(Me.cboKelompok)
        Me.GroupBox1.Controls.Add(Me.lblNama)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(735, 293)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'lblBebanPerbulan
        '
        Me.lblBebanPerbulan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBebanPerbulan.Location = New System.Drawing.Point(540, 210)
        Me.lblBebanPerbulan.Name = "lblBebanPerbulan"
        Me.lblBebanPerbulan.Size = New System.Drawing.Size(137, 21)
        Me.lblBebanPerbulan.TabIndex = 122
        Me.lblBebanPerbulan.Text = "0"
        Me.lblBebanPerbulan.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(183, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 121
        Me.Label5.Text = "bulan"
        '
        'btnHitung
        '
        Me.btnHitung.BackColor = System.Drawing.SystemColors.Control
        Me.btnHitung.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHitung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHitung.Location = New System.Drawing.Point(542, 244)
        Me.btnHitung.Name = "btnHitung"
        Me.btnHitung.Size = New System.Drawing.Size(137, 25)
        Me.btnHitung.TabIndex = 120
        Me.btnHitung.Text = "&Hitung Penyusutan"
        Me.btnHitung.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHitung.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(455, 190)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(69, 15)
        Me.Label18.TabIndex = 29
        Me.Label18.Text = "Nilai Buku :"
        '
        'txtNilaiBuku
        '
        Me.txtNilaiBuku.Location = New System.Drawing.Point(540, 187)
        Me.txtNilaiBuku.MaxLength = 15
        Me.txtNilaiBuku.Name = "txtNilaiBuku"
        Me.txtNilaiBuku.Size = New System.Drawing.Size(137, 20)
        Me.txtNilaiBuku.TabIndex = 28
        Me.txtNilaiBuku.Text = "0"
        Me.txtNilaiBuku.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(405, 160)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(125, 15)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "Beban Per Tahun Ini :"
        '
        'txtBeban
        '
        Me.txtBeban.Location = New System.Drawing.Point(540, 160)
        Me.txtBeban.MaxLength = 15
        Me.txtBeban.Name = "txtBeban"
        Me.txtBeban.Size = New System.Drawing.Size(137, 20)
        Me.txtBeban.TabIndex = 26
        Me.txtBeban.Text = "0"
        Me.txtBeban.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(421, 134)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(109, 15)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Akumulasi Beban :"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(427, 216)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(102, 15)
        Me.Label20.TabIndex = 30
        Me.Label20.Text = "Baban Perbulan :"
        '
        'txtAkumulasi
        '
        Me.txtAkumulasi.Location = New System.Drawing.Point(540, 133)
        Me.txtAkumulasi.MaxLength = 15
        Me.txtAkumulasi.Name = "txtAkumulasi"
        Me.txtAkumulasi.Size = New System.Drawing.Size(137, 20)
        Me.txtAkumulasi.TabIndex = 24
        Me.txtAkumulasi.Text = "0"
        Me.txtAkumulasi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tglTerhitung
        '
        Me.tglTerhitung.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tglTerhitung.Location = New System.Drawing.Point(540, 107)
        Me.tglTerhitung.Name = "tglTerhitung"
        Me.tglTerhitung.Size = New System.Drawing.Size(87, 20)
        Me.tglTerhitung.TabIndex = 23
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(416, 108)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(113, 15)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Terhitung Tanggal :"
        '
        'txtNoSeri
        '
        Me.txtNoSeri.Location = New System.Drawing.Point(540, 84)
        Me.txtNoSeri.MaxLength = 15
        Me.txtNoSeri.Name = "txtNoSeri"
        Me.txtNoSeri.Size = New System.Drawing.Size(137, 20)
        Me.txtNoSeri.TabIndex = 21
        '
        'cboPenyusutan
        '
        Me.cboPenyusutan.FormattingEnabled = True
        Me.cboPenyusutan.Items.AddRange(New Object() {"Garis Lurus", "Tanpa Penyusutan"})
        Me.cboPenyusutan.Location = New System.Drawing.Point(138, 222)
        Me.cboPenyusutan.Name = "cboPenyusutan"
        Me.cboPenyusutan.Size = New System.Drawing.Size(158, 21)
        Me.cboPenyusutan.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(51, 222)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 15)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Penyusutan :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(48, 196)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 15)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Nilai Residu :"
        '
        'txtNilaiResidu
        '
        Me.txtNilaiResidu.Location = New System.Drawing.Point(138, 196)
        Me.txtNilaiResidu.MaxLength = 15
        Me.txtNilaiResidu.Name = "txtNilaiResidu"
        Me.txtNilaiResidu.Size = New System.Drawing.Size(137, 20)
        Me.txtNilaiResidu.TabIndex = 17
        Me.txtNilaiResidu.Text = "0"
        Me.txtNilaiResidu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tglPensiun
        '
        Me.tglPensiun.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tglPensiun.Location = New System.Drawing.Point(138, 170)
        Me.tglPensiun.Name = "tglPensiun"
        Me.tglPensiun.Size = New System.Drawing.Size(87, 20)
        Me.tglPensiun.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(50, 169)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 15)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Tgl.Pensiun :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(26, 142)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 15)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Umur Ekonomis :"
        '
        'txtUmur
        '
        Me.txtUmur.Location = New System.Drawing.Point(138, 144)
        Me.txtUmur.MaxLength = 3
        Me.txtUmur.Name = "txtUmur"
        Me.txtUmur.Size = New System.Drawing.Size(38, 20)
        Me.txtUmur.TabIndex = 13
        Me.txtUmur.Text = "0"
        Me.txtUmur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Harga Perolehan :"
        '
        'txtHargaPerolehan
        '
        Me.txtHargaPerolehan.Location = New System.Drawing.Point(138, 118)
        Me.txtHargaPerolehan.MaxLength = 15
        Me.txtHargaPerolehan.Name = "txtHargaPerolehan"
        Me.txtHargaPerolehan.Size = New System.Drawing.Size(137, 20)
        Me.txtHargaPerolehan.TabIndex = 11
        Me.txtHargaPerolehan.Text = "0"
        Me.txtHargaPerolehan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tglPerolehan
        '
        Me.tglPerolehan.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tglPerolehan.Location = New System.Drawing.Point(138, 95)
        Me.tglPerolehan.Name = "tglPerolehan"
        Me.tglPerolehan.Size = New System.Drawing.Size(87, 20)
        Me.tglPerolehan.TabIndex = 10
        '
        'cboKelompok
        '
        Me.cboKelompok.FormattingEnabled = True
        Me.cboKelompok.Items.AddRange(New Object() {"A. Tanah", "B. Bangunan", "C. Kendaraan", "D. Peralatan", "E. Mebel"})
        Me.cboKelompok.Location = New System.Drawing.Point(138, 68)
        Me.cboKelompok.Name = "cboKelompok"
        Me.cboKelompok.Size = New System.Drawing.Size(158, 21)
        Me.cboKelompok.TabIndex = 9
        '
        'lblNama
        '
        Me.lblNama.BackColor = System.Drawing.Color.White
        Me.lblNama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNama.Location = New System.Drawing.Point(138, 44)
        Me.lblNama.Name = "lblNama"
        Me.lblNama.Size = New System.Drawing.Size(462, 21)
        Me.lblNama.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(38, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Tgl.Perolehan :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(468, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "No.Seri :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(59, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Kelompok :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(81, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Nama :"
        '
        'btnKeluar
        '
        Me.btnKeluar.Location = New System.Drawing.Point(279, 438)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(80, 28)
        Me.btnKeluar.TabIndex = 10
        Me.btnKeluar.Text = "&Keluar"
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'btnHapus
        '
        Me.btnHapus.Location = New System.Drawing.Point(193, 438)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(80, 28)
        Me.btnHapus.TabIndex = 9
        Me.btnHapus.Text = "&Hapus"
        Me.btnHapus.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(107, 438)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(80, 28)
        Me.btnEdit.TabIndex = 8
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Location = New System.Drawing.Point(21, 438)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(80, 28)
        Me.btnSimpan.TabIndex = 7
        Me.btnSimpan.Text = "&Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'FormAktivaTetap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 500)
        Me.Controls.Add(Me.btnKeluar)
        Me.Controls.Add(Me.btnHapus)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAktivaTetap"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aktiva Tetap"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboAkumulasi As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnHitung As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtNilaiBuku As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtBeban As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtAkumulasi As System.Windows.Forms.TextBox
    Friend WithEvents tglTerhitung As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtNoSeri As System.Windows.Forms.TextBox
    Friend WithEvents cboPenyusutan As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNilaiResidu As System.Windows.Forms.TextBox
    Friend WithEvents tglPensiun As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtUmur As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHargaPerolehan As System.Windows.Forms.TextBox
    Friend WithEvents tglPerolehan As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboKelompok As System.Windows.Forms.ComboBox
    Friend WithEvents lblNama As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblBebanPerbulan As System.Windows.Forms.Label
    Friend WithEvents btnKeluar As System.Windows.Forms.Button
    Friend WithEvents btnHapus As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnSimpan As System.Windows.Forms.Button
End Class
