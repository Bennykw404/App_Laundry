Imports System.Data.SqlClient
Public Class Pegawai
    Dim selrow As String

    Sub kodepegawaiOtomatis()
        Dim dr As DataRow
        dr = SqlTable("SELECT MAX (RIGHT (idpegawai, 4)) AS Nomor FROM pegawai").Rows(0)
        If dr.IsNull("Nomor") Then
            txtkode.Text = "0001"
        Else
            txtkode.Text = Format(dr("Nomor") + 1, "0000")
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Sub kosongkan()
        txtkode.Text = ""
        txtnama.Text = ""
        cmbjabatan.Text = ""
        txtalamat.Text = ""
        selrow = ""

        txtkode.MaxLength = 10
        txtnama.MaxLength = 30
        cmbjabatan.MaxLength = 15
        txtalamat.MaxLength = 50
    End Sub
    Sub TampilGrid()
        Dim tampil As String = "SELECT * FROM Pegawai"
        Dim da As New SqlDataAdapter(tampil, koneksi)
        Dim dt As New DataTable
        Dim ds As New DataSet
        da.Fill(ds)
        For Each dt In ds.Tables
            dgpegawai.DataSource = dt
        Next
        dgpegawai.AutoResizeColumns()
        dgpegawai.AutoGenerateColumns = True
        dgpegawai.ReadOnly = True
        dgpegawai.RowHeadersVisible = False
        dgpegawai.Columns(0).Width = 150
        dgpegawai.Columns(0).HeaderText = "Kode pegawai"
        dgpegawai.Columns(2).Width = 200
        dgpegawai.Columns(2).HeaderText = "Nama"
        dgpegawai.Columns(1).Width = 100
        dgpegawai.Columns(1).HeaderText = "Jabatan"
        dgpegawai.Columns(3).Width = 200
        dgpegawai.Columns(3).HeaderText = "Alamat"
        dgpegawai.Refresh()
    End Sub
    Public Sub jabatan()
        Dim cmd As SqlCommand
        Dim rd As SqlDataReader
        cmd = New SqlCommand("SELECT DISTINCT Jabatan FROM Jabatan", koneksi)
        rd = cmd.ExecuteReader
        Do While rd.Read
            cmbjabatan.Items.Add(rd.Item("Jabatan"))
        Loop
    End Sub

    Private Sub pegawai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bukakoneksi()
        TampilGrid()
        kodepegawaiOtomatis()
        jabatan()
    End Sub

    Private Sub btnreset_Click(sender As Object, e As EventArgs) Handles btnreset.Click
        Call kosongkan()
        'Call tidakaktif()
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        If txtkode.Text = "" Then
            MsgBox("Id harus di-Isi", MsgBoxStyle.Information, "INFORMASI")
            txtkode.Focus()
            Exit Sub
        ElseIf MsgBox("Yakin Data pegawai akan diHapus..?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim cmd As SqlCommand
            cmd = New SqlCommand("DELETE FROM Pegawai WHERE idpegawai = '" & txtkode.Text & "'", koneksi)
            cmd.ExecuteNonQuery()
            TampilGrid()
            kosongkan()
            MsgBox("Data Berhasil DiHapus", MsgBoxStyle.Information, "INFORMASI")
        End If
    End Sub

    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        If selrow = "" Then
            MsgBox("Anda Belum Memilih Data yang Ingin di Edit", MsgBoxStyle.Critical)
        Else
            'mengedit data
            Dim cmd As SqlCommand
            cmd = New SqlCommand("UPDATE Pegawai SET nama = '" & txtnama.Text & "', Jabatan = '" & cmbjabatan.Text & "', Alamat = '" & txtalamat.Text & "' WHERE idpegawai = '" & selrow & "'", koneksi)
            cmd.ExecuteNonQuery()
            TampilGrid()
            kosongkan()
            MsgBox("Data Berhasil DiUpdate", MsgBoxStyle.Information, "INFORMASI")
        End If
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If txtkode.Text = "" Or txtnama.Text = "" Or cmbjabatan.Text = "" Or txtalamat.Text = "" Then
            MsgBox("Data Belum Lengkap", MsgBoxStyle.Information, "INFORMASI")
        Else
            Dim cmd As SqlCommand
            cmd = New SqlCommand("INSERT INTO Pegawai (idpegawai, nama, Jabatan, Alamat) " &
                                   "VALUES ('" & txtkode.Text & "', '" & txtnama.Text & "', '" & cmbjabatan.Text & "', '" & txtalamat.Text & "')", koneksi)
            cmd.ExecuteNonQuery()
            TampilGrid()
            kosongkan()
            MsgBox("Data Berhasil DiSimpan", MsgBoxStyle.Information, "INFORMASI")
        End If
    End Sub

    Private Sub dgpegawai_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgpegawai.CellMouseClick
        selrow = dgpegawai.SelectedRows.Item(0).Cells("idpegawai").Value
        txtkode.Text = dgpegawai.SelectedRows.Item(0).Cells("idpegawai").Value
        txtnama.Text = dgpegawai.SelectedRows.Item(0).Cells("nama").Value
        cmbjabatan.Text = dgpegawai.SelectedRows.Item(0).Cells("Jabatan").Value
        txtalamat.Text = dgpegawai.SelectedRows.Item(0).Cells("Alamat").Value
    End Sub

    Private Sub txtcari_TextChanged(sender As Object, e As EventArgs) Handles txtcari.TextChanged
        Dim cari As String
        If txtcari.Text = "" Then
            cari = "SELECT * FROM pegawai"
            dgpegawai.DataSource = SqlTable(cari)
        Else
            cari = "SELECT * FROM pegawai WHERE Nama LIKE '%" & txtcari.Text & "%'"
            dgpegawai.DataSource = SqlTable(cari)
        End If
    End Sub
End Class