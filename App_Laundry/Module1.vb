Imports System.Data.SqlClient
Module ModKoneksi
    Public koneksi As SqlConnection
    Public str As String
    Public users As String
    Public laporan As String
    Public filter As String
    Public Sub bukakoneksi()
        str = "Data Source=LAPTOP-J85JD9KK\BENNY;initial catalog=db_laundry;integrated security=true"
        koneksi = New SqlConnection(str)
        If koneksi.State = ConnectionState.Closed Then koneksi.Open()
    End Sub
    Public Function SqlTable(ByVal Source As String) As DataTable
        Try
            Dim da As New SqlDataAdapter(Source, koneksi)
            Dim dt As New DataTable

            da.Fill(dt)
            SqlTable = dt
        Catch ex As OleDb.OleDbException
            MsgBox(ex.Message)
            SqlTable = Nothing
        End Try
    End Function
End Module

