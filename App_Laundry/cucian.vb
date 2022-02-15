Imports System.Data.SqlClient
Public Class cucian
    Dim bln As String
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

    Public Sub tampilcucian()
        Dim str As String = "SELECT * FROM Penyerahan_Cucian"
        Dim da As New SqlDataAdapter(str, koneksi)
        Dim ds As New DataSet
        Dim dt As New DataTable
        da.Fill(ds)
        For Each dt In ds.Tables
            dgcucian.DataSource = dt
        Next
        dgcucian.AutoResizeColumns()
        dgcucian.AutoGenerateColumns = True
    End Sub

    Private Sub cucian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bukakoneksi()
        tampilcucian()
        tglharian()
        tahun()
    End Sub

    Private Sub rdfaktur_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdfaktur.CheckedChanged
        txtkons.Enabled = True
        txtfaktur.Enabled = False
        txtkons.Focus()
    End Sub

    Private Sub rdkons_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdkons.CheckedChanged
        txtfaktur.Enabled = True
        txtkons.Enabled = False
        txtfaktur.Focus()
    End Sub

    Private Sub txtkons_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkons.TextChanged
        Dim cari As String = ""
        If txtkons.Text = "" Then
            cari = "SELECT * FROM Penyerahan_Cucian"
        Else
            cari = "SELECT * FROM Penyerahan_Cucian WHERE Konsumen LIKE '%" & txtkons.Text & "%'"
        End If
        dgcucian.DataSource = SqlTable(cari)
    End Sub

    Private Sub txtfaktur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfaktur.TextChanged
        Dim cari As String = ""
        If txtfaktur.Text = "" Then
            cari = "SELECT * FROM Penyerahan_Cucian"
        Else
            cari = "SELECT * FROM Penyerahan_Cucian WHERE Faktur LIKE '%" & txtfaktur.Text & "%'"
        End If
        dgcucian.DataSource = SqlTable(cari)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'proses memfilter data berdasarkan tanggal, bulan dan tahun
        bulan()
        If bln = "" Then
            Exit Sub
        Else
            If tglhari.Text = "" Or blnhari.Text = "" Or thnhari.Text = "" Then
                MsgBox("Pilih Tanggal, Bulan dan Tahun", MsgBoxStyle.Critical)
            Else
                Dim filter As String = "SELECT * FROM Penyerahan_Cucian WHERE Tanggal2 = '" & tglhari.Text & "/" & bln & "/" & thnhari.Text & "'"
                dgcucian.DataSource = SqlTable(filter)
            End If
        End If
    End Sub

    Public Sub tglharian()
        For i As Integer = 1 To 31
            tglhari.Items.Add(Format(i, "00"))
        Next
    End Sub

    Public Sub tahun()
        For i As Integer = 2020 To 2021
            thnhari.Items.Add(i)
        Next
    End Sub

    Public Sub bulan()
        Select Case blnhari.Text
            Case "Januari"
                bln = "01"
            Case "Februari"
                bln = "02"
            Case "Maret"
                bln = "03"
            Case "April"
                bln = "04"
            Case "Mei"
                bln = "05"
            Case "Juni"
                bln = "06"
            Case "Juli"
                bln = "07"
            Case "Agustus"
                bln = "08"
            Case "September"
                bln = "09"
            Case "Oktober"
                bln = "10"
            Case "November"
                bln = "11"
            Case "Desember"
                bln = "12"
            Case Else
                bln = ""
                MsgBox("Bulan Belum di Pilih", MsgBoxStyle.Critical)
                'blnhari.Text = ""
                blnhari.Focus()
        End Select
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call tampilcucian()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim filter As String = ""
        If cmbket.Text = "Lunas" Then
            filter = "SELECT * FROM Penyerahan_Cucian WHERE Keterangan = '" & cmbket.Text & "'"
        Else
            If cmbket.Text = "Belum Lunas" Then
                filter = "SELECT * FROM Penyerahan_Cucian WHERE Keterangan = '" & cmbket.Text & "'"
            Else
                MsgBox("Inputan Anda Salah", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If
        dgcucian.DataSource = SqlTable(filter)
    End Sub

    Private Sub dgcucian_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgcucian.DoubleClick
        Dim i As Integer
        i = dgcucian.CurrentRow.Index

        pengembalian_cucian.txtfaktur.Text = dgcucian.Item(0, i).Value
        pengembalian_cucian.cekfaktur()
        pengembalian_cucian.Show()
        Me.Hide()
    End Sub
End Class