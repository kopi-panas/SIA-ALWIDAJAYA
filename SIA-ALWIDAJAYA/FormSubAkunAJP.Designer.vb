<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSubAkunAJP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSubAkunAJP))
        Me.btnYa = New System.Windows.Forms.Button()
        Me.btnTidak = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.SuspendLayout()
        '
        'btnYa
        '
        Me.btnYa.Font = New System.Drawing.Font("Microsoft Tai Le", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYa.Image = CType(resources.GetObject("btnYa.Image"), System.Drawing.Image)
        Me.btnYa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnYa.Location = New System.Drawing.Point(136, 355)
        Me.btnYa.Name = "btnYa"
        Me.btnYa.Size = New System.Drawing.Size(57, 29)
        Me.btnYa.TabIndex = 17
        Me.btnYa.Text = "&Ya"
        Me.btnYa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnYa.UseVisualStyleBackColor = True
        '
        'btnTidak
        '
        Me.btnTidak.Font = New System.Drawing.Font("Microsoft Tai Le", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTidak.Image = CType(resources.GetObject("btnTidak.Image"), System.Drawing.Image)
        Me.btnTidak.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTidak.Location = New System.Drawing.Point(199, 355)
        Me.btnTidak.Name = "btnTidak"
        Me.btnTidak.Size = New System.Drawing.Size(73, 29)
        Me.btnTidak.TabIndex = 18
        Me.btnTidak.Text = "&Tidak"
        Me.btnTidak.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTidak.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(1, 1)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(406, 335)
        Me.ListView1.TabIndex = 16
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'FormSubAkunAJP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 392)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnYa)
        Me.Controls.Add(Me.btnTidak)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSubAkunAJP"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Akun"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnYa As System.Windows.Forms.Button
    Friend WithEvents btnTidak As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
End Class
