Public Class ReportBarang

    Private Sub ReportBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSetBarang.tbl_barang' table. You can move, or remove it, as needed.
        Me.tbl_barangTableAdapter.Fill(Me.DataSetBarang.tbl_barang)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class