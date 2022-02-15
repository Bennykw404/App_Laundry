Imports System.Data.SqlClient
Public Class user

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
    Public Sub awal()
        txtnama.Text = ""
        txtuser.Text = ""
        txtpass.Text = ""
        cmbjenis.Text = ""
        txtnama.Focus()
    End Sub
    Public Sub tampiluser()
        Try
            Dim tampil As String = "SELECT * FROM Users"
            Dim da As New SqlDataAdapter(tampil, koneksi)
            Dim ds As New DataSet
            Dim dt As New DataTable
            da.Fill(ds)
            For Each dt In ds.Tables
                dgusers.DataSource = dt
            Next
            dgusers.AutoResizeColumns()
            dgusers.Columns("Password").Visible = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub FormUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bukakoneksi()
        tampiluser()
    End Sub
    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If txtnama.Text = "" Or txtuser.Text = "" Or txtpass.Text = "" Or cmbjenis.Text = "" Then
            MsgBox("Data Belum Lengkap", MsgBoxStyle.Critical)
        Else
            'menyimpan data
            Dim cmd As SqlCommand
            cmd = New SqlCommand("INSERT INTO Users ([Nama], [Username], [Password], [Jenis_User]) " &
                                   "VALUES ('" & txtnama.Text & "', '" & txtuser.Text & "', '" & txtpass.Text & "', '" & cmbjenis.Text & "')", koneksi)
            cmd.ExecuteNonQuery()
            awal()
            tampiluser()
            MsgBox("Data Berhasil DiSimpan", MsgBoxStyle.Information, "INFORMASI")
        End If
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        If txtnama.Text = "" Then
            MsgBox("Id harus di-Isi", MsgBoxStyle.Information, "INFORMASI")
            txtnama.Focus()
            Exit Sub
        End If

        If MsgBox("Yakin Data anggota akan diHapus..?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim cmd As SqlCommand
            cmd = New SqlCommand("DELETE * FROM Users WHERE Nama = '" & txtnama.Text & "'", koneksi)
            cmd.ExecuteNonQuery()
            tampiluser()
            awal()
        End If
    End Sub
    Private Sub btnreset_Click(sender As Object, e As EventArgs) Handles btnreset.Click
        awal()
    End Sub

    Private Sub dgusers_DoubleClick(sender As Object, e As EventArgs) Handles dgusers.DoubleClick
        txtnama.Text = dgusers.SelectedRows.Item(0).Cells("Nama").Value
        txtuser.Text = dgusers.SelectedRows.Item(0).Cells("Username").Value
        txtpass.Text = dgusers.SelectedRows.Item(0).Cells("Password").Value
        cmbjenis.Text = dgusers.SelectedRows.Item(0).Cells("Jenis_User").Value
    End Sub
End Class