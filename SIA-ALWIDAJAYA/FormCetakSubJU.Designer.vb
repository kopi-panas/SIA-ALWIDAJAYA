<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCetakSubJU
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCetakSubJU))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnNS = New System.Windows.Forms.Button()
        Me.btnBB = New System.Windows.Forms.Button()
        Me.btnJU = New System.Windows.Forms.Button()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.jurnalumum = New System.Windows.Forms.Panel()
        Me.btnCetakJU = New System.Windows.Forms.Button()
        Me.Group = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbPeriodeJU = New System.Windows.Forms.ComboBox()
        Me.bukubesar = New System.Windows.Forms.Panel()
        Me.btnCetakBB = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbPeriodeBB = New System.Windows.Forms.ComboBox()
        Me.neracasaldo = New System.Windows.Forms.Panel()
        Me.btnCetakNS = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbPeriodeNS = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.jurnalumum.SuspendLayout()
        Me.Group.SuspendLayout()
        Me.bukubesar.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.neracasaldo.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnNS)
        Me.Panel1.Controls.Add(Me.btnBB)
        Me.Panel1.Controls.Add(Me.btnJU)
        Me.Panel1.Controls.Add(Me.btnKeluar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(142, 197)
        Me.Panel1.TabIndex = 0
        '
        'btnNS
        '
        Me.btnNS.Font = New System.Drawing.Font("Microsoft Tai Le", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNS.Image = CType(resources.GetObject("btnNS.Image"), System.Drawing.Image)
        Me.btnNS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNS.Location = New System.Drawing.Point(12, 103)
        Me.btnNS.Name = "btnNS"
        Me.btnNS.Size = New System.Drawing.Size(114, 32)
        Me.btnNS.TabIndex = 122
        Me.btnNS.Text = "Neraca Saldo"
        Me.btnNS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNS.UseVisualStyleBackColor = True
        '
        'btnBB
        '
        Me.btnBB.Font = New System.Drawing.Font("Microsoft Tai Le", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBB.Image = CType(resources.GetObject("btnBB.Image"), System.Drawing.Image)
        Me.btnBB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBB.Location = New System.Drawing.Point(12, 65)
        Me.btnBB.Name = "btnBB"
        Me.btnBB.Size = New System.Drawing.Size(114, 32)
        Me.btnBB.TabIndex = 123
        Me.btnBB.Text = "Buku Besar"
        Me.btnBB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBB.UseVisualStyleBackColor = True
        '
        'btnJU
        '
        Me.btnJU.Font = New System.Drawing.Font("Microsoft Tai Le", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnJU.Image = CType(resources.GetObject("btnJU.Image"), System.Drawing.Image)
        Me.btnJU.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnJU.Location = New System.Drawing.Point(12, 27)
        Me.btnJU.Name = "btnJU"
        Me.btnJU.Size = New System.Drawing.Size(114, 32)
        Me.btnJU.TabIndex = 124
        Me.btnJU.Text = "Jurnal Umum"
        Me.btnJU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnJU.UseVisualStyleBackColor = True
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Microsoft Tai Le", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(29, 161)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(74, 32)
        Me.btnKeluar.TabIndex = 121
        Me.btnKeluar.Text = "&Keluar"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'jurnalumum
        '
        Me.jurnalumum.Controls.Add(Me.btnCetakJU)
        Me.jurnalumum.Controls.Add(Me.Group)
        Me.jurnalumum.Dock = System.Windows.Forms.DockStyle.Fill
        Me.jurnalumum.Location = New System.Drawing.Point(142, 0)
        Me.jurnalumum.Name = "jurnalumum"
        Me.jurnalumum.Size = New System.Drawing.Size(281, 197)
        Me.jurnalumum.TabIndex = 1
        '
        'btnCetakJU
        '
        Me.btnCetakJU.Font = New System.Drawing.Font("Microsoft Tai Le", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCetakJU.Image = CType(resources.GetObject("btnCetakJU.Image"), System.Drawing.Image)
        Me.btnCetakJU.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCetakJU.Location = New System.Drawing.Point(106, 132)
        Me.btnCetakJU.Name = "btnCetakJU"
        Me.btnCetakJU.Size = New System.Drawing.Size(74, 32)
        Me.btnCetakJU.TabIndex = 121
        Me.btnCetakJU.Text = "&Cetak"
        Me.btnCetakJU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCetakJU.UseVisualStyleBackColor = True
        '
        'Group
        '
        Me.Group.Controls.Add(Me.Label15)
        Me.Group.Controls.Add(Me.cbPeriodeJU)
        Me.Group.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group.Location = New System.Drawing.Point(14, 55)
        Me.Group.Name = "Group"
        Me.Group.Size = New System.Drawing.Size(263, 54)
        Me.Group.TabIndex = 120
        Me.Group.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(18, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 13)
        Me.Label15.TabIndex = 62
        Me.Label15.Text = "Periode :"
        '
        'cbPeriodeJU
        '
        Me.cbPeriodeJU.BackColor = System.Drawing.SystemColors.Window
        Me.cbPeriodeJU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriodeJU.FormattingEnabled = True
        Me.cbPeriodeJU.Location = New System.Drawing.Point(82, 19)
        Me.cbPeriodeJU.Name = "cbPeriodeJU"
        Me.cbPeriodeJU.Size = New System.Drawing.Size(160, 21)
        Me.cbPeriodeJU.TabIndex = 61
        '
        'bukubesar
        '
        Me.bukubesar.Controls.Add(Me.btnCetakBB)
        Me.bukubesar.Controls.Add(Me.GroupBox1)
        Me.bukubesar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bukubesar.Location = New System.Drawing.Point(142, 0)
        Me.bukubesar.Name = "bukubesar"
        Me.bukubesar.Size = New System.Drawing.Size(281, 197)
        Me.bukubesar.TabIndex = 122
        '
        'btnCetakBB
        '
        Me.btnCetakBB.Font = New System.Drawing.Font("Microsoft Tai Le", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCetakBB.Image = CType(resources.GetObject("btnCetakBB.Image"), System.Drawing.Image)
        Me.btnCetakBB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCetakBB.Location = New System.Drawing.Point(105, 125)
        Me.btnCetakBB.Name = "btnCetakBB"
        Me.btnCetakBB.Size = New System.Drawing.Size(74, 32)
        Me.btnCetakBB.TabIndex = 123
        Me.btnCetakBB.Text = "&Cetak"
        Me.btnCetakBB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCetakBB.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbPeriodeBB)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(263, 54)
        Me.GroupBox1.TabIndex = 122
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Periode :"
        '
        'cbPeriodeBB
        '
        Me.cbPeriodeBB.BackColor = System.Drawing.SystemColors.Window
        Me.cbPeriodeBB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriodeBB.FormattingEnabled = True
        Me.cbPeriodeBB.Location = New System.Drawing.Point(82, 19)
        Me.cbPeriodeBB.Name = "cbPeriodeBB"
        Me.cbPeriodeBB.Size = New System.Drawing.Size(160, 21)
        Me.cbPeriodeBB.TabIndex = 61
        '
        'neracasaldo
        '
        Me.neracasaldo.Controls.Add(Me.btnCetakNS)
        Me.neracasaldo.Controls.Add(Me.GroupBox2)
        Me.neracasaldo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.neracasaldo.Location = New System.Drawing.Point(142, 0)
        Me.neracasaldo.Name = "neracasaldo"
        Me.neracasaldo.Size = New System.Drawing.Size(281, 197)
        Me.neracasaldo.TabIndex = 125
        '
        'btnCetakNS
        '
        Me.btnCetakNS.Font = New System.Drawing.Font("Microsoft Tai Le", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCetakNS.Image = CType(resources.GetObject("btnCetakNS.Image"), System.Drawing.Image)
        Me.btnCetakNS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCetakNS.Location = New System.Drawing.Point(105, 125)
        Me.btnCetakNS.Name = "btnCetakNS"
        Me.btnCetakNS.Size = New System.Drawing.Size(74, 32)
        Me.btnCetakNS.TabIndex = 123
        Me.btnCetakNS.Text = "&Cetak"
        Me.btnCetakNS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCetakNS.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cbPeriodeNS)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(13, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(263, 54)
        Me.GroupBox2.TabIndex = 122
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "Periode :"
        '
        'cbPeriodeNS
        '
        Me.cbPeriodeNS.BackColor = System.Drawing.SystemColors.Window
        Me.cbPeriodeNS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPeriodeNS.FormattingEnabled = True
        Me.cbPeriodeNS.Location = New System.Drawing.Point(82, 19)
        Me.cbPeriodeNS.Name = "cbPeriodeNS"
        Me.cbPeriodeNS.Size = New System.Drawing.Size(160, 21)
        Me.cbPeriodeNS.TabIndex = 61
        '
        'FormCetakSubJU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 197)
        Me.ControlBox = False
        Me.Controls.Add(Me.jurnalumum)
        Me.Controls.Add(Me.bukubesar)
        Me.Controls.Add(Me.neracasaldo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCetakSubJU"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cetak Jurnal Umum"
        Me.Panel1.ResumeLayout(False)
        Me.jurnalumum.ResumeLayout(False)
        Me.Group.ResumeLayout(False)
        Me.Group.PerformLayout()
        Me.bukubesar.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.neracasaldo.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents jurnalumum As System.Windows.Forms.Panel
    Friend WithEvents btnKeluar As System.Windows.Forms.Button
    Friend WithEvents btnNS As System.Windows.Forms.Button
    Friend WithEvents btnBB As System.Windows.Forms.Button
    Friend WithEvents btnJU As System.Windows.Forms.Button
    Friend WithEvents bukubesar As System.Windows.Forms.Panel
    Friend WithEvents btnCetakJU As System.Windows.Forms.Button
    Friend WithEvents Group As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbPeriodeJU As System.Windows.Forms.ComboBox
    Friend WithEvents neracasaldo As System.Windows.Forms.Panel
    Friend WithEvents btnCetakBB As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbPeriodeBB As System.Windows.Forms.ComboBox
    Friend WithEvents btnCetakNS As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbPeriodeNS As System.Windows.Forms.ComboBox
End Class
