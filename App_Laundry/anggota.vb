Imports System.Data.SqlClient
Public Class anggota
    Dim selrow As String
    Public Sub kosong()
        txtkode.Text = ""
        txtnama.Text = ""
        cmbjeniskel.Text = ""
        txtalamat.Text = ""
        txthp.Text = ""
        selrow = ""

        txtkode.MaxLength = 10
        txtnama.MaxLength = 30
        cmbjeniskel.MaxLength = 15
        txtalamat.MaxLength = 50
        txthp.MaxLength = 15
    End Sub
    Sub TampilGrid()
        Dim tampil As String = "SELECT * FROM anggota"
        Dim da As New SqlDataAdapter(tampil, koneksi)
        Dim dt As New DataTable
        Dim ds As New DataSet
        da.Fill(ds)
        For Each dt In ds.Tables
            dganggota.DataSource = dt
        Next
        dganggota.AutoResizeColumns()
        dganggota.AutoGenerateColumns = True
        dganggota.ReadOnly = True
        dganggota.RowHeadersVisible = False
        dganggota.Columns(0).Width = 150
        dganggota.Columns(0).HeaderText = "Kode Anggota"
        dganggota.Columns(1).Width = 150
        dganggota.Columns(1).HeaderText = "Nama"
        dganggota.Columns(2).Width = 100
        dganggota.Columns(2).HeaderText = "Jenis-Kelamin"
        dganggota.Columns(3).Width = 150
        dganggota.Columns(3).HeaderText = "Alamat"
        dganggota.Columns(4).Width = 90
        dganggota.Columns(4).HeaderText = "No HP"
        dganggota.Refresh()
    End Sub

    Sub kodeanggotaOtomatis()
        Dim dr As DataRow
        dr = SqlTable("SELECT MAX (RIGHT (idanggota, 4)) AS Nomor FROM anggota").Rows(0)
        If dr.IsNull("Nomor") Then
            txtkode.Text = "0001"
        Else
            txtkode.Text = Format(dr("Nomor") + 1, "0000")
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub anggota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bukakoneksi()
        TampilGrid()
        kodeanggotaOtomatis()
    End Sub
    Private Sub btnreset_Click(sender As Object, e As EventArgs) Handles btnreset.Click
        kosong()
        kodeanggotaOtomatis()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If txtkode.Text = "" Or txtnama.Text = "" Or cmbjeniskel.Text = "" Or txtalamat.Text = "" Or txthp.Text = "" Then
            MsgBox("Data Belum Lengkap", MsgBoxStyle.Information, "INFORMASI")
        Else
            Dim cmd As SqlCommand
            cmd = New SqlCommand("INSERT INTO anggota (idanggota, Nama, Jenis_Kelamin, Alamat, No_HP) " &
                               "VALUES ('" & txtkode.Text & "', '" & txtnama.Text & "', '" & cmbjeniskel.Text & "', '" & txtalamat.Text & "', '" & txthp.Text & "')", koneksi)
            cmd.ExecuteNonQuery()
            TampilGrid()
            kosong()
            kodeanggotaOtomatis()
            MsgBox("Data Berhasil DiSimpan", MsgBoxStyle.Information, "INFORMASI")
        End If
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        If selrow = "" Then
            MsgBox("Data harus di-Isi", MsgBoxStyle.Information, "INFORMASI")
        ElseIf MsgBox("Yakin Data anggota akan diHapus..?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim cmd As SqlCommand
            cmd = New SqlCommand("DELETE FROM anggota WHERE idanggota = '" & txtkode.Text & "'", koneksi)
            cmd.ExecuteNonQuery()
            TampilGrid()
            kosong()
            kodeanggotaOtomatis()
            MsgBox("Data Berhasil DiHapus", MsgBoxStyle.Information, "INFORMASI")
        End If
    End Sub

    Private Sub dganggota_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dganggota.CellMouseClick
        selrow = dganggota.SelectedRows.Item(0).Cells("idanggota").Value
        txtkode.Text = dganggota.SelectedRows.Item(0).Cells("idanggota").Value
        txtnama.Text = dganggota.SelectedRows.Item(0).Cells("Nama").Value
        cmbjeniskel.Text = dganggota.SelectedRows.Item(0).Cells("Jenis_Kelamin").Value
        txtalamat.Text = dganggota.SelectedRows.Item(0).Cells("Alamat").Value
        txthp.Text = dganggota.SelectedRows.Item(0).Cells("No_HP").Value
    End Sub

    Private Sub cmbjeniskel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbjeniskel.SelectedIndexChanged
        txtalamat.Focus()
    End Sub

    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        If selrow = "" Then
            MsgBox("Anda Belum Memilih Data yang Ingin di Edit", MsgBoxStyle.Critical)
        Else
            Dim cmd As SqlCommand
            cmd = New SqlCommand("UPDATE anggota SET Nama = '" & txtnama.Text & "', Jenis_Kelamin = '" & cmbjeniskel.Text & "', Alamat = '" & txtalamat.Text & "', No_HP = '" & txthp.Text & "' WHERE idanggota = '" & selrow & "'", koneksi)
            cmd.ExecuteNonQuery()
            TampilGrid()
            kosong()
            MsgBox("Data Berhasil DiUpdate", MsgBoxStyle.Information, "INFORMASI")
        End If
    End Sub

    Private Sub txtcari_TextChanged(sender As Object, e As EventArgs) Handles txtcari.TextChanged
        Dim cari As String
        If txtcari.Text = "" Then
            cari = "SELECT * FROM anggota"
            dganggota.DataSource = SqlTable(cari)
        Else
            cari = "SELECT * FROM anggota WHERE Nama LIKE '%" & txtcari.Text & "%'"
            dganggota.DataSource = SqlTable(cari)
        End If
    End Sub
End Class
