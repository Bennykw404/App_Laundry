Imports System.Data.SqlClient
Public Class Konsumen
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
        Dim tampil As String = "SELECT * FROM Konsumen"
        Dim da As New SqlDataAdapter(tampil, koneksi)
        Dim dt As New DataTable
        Dim ds As New DataSet
        da.Fill(ds)
        For Each dt In ds.Tables
            dgkonsumen.DataSource = dt
        Next
        dgkonsumen.AutoResizeColumns()
        dgkonsumen.AutoGenerateColumns = True
        dgkonsumen.ReadOnly = True
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
        dgkonsumen.Refresh()
    End Sub

    Sub kodeKonsumenOtomatis()
        Dim dr As DataRow
        dr = SqlTable("SELECT MAX (RIGHT (idkonsumen, 4)) AS Nomor FROM Konsumen").Rows(0)
        If dr.IsNull("Nomor") Then
            txtkode.Text = "0001"
        Else
            txtkode.Text = Format(dr("Nomor") + 1, "0000")
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Konsumen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bukakoneksi()
        TampilGrid()
        kodeKonsumenOtomatis()
    End Sub
    Private Sub btnreset_Click(sender As Object, e As EventArgs) Handles btnreset.Click
        kosong()
        kodeKonsumenOtomatis()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        If txtkode.Text = "" Or txtnama.Text = "" Or cmbjeniskel.Text = "" Or txtalamat.Text = "" Or txthp.Text = "" Then
            MsgBox("Data Belum Lengkap", MsgBoxStyle.Information, "INFORMASI")
        Else
            Dim cmd As SqlCommand
            cmd = New SqlCommand("INSERT INTO Konsumen (idkonsumen, Nama, Jenis_Kelamin, Alamat, No_HP) " &
                               "VALUES ('" & txtkode.Text & "', '" & txtnama.Text & "', '" & cmbjeniskel.Text & "', '" & txtalamat.Text & "', '" & txthp.Text & "')", koneksi)
            cmd.ExecuteNonQuery()
            TampilGrid()
            kosong()
            kodeKonsumenOtomatis()
            MsgBox("Data Berhasil DiSimpan", MsgBoxStyle.Information, "INFORMASI")
        End If
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        If selrow = "" Then
            MsgBox("Data harus di-Isi", MsgBoxStyle.Information, "INFORMASI")
        ElseIf MsgBox("Yakin Data Konsumen akan diHapus..?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim cmd As SqlCommand
            cmd = New SqlCommand("DELETE FROM Konsumen WHERE idkonsumen = '" & txtkode.Text & "'", koneksi)
            cmd.ExecuteNonQuery()
            TampilGrid()
            kosong()
            kodeKonsumenOtomatis()
            MsgBox("Data Berhasil DiHapus", MsgBoxStyle.Information, "INFORMASI")
        End If
    End Sub

    Private Sub dgkonsumen_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgkonsumen.CellMouseClick
        selrow = dgkonsumen.SelectedRows.Item(0).Cells("idkonsumen").Value
        txtkode.Text = dgkonsumen.SelectedRows.Item(0).Cells("idkonsumen").Value
        txtnama.Text = dgkonsumen.SelectedRows.Item(0).Cells("Nama").Value
        cmbjeniskel.Text = dgkonsumen.SelectedRows.Item(0).Cells("Jenis_Kelamin").Value
        txtalamat.Text = dgkonsumen.SelectedRows.Item(0).Cells("Alamat").Value
        txthp.Text = dgkonsumen.SelectedRows.Item(0).Cells("No_HP").Value
    End Sub

    Private Sub cmbjeniskel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbjeniskel.SelectedIndexChanged
        txtalamat.Focus()
    End Sub

    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        If selrow = "" Then
            MsgBox("Anda Belum Memilih Data yang Ingin di Edit", MsgBoxStyle.Critical)
        Else
            Dim cmd As SqlCommand
            cmd = New SqlCommand("UPDATE Konsumen SET Nama = '" & txtnama.Text & "', Jenis_Kelamin = '" & cmbjeniskel.Text & "', Alamat = '" & txtalamat.Text & "', No_HP = '" & txthp.Text & "' WHERE idkonsumen = '" & selrow & "'", koneksi)
            cmd.ExecuteNonQuery()
            TampilGrid()
            kosong()
            MsgBox("Data Berhasil DiUpdate", MsgBoxStyle.Information, "INFORMASI")
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
End Class