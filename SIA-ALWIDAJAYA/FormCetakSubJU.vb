Imports System.Data.OleDb
Public Class FormCetakSubJU

    Private Sub SetPeriodeJU()
        Dim mTahun As String
        Dim mPeriode As String

        mTahun = Format(Now.Year)
        mPeriode = mTahun
        Try
            Query = "SELECT DISTINCT tbl_jurnalumum.Periode, IIf(Right([Periode],2)= '" & "01" & "', '" & "Januari" & "',IIf(Right([Periode],2)='" & "02" & "','" & "Februari" & "',IIf(Right([Periode],2)='" & "03" & "','" & "Maret" & "',IIf(Right([Periode],2)='" & "04" & "','" & "April" & "',IIf(Right([Periode],2)='" & "05" & "','" & "Mei" & "',IIf(Right([Periode],2)='" & "06" & "','" & "Juni" & "',IIf(Right([Periode],2)='" & "07" & "','" & "Juli" & "',IIf(Right([Periode],2)='" & "08" & "','" & "Agustus" & "',IIf(Right([Periode],2)='" & "09" & "','" & "September" & "',IIf(Right([Periode],2)='" & "10" & "','" & "Oktober" & "',IIf(Right([Periode],2)='" & "11" & "','" & "November" & "',IIf(Right([Periode],2)='" & "12" & "','" & "Desember" & "','" & "Bulan tidak dikenal" & "')))))))))))) AS Bulan FROM(tbl_jurnalumum) GROUP BY tbl_jurnalumum.Periode, IIf(Right([Periode],2)='" & "01" & "','" & "Januari" & "',IIf(Right([Periode],2)='" & "02" & "','" & "Februari" & "',IIf(Right([Periode],2)='" & "03" & "','" & "Maret" & "',IIf(Right([Periode],2)='" & "04" & "','" & "April" & "',IIf(Right([Periode],2)='" & "05" & "','" & "Mei" & "',IIf(Right([Periode],2)='" & "06" & "','" & "Juni" & "',IIf(Right([Periode],2)='" & "07" & "','" & "Juli" & "',IIf(Right([Periode],2)='" & "08" & "','" & "Agustus" & "',IIf(Right([Periode],2)='" & "09" & "','" & "September" & "',IIf(Right([Periode],2)='" & "10" & "','" & "Oktober" & "',IIf(Right([Periode],2)='" & "11" & "','" & "November" & "',IIf(Right([Periode],2)='" & "12" & "','" & "Desember" & "','" & "Bulan tidak dikenal" & "')))))))))))) ORDER BY tbl_jurnalumum.Periode DESC"

            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            cbPeriodeJU.Items.Clear()
            For a = 0 To Ds.Tables(0).Rows.Count - 1
                With cbPeriodeJU
                    .Items.Add(Ds.Tables(0).Rows(a).Item(0) & " : " & Ds.Tables(0).Rows(a).Item(1))
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SetPeriodeBB()
        Dim mTahun As String
        Dim mPeriode As String

        mTahun = Format(Now.Year)
        mPeriode = mTahun
        Try
            Query = "SELECT DISTINCT tbl_bbjurnal.Periode, IIf(Right([Periode],2)= '" & "01" & "', '" & "Januari" & "',IIf(Right([Periode],2)='" & "02" & "','" & "Februari" & "',IIf(Right([Periode],2)='" & "03" & "','" & "Maret" & "',IIf(Right([Periode],2)='" & "04" & "','" & "April" & "',IIf(Right([Periode],2)='" & "05" & "','" & "Mei" & "',IIf(Right([Periode],2)='" & "06" & "','" & "Juni" & "',IIf(Right([Periode],2)='" & "07" & "','" & "Juli" & "',IIf(Right([Periode],2)='" & "08" & "','" & "Agustus" & "',IIf(Right([Periode],2)='" & "09" & "','" & "September" & "',IIf(Right([Periode],2)='" & "10" & "','" & "Oktober" & "',IIf(Right([Periode],2)='" & "11" & "','" & "November" & "',IIf(Right([Periode],2)='" & "12" & "','" & "Desember" & "','" & "Bulan tidak dikenal" & "')))))))))))) AS Bulan FROM(tbl_bbjurnal) GROUP BY tbl_bbjurnal.Periode, IIf(Right([Periode],2)='" & "01" & "','" & "Januari" & "',IIf(Right([Periode],2)='" & "02" & "','" & "Februari" & "',IIf(Right([Periode],2)='" & "03" & "','" & "Maret" & "',IIf(Right([Periode],2)='" & "04" & "','" & "April" & "',IIf(Right([Periode],2)='" & "05" & "','" & "Mei" & "',IIf(Right([Periode],2)='" & "06" & "','" & "Juni" & "',IIf(Right([Periode],2)='" & "07" & "','" & "Juli" & "',IIf(Right([Periode],2)='" & "08" & "','" & "Agustus" & "',IIf(Right([Periode],2)='" & "09" & "','" & "September" & "',IIf(Right([Periode],2)='" & "10" & "','" & "Oktober" & "',IIf(Right([Periode],2)='" & "11" & "','" & "November" & "',IIf(Right([Periode],2)='" & "12" & "','" & "Desember" & "','" & "Bulan tidak dikenal" & "')))))))))))) ORDER BY tbl_bbjurnal.Periode DESC"

            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            cbPeriodeBB.Items.Clear()
            For a = 0 To Ds.Tables(0).Rows.Count - 1
                With cbPeriodeBB
                    .Items.Add(Ds.Tables(0).Rows(a).Item(0) & " : " & Ds.Tables(0).Rows(a).Item(1))
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SetPeriodeNS()
        Dim mTahun As String
        Dim mPeriode As String

        mTahun = Format(Now.Year)
        mPeriode = mTahun
        Try
            Query = "SELECT DISTINCT tbl_neracasaldo.Periode, IIf(Right([Periode],2)= '" & "01" & "', '" & "Januari" & "',IIf(Right([Periode],2)='" & "02" & "','" & "Februari" & "',IIf(Right([Periode],2)='" & "03" & "','" & "Maret" & "',IIf(Right([Periode],2)='" & "04" & "','" & "April" & "',IIf(Right([Periode],2)='" & "05" & "','" & "Mei" & "',IIf(Right([Periode],2)='" & "06" & "','" & "Juni" & "',IIf(Right([Periode],2)='" & "07" & "','" & "Juli" & "',IIf(Right([Periode],2)='" & "08" & "','" & "Agustus" & "',IIf(Right([Periode],2)='" & "09" & "','" & "September" & "',IIf(Right([Periode],2)='" & "10" & "','" & "Oktober" & "',IIf(Right([Periode],2)='" & "11" & "','" & "November" & "',IIf(Right([Periode],2)='" & "12" & "','" & "Desember" & "','" & "Bulan tidak dikenal" & "')))))))))))) AS Bulan FROM(tbl_neracasaldo) GROUP BY tbl_neracasaldo.Periode, IIf(Right([Periode],2)='" & "01" & "','" & "Januari" & "',IIf(Right([Periode],2)='" & "02" & "','" & "Februari" & "',IIf(Right([Periode],2)='" & "03" & "','" & "Maret" & "',IIf(Right([Periode],2)='" & "04" & "','" & "April" & "',IIf(Right([Periode],2)='" & "05" & "','" & "Mei" & "',IIf(Right([Periode],2)='" & "06" & "','" & "Juni" & "',IIf(Right([Periode],2)='" & "07" & "','" & "Juli" & "',IIf(Right([Periode],2)='" & "08" & "','" & "Agustus" & "',IIf(Right([Periode],2)='" & "09" & "','" & "September" & "',IIf(Right([Periode],2)='" & "10" & "','" & "Oktober" & "',IIf(Right([Periode],2)='" & "11" & "','" & "November" & "',IIf(Right([Periode],2)='" & "12" & "','" & "Desember" & "','" & "Bulan tidak dikenal" & "')))))))))))) ORDER BY tbl_neracasaldo.Periode DESC"

            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            cbPeriodeNS.Items.Clear()
            For a = 0 To Ds.Tables(0).Rows.Count - 1
                With cbPeriodeNS
                    .Items.Add(Ds.Tables(0).Rows(a).Item(0) & " : " & Ds.Tables(0).Rows(a).Item(1))
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormCetakSubJU_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub

    Private Sub btnJU_Click(sender As Object, e As EventArgs) Handles btnJU.Click
        jurnalumum.Show()
    End Sub

    Private Sub btnBB_Click(sender As Object, e As EventArgs) Handles btnBB.Click
        jurnalumum.Hide()
        'neracasaldo.Hide()
    End Sub

    Private Sub btnNS_Click(sender As Object, e As EventArgs) Handles btnNS.Click
        bukubesar.Hide()
        'jurnalumum.Hide()
    End Sub
End Class