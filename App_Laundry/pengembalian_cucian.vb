
Imports System.Data.SqlClient
Public Class pengembalian_cucian

    Dim sisa As String = ""

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
    Sub awal()
        txtfaktur.Text = ""
        txtfaktur.Focus()
        txtkons.Text = ""
        txtberat.Text = ""
        txtpakaian.Text = ""
        txtharga.Text = ""
        txtdiskon.Text = ""
        txtpanjar.Text = ""
        cmbket.Text = ""
        rdobukan.Checked = True
        cmbkode.Text = ""
        cmbanggota.Text = ""
        txtbayar.Text = ""
        txtsisa.Text = ""
    End Sub
    Public Sub cekfaktur()
        Dim cmd As SqlCommand
        Dim rd As SqlDataReader
        cmd = New SqlCommand("SELECT * FROM Penyerahan_Cucian WHERE Faktur ='" & txtfaktur.Text & "'", koneksi)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            txtkons.Text = rd.Item("Konsumen")
            txtberat.Text = rd.Item("Berat_Cucian")
            txtpakaian.Text = rd.Item("Jumlah_Pakaian")
            txtharga.Text = rd.Item("Harga")
            txtdiskon.Text = rd.Item("Diskon")
            txtpanjar.Text = rd.Item("Panjar")
            txtbayar.Text = rd.Item("Total_Bayar")
            txtsisa.Text = rd.Item("Sisa")
            sisa = txtsisa.Text
            cmbket.Text = rd.Item("Keterangan")
            If rd.Item("Diskon") = "15" Then
                txtkons.Text = ""
                cmbanggota.Text = rd.Item("Konsumen")
            Else
                txtkons.Text = rd.Item("Konsumen")
                cmbkode.Text = ""
                cmbanggota.Text = ""
            End If
            If cmbanggota.Text = "" Then
                cmbkode.Text = ""
            Else
                bukakoneksi()
                cmd = New SqlCommand("SELECT * FROM Anggota WHERE nama = '" & cmbanggota.Text & "'", koneksi)
                rd = cmd.ExecuteReader
                rd.Read()
                If rd.HasRows Then
                    cmbkode.Text = rd.Item("idanggota")
                End If
            End If
        Else
            MsgBox("Faktur Tidak Terdaftar", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Sub txtfaktur_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtfaktur.KeyPress
        If e.KeyChar = Chr(13) Then 'jika user menekan enter
            cekfaktur()
        End If
    End Sub

    Private Sub FormPengembalian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bukakoneksi()
        lbltanggal.Text = Now.Date
    End Sub

    Private Sub cmbket_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbket.SelectedIndexChanged
        If cmbket.Text = "Lunas" Then
            txtsisa.Text = "0"
            btnsimpan.Enabled = True
        ElseIf cmbket.Text = "Belum Lunas" Then
            txtsisa.Text = sisa
            btnsimpan.Enabled = False
        End If
    End Sub

    Private Sub btnreset_Click(sender As Object, e As EventArgs) Handles btnreset.Click
        awal()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        Dim kons As String = ""
        If txtkons.Text = "" Then
            kons = cmbanggota.Text
        ElseIf cmbanggota.Text = "" Then
            kons = txtkons.Text
        End If
        'menyimpan data ke dalam database pengembalian cucian
        bukakoneksi()
        Dim cmd As SqlCommand
        cmd = New SqlCommand("INSERT INTO Pengembalian_Cucian (Faktur, Tanggal_Serah, Tanggal2, Konsumen, Berat_Cucian, Jumlah_Pakaian, Harga, Diskon, Total_Bayar, Panjar, Sisa, Keterangan) " &
                                 "VALUES ('" & txtfaktur.Text & "', '" & lbltanggal.Text & "', '" & lbltanggal.Text & "', '" & kons & "', '" & txtberat.Text & "', '" & txtpakaian.Text & "', '" & txtharga.Text & "', '" & txtdiskon.Text & "', '" & txtbayar.Text & "', '" & txtpanjar.Text & "', '" & txtsisa.Text & "', '" & cmbket.Text & "')", koneksi)
        cmd.ExecuteNonQuery()

        'menyimpan data ke dalam database pemasukan
        cmd = New SqlCommand("INSERT INTO Pemasukan (Faktur, Tanggal_pemasukan, Tanggal2, Konsumen, Harga, Diskon, Bayar) " &
                               "VALUES ('" & txtfaktur.Text & "', '" & lbltanggal.Text & "', '" & lbltanggal.Text & "', '" & kons & "', '" & txtharga.Text & "', '" & txtdiskon.Text & "', '" & txtbayar.Text & "')", koneksi)
        cmd.ExecuteNonQuery()

        'menghapus data dari penyerahan cucian
        cmd = New SqlCommand("DELETE FROM Penyerahan_Cucian WHERE Faktur = '" & txtfaktur.Text & "'", koneksi)
        cmd.ExecuteNonQuery()

        awal()
        cucian.tampilcucian()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cucian.Show()
    End Sub

End Class