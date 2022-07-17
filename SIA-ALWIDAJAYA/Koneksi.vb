Imports System.Data.OleDb
Module Koneksi
    Public CONN As OleDbConnection
    Public Da As OleDbDataAdapter
    Public Ds As DataSet
    Public Command As OleDbCommand
    Public Rd As OleDbDataReader
    Public Query As String

    Public DaDebetKredit As OleDbDataAdapter
    Public DsDebetKredit As DataSet
    Public QueryDebetKredit As String

    Public LokasiData As String

    Public Sub BukaKoneksi()
        LokasiData = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_akuntansi.mdb;"
        CONN = New OleDbConnection(LokasiData)
        If CONN.State = ConnectionState.Closed Then CONN.Open()
    End Sub

End Module
