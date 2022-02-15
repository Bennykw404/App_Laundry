Imports System.Data.SqlClient
Public Class penyerahan_cucian

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

    Public Sub KondisiAwal()
        txtkons.Text = ""
        txtberat.Text = ""
        txtpakaian.Text = ""
        txtharga.Text = ""
        txtdiskon.Text = "0"
        txtpanjar.Text = ""
        cmbket.Text = ""
        rdobukan.Checked = True
        cmbkode.Text = ""
        cmbanggota.Text = ""
        txtbayar.Text = ""
        txtsisa.Text = ""
    End Sub

    Sub TampilGrid()
        Dim str As String = "SELECT * FROM Konsumen"
        Dim da As New SqlDataAdapter(str, koneksi)
        Dim dt As New DataTable
        Dim ds As New DataSet
        da.Fill(ds)
        For Each dt In ds.Tables
            dgkonsumen.DataSource = dt
        Next
        dgkonsumen.AutoResizeColumns()
        dgkonsumen.AutoGenerateColumns = True
        dgkonsumen.RowHeadersVisible = False
        dgkonsumen.Columns(0).Width = 150
        dgkonsumen.Columns(0).HeaderText = "Kode Konsumen"
        dgkonsumen.Columns(1).Width = 150
        dgkonsumen.Columns(1).HeaderText = "Nama"
        dgkonsumen.Columns(2).Width = 100
        dgkonsumen.Columns(2).HeaderText = "Jenis-Kelamin"
        dgkonsumen.Columns(3).Width = 150
        dgkonsumen.Columns(3).HeaderText = "Alamat"
        dgkonsumen.Columns(4).Width = 90
        dgkonsumen.Columns(4).HeaderText = "No HP"
    End Sub

    Public Sub faktur()
        Dim dr As DataRow
        dr = SqlTable("SELECT MAX (RIGHT (faktur, 4)) AS Nomor FROM Penyerahan_Cucian WHERE Tanggal2 = '" & lbltanggal.Text & "'").Rows(0)
        If dr.IsNull("Nomor") Then
            txtfaktur.Text = Format(Now.Day, "00") & Format(Now.Month, "00") & Strings.Right(Now.Year, 2) & "0001"
        Else
            txtfaktur.Text = Format(Now.Day, "00") & Format(Now.Month, "00") & Strings.Right(Now.Year, 2) & Format(dr("Nomor") + 1, "0000")

        End If
    End Sub

    Sub daftaranggota()
        Dim cmd As SqlCommand
        Dim rd As SqlDataReader
        cmd = New SqlCommand("SELECT DISTINCT idanggota FROM Anggota", koneksi)
        rd = cmd.ExecuteReader
        Do While rd.Read
            cmbkode.Items.Add(rd.Item("idanggota"))
        Loop
    End Sub
    Public Sub bayar()
        txtbayar.Text = Val(txtharga.Text) - (Val(txtdiskon.Text) / 100 * Val(txtharga.Text))
    End Sub
    Private Sub FormPenyerahan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bukakoneksi()
        lbltanggal.Text = Now.Date
        TampilGrid()
        faktur()
        daftaranggota()
        rdobukan.Checked = 1
    End Sub
    Private Sub rdobukan_CheckedChanged(sender As Object, e As EventArgs) Handles rdobukan.CheckedChanged
        cmbkode.Enabled = False
        cmbkode.Text = ""
        cmbanggota.Text = ""
        txtdiskon.Text = "0"
        bayar()
        txtberat.Focus()
    End Sub
    Private Sub rdoanggota_CheckedChanged(sender As Object, e As EventArgs) Handles rdoanggota.CheckedChanged
        cmbkode.Enabled = True
        txtdiskon.Text = "15"
        bayar()
    End Sub

    Private Sub cmbkode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbkode.SelectedIndexChanged
        bukakoneksi()
        Dim cmd As SqlCommand
        Dim rd As SqlDataReader
        cmd = New SqlCommand("SELECT * FROM Anggota WHERE idanggota = '" & cmbkode.Text & "'", koneksi)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            cmbanggota.Text = rd.Item("nama")
        End If
        txtkons.Text = ""
        txtberat.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        anggota.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Konsumen.Show()
    End Sub

    Private Sub btnreset_Click(sender As Object, e As EventArgs) Handles btnreset.Click
        KondisiAwal()
    End Sub

    Private Sub txtberat_Leave(sender As Object, e As EventArgs) Handles txtberat.Leave
        txtharga.Text = Val(txtberat.Text) * 6000
        bayar()
    End Sub

    Private Sub txtberat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtberat.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtpakaian_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpakaian.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtpanjar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpanjar.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtcari_TextChanged(sender As Object, e As EventArgs) Handles txtcari.TextChanged
        Dim cari As String
        If txtcari.Text = "" Then
            cari = "SELECT * FROM Konsumen"
            dgkonsumen.DataSource = SqlTable(cari)
        Else
            cari = "SELECT * FROM Konsumen WHERE Nama LIKE '%" & txtcari.Text & "%'"
            dgkonsumen.DataSource = SqlTable(cari)
        End If
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        Dim kons As String = ""
        If rdoanggota.Checked = True Then
            kons = cmbanggota.Text
        ElseIf rdobukan.Checked = True Then
            kons = txtkons.Text
        End If
        bukakoneksi()
        Dim cmd As SqlCommand
        cmd = New SqlCommand("INSERT INTO Penyerahan_Cucian (faktur, Tanggal_Serah, Tanggal2, Konsumen, Berat_Cucian, Jumlah_Pakaian, Harga, Diskon, Total_Bayar, Panjar, Sisa, Keterangan) " &
                                "VALUES ('" & txtfaktur.Text & "', '" & lbltanggal.Text & "', '" & lbltanggal.Text & "', '" & kons & "', '" & txtberat.Text & " Kg" & "', '" & txtpakaian.Text & " Potong" & "', '" & txtharga.Text & "', '" & txtdiskon.Text & "', '" & txtbayar.Text & "', '" & txtpanjar.Text & "', '" & txtsisa.Text & "', '" & cmbket.Text & "')", koneksi)
        cmd.ExecuteNonQuery()
        KondisiAwal()
        faktur()
    End Sub

    Private Sub txtpanjar_Leave(sender As Object, e As EventArgs) Handles txtpanjar.Leave
        txtsisa.Text = Val(txtbayar.Text) - Val(txtpanjar.Text)
        If Val(txtsisa.Text) <= 0 Then
            cmbket.Text = "Lunas"
            txtsisa.Text = "0"
        End If
        If txtsisa.Text = "0" Then
            cmbket.Text = "Lunas"
        Else
            cmbket.Text = "Belum Lunas"
        End If
        btnsimpan.Focus()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        bukakoneksi()
        lbltanggal.Text = Now.Date
        TampilGrid()
        faktur()
        daftaranggota()
        rdobukan.Checked = 1
    End Sub

    Private Sub dgkonsumen_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgkonsumen.CellDoubleClick
        Dim i As Integer
        i = dgkonsumen.CurrentRow.Index

        txtkons.Text = dgkonsumen.Item(1, i).Value
        rdobukan.Checked = True
        cmbkode.Text = ""
        cmbanggota.Text = ""
        txtberat.Focus()
    End Sub
End Class