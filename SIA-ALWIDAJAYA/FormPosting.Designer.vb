﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPosting
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
        Me.lblPeriodeBerikutnya = New System.Windows.Forms.Label()
        Me.cbPeriode = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnPosting = New System.Windows.Forms.Button()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblPeriodeBerikutnya)
        Me.GroupBox1.Controls.Add(Me.cbPeriode)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(21, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(404, 166)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pilih Periode:"
        '
        'lblPeriodeBerikutnya
        '
        Me.lblPeriodeBerikutnya.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblPeriodeBerikutnya.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPeriodeBerikutnya.Location = New System.Drawing.Point(189, 94)
        Me.lblPeriodeBerikutnya.Name = "lblPeriodeBerikutnya"
        Me.lblPeriodeBerikutnya.Size = New System.Drawing.Size(113, 25)
        Me.lblPeriodeBerikutnya.TabIndex = 3
        '
        'cbPeriode
        '
        Me.cbPeriode.FormattingEnabled = True
        Me.cbPeriode.Location = New System.Drawing.Point(189, 61)
        Me.cbPeriode.Name = "cbPeriode"
        Me.cbPeriode.Size = New System.Drawing.Size(113, 24)
        Me.cbPeriode.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Periode bulan berikutnya:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Periode yang diposting:"
        '
        'btnPosting
        '
        Me.btnPosting.Location = New System.Drawing.Point(135, 206)
        Me.btnPosting.Name = "btnPosting"
        Me.btnPosting.Size = New System.Drawing.Size(80, 28)
        Me.btnPosting.TabIndex = 22
        Me.btnPosting.Text = "&Posting"
        Me.btnPosting.UseVisualStyleBackColor = True
        '
        'btnKeluar
        '
        Me.btnKeluar.Location = New System.Drawing.Point(221, 206)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(80, 28)
        Me.btnKeluar.TabIndex = 23
        Me.btnKeluar.Text = "&Keluar"
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'FormPosting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 268)
        Me.Controls.Add(Me.btnPosting)
        Me.Controls.Add(Me.btnKeluar)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPosting"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Posting"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPeriodeBerikutnya As System.Windows.Forms.Label
    Friend WithEvents cbPeriode As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnPosting As System.Windows.Forms.Button
    Friend WithEvents btnKeluar As System.Windows.Forms.Button
End Class
