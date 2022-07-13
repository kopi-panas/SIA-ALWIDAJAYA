Imports System.Data.OleDb
Public Class ClassPosting

    Private mPrive As Long
    Private mModal As Long
    Private mPeriode As String
    Private mPerubahanModal As Long
    Private mLabaRugi As Long
    Private mPeriodeBerikutnya As String

    'Memasukkan data saldo awal & saldo bulan lalu
    Public Sub InsertSaldoBulanlalu()
        mPeriode = FormPosting.cbPeriode.Text
        Try
            Query = "INSERT INTO tbl_bbjurnal SELECT tbl_saldoblnlalu.Periode, '" & "SBL-" & "' & [Periode] AS NoTransaksi, tbl_saldoblnlalu.TglTransaksi, tbl_saldoblnlalu.NoAkun, tbl_saldoblnlalu.Keterangan, tbl_saldoblnlalu.DK, tbl_saldoblnlalu.Debet, tbl_saldoblnlalu.Kredit, tbl_saldoblnlalu.Status FROM(tbl_saldoblnlalu) WHERE(((tbl_saldoblnlalu.Periode) = '" & mPeriode & "') And ((tbl_saldoblnlalu.Status) = '" & "UnPosted" & "'))"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
        Catch ex As Exception
        End Try
    End Sub

    'Memasukkan data ke buku besar
    Public Sub InsertBukuBesar()
        mPeriode = FormPosting.cbPeriode.Text
        Try
            'pengambilan data pada tabel jurnal umum
            Query = "SELECT DISTINCT tbl_jurnalumum.Periode, tbl_jurnalumum.Status FROM tbl_jurnalumum WHERE (((tbl_jurnalumum.Periode)='" & mPeriode & "') AND ((tbl_jurnalumum.Status)='" & "UnPosted" & "'))"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            'Command = New OleDbCommand(Query, CONN)
            'Rd = Command.ExecuteReader
            'Rd.Read()

            'Dim Periode As String = Rd.Item("Periode")
            'Dim Staus As String = Rd.Item("Status")
            'Dim noTransaksi As String = Rd.Item("NoTransaksi")

            'akhir pengambilan data jurnal umum

            If Ds.Tables(0).Rows.Count = 0 Then
                'InsertSaldoBulanlalu()
            Else
                'InsertSaldoBulanlalu()
                Query = "INSERT INTO tbl_bbjurnal SELECT tbl_jurnalumum.Periode, tbl_jurnalumum.NoTransaksi, tbl_jurnalumum.TglTransaksi, tbl_detailjurnal.NoAkun, tbl_jurnalumum.Keterangan, tbl_detailjurnal.DK, tbl_detailjurnal.Debet, tbl_detailjurnal.Kredit, tbl_jurnalumum.Status FROM (tbl_detailjurnal LEFT JOIN tbl_jurnalumum ON tbl_detailjurnal.NoTransaksi = tbl_jurnalumum.NoTransaksi) LEFT JOIN tbl_coa ON tbl_detailjurnal.NoAkun = tbl_coa.NoAkun WHERE (((tbl_jurnalumum.Periode)='" & mPeriode & "') AND ((tbl_jurnalumum.Status)= '" & "UnPosted" & "'))"
                Da = New OleDbDataAdapter(Query, CONN)
                Ds = New DataSet
                Da.Fill(Ds)
            End If
        Catch ex As Exception
            MsgBox("Insert Buku Besar " & ex.Message)
        End Try
    End Sub

    'Memasukkan data ke buku besar AJP
    Public Sub InsertBukuBesarAJP()
        mPeriode = FormPosting.cbPeriode.Text
        Try
            Query = "INSERT INTO tbl_bbajp SELECT tbl_jurnalajp.Periode, tbl_jurnalajp.NoTransaksi, tbl_jurnalajp.TglTransaksi, tbl_detailajp.NoAkun, tbl_jurnalajp.Keterangan, tbl_detailajp.DK, tbl_detailajp.Debet, tbl_detailajp.Kredit, tbl_jurnalajp.Status FROM (tbl_detailajp LEFT JOIN tbl_jurnalajp ON tbl_detailajp.NoTransaksi = tbl_jurnalajp.NoTransaksi) LEFT JOIN tbl_coa ON tbl_detailajp.NoAkun = tbl_coa.NoAkun WHERE (((tbl_jurnalajp.Periode) = '" & mPeriode & "') AND ((tbl_jurnalajp.Status)= '" & "UnPosted" & "'))"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
        Catch ex As Exception
            MsgBox("Inser Buku Besar AJP " & ex.Message)
        End Try
    End Sub

    'Memasukkan saldo-saldo dari buku besar ke neraca saldo
    Public Sub InsertNeracaSaldo()
        mPeriode = FormPosting.cbPeriode.Text
        Try
            Query = "INSERT INTO tbl_neracasaldo SELECT tbl_bbjurnal.Periode, tbl_bbjurnal.NoAkun, Sum(tbl_bbjurnal.Debet) AS TotalDebet, Sum(tbl_bbjurnal.Kredit) AS TotalKredit, IIf([TotalDebet]>[TotalKredit],[TotalDebet]-[TotalKredit],0) AS Saldodebet, IIf([TotalKredit]>[TotalDebet],[TotalKredit]-[TotalDebet],0) AS SaldoKredit FROM(tbl_bbjurnal) GROUP BY tbl_bbjurnal.Periode, tbl_bbjurnal.NoAkun HAVING(((tbl_bbjurnal.Periode) = '" & mPeriode & "')) ORDER BY tbl_bbjurnal.NoAkun"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
        Catch ex As Exception
            MsgBox("Insert Naraca Saldo" & ex.Message)
        End Try
    End Sub

    'Masukkan saldo-saldo dari buku besar AJP ke neraca saldo AJP
    Public Sub InsertNeracaSaldoAJP()
        mPeriode = FormPosting.cbPeriode.Text
        Try
            Query = "INSERT INTO tbl_neracasaldoajp SELECT tbl_bbajp.Periode, tbl_bbajp.NoAkun, Sum(tbl_bbajp.Debet) AS TotalDebet, Sum(tbl_bbajp.Kredit) AS TotalKredit, IIf([TotalDebet]>[TotalKredit],[TotalDebet]-[TotalKredit],0) AS mSaldoDebet, IIf([TotalKredit]>[TotalDebet],[TotalKredit]-[TotalDebet],0) AS mSaldoKredit FROM(tbl_bbajp) GROUP BY tbl_bbajp.Periode, tbl_bbajp.NoAkun HAVING(((tbl_bbajp.Periode) = '" & mPeriode & "')) ORDER BY tbl_bbajp.NoAkun"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
        Catch ex As Exception
            MsgBox("Insert Naraca Saldo AJP " & ex.Message)
        End Try
    End Sub

    'Neraca Lajur
    Public Sub InsertNeracaLajur()
        mPeriode = FormPosting.cbPeriode.Text
        Try
            Query = "INSERT INTO tbl_neracalajur SELECT tbl_neracasaldo.Periode, tbl_neracasaldo.NoAkun, tbl_neracasaldo.SaldoDebet AS DebetNS, tbl_neracasaldo.SaldoKredit AS KreditNS, IIf([tbl_neracasaldoajp].[TotalDebet]>0,[tbl_neracasaldoajp].[TotalDebet],0) AS DebetAJP, IIf([tbl_neracasaldoajp].[TotalKredit]>0,[tbl_neracasaldoajp].[TotalKredit],0) AS KreditAJP, IIf(([DebetNS]+[DebetAJP])-[KreditAJP]>0,(([DebetNS]+[DebetAJP])-([KreditNS]+[KreditAJP])),0) AS DebetNSD, IIf(([KreditNS]+[KreditAJP])-[DebetNS]+[DebetAJP]>0,(([KreditNS]+[KreditAJP])-([DebetNS]+[DebetAJP])),0) AS KreditNSD, IIf(Left(tbl_neracasaldo.NoAkun,1)= '" & "4" & "' Or Left(tbl_neracasaldo.NoAkun,1)= '" & "5" & "',[DebetNSD],0) AS DebetRL, IIf(Left(tbl_neracasaldo.NoAkun,1)= '" & "4" & "' Or Left(tbl_neracasaldo.NoAkun,1)= '" & "5" & "',[KreditNSD],0) AS KreditRL, IIf(Left([tbl_neracasaldo].[NoAkun],1)= '" & "1" & "' Or Left([tbl_neracasaldo].[NoAkun],1)= '" & "2" & "' Or Left([tbl_neracasaldo].[NoAkun],1)= '" & "3" & "',[DebetNSD],0) AS DebetNeraca, IIf(Left([tbl_neracasaldo].[NoAkun],1)= '" & "1" & "' Or Left([tbl_neracasaldo].[NoAkun],1)= '" & "2" & "' Or Left([tbl_neracasaldo].[NoAkun],1)= '" & "3" & "',[KreditNSD],0) AS KreditNeraca FROM (tbl_neracasaldo LEFT JOIN tbl_coa ON tbl_neracasaldo.NoAkun = tbl_coa.NoAkun) LEFT JOIN tbl_neracasaldoajp ON tbl_coa.NoAkun = tbl_neracasaldoajp.NoAkun WHERE(((tbl_neracasaldo.Periode) = '" & mPeriode & "')) ORDER BY tbl_neracasaldo.NoAkun"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
        Catch ex As Exception
            MsgBox("Insert Naraca Lajur " & ex.Message)
        End Try
    End Sub

    'Laporan Rugi/Laba
    Public Sub InsertRugiLaba()
        mPeriode = FormPosting.cbPeriode.Text
        Try
            'Periksa data rugi / laba ada apa tidak
            Query = "SELECT tbl_neracalajur.Periode, tbl_neracalajur.NoAkun, IIf(Left(tbl_neracalajur.NoAkun,1)= '" & "4" & "','" & "Pendapatan" & "',IIf(Left(tbl_neracalajur.NoAkun,1)='" & "5" & "','" & "Biaya-Biaya" & "','" & " " & "')) AS Keterangan, tbl_neracalajur.DebetRL AS Debet, tbl_neracalajur.KreditRL AS Kredit FROM tbl_neracalajur LEFT JOIN tbl_coa ON tbl_neracalajur.NoAkun = tbl_coa.NoAkun WHERE(((tbl_neracalajur.Periode) ='" & mPeriode & "') And ((tbl_neracalajur.NoAkun) Like '" & "4" & "%" & "' Or (tbl_neracalajur.NoAkun) Like '" & "5" & "%" & "'))"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            If Ds.Tables(0).Rows.Count = 0 Then
                Query = "INSERT INTO tbl_rugilaba Values('" & mPeriode & "', '" & "41001" & "' , '" & "Pendapatan" & "', '" & 0 & "', '" & 0 & "')"
                Da = New OleDbDataAdapter(Query, CONN)
                Ds = New DataSet
                Da.Fill(Ds)

                Query = "INSERT INTO tbl_rugilaba Values('" & mPeriode & "', '" & "51001" & "' , '" & "Biaya-Biaya" & "', '" & 0 & "', '" & 0 & "')"
                Da = New OleDbDataAdapter(Query, CONN)
                Ds = New DataSet
                Da.Fill(Ds)
            Else
                Query = "INSERT INTO tbl_rugilaba SELECT tbl_neracalajur.Periode, tbl_neracalajur.NoAkun, IIf(Left(tbl_neracalajur.NoAkun,1)= '" & "4" & "','" & "Pendapatan" & "',IIf(Left(tbl_neracalajur.NoAkun,1)='" & "5" & "','" & "Biaya-Biaya" & "','" & " " & "')) AS Keterangan, tbl_neracalajur.DebetRL AS Debet, tbl_neracalajur.KreditRL AS Kredit FROM tbl_neracalajur LEFT JOIN tbl_coa ON tbl_neracalajur.NoAkun = tbl_coa.NoAkun WHERE(((tbl_neracalajur.Periode) ='" & mPeriode & "') And ((tbl_neracalajur.NoAkun) Like '" & "4" & "%" & "' Or (tbl_neracalajur.NoAkun) Like '" & "5" & "%" & "'))"
                Da = New OleDbDataAdapter(Query, CONN)
                Ds = New DataSet
                Da.Fill(Ds)
            End If
        Catch ex As Exception
            MsgBox("Insert Rugilaba" & ex.Message)
        End Try
    End Sub

    'Perubahan Modal
    Public Sub PerubahanModal()
        mPeriode = FormPosting.cbPeriode.Text
        Try
            Query = "SELECT tbl_neracalajur.Periode, tbl_neracalajur.NoAkun, IIf(Left(tbl_neracalajur.NoAkun,1)='" & "4" & "','" & "Pendapatan" & "',IIf(Left(tbl_neracalajur.NoAkun,1)= '" & "5" & "','" & "Biaya-Biaya" & "','" & "" & "')) AS Keterangan, tbl_neracalajur.DebetRL AS Debet, tbl_neracalajur.KreditRL AS Kredit FROM tbl_neracalajur LEFT JOIN tbl_coa ON tbl_neracalajur.NoAkun = tbl_coa.NoAkun WHERE(((tbl_neracalajur.Periode) = '" & mPeriode & "') And ((tbl_neracalajur.NoAkun) Like '" & "4" & "%" & "' Or (tbl_neracalajur.NoAkun) Like '" & "5" & "%" & "'))"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            If Ds.Tables(0).Rows.Count = 0 Then
                mPeriode = FormPosting.cbPeriode.Text
                mLabaRugi = 0
                Query = "INSERT INTO tbl_perubahanmodal(Periode, LabaBersih) VALUES('" & mPeriode & "','" & mLabaRugi & "')"
                Da = New OleDbDataAdapter(Query, CONN)
                Ds = New DataSet
                Da.Fill(Ds)
            Else
                Query = "INSERT INTO tbl_perubahanmodal SELECT tbl_neracalajur.Periode, Sum([KreditRL])-Sum([DebetRL]) AS LabaBersih FROM tbl_neracalajur LEFT JOIN tbl_coa ON tbl_neracalajur.NoAkun = tbl_coa.NoAkun GROUP BY tbl_neracalajur.Periode HAVING (((tbl_neracalajur.Periode)='" & mPeriode & "'))"
                Da = New OleDbDataAdapter(Query, CONN)
                Ds = New DataSet
                Da.Fill(Ds)
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Update Prive
    Public Sub UpdatePrive()
        mPeriode = FormPosting.cbPeriode.Text
        Try
            Query = "SELECT tbl_neracalajur.Periode, IIf([DebetNeraca]>0,[DebetNeraca],0) AS Prive FROM tbl_neracalajur LEFT JOIN tbl_coa ON tbl_neracalajur.NoAkun = tbl_coa.NoAkun GROUP BY tbl_neracalajur.Periode, tbl_neracalajur.NoAkun, IIf([DebetNeraca]>0,[DebetNeraca],0) HAVING(((tbl_neracalajur.Periode) = '" & mPeriode & "') And ((tbl_neracalajur.NoAkun) = '" & "32010" & "'))"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            If Ds.Tables(0).Rows.Count = 0 Then
                mPrive = 0
            Else
                mPrive = Ds.Tables(0).Rows(0).Item(1)
            End If
            Query = "UPDATE tbl_perubahanmodal SET prive = '" & mPrive & "' WHERE Periode = '" & mPeriode & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
        Catch ex As Exception
        End Try
    End Sub

    'Neraca
    Public Sub NilaiNeraca()
        mPeriode = FormPosting.cbPeriode.Text
        Try
            Query = "INSERT INTO tbl_neraca SELECT tbl_neracalajur.Periode, IIf(Left(tbl_neracalajur.NoAkun,1)='" & "1" & "','" & "Aktiva" & "','" & "Pasiva" & "') AS Judul1, IIf(Left(tbl_neracalajur.NoAkun,2)='" & "11" & "','" & "Aktiva Lancar" & "',IIf(Left(tbl_neracalajur.NoAkun,2)='" & "12" & "','" & "Aktiva Tidak Lancar" & "',IIf(Left(tbl_neracalajur.NoAkun,1)='" & "2" & "','" & "Hutang" & "',IIf(Left(tbl_neracalajur.NoAkun,1)='" & "3" & "','" & "Modal" & "' ,'" & " " & "')))) AS Judul2, IIf(Left(tbl_neracalajur.NoAkun,2)='" & "11" & "','" & " " & "',IIf(Left(tbl_neracalajur.NoAkun,2)='" & "12" & "','" & " " & "',IIf(Left(tbl_neracalajur.NoAkun,2)='" & "21" & "','" & "Hutang Jangka Pendek" & "',IIf(Left(tbl_neracalajur.NoAkun,2)='" & "22" & "' ,'" & "Hutang Jangka Panjang" & "',IIf(Left(tbl_neracalajur.NoAkun,2)='" & "31" & "','" & "Modal" & "',IIf(Left(tbl_neracalajur.NoAkun,2)='" & "32" & "','" & "Prive" & "','" & " " & "')))))) AS Judul3, tbl_neracalajur.NoAkun, [DebetNeraca]+[KreditNeraca] AS Nominal, IIf([NoAkun]='" & "32010" & "',-[Nominal],[Nominal]) AS Nilai FROM(tbl_neracalajur) WHERE (((tbl_neracalajur.Periode)='" & mPeriode & "') AND ((tbl_neracalajur.NoAkun) Like '" & "1" & "%" & "' Or (tbl_neracalajur.NoAkun) Like '" & "2" & "%" & "' Or (tbl_neracalajur.NoAkun) Like '" & "3" & "%" & "'))"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
        Catch ex As Exception
        End Try
    End Sub

    'Update Nilai Neraca dengan nilai Akumulasi Penyusutan
    Public Sub NilaiNeracaAkumulasi()
        Try
            mPeriode = FormPosting.cbPeriode.Text
            Query = "UPDATE (tbl_neraca LEFT JOIN tbl_coa ON tbl_neraca.NoAkun = tbl_coa.NoAkun) LEFT JOIN tbl_neracalajur ON tbl_neraca.NoAkun = tbl_neracalajur.NoAkun SET tbl_neraca.Nominal = -[tbl_neracalajur].[KreditNSD], tbl_neraca.Nilai = -[tbl_neracalajur].[KreditNSD] WHERE (((tbl_coa.Keterangan)='" & "Ya" & "') AND ((tbl_neraca.Periode)='" & mPeriode & "'));"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
        Catch ex As Exception
        End Try
    End Sub


    'UpDate Modal di Tabel perubahan modal dari neraca
    Public Sub UpdateModal()
        mPeriode = FormPosting.cbPeriode.Text
        Try
            Query = "SELECT DISTINCT tbl_neraca.Periode, tbl_neraca.NoAkun, tbl_neraca.Nominal FROM(tbl_neraca) WHERE(((tbl_neraca.Periode) = '" & mPeriode & "') And ((tbl_neraca.NoAkun) = '" & "31001" & "'))"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            If Ds.Tables(0).Rows.Count = 0 Then
                mModal = 0
            Else
                mModal = Ds.Tables(0).Rows(0).Item(2)
            End If

            Query = "UPDATE tbl_perubahanmodal SET Modal = '" & mModal & "' WHERE Periode = '" & mPeriode & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
        Catch ex As Exception
        End Try
    End Sub


    'Update Laba tidak dibagi ke tabel neraca
    Public Sub InsertLabaTakDibagi()
        mPeriode = FormPosting.cbPeriode.Text
        Dim mNilai As Long
        Dim mLabaBersih As Long

        Try
            'Tanpa saldo awal di master perkiraan
            Query = "SELECT tbl_neracalajur.Periode, Sum([KreditRL])-Sum([DebetRL]) AS LabaBersih FROM tbl_neracalajur LEFT JOIN tbl_coa ON tbl_neracalajur.NoAkun=tbl_coa.NoAkun GROUP BY tbl_neracalajur.Periode HAVING (((tbl_neracalajur.Periode)='" & mPeriode & "'))"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            If Ds.Tables(0).Rows.Count = 0 Then
                mLabaBersih = 0
            Else
                mLabaBersih = Ds.Tables(0).Rows(0).Item(1)
            End If

            mNilai = mLabaBersih
            Query = "INSERT INTO tbl_neraca (Periode, Judul1, Judul2, Judul3, NoPerkiraan, Nominal, Nilai)  VALUES('" & mPeriode & "', '" & "Pasiva" & "' , '" & "Modal" & "', '" & "Rugi/Laba bersih" & "',  '" & "31002" & "', '" & mLabaBersih & "', '" & mNilai & "')"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
        Catch ex As Exception
        End Try
    End Sub

    'Update UnPosted menjadi Posted pada tabel saldo awal
    Public Sub UpDateSaldoAwal()
        mPeriode = FormPosting.cbPeriode.Text
        Try
            Query = "UPDATE tbl_saldoblnlalu SET Status = '" & "Posted" & "' WHERE Periode = '" & mPeriode & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
        Catch ex As Exception
        End Try
    End Sub

    'Insert keterangan pada tabel tblStatusSetUpSaldoAwal
    Public Sub InsertKeteranganSaldoAwal()
        mPeriode = FormPosting.cbPeriode.Text
        Try
            Query = "SELECT * FROM tbl_setupsaldoawal"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            If Ds.Tables(0).Rows.Count = 0 Then
                Query = "INSERT INTO tbl_setupsaldoawal VALUES('" & "Posted" & "')"
                Da = New OleDbDataAdapter(Query, CONN)
                Ds = New DataSet
                Da.Fill(Ds)
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Mutasi Saldo , menjadi saldo awal di periode berikutnya
    Public Sub SaldoBulanLalu()
        mPeriode = FormPosting.cbPeriode.Text
        mPeriodeBerikutnya = FormPosting.lblPeriodeBerikutnya.Text
        Try
            'Memasukkan saldo bulan lalu
            Query = "INSERT INTO tbl_saldoblnlalu SELECT tbl_neracalajur.Periode, tbl_coa.SampaiTgl AS TglTransaksi, tbl_neracalajur.NoAkun, IIf([DebetNeraca]>[KreditNeraca],'" & "D" & "',IIf([DebetNeraca]=0 And [KreditNeraca]=0,'" & "D" & "','" & "K" & "')) AS DK, tbl_neracalajur.DebetNeraca AS Debet, tbl_neracalajur.KreditNeraca AS Kredit, '" & "UnPosted" & "' AS Status, '" & "Saldo bulan lalu" & "' AS Keterangan FROM tbl_neracalajur LEFT JOIN tbl_coa ON tbl_neracalajur.Periode = tbl_periode.Periode GROUP BY tbl_neracalajur.Periode, tbl_periode.SampaiTgl, tbl_neracalajur.NoAkun, IIf([DebetNeraca]>[KreditNeraca],'" & "D" & "',IIf([DebetNeraca]=0 And [KreditNeraca]=0,'" & "D" & "','" & "K" & "')), tbl_neracalajur.DebetNeraca, tbl_neracalajur.KreditNeraca, '" & "UnPosted" & "', '" & "Saldo bulan lalu" & "'  HAVING (((tbl_neracalajur.Periode)= '" & mPeriode & "') AND ((tbl_neracalajur.NoAkun) Like '" & "1" & "%" & "' Or (tbl_neracalajur.NoAkun) Like '" & "2" & "%" & "' Or (tbl_neracalajur.NoAkun)='" & "31001" & "'))"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            'Update periode menjadi periode berikutnya
            Query = "UPDATE tbl_saldoblnlalu SET Periode = '" & mPeriodeBerikutnya & "' WHERE Periode = '" & mPeriode & "' And Status = '" & "UnPosted" & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            'Mengambil data perubahan modal
            Query = "SELECT tbl_perubahanmodal.Periode, [Modal]+([LabaBersih]-[Prive]) AS LabaDitahan FROM tbl_perubahanmodal WHERE (((tbl_perubahanmodal.Periode)= '" & mPeriode & "'))"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            If Ds.Tables(0).Rows.Count = 0 Then
                mPerubahanModal = 0
            Else
                mPerubahanModal = Ds.Tables(0).Rows(0).Item(1)
            End If

            'Update Modal dengan data perubahan ekuitas
            Query = "UPDATE tbl_saldoblnlalu SET Kredit = '" & mPerubahanModal & "' WHERE Periode = '" & mPeriodeBerikutnya & "' And Status = '" & "UnPosted" & "' AND NoAkun = '" & "31001" & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            'Buat status dari unposted menjadi posted pada tabel
            'HJurnal, HJurnalAJP, MasterPeriode, BukuBesar, BukuBEsarAJP
            Query = "UPDATE tbl_jurnalumum SET Status = '" & "Posted" & "' WHERE Periode = '" & mPeriode & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            Query = "UPDATE tbl_jurnalajp SET Status = '" & "Posted" & "' WHERE Periode = '" & mPeriode & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            Query = "UPDATE tbl_bbjurnal SET Status = '" & "Posted" & "' WHERE Periode = '" & mPeriode & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            Query = "UPDATE tbl_bbajp SET Status = '" & "Posted" & "' WHERE Periode = '" & mPeriode & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)

            Query = "UPDATE tbl_periode SET Keterangan = '" & "Posted" & "' WHERE Periode = '" & mPeriode & "'"
            Da = New OleDbDataAdapter(Query, CONN)
            Ds = New DataSet
            Da.Fill(Ds)
        Catch ex As Exception
        End Try
    End Sub

End Class
