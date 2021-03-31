Imports System.Data.SqlClient
Module Module1
    Public con As New SqlConnection
    Public Sub conectar()
        con.ConnectionString = "Data Source=DESKTOP-7B0ICK7;Initial Catalog=Parcial;Integrated Security=True"
        con.Open()

    End Sub
End Module
