<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSubAkunJurnalUmum
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
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.btnYa = New System.Windows.Forms.Button()
        Me.btnTidak = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(2, 3)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(409, 335)
        Me.ListView1.TabIndex = 4
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'btnYa
        '
        Me.btnYa.Location = New System.Drawing.Point(122, 352)
        Me.btnYa.Name = "btnYa"
        Me.btnYa.Size = New System.Drawing.Size(80, 28)
        Me.btnYa.TabIndex = 14
        Me.btnYa.Text = "&Ya"
        Me.btnYa.UseVisualStyleBackColor = True
        '
        'btnTidak
        '
        Me.btnTidak.Location = New System.Drawing.Point(208, 352)
        Me.btnTidak.Name = "btnTidak"
        Me.btnTidak.Size = New System.Drawing.Size(80, 28)
        Me.btnTidak.TabIndex = 15
        Me.btnTidak.Text = "&Tidak"
        Me.btnTidak.UseVisualStyleBackColor = True
        '
        'FormSubAkunJurnalUmum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 392)
        Me.Controls.Add(Me.btnYa)
        Me.Controls.Add(Me.btnTidak)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSubAkunJurnalUmum"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Akun"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents btnYa As System.Windows.Forms.Button
    Friend WithEvents btnTidak As System.Windows.Forms.Button
End Class
