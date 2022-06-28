Imports System.Data.OleDb
Public Class ClassJurnalUmum

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
            mNoTransaksi = FormJurnalUmum.lblNoTransaksi.Text
            mPeriode = FormJurnalUmum.lblPeriode.Text
            mTglTransaksi = FormJurnalUmum.txtTgl.Value
            mKeterangan = FormJurnalUmum.txtKeterangan.Text

            Query = "INSERT INTO tbl_jurnalumum VALUES('" & mNoTransaksi & "', '" & mPeriode & "' , '" & mTglTransaksi & "', '" & mKeterangan & "', '" & "UnPosted" & "')"
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
            mNoTransaksi = FormJurnalUmum.lblNoTransaksi.Text
            mNoAkun = FormJurnalUmum.txtNoAkun.Text
            DK = FormJurnalUmum.mDK
            mDebet = FormJurnalUmum.txtDebet.Text
            mKredit = FormJurnalUmum.txtKredit.Text

            Query = "INSERT INTO tbl_detailjurnal VALUES('" & mNoTransaksi & "','" & mNoAkun & "',  '" & DK & "' , '" & mDebet & "' ,'" & mKredit & "')"
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
            mNoTransaksi = FormJurnalUmum.lblNoTransaksi.Text
            mTglTransaksi = Format(FormJurnalUmum.txtTgl.Value, "dd/MM/yyyy")
            mKeterangan = FormJurnalUmum.txtKeterangan.Text

            Query = "UPDATE tbl_jurnalumum SET  TglTransaksi = '" & mTglTransaksi & "', Keterangan = '" & mKeterangan & "' WHERE NoTransaksi = '" & mNoTransaksi & "'"
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
            DK = FormJurnalUmum.mDK
            mDebet = FormJurnalUmum.txtDebet.Text
            mKredit = FormJurnalUmum.txtKredit.Text
            mNoTransaksi = FormJurnalUmum.lblNoTransaksi.Text
            mNoAkun = FormJurnalUmum.txtNoAkun.Text

            Query = "UPDATE tbl_detailjurnal SET  DK = '" & DK & "', Debet = '" & mDebet & "', Kredit = '" & mKredit & "' WHERE NoTransaksi = '" & mNoTransaksi & "' AND NoAkun = '" & mNoAkun & "'"
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
            mNoTransaksi = FormJurnalUmum.lblNoTransaksi.Text
            Query = "DELETE FROM tbl_jurnalumum WHERE NoTransaksi = '" & mNoTransaksi & "'"
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
            mNoTransaksi = FormJurnalUmum.lblNoTransaksi.Text
            Query = "DELETE FROM tbl_detailjurnal WHERE NoTransaksi = '" & mNoTransaksi & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
            Return Query
        Catch ex As Exception
            Return 0
        End Try
    End Function

End Class
