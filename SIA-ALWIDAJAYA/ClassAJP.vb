Imports System.Data.OleDb
Public Class ClassAJP

    Private mNoTransaksi As String
    Private mPeriode As String
    Private mTglTransaksi As Date
    Private mKeterangan As String
    Private mNoAkun As String
    Private DK As String
    Private mDebet As Long
    Private mKredit As Long

    Public Function SimpanDataHJurnal()
        Try
            mNoTransaksi = FormAJP.lblNoTransaksi.Text
            mPeriode = FormAJP.lblPeriode.Text
            mTglTransaksi = FormAJP.txtTgl.Value
            mKeterangan = FormAJP.txtKeterangan.Text

            Query = "INSERT INTO tbl_jurnalajp VALUES('" & mNoTransaksi & "', '" & mPeriode & "' , '" & mTglTransaksi & "', '" & mKeterangan & "', '" & "UnPosted" & "')"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
            Return Query
        Catch ex As Exception
            Return Query
        End Try
    End Function

    Public Function SimpanData()
        Try
            mNoTransaksi = FormAJP.lblNoTransaksi.Text
            mNoAkun = FormAJP.txtNoAkun.Text
            DK = FormAJP.mDK
            mDebet = FormAJP.txtDebet.Text
            mKredit = FormAJP.txtKredit.Text

            Query = "INSERT INTO tbl_detailajp VALUES('" & mNoTransaksi & "','" & mNoAkun & "',  '" & DK & "' , '" & mDebet & "' ,'" & mKredit & "')"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
            FormAkun.MunculGrid()
            Return Query
        Catch ex As Exception
            MsgBox("Data tidak bisa tersimpan karena NoPerkiraan sudah ada...", MsgBoxStyle.Exclamation, "Error")
            FormAkun.txtNoAkun.Focus()
            Return Query
        End Try
    End Function

    Public Function EditDataHJurnal()
        Try
            mNoTransaksi = FormAJP.lblNoTransaksi.Text
            mTglTransaksi = Format(FormAJP.txtTgl.Value, "dd/MM/yyyy")
            mKeterangan = FormAJP.txtKeterangan.Text

            Query = "UPDATE tbl_jurnalajp SET  TglTransaksi = '" & mTglTransaksi & "', Keterangan = '" & mKeterangan & "' WHERE NoTransaksi = '" & mNoTransaksi & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
            Return Query
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function EditData()
        Try
            DK = FormAJP.mDK
            mDebet = FormAJP.txtDebet.Text
            mKredit = FormAJP.txtKredit.Text
            mNoTransaksi = FormAJP.lblNoTransaksi.Text
            mNoAkun = FormAJP.txtNoAkun.Text

            Query = "UPDATE tbl_detailajp SET  DK = '" & DK & "', Debet = '" & mDebet & "', Kredit = '" & mKredit & "' WHERE NoTransaksi = '" & mNoTransaksi & "' AND NoAkun = '" & mNoAkun & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
            Return Query
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function HapusDataHJurnal()
        Try
            mNoTransaksi = FormAJP.lblNoTransaksi.Text
            Query = "DELETE FROM tbl_jurnalajp WHERE NoTransaksi = '" & mNoTransaksi & "'"
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
            mNoTransaksi = FormAJP.lblNoTransaksi.Text
            Query = "DELETE FROM tbl_detailajp WHERE NoTransaksi = '" & mNoTransaksi & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
            Return Query
        Catch ex As Exception
            Return 0
        End Try
    End Function

End Class
