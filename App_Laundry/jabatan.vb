Imports System.Data.SqlClient
Public Class jabatan
    Dim selrow = ""
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub
    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Sub KondisiAwal()
        txtKode.Text = ""
        txtJabatan.Text = ""
        selrow = ""
    End Sub

    Private Sub FormJabatan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bukakoneksi()
        Call tampilGrid()
    End Sub

    Public Sub tampilGrid()
        Dim tampil As String = "SELECT * FROM Jabatan"
        Dim da As New SqlDataAdapter(tampil, koneksi)
        Dim dt As New DataTable
        Dim ds As New DataSet
        da.Fill(ds)
        For Each dt In ds.Tables
            dgJabatan.DataSource = dt
        Next
        dgJabatan.AutoResizeColumns()
        dgJabatan.AutoGenerateColumns = True
    End Sub
    Private Sub btnreset_Click(sender As Object, e As EventArgs) Handles btnreset.Click
        Call KondisiAwal()
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        If selrow = "" Then
            MsgBox("Data harus di-Isi", MsgBoxStyle.Information, "INFORMASI")
        ElseIf MsgBox("Yakin Data Jabatan akan diHapus..?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim cmd As SqlCommand
            cmd = New SqlCommand("DELETE FROM jabatan WHERE kode_jabatan = '" & txtKode.Text & "'", koneksi)
            cmd.ExecuteNonQuery()
            tampilGrid()
            KondisiAwal()
            MsgBox("Data Berhasil DiHapus", MsgBoxStyle.Information, "INFORMASI")
        End If
    End Sub
    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        If selrow = "" Then
            MsgBox("Anda Belum Memilih Data yang Ingin di Edit", MsgBoxStyle.Critical)
        Else
            Dim cmd As SqlCommand
            cmd = New SqlCommand("UPDATE jabatan SET Nama = '" & txtJabatan.Text & "'WHERE kode_jabatan= '" & selrow & "'", koneksi)
            cmd.ExecuteNonQuery()
            tampilGrid()
            KondisiAwal()
            MsgBox("Data Berhasil DiUpdate", MsgBoxStyle.Information, "INFORMASI")
        End If
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If txtKode.Text = "" Or txtJabatan.Text = "" Then
            MsgBox("Data Belum Lengkap", MsgBoxStyle.Critical)
        Else
            'menyimpan data ke dalam database
            Dim cmd As SqlCommand
            cmd = New SqlCommand("INSERT INTO Jabatan (Kode_Jabatan, Jabatan) " &
                                   "VALUES ('" & txtKode.Text & "', '" & txtJabatan.Text & "')", koneksi)
            cmd.ExecuteNonQuery()
            tampilGrid()
            KondisiAwal()
            txtKode.Focus()
            MsgBox("Data Berhasil DiSimpan", MsgBoxStyle.Information, "INFORMASI")
        End If
    End Sub

    Private Sub dgJabatan_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgJabatan.CellClick
        Dim i As Integer
        i = dgJabatan.CurrentRow.Index

        txtKode.Text = dgJabatan.Item(0, i).Value
        txtJabatan.Text = dgJabatan.Item(1, i).Value
    End Sub

End Class