<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormJurnalUmum
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblNoTransaksi = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblPeriode = New System.Windows.Forms.Label()
        Me.txtTgl = New System.Windows.Forms.DateTimePicker()
        Me.txtKeterangan = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNoAkun = New System.Windows.Forms.TextBox()
        Me.lblNamaAkun = New System.Windows.Forms.Label()
        Me.txtDebet = New System.Windows.Forms.TextBox()
        Me.txtKredit = New System.Windows.Forms.TextBox()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.btnTambah = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.lblDebet = New System.Windows.Forms.Label()
        Me.lblKredit = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblNoTransaksi)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.lblPeriode)
        Me.GroupBox1.Controls.Add(Me.txtTgl)
        Me.GroupBox1.Controls.Add(Me.txtKeterangan)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(850, 140)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lblNoTransaksi
        '
        Me.lblNoTransaksi.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblNoTransaksi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNoTransaksi.Location = New System.Drawing.Point(149, 31)
        Me.lblNoTransaksi.Name = "lblNoTransaksi"
        Me.lblNoTransaksi.Size = New System.Drawing.Size(120, 20)
        Me.lblNoTransaksi.TabIndex = 16
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(274, 31)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(24, 20)
        Me.btnSearch.TabIndex = 15
        Me.btnSearch.Text = "Button1"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblPeriode
        '
        Me.lblPeriode.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblPeriode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPeriode.Location = New System.Drawing.Point(693, 31)
        Me.lblPeriode.Name = "lblPeriode"
        Me.lblPeriode.Size = New System.Drawing.Size(69, 20)
        Me.lblPeriode.TabIndex = 14
        '
        'txtTgl
        '
        Me.txtTgl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtTgl.Location = New System.Drawing.Point(149, 60)
        Me.txtTgl.Name = "txtTgl"
        Me.txtTgl.Size = New System.Drawing.Size(117, 20)
        Me.txtTgl.TabIndex = 13
        '
        'txtKeterangan
        '
        Me.txtKeterangan.Location = New System.Drawing.Point(149, 90)
        Me.txtKeterangan.Name = "txtKeterangan"
        Me.txtKeterangan.Size = New System.Drawing.Size(544, 20)
        Me.txtKeterangan.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(635, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Periode:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(70, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Keterangan:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(36, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Tanggal Transaksi:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(60, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "No. Transaksi:"
        '
        'txtNoAkun
        '
        Me.txtNoAkun.Location = New System.Drawing.Point(75, 163)
        Me.txtNoAkun.Name = "txtNoAkun"
        Me.txtNoAkun.Size = New System.Drawing.Size(88, 20)
        Me.txtNoAkun.TabIndex = 15
        '
        'lblNamaAkun
        '
        Me.lblNamaAkun.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.lblNamaAkun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNamaAkun.Location = New System.Drawing.Point(161, 163)
        Me.lblNamaAkun.Name = "lblNamaAkun"
        Me.lblNamaAkun.Size = New System.Drawing.Size(307, 20)
        Me.lblNamaAkun.TabIndex = 15
        '
        'txtDebet
        '
        Me.txtDebet.Location = New System.Drawing.Point(474, 163)
        Me.txtDebet.Name = "txtDebet"
        Me.txtDebet.Size = New System.Drawing.Size(116, 20)
        Me.txtDebet.TabIndex = 16
        '
        'txtKredit
        '
        Me.txtKredit.Location = New System.Drawing.Point(591, 163)
        Me.txtKredit.Name = "txtKredit"
        Me.txtKredit.Size = New System.Drawing.Size(114, 20)
        Me.txtKredit.TabIndex = 17
        '
        'btnKeluar
        '
        Me.btnKeluar.Location = New System.Drawing.Point(356, 496)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(80, 28)
        Me.btnKeluar.TabIndex = 22
        Me.btnKeluar.Text = "&Keluar"
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'btnHapus
        '
        Me.btnHapus.Location = New System.Drawing.Point(184, 496)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(80, 28)
        Me.btnHapus.TabIndex = 21
        Me.btnHapus.Text = "&Hapus"
        Me.btnHapus.UseVisualStyleBackColor = True
        '
        'btnTambah
        '
        Me.btnTambah.Location = New System.Drawing.Point(711, 158)
        Me.btnTambah.Name = "btnTambah"
        Me.btnTambah.Size = New System.Drawing.Size(80, 28)
        Me.btnTambah.TabIndex = 18
        Me.btnTambah.Text = "&Tambah"
        Me.btnTambah.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Location = New System.Drawing.Point(12, 496)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(80, 28)
        Me.btnSimpan.TabIndex = 19
        Me.btnSimpan.Text = "&Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'btnBatal
        '
        Me.btnBatal.Location = New System.Drawing.Point(98, 496)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(80, 28)
        Me.btnBatal.TabIndex = 20
        Me.btnBatal.Text = "&Batal"
        Me.btnBatal.UseVisualStyleBackColor = True
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(270, 496)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(80, 28)
        Me.btnPreview.TabIndex = 23
        Me.btnPreview.Text = "&Preview"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(75, 385)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(716, 56)
        Me.ListView1.TabIndex = 24
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'lblDebet
        '
        Me.lblDebet.BackColor = System.Drawing.Color.White
        Me.lblDebet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDebet.Location = New System.Drawing.Point(580, 444)
        Me.lblDebet.Name = "lblDebet"
        Me.lblDebet.Size = New System.Drawing.Size(106, 24)
        Me.lblDebet.TabIndex = 26
        '
        'lblKredit
        '
        Me.lblKredit.BackColor = System.Drawing.Color.White
        Me.lblKredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblKredit.Location = New System.Drawing.Point(685, 444)
        Me.lblKredit.Name = "lblKredit"
        Me.lblKredit.Size = New System.Drawing.Size(106, 24)
        Me.lblKredit.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(540, 452)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 16)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Total"
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(75, 197)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(715, 175)
        Me.DataGridView1.TabIndex = 28
        '
        'FormJurnalUmum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 536)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblKredit)
        Me.Controls.Add(Me.lblDebet)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.btnKeluar)
        Me.Controls.Add(Me.btnHapus)
        Me.Controls.Add(Me.btnTambah)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.btnBatal)
        Me.Controls.Add(Me.txtKredit)
        Me.Controls.Add(Me.txtDebet)
        Me.Controls.Add(Me.lblNamaAkun)
        Me.Controls.Add(Me.txtNoAkun)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormJurnalUmum"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPeriode As System.Windows.Forms.Label
    Friend WithEvents txtTgl As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtKeterangan As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNoAkun As System.Windows.Forms.TextBox
    Friend WithEvents lblNamaAkun As System.Windows.Forms.Label
    Friend WithEvents txtDebet As System.Windows.Forms.TextBox
    Friend WithEvents txtKredit As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnKeluar As System.Windows.Forms.Button
    Friend WithEvents btnHapus As System.Windows.Forms.Button
    Friend WithEvents btnTambah As System.Windows.Forms.Button
    Friend WithEvents btnSimpan As System.Windows.Forms.Button
    Friend WithEvents btnBatal As System.Windows.Forms.Button
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents lblDebet As System.Windows.Forms.Label
    Friend WithEvents lblKredit As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents lblNoTransaksi As System.Windows.Forms.Label
End Class
