<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportBarang
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.tbl_barangBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetBarang = New SIA_ALWIDAJAYA.DataSetBarang()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.tbl_barangTableAdapter = New SIA_ALWIDAJAYA.DataSetBarangTableAdapters.tbl_barangTableAdapter()
        CType(Me.tbl_barangBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetBarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbl_barangBindingSource
        '
        Me.tbl_barangBindingSource.DataMember = "tbl_barang"
        Me.tbl_barangBindingSource.DataSource = Me.DataSetBarang
        '
        'DataSetBarang
        '
        Me.DataSetBarang.DataSetName = "DataSetBarang"
        Me.DataSetBarang.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.tbl_barangBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SIA_ALWIDAJAYA.ReportBarang.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(811, 528)
        Me.ReportViewer1.TabIndex = 0
        '
        'tbl_barangTableAdapter
        '
        Me.tbl_barangTableAdapter.ClearBeforeFill = True
        '
        'ReportBarang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 528)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "ReportBarang"
        Me.Text = "ReportBarang"
        CType(Me.tbl_barangBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetBarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tbl_barangBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSetBarang As SIA_ALWIDAJAYA.DataSetBarang
    Friend WithEvents tbl_barangTableAdapter As SIA_ALWIDAJAYA.DataSetBarangTableAdapters.tbl_barangTableAdapter
End Class
