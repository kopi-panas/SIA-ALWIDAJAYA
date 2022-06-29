<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMenuUtama
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMenuUtama))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeluarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetUpSaldoAwalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnPeriode = New System.Windows.Forms.Button()
        Me.btnCoA = New System.Windows.Forms.Button()
        Me.btnPengguna = New System.Windows.Forms.Button()
        Me.btnSupplier = New System.Windows.Forms.Button()
        Me.btnBarang = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnAJP = New System.Windows.Forms.Button()
        Me.btnJurnalUmum = New System.Windows.Forms.Button()
        Me.btnJualBeli = New System.Windows.Forms.Button()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.btnProses = New System.Windows.Forms.Button()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.btnLapNeraca = New System.Windows.Forms.Button()
        Me.btnLapAkun = New System.Windows.Forms.Button()
        Me.btnLapJU = New System.Windows.Forms.Button()
        Me.btnLapPM = New System.Windows.Forms.Button()
        Me.btnLapAJP = New System.Windows.Forms.Button()
        Me.btnLapNL = New System.Windows.Forms.Button()
        Me.btnLapRL = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtName = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 142)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1370, 28)
        Me.Panel1.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SetupToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1370, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogoutToolStripMenuItem, Me.KeluarToolStripMenuItem})
        Me.FileToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Image = CType(resources.GetObject("LogoutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'KeluarToolStripMenuItem
        '
        Me.KeluarToolStripMenuItem.Image = CType(resources.GetObject("KeluarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.KeluarToolStripMenuItem.Name = "KeluarToolStripMenuItem"
        Me.KeluarToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.KeluarToolStripMenuItem.Text = "Keluar"
        '
        'SetupToolStripMenuItem
        '
        Me.SetupToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetUpSaldoAwalToolStripMenuItem})
        Me.SetupToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SetupToolStripMenuItem.Name = "SetupToolStripMenuItem"
        Me.SetupToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.SetupToolStripMenuItem.Text = "Setup"
        '
        'SetUpSaldoAwalToolStripMenuItem
        '
        Me.SetUpSaldoAwalToolStripMenuItem.Image = CType(resources.GetObject("SetUpSaldoAwalToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SetUpSaldoAwalToolStripMenuItem.Name = "SetUpSaldoAwalToolStripMenuItem"
        Me.SetUpSaldoAwalToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.SetUpSaldoAwalToolStripMenuItem.Text = "Set Up Saldo Awal"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnPeriode)
        Me.GroupBox2.Controls.Add(Me.btnCoA)
        Me.GroupBox2.Controls.Add(Me.btnPengguna)
        Me.GroupBox2.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(26, 196)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(339, 140)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Master"
        '
        'btnPeriode
        '
        Me.btnPeriode.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnPeriode.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.btnPeriode.FlatAppearance.BorderSize = 0
        Me.btnPeriode.Font = New System.Drawing.Font("Leelawadee UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPeriode.Image = CType(resources.GetObject("btnPeriode.Image"), System.Drawing.Image)
        Me.btnPeriode.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPeriode.Location = New System.Drawing.Point(222, 34)
        Me.btnPeriode.Name = "btnPeriode"
        Me.btnPeriode.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.btnPeriode.Size = New System.Drawing.Size(95, 85)
        Me.btnPeriode.TabIndex = 2
        Me.btnPeriode.Text = "Periode"
        Me.btnPeriode.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPeriode.UseVisualStyleBackColor = False
        '
        'btnCoA
        '
        Me.btnCoA.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnCoA.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.btnCoA.FlatAppearance.BorderSize = 0
        Me.btnCoA.Font = New System.Drawing.Font("Leelawadee UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCoA.Image = CType(resources.GetObject("btnCoA.Image"), System.Drawing.Image)
        Me.btnCoA.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCoA.Location = New System.Drawing.Point(121, 34)
        Me.btnCoA.Name = "btnCoA"
        Me.btnCoA.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.btnCoA.Size = New System.Drawing.Size(95, 85)
        Me.btnCoA.TabIndex = 1
        Me.btnCoA.Text = "Akun"
        Me.btnCoA.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCoA.UseVisualStyleBackColor = False
        '
        'btnPengguna
        '
        Me.btnPengguna.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnPengguna.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.btnPengguna.FlatAppearance.BorderSize = 0
        Me.btnPengguna.Font = New System.Drawing.Font("Leelawadee UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPengguna.Image = CType(resources.GetObject("btnPengguna.Image"), System.Drawing.Image)
        Me.btnPengguna.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPengguna.Location = New System.Drawing.Point(20, 34)
        Me.btnPengguna.Name = "btnPengguna"
        Me.btnPengguna.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.btnPengguna.Size = New System.Drawing.Size(95, 85)
        Me.btnPengguna.TabIndex = 0
        Me.btnPengguna.Text = "Pengguna"
        Me.btnPengguna.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPengguna.UseVisualStyleBackColor = False
        '
        'btnSupplier
        '
        Me.btnSupplier.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnSupplier.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.btnSupplier.FlatAppearance.BorderSize = 0
        Me.btnSupplier.Font = New System.Drawing.Font("Leelawadee UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupplier.Image = CType(resources.GetObject("btnSupplier.Image"), System.Drawing.Image)
        Me.btnSupplier.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSupplier.Location = New System.Drawing.Point(121, 44)
        Me.btnSupplier.Name = "btnSupplier"
        Me.btnSupplier.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.btnSupplier.Size = New System.Drawing.Size(95, 85)
        Me.btnSupplier.TabIndex = 4
        Me.btnSupplier.Text = "Pemasok"
        Me.btnSupplier.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSupplier.UseVisualStyleBackColor = False
        '
        'btnBarang
        '
        Me.btnBarang.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnBarang.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.btnBarang.FlatAppearance.BorderSize = 0
        Me.btnBarang.Font = New System.Drawing.Font("Leelawadee UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBarang.Image = CType(resources.GetObject("btnBarang.Image"), System.Drawing.Image)
        Me.btnBarang.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBarang.Location = New System.Drawing.Point(20, 44)
        Me.btnBarang.Name = "btnBarang"
        Me.btnBarang.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.btnBarang.Size = New System.Drawing.Size(95, 85)
        Me.btnBarang.TabIndex = 3
        Me.btnBarang.Text = "Barang"
        Me.btnBarang.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBarang.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnAJP)
        Me.GroupBox5.Controls.Add(Me.btnJurnalUmum)
        Me.GroupBox5.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(394, 196)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(226, 140)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Transaksi"
        '
        'btnAJP
        '
        Me.btnAJP.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnAJP.Font = New System.Drawing.Font("Leelawadee UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAJP.Image = CType(resources.GetObject("btnAJP.Image"), System.Drawing.Image)
        Me.btnAJP.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAJP.Location = New System.Drawing.Point(118, 33)
        Me.btnAJP.Name = "btnAJP"
        Me.btnAJP.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.btnAJP.Size = New System.Drawing.Size(95, 85)
        Me.btnAJP.TabIndex = 2
        Me.btnAJP.Text = " AJP"
        Me.btnAJP.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAJP.UseVisualStyleBackColor = False
        '
        'btnJurnalUmum
        '
        Me.btnJurnalUmum.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnJurnalUmum.Font = New System.Drawing.Font("Leelawadee UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnJurnalUmum.Image = CType(resources.GetObject("btnJurnalUmum.Image"), System.Drawing.Image)
        Me.btnJurnalUmum.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnJurnalUmum.Location = New System.Drawing.Point(17, 33)
        Me.btnJurnalUmum.Name = "btnJurnalUmum"
        Me.btnJurnalUmum.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.btnJurnalUmum.Size = New System.Drawing.Size(95, 85)
        Me.btnJurnalUmum.TabIndex = 1
        Me.btnJurnalUmum.Text = "Jurnal Umum"
        Me.btnJurnalUmum.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnJurnalUmum.UseVisualStyleBackColor = False
        '
        'btnJualBeli
        '
        Me.btnJualBeli.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnJualBeli.Font = New System.Drawing.Font("Leelawadee UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnJualBeli.Image = CType(resources.GetObject("btnJualBeli.Image"), System.Drawing.Image)
        Me.btnJualBeli.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnJualBeli.Location = New System.Drawing.Point(221, 43)
        Me.btnJualBeli.Name = "btnJualBeli"
        Me.btnJualBeli.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.btnJualBeli.Size = New System.Drawing.Size(95, 85)
        Me.btnJualBeli.TabIndex = 0
        Me.btnJualBeli.Text = "Terima-Jual"
        Me.btnJualBeli.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnJualBeli.UseVisualStyleBackColor = False
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.btnProses)
        Me.GroupBox8.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(649, 196)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(137, 140)
        Me.GroupBox8.TabIndex = 7
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Proses"
        '
        'btnProses
        '
        Me.btnProses.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnProses.Font = New System.Drawing.Font("Leelawadee UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProses.Image = CType(resources.GetObject("btnProses.Image"), System.Drawing.Image)
        Me.btnProses.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProses.Location = New System.Drawing.Point(21, 34)
        Me.btnProses.Name = "btnProses"
        Me.btnProses.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.btnProses.Size = New System.Drawing.Size(95, 82)
        Me.btnProses.TabIndex = 0
        Me.btnProses.Text = "Posting"
        Me.btnProses.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProses.UseVisualStyleBackColor = False
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.btnLapNeraca)
        Me.GroupBox9.Controls.Add(Me.btnLapAkun)
        Me.GroupBox9.Controls.Add(Me.btnLapJU)
        Me.GroupBox9.Controls.Add(Me.btnLapPM)
        Me.GroupBox9.Controls.Add(Me.btnLapAJP)
        Me.GroupBox9.Controls.Add(Me.btnLapNL)
        Me.GroupBox9.Controls.Add(Me.btnLapRL)
        Me.GroupBox9.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(809, 196)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(549, 249)
        Me.GroupBox9.TabIndex = 5
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Laporan"
        '
        'btnLapNeraca
        '
        Me.btnLapNeraca.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnLapNeraca.Font = New System.Drawing.Font("Leelawadee UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLapNeraca.Image = CType(resources.GetObject("btnLapNeraca.Image"), System.Drawing.Image)
        Me.btnLapNeraca.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLapNeraca.Location = New System.Drawing.Point(282, 137)
        Me.btnLapNeraca.Name = "btnLapNeraca"
        Me.btnLapNeraca.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.btnLapNeraca.Size = New System.Drawing.Size(94, 85)
        Me.btnLapNeraca.TabIndex = 6
        Me.btnLapNeraca.Text = "Neraca"
        Me.btnLapNeraca.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLapNeraca.UseVisualStyleBackColor = False
        '
        'btnLapAkun
        '
        Me.btnLapAkun.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnLapAkun.Font = New System.Drawing.Font("Leelawadee UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLapAkun.Image = CType(resources.GetObject("btnLapAkun.Image"), System.Drawing.Image)
        Me.btnLapAkun.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLapAkun.Location = New System.Drawing.Point(29, 34)
        Me.btnLapAkun.Name = "btnLapAkun"
        Me.btnLapAkun.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.btnLapAkun.Size = New System.Drawing.Size(95, 85)
        Me.btnLapAkun.TabIndex = 0
        Me.btnLapAkun.Text = "Akun"
        Me.btnLapAkun.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLapAkun.UseVisualStyleBackColor = False
        '
        'btnLapJU
        '
        Me.btnLapJU.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnLapJU.Font = New System.Drawing.Font("Leelawadee UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLapJU.Image = CType(resources.GetObject("btnLapJU.Image"), System.Drawing.Image)
        Me.btnLapJU.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLapJU.Location = New System.Drawing.Point(130, 34)
        Me.btnLapJU.Name = "btnLapJU"
        Me.btnLapJU.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.btnLapJU.Size = New System.Drawing.Size(94, 85)
        Me.btnLapJU.TabIndex = 1
        Me.btnLapJU.Text = "Jurnal Umum"
        Me.btnLapJU.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLapJU.UseVisualStyleBackColor = False
        '
        'btnLapPM
        '
        Me.btnLapPM.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnLapPM.Font = New System.Drawing.Font("Leelawadee UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLapPM.Image = CType(resources.GetObject("btnLapPM.Image"), System.Drawing.Image)
        Me.btnLapPM.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLapPM.Location = New System.Drawing.Point(180, 137)
        Me.btnLapPM.Name = "btnLapPM"
        Me.btnLapPM.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.btnLapPM.Size = New System.Drawing.Size(94, 85)
        Me.btnLapPM.TabIndex = 5
        Me.btnLapPM.Text = "Perub. Modal"
        Me.btnLapPM.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLapPM.UseVisualStyleBackColor = False
        '
        'btnLapAJP
        '
        Me.btnLapAJP.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnLapAJP.Font = New System.Drawing.Font("Leelawadee UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLapAJP.Image = CType(resources.GetObject("btnLapAJP.Image"), System.Drawing.Image)
        Me.btnLapAJP.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLapAJP.Location = New System.Drawing.Point(230, 34)
        Me.btnLapAJP.Name = "btnLapAJP"
        Me.btnLapAJP.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.btnLapAJP.Size = New System.Drawing.Size(94, 85)
        Me.btnLapAJP.TabIndex = 2
        Me.btnLapAJP.Text = "AJP"
        Me.btnLapAJP.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLapAJP.UseVisualStyleBackColor = False
        '
        'btnLapNL
        '
        Me.btnLapNL.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnLapNL.Font = New System.Drawing.Font("Leelawadee UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLapNL.Image = CType(resources.GetObject("btnLapNL.Image"), System.Drawing.Image)
        Me.btnLapNL.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLapNL.Location = New System.Drawing.Point(330, 34)
        Me.btnLapNL.Name = "btnLapNL"
        Me.btnLapNL.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.btnLapNL.Size = New System.Drawing.Size(94, 85)
        Me.btnLapNL.TabIndex = 3
        Me.btnLapNL.Text = "Neraca Lajur"
        Me.btnLapNL.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLapNL.UseVisualStyleBackColor = False
        '
        'btnLapRL
        '
        Me.btnLapRL.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnLapRL.Font = New System.Drawing.Font("Leelawadee UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLapRL.Image = CType(resources.GetObject("btnLapRL.Image"), System.Drawing.Image)
        Me.btnLapRL.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLapRL.Location = New System.Drawing.Point(430, 34)
        Me.btnLapRL.Name = "btnLapRL"
        Me.btnLapRL.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.btnLapRL.Size = New System.Drawing.Size(94, 85)
        Me.btnLapRL.TabIndex = 4
        Me.btnLapRL.Text = "Rugi/Laba"
        Me.btnLapRL.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLapRL.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(113, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 18)
        Me.Label3.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(3, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(23, 123)
        Me.Panel2.TabIndex = 5
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(26, 16)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(142, 123)
        Me.Panel3.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
        Me.Label5.Location = New System.Drawing.Point(6, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 88)
        Me.Label5.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(142, 123)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(1344, 16)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(23, 123)
        Me.Panel4.TabIndex = 7
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.txtName)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(1109, 16)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(235, 123)
        Me.Panel5.TabIndex = 8
        '
        'txtName
        '
        Me.txtName.AutoSize = True
        Me.txtName.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(81, 67)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(0, 20)
        Me.txtName.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(181, 26)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Selamat Datang!"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(168, 16)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(941, 123)
        Me.Panel6.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(270, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(478, 19)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Alamat: Jalan Monginsidi Desa Pacul RT 14 RW 02, Bojonegoro, Jawa Timur"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bell MT", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(194, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(672, 58)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "SISTEM INFORMASI AKUNTANSI LAPORAN KEUANGAN" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "UD AL-WIDA JAYA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox1.Controls.Add(Me.Panel6)
        Me.GroupBox1.Controls.Add(Me.Panel5)
        Me.GroupBox1.Controls.Add(Me.Panel4)
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1370, 142)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnBarang)
        Me.GroupBox3.Controls.Add(Me.btnSupplier)
        Me.GroupBox3.Controls.Add(Me.btnJualBeli)
        Me.GroupBox3.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(26, 350)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(338, 158)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Transaksi Barang"
        '
        'FormMenuUtama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1370, 687)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormMenuUtama"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Utama"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSupplier As System.Windows.Forms.Button
    Friend WithEvents btnBarang As System.Windows.Forms.Button
    Friend WithEvents btnPeriode As System.Windows.Forms.Button
    Friend WithEvents btnCoA As System.Windows.Forms.Button
    Friend WithEvents btnPengguna As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAJP As System.Windows.Forms.Button
    Friend WithEvents btnJurnalUmum As System.Windows.Forms.Button
    Friend WithEvents btnJualBeli As System.Windows.Forms.Button
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents btnProses As System.Windows.Forms.Button
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLapRL As System.Windows.Forms.Button
    Friend WithEvents btnLapNL As System.Windows.Forms.Button
    Friend WithEvents btnLapAJP As System.Windows.Forms.Button
    Friend WithEvents btnLapJU As System.Windows.Forms.Button
    Friend WithEvents btnLapAkun As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeluarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetUpSaldoAwalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLapNeraca As System.Windows.Forms.Button
    Friend WithEvents btnLapPM As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents txtName As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
End Class
