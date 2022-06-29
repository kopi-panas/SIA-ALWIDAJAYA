<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPenjualanBarang
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
        Me.lblItem = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblKembali = New System.Windows.Forms.Label()
        Me.txtDibayar = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.btnTutup = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnInput = New System.Windows.Forms.Button()
        Me.txtJumlah = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblHarga = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblNamaBrg = New System.Windows.Forms.Label()
        Me.txtKodeBrg = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblAdmin = New System.Windows.Forms.Label()
        Me.lblJam = New System.Windows.Forms.Label()
        Me.lblTanggal = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblNoJual = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblItem
        '
        Me.lblItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblItem.Location = New System.Drawing.Point(461, 400)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(77, 23)
        Me.lblItem.TabIndex = 99
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(424, 407)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 16)
        Me.Label4.TabIndex = 98
        Me.Label4.Text = "Item"
        '
        'lblKembali
        '
        Me.lblKembali.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblKembali.Location = New System.Drawing.Point(597, 423)
        Me.lblKembali.Name = "lblKembali"
        Me.lblKembali.Size = New System.Drawing.Size(117, 22)
        Me.lblKembali.TabIndex = 97
        '
        'txtDibayar
        '
        Me.txtDibayar.Location = New System.Drawing.Point(597, 400)
        Me.txtDibayar.Name = "txtDibayar"
        Me.txtDibayar.Size = New System.Drawing.Size(117, 20)
        Me.txtDibayar.TabIndex = 96
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(544, 423)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 95
        Me.Label2.Text = "Kembali"
        '
        'btnBatal
        '
        Me.btnBatal.Location = New System.Drawing.Point(117, 400)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(73, 30)
        Me.btnBatal.TabIndex = 94
        Me.btnBatal.Text = "BATAL"
        Me.btnBatal.UseVisualStyleBackColor = True
        '
        'btnTutup
        '
        Me.btnTutup.Location = New System.Drawing.Point(196, 400)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New System.Drawing.Size(73, 30)
        Me.btnTutup.TabIndex = 93
        Me.btnTutup.Text = "TUTUP"
        Me.btnTutup.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Location = New System.Drawing.Point(38, 400)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(73, 30)
        Me.btnSimpan.TabIndex = 92
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(544, 400)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(48, 16)
        Me.Label24.TabIndex = 91
        Me.Label24.Text = "Dibayar"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(34, 170)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(680, 222)
        Me.DataGridView1.TabIndex = 90
        '
        'btnInput
        '
        Me.btnInput.Location = New System.Drawing.Point(642, 139)
        Me.btnInput.Name = "btnInput"
        Me.btnInput.Size = New System.Drawing.Size(58, 25)
        Me.btnInput.TabIndex = 89
        Me.btnInput.Text = "Insert"
        Me.btnInput.UseVisualStyleBackColor = True
        '
        'txtJumlah
        '
        Me.txtJumlah.Location = New System.Drawing.Point(581, 144)
        Me.txtJumlah.Name = "txtJumlah"
        Me.txtJumlah.Size = New System.Drawing.Size(55, 20)
        Me.txtJumlah.TabIndex = 88
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(530, 148)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(46, 16)
        Me.Label23.TabIndex = 87
        Me.Label23.Text = "Jumlah"
        '
        'lblHarga
        '
        Me.lblHarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHarga.Location = New System.Drawing.Point(417, 144)
        Me.lblHarga.Name = "lblHarga"
        Me.lblHarga.Size = New System.Drawing.Size(107, 20)
        Me.lblHarga.TabIndex = 86
        Me.lblHarga.Text = "Harga"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(372, 148)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(39, 16)
        Me.Label21.TabIndex = 85
        Me.Label21.Text = "Harga"
        '
        'lblNamaBrg
        '
        Me.lblNamaBrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNamaBrg.Location = New System.Drawing.Point(205, 144)
        Me.lblNamaBrg.Name = "lblNamaBrg"
        Me.lblNamaBrg.Size = New System.Drawing.Size(154, 20)
        Me.lblNamaBrg.TabIndex = 84
        Me.lblNamaBrg.Text = "Nama"
        '
        'txtKodeBrg
        '
        Me.txtKodeBrg.Location = New System.Drawing.Point(87, 147)
        Me.txtKodeBrg.Name = "txtKodeBrg"
        Me.txtKodeBrg.Size = New System.Drawing.Size(69, 20)
        Me.txtKodeBrg.TabIndex = 83
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(162, 148)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(37, 16)
        Me.Label19.TabIndex = 82
        Me.Label19.Text = "Nama"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(45, 148)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(36, 16)
        Me.Label18.TabIndex = 81
        Me.Label18.Text = "Kode"
        '
        'lblAdmin
        '
        Me.lblAdmin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAdmin.Location = New System.Drawing.Point(59, 55)
        Me.lblAdmin.Name = "lblAdmin"
        Me.lblAdmin.Size = New System.Drawing.Size(109, 23)
        Me.lblAdmin.TabIndex = 80
        Me.lblAdmin.Text = "lblAdmin"
        '
        'lblJam
        '
        Me.lblJam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblJam.Location = New System.Drawing.Point(59, 32)
        Me.lblJam.Name = "lblJam"
        Me.lblJam.Size = New System.Drawing.Size(109, 23)
        Me.lblJam.TabIndex = 79
        Me.lblJam.Text = "lblJam"
        '
        'lblTanggal
        '
        Me.lblTanggal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTanggal.Location = New System.Drawing.Point(59, 9)
        Me.lblTanggal.Name = "lblTanggal"
        Me.lblTanggal.Size = New System.Drawing.Size(109, 23)
        Me.lblTanggal.TabIndex = 78
        Me.lblTanggal.Text = "lblTanggal"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 62)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 16)
        Me.Label14.TabIndex = 77
        Me.Label14.Text = "Admin"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(24, 39)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 16)
        Me.Label13.TabIndex = 76
        Me.Label13.Text = "Jam"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 16)
        Me.Label12.TabIndex = 75
        Me.Label12.Text = "Tanggal"
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(466, 24)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(239, 58)
        Me.lblTotal.TabIndex = 74
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(335, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(125, 35)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "TOTAL: Rp"
        '
        'lblNoJual
        '
        Me.lblNoJual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNoJual.Location = New System.Drawing.Point(87, 116)
        Me.lblNoJual.Name = "lblNoJual"
        Me.lblNoJual.Size = New System.Drawing.Size(98, 23)
        Me.lblNoJual.TabIndex = 72
        Me.lblNoJual.Text = "lblNoJual"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 16)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Nomor Jual"
        '
        'FormPenjualanBarang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 480)
        Me.Controls.Add(Me.lblItem)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblKembali)
        Me.Controls.Add(Me.txtDibayar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnBatal)
        Me.Controls.Add(Me.btnTutup)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnInput)
        Me.Controls.Add(Me.txtJumlah)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.lblHarga)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.lblNamaBrg)
        Me.Controls.Add(Me.txtKodeBrg)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lblAdmin)
        Me.Controls.Add(Me.lblJam)
        Me.Controls.Add(Me.lblTanggal)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblNoJual)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPenjualanBarang"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Penjualan Barang"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblKembali As System.Windows.Forms.Label
    Friend WithEvents txtDibayar As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBatal As System.Windows.Forms.Button
    Friend WithEvents btnTutup As System.Windows.Forms.Button
    Friend WithEvents btnSimpan As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnInput As System.Windows.Forms.Button
    Friend WithEvents txtJumlah As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblHarga As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblNamaBrg As System.Windows.Forms.Label
    Friend WithEvents txtKodeBrg As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblAdmin As System.Windows.Forms.Label
    Friend WithEvents lblJam As System.Windows.Forms.Label
    Friend WithEvents lblTanggal As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblNoJual As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
