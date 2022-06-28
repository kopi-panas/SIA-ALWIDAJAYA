Imports System.Data.OleDb
Public Class FormMenuUtama

    Public status As String

    Sub Disable()
        btnAJP.Enabled = False
        btnBarang.Enabled = False
        btnCoA.Enabled = False
        btnJualBeli.Enabled = False
        btnJurnalUmum.Enabled = False
        btnPengguna.Enabled = False
        btnPeriode.Enabled = False
        btnProses.Enabled = False
        btnSupplier.Enabled = False
        btnLapAkun.Enabled = False
        btnLapJU.Enabled = False
        btnLapAJP.Enabled = False
        btnLapNL.Enabled = False
        btnLapPM.Enabled = False
        btnLapRL.Enabled = False
        btnLapNeraca.Enabled = False
    End Sub

    Private Sub btnPengguna_Click(sender As Object, e As EventArgs) Handles btnPengguna.Click
        FormPengguna.Show()
    End Sub

    Private Sub btnCoA_Click(sender As Object, e As EventArgs) Handles btnCoA.Click
        FormAkun.Show()
    End Sub

    Private Sub btnBarang_Click(sender As Object, e As EventArgs) Handles btnBarang.Click
        FormMasterBarang.Show()
    End Sub

    Private Sub btnSupplier_Click(sender As Object, e As EventArgs) Handles btnSupplier.Click
        FormSupplier.Show()
    End Sub

    Private Sub btnPeriode_Click(sender As Object, e As EventArgs) Handles btnPeriode.Click
        FormPeriode.Show()
    End Sub

    Private Sub btnJurnalUmum_Click(sender As Object, e As EventArgs) Handles btnJurnalUmum.Click
        FormJurnalUmum.Show()
    End Sub

    Private Sub btnAJP_Click(sender As Object, e As EventArgs) Handles btnAJP.Click
        FormAJP.Show()
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        FormPosting.Show()
    End Sub

    Private Sub btnJualBeli_Click(sender As Object, e As EventArgs) Handles btnJualBeli.Click
        FormMenuJualBeli.Show()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        txtName.Text = "Guest"
        Disable()
        FormLogin.ShowDialog()
    End Sub

    Private Sub FormMenuUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        FormLogin.ShowDialog()
    End Sub

    Private Sub KeluarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeluarToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SetUpSaldoAwalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetUpSaldoAwalToolStripMenuItem.Click
        FormSetupSaldoAwal.Show()
    End Sub

    Private Sub btnLapMaster_Click(sender As Object, e As EventArgs) Handles btnLapAkun.Click
        FormCetakAkun.Show()
    End Sub

    Private Sub btnLapJU_Click(sender As Object, e As EventArgs) Handles btnLapJU.Click
        FormCetakSubJU.Show()
    End Sub

    Private Sub btnLapAJP_Click(sender As Object, e As EventArgs) Handles btnLapAJP.Click
        FormCetakAJP.Show()
    End Sub

    Private Sub btnLapNL_Click(sender As Object, e As EventArgs) Handles btnLapNL.Click
        FormCetakNL.Show()
    End Sub

    Private Sub btnLapRL_Click(sender As Object, e As EventArgs) Handles btnLapRL.Click
        FormCetakRL.Show()
    End Sub

    Private Sub btnLapPM_Click(sender As Object, e As EventArgs) Handles btnLapPM.Click
        FormCetakPerbModal.Show()
    End Sub

    Private Sub btnLapNeraca_Click(sender As Object, e As EventArgs) Handles btnLapNeraca.Click
        FormCetakNeraca.Show()
    End Sub
End Class