Imports System.Data.SqlClient
Public Class gantipassword
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
    Private Sub gantipassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        kondisiawal()
    End Sub

    Sub kondisiawal()
        txtKode.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        txtKode.Enabled = True
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        txtKode.PasswordChar = "*"
        TextBox1.PasswordChar = "*"
        TextBox2.PasswordChar = "*"
    End Sub

    Private Sub txtKode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKode.KeyPress
        Dim cmd As SqlCommand
        Dim rd As SqlDataReader
        If e.KeyChar = Chr(13) Then
            bukakoneksi()
            cmd = New SqlCommand("SELECT * FROM users where Username ='" & MenuUtama.btnGntiPassword.Text & "' and Password='" & TextBox1.Text & "'", koneksi)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                TextBox1.Enabled = True
                TextBox2.Enabled = True
                txtKode.Enabled = False
                TextBox1.Focus()
            Else
                MsgBox("Password Lama Salah")
                TextBox1.Text = ""
            End If
        End If
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Password Baru Harus Di-isi")
        Else
            If TextBox1.Text <> TextBox2.Text Then
                MsgBox("Password Baru dan Konfirmasi Harus Sama ! ")
            Else
                bukakoneksi()
                Dim cmd As SqlCommand
                Dim editpass As String = "update users set password='" & TextBox1.Text & "'  where password = '" & MenuUtama.btnGntiPassword.Text & "'"
                cmd = New SqlCommand(editpass, koneksi)
                cmd.ExecuteNonQuery()
                MsgBox("Update Passqord Berhasil")
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class