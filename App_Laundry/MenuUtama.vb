Imports System.Data.SqlClient
Public Class MenuUtama
    Dim conn1 As SqlConnection
    Dim cmd1 As SqlCommand
    Dim adp1 As SqlDataAdapter
    Dim dt_laporan As New DataTable

    Dim userr As String
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MsgBox("Yakin ingin Tutup Aplikasi..?", MsgBoxStyle.YesNo, "INFORMASI") = MsgBoxResult.Yes Then
            End
        End If
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
    Private Sub btnDataMaster_Click(sender As Object, e As EventArgs) Handles btnDataMaster.Click
        'Label section
        lblSected1.Visible = True
        lblSected2.Visible = False
        lblSected3.Visible = False
        lblSected4.Visible = False
        lblSected5.Visible = False
        lblSected6.Visible = False

        'Label kontent
        pnlDataMaster.Visible = True
        pnlTransaksi.Visible = False
        pnlLaporan.Visible = False
        pnlLainnya.Visible = False
        pnlTentang.Visible = False
    End Sub

    Private Sub btnTransaksi_Click(sender As Object, e As EventArgs) Handles btnTransaksi.Click
        'Label section
        lblSected1.Visible = False
        lblSected2.Visible = True
        lblSected3.Visible = False
        lblSected4.Visible = False
        lblSected5.Visible = False
        lblSected6.Visible = False

        'Label kontent
        pnlDataMaster.Visible = False
        pnlTransaksi.Visible = True
        pnlLaporan.Visible = False
        pnlLainnya.Visible = False
        pnlTentang.Visible = False

    End Sub
    Private Sub btnLaporan_Click(sender As Object, e As EventArgs) Handles btnLaporan.Click
        If users = "Kasir" Then
            MsgBox("Anda Tidak Memiliki Izin Untuk Membuka Menu Ini", MsgBoxStyle.Critical)
            Exit Sub
        Else
            'Label section
            lblSected1.Visible = False
            lblSected2.Visible = False
            lblSected3.Visible = True
            lblSected4.Visible = False
            lblSected5.Visible = False
            lblSected6.Visible = False

            'Label kontent
            pnlDataMaster.Visible = False
            pnlTransaksi.Visible = False
            pnlLaporan.Visible = True
            pnlLainnya.Visible = False
            pnlTentang.Visible = False
        End If

    End Sub

    Private Sub btnLainnya_Click(sender As Object, e As EventArgs) Handles btnLainnya.Click
        'Label section
        lblSected1.Visible = False
        lblSected2.Visible = False
        lblSected3.Visible = False
        lblSected4.Visible = True
        lblSected5.Visible = False
        lblSected6.Visible = False

        'Label kontent
        pnlDataMaster.Visible = False
        pnlTransaksi.Visible = False
        pnlLaporan.Visible = False
        pnlLainnya.Visible = True
        pnlTentang.Visible = False
    End Sub

    Private Sub btnTentang_Click(sender As Object, e As EventArgs) Handles btnTentang.Click
        'Label section
        lblSected1.Visible = False
        lblSected2.Visible = False
        lblSected3.Visible = False
        lblSected4.Visible = False
        lblSected5.Visible = True
        lblSected6.Visible = False

        'Label kontent
        pnlDataMaster.Visible = False
        pnlTransaksi.Visible = False
        pnlLaporan.Visible = False
        pnlLainnya.Visible = False
        pnlTentang.Visible = True
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        lblSected1.Visible = False
        lblSected2.Visible = False
        lblSected3.Visible = False
        lblSected4.Visible = False
        lblSected5.Visible = False
        lblSected6.Visible = True

        Panel1.Text = ""
        Panel2.Text = ""
        Panel3.Text = ""
        Me.Close()
        Flogin.Show()
        Flogin.Visible = True
        Flogin.txtUsername.Text = ""
        Flogin.txtPassword.Text = ""
        Flogin.txtUsername.Focus()
    End Sub

    Private Sub btnKonsumen_Click(sender As Object, e As EventArgs) Handles btnKonsumen.Click
        Konsumen.Show()
    End Sub

    Private Sub btnAnggota_Click(sender As Object, e As EventArgs) Handles btnAnggota.Click
        anggota.Show()
    End Sub

    Private Sub btnPegawai_Click(sender As Object, e As EventArgs) Handles btnPegawai.Click
        Pegawai.Show()
    End Sub



    Private Sub btnPenyerahan_Click(sender As Object, e As EventArgs) Handles btnPenyerahan.Click
        penyerahan_cucian.Show()
    End Sub

    Private Sub btnPengembalian_Click(sender As Object, e As EventArgs) Handles btnPengembalian.Click
        pengembalian_cucian.Show()
    End Sub

    Private Sub btnCucian_Click(sender As Object, e As EventArgs) Handles btnCucian.Click
        cucian.Show()
    End Sub

    Private Sub btnTambahAnggota_Click(sender As Object, e As EventArgs) Handles btnTambahAnggota.Click
        user.Show()
    End Sub

    Private Sub btnJabatan_Click(sender As Object, e As EventArgs) Handles btnJabatan.Click
        jabatan.Show()
    End Sub

    Private Sub btnLapPegawai_Click(sender As Object, e As EventArgs) Handles btnLapPegawai.Click
        Me.Cursor = Cursors.WaitCursor
        dt_laporan.Clear()
        Try
            conn1 = New SqlConnection("Data Source=LAPTOP-J85JD9KK\BENNY;initial catalog=db_laundry;integrated security=true")
            Dim rpt As New rptlaporan
            cetaksemua()
            rpt.Database.Tables("pegawai").SetDataSource(dt_laporan)
            Flaporan.CrystalReportViewer1.ReportSource = Nothing
            Flaporan.CrystalReportViewer1.ReportSource = rpt
            Flaporan.ShowDialog()
            rpt.Clone()
            rpt.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Sub cetaksemua()
        cmd1 = New SqlCommand("SELECT * FROM pegawai", conn1)
        adp1 = New SqlDataAdapter(cmd1)
        adp1.Fill(dt_laporan)

        conn1.Close()
        conn1.Dispose()
    End Sub

    Private Sub btnLapAnggota_Click(sender As Object, e As EventArgs) Handles btnLapAnggota.Click
        Me.Cursor = Cursors.WaitCursor
        dt_laporan.Clear()
        Try
            conn1 = New SqlConnection("Data Source=LAPTOP-J85JD9KK\BENNY;initial catalog=db_laundry;integrated security=true")
            Dim rpt As New rptanggota
            cmd1 = New SqlCommand("SELECT * FROM anggota", conn1)
            adp1 = New SqlDataAdapter(cmd1)
            adp1.Fill(dt_laporan)
            rpt.Database.Tables("anggota").SetDataSource(dt_laporan)
            Flaporan.CrystalReportViewer1.ReportSource = Nothing
            Flaporan.CrystalReportViewer1.ReportSource = rpt
            Flaporan.ShowDialog()
            rpt.Clone()
            rpt.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLapKonsumen_Click(sender As Object, e As EventArgs) Handles btnLapKonsumen.Click
        Me.Cursor = Cursors.WaitCursor
        dt_laporan.Clear()
        Try
            conn1 = New SqlConnection("Data Source=LAPTOP-J85JD9KK\BENNY;initial catalog=db_laundry;integrated security=true")
            Dim rpt As New rptkonsumen
            cmd1 = New SqlCommand("SELECT * FROM konsumen", conn1)
            adp1 = New SqlDataAdapter(cmd1)
            adp1.Fill(dt_laporan)
            rpt.Database.Tables("konsumen").SetDataSource(dt_laporan)
            Flaporan.CrystalReportViewer1.ReportSource = Nothing
            Flaporan.CrystalReportViewer1.ReportSource = rpt
            Flaporan.ShowDialog()
            rpt.Clone()
            rpt.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLapKembalian_Click(sender As Object, e As EventArgs) Handles btnLapKembalian.Click
        Me.Cursor = Cursors.WaitCursor
        dt_laporan.Clear()
        Try
            conn1 = New SqlConnection("Data Source=LAPTOP-J85JD9KK\BENNY;initial catalog=db_laundry;integrated security=true")
            Dim rpt As New rptkembali
            cmd1 = New SqlCommand("SELECT * FROM pengembalian_cucian", conn1)
            adp1 = New SqlDataAdapter(cmd1)
            adp1.Fill(dt_laporan)
            rpt.Database.Tables("pengembalian_cucian").SetDataSource(dt_laporan)
            Flaporan.CrystalReportViewer1.ReportSource = Nothing
            Flaporan.CrystalReportViewer1.ReportSource = rpt
            Flaporan.ShowDialog()
            rpt.Clone()
            rpt.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLapSerah_Click(sender As Object, e As EventArgs) Handles btnLapSerah.Click
        Me.Cursor = Cursors.WaitCursor
        dt_laporan.Clear()
        Try
            conn1 = New SqlConnection("Data Source=LAPTOP-J85JD9KK\BENNY;initial catalog=db_laundry;integrated security=true")
            Dim rpt As New rptserah
            cmd1 = New SqlCommand("SELECT * FROM penyerahan_cucian", conn1)
            adp1 = New SqlDataAdapter(cmd1)
            adp1.Fill(dt_laporan)
            rpt.Database.Tables("penyerahan_cucian").SetDataSource(dt_laporan)
            Flaporan.CrystalReportViewer1.ReportSource = Nothing
            Flaporan.CrystalReportViewer1.ReportSource = rpt
            Flaporan.ShowDialog()
            rpt.Clone()
            rpt.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLapPemasukan_Click(sender As Object, e As EventArgs) Handles btnLapPemasukan.Click
        Me.Cursor = Cursors.WaitCursor
        dt_laporan.Clear()
        Try
            conn1 = New SqlConnection("Data Source=LAPTOP-J85JD9KK\BENNY;initial catalog=db_laundry;integrated security=true")
            Dim rpt As New rptpemasukan
            cmd1 = New SqlCommand("SELECT * FROM pemasukan", conn1)
            adp1 = New SqlDataAdapter(cmd1)
            adp1.Fill(dt_laporan)
            rpt.Database.Tables("pemasukan").SetDataSource(dt_laporan)
            Flaporan.CrystalReportViewer1.ReportSource = Nothing
            Flaporan.CrystalReportViewer1.ReportSource = rpt
            Flaporan.ShowDialog()
            rpt.Clone()
            rpt.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGntiPassword_Click(sender As Object, e As EventArgs) Handles btnGntiPassword.Click
        gantipassword.Show()
    End Sub

End Class