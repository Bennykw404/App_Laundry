Imports System.Data.SqlClient
Public Class Flogin
    Dim user As String
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MsgBox("Yakin ingin Tutup Aplikasi..?", MsgBoxStyle.YesNo, "INFORMASI") = MsgBoxResult.Yes Then
        ElseIf koneksi.State = ConnectionState.Open Then
            koneksi.Close()
        End If
        Application.Exit()
    End Sub
    Private Sub txtUsername_Leave(sender As Object, e As EventArgs) Handles txtUsername.Leave
        If txtUsername.Text = "Username" Or txtUsername.Text = "" Then
            txtUsername.Text = "Username"
            txtUsername.ForeColor = Color.Silver
        End If
    End Sub
    Private Sub txtUsername_MouseClick(sender As Object, e As MouseEventArgs) Handles txtUsername.MouseClick
        If txtUsername.Text = "Username" Then
            txtUsername.Clear()
            txtUsername.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtPassword_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave
        If txtPassword.Text = "Password" Or txtPassword.Text = "" Then
            txtPassword.Text = "Password"
            txtPassword.ForeColor = Color.Silver
        End If
    End Sub
    Private Sub txtPassword_MouseClick(sender As Object, e As MouseEventArgs) Handles txtPassword.MouseClick
        If txtPassword.Text = "Password" Then
            txtPassword.Clear()
            txtPassword.ForeColor = Color.Black
            txtPassword.PasswordChar = "*"
        End If
    End Sub

    Private Sub btnMasuk_Click(sender As Object, e As EventArgs) Handles btnMasuk.Click
        bukakoneksi()
        Dim cmd As SqlCommand
        Dim rd As SqlDataReader
        cmd = New SqlCommand("SELECT * FROM users WHERE Username = '" & txtUsername.Text & "'", koneksi)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            If txtPassword.Text = rd.Item("Password") Then
                If rd.Item("Jenis_User") = "Manager" Then
                    user = "Manager"
                    txtUsername.Text = ""
                    txtPassword.Text = ""
                    MsgBox("Selamat Datang " & rd.Item("Nama"), MsgBoxStyle.MsgBoxSetForeground)
                    MenuUtama.Show()
                    MenuUtama.Panel.Text = rd.Item("Jenis_User")
                    MenuUtama.Panel2.Text = rd.Item("Nama")
                    MenuUtama.Panel3.Text = rd.Item("Username")
                    Me.Hide()
                ElseIf rd.Item("Jenis_User") = "Kasir" Then
                    user = "kasir"
                    txtUsername.Text = ""
                    txtPassword.Text = ""
                    MsgBox("Selamat Datang " & rd.Item("Nama"), MsgBoxStyle.MsgBoxSetForeground)
                    MenuUtama.Show()
                    hakakses()
                    MenuUtama.Panel.Text = rd.Item("Jenis_User")
                    MenuUtama.Panel2.Text = rd.Item("Nama")
                    MenuUtama.Panel3.Text = rd.Item("Username")
                    Me.Hide()
                End If
            Else
                MsgBox("Username dan Password Tidak Cocok", MsgBoxStyle.Information)
                txtUsername.Text = ""
                txtPassword.Text = ""
                txtUsername.Focus()
            End If
        Else
            MsgBox("Username Tidak Ada", MsgBoxStyle.Information)
            txtUsername.Text = ""
            txtPassword.Text = ""
            txtUsername.Focus()
        End If
    End Sub

    Sub hakakses()
        MenuUtama.btnTambahAnggota.Enabled = False
        MenuUtama.btnLapAnggota.Enabled = False
        MenuUtama.btnLapKembalian.Enabled = False
        MenuUtama.btnLapPegawai.Enabled = False
        MenuUtama.btnLapPemasukan.Enabled = False
        MenuUtama.btnLapKonsumen.Enabled = False
        MenuUtama.btnLapSerah.Enabled = False
    End Sub
End Class
