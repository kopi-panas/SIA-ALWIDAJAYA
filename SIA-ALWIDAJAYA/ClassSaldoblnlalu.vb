Imports System.Data.OleDb
Public Class ClassSaldoblnlalu

    Private mPeriode As String
    Private mTgl As Date
    Private mKodeRekening As String
    Private tempDK As String
    Private mDebet As Long
    Private mKredit As Long

    Public Sub TambahData()
        With FormSetupSaldoAwal
            .KondisiAwal()
            '.BersihkanIsian()
            '.txtNoAkun.Focus()
        End With
    End Sub

    Public Function SimpanData()
        Try
            mPeriode = FormSetupSaldoAwal.cbPeriode.Text
            mTgl = FormSetupSaldoAwal.txtTgl.Value
            mKodeRekening = FormSetupSaldoAwal.txtNoAkun.Text
            tempDK = FormSetupSaldoAwal.mDK
            mDebet = FormSetupSaldoAwal.txtDebet.Text
            mKredit = FormSetupSaldoAwal.txtKredit.Text

            Query = "INSERT INTO tbl_saldoblnlalu VALUES('" & mPeriode & "', '" & mTgl & "', '" & mKodeRekening & "', '" & tempDK & "', '" & mDebet & "','" & mKredit & "', '" & "UnPosted" & "', '" & "Saldo bulan lalu" & "')"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
            Return Query
        Catch ex As Exception
            Return Query
        End Try
    End Function

    Public Function EditData()
        Try
            mKodeRekening = FormSetupSaldoAwal.txtNoAkun.Text
            mDebet = FormSetupSaldoAwal.txtDebet.Text
            mKredit = FormSetupSaldoAwal.txtKredit.Text

            Query = "UPDATE tbl_saldoblnlalu SET  Debet = '" & mDebet & "', Kredit = '" & mKredit & "'  WHERE NoAkun = '" & mKodeRekening & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
            Return Query
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function HapusData()
        Try
            mPeriode = FormSetupSaldoAwal.cbPeriode.Text
            mKodeRekening = FormSetupSaldoAwal.txtNoAkun.Text

            Query = "DELETE FROM tbl_saldoblnlalu WHERE NoAkun = '" & mKodeRekening & "' AND Periode = '" & mPeriode & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
            Return Query
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Sub Keluar()
        'frmTransaksiSaloBlnLalu.Dispose()
    End Sub

End Class
