Imports System.Data.SqlClient
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar()
        mostrardatos()
    End Sub
    Sub mostrardatos()
        Dim da As New SqlDataAdapter("select * from Profesor", con)
        Dim ds As New DataSet
        da.Fill(ds, "Profesor")
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns("Dni").HeaderText = "DNI"
        DataGridView1.Columns("nombre").HeaderText = "Nombre"
        DataGridView1.Columns("direccion").HeaderText = "Direccion"
        DataGridView1.Columns("telefono").HeaderText = "Telefono"
    End Sub

    Private Sub cmdInsertar_Click(sender As Object, e As EventArgs) Handles cmdInsertar.Click
        Try
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "insert into Profesor(Dni, nombre, direccion, telefono) values('" & txtDNI.Text & "','" & txtNombre.Text & "','" & txtDireccion.Text & "','" & txtTelefono.Text & "')"
            cmd.ExecuteNonQuery()
            MessageBox.Show("datos guardados")
            mostrardatos()

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        If DataGridView1.Rows.Count > 0 Then
            If DataGridView1.SelectedRows.Count > 0 Then
                txtDNI.Text = DataGridView1.SelectedRows(0).Cells("DNi").Value
                txtNombre.Text = DataGridView1.SelectedRows(0).Cells("nombre").Value
                txtDireccion.Text = DataGridView1.SelectedRows(0).Cells("direccion").Value
                txtTelefono.Text = DataGridView1.SelectedRows(0).Cells("telefono").Value


            End If
        End If
    End Sub

    Private Sub cmdActualizar_Click(sender As Object, e As EventArgs) Handles cmdActualizar.Click
        Try
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Update Profesor set DNi = '" & txtDNI.Text & "',nombre = '" & txtNombre.Text & "',direccion = '" & txtDireccion.Text & "',telefono = '" & txtTelefono.Text & "' where DNi = '" & txtDNI.Text & "' "
            cmd.ExecuteNonQuery()
            MessageBox.Show("datos guardados")
            mostrardatos()

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "delete from Profesor where DNi = '" & txtDNI.Text & "'"
        cmd.ExecuteNonQuery()
        MessageBox.Show("Datos eliminados")
        mostrardatos()
    End Sub

    Private Sub cmdLimpiar_Click(sender As Object, e As EventArgs) Handles cmdLimpiar.Click
        limpiar()

    End Sub
    Sub limpiar()
        txtDNI.Clear()
        txtNombre.Clear()
        txtDireccion.Clear()
        txtTelefono.Clear()

    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Dim Opcion As DialogResult
        Opcion = MessageBox.Show("Seguro que desea cerrar el programa?", "Cerrar el programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (Opcion = Windows.Forms.DialogResult.Yes) Then
            Me.Close()



        End If
    End Sub
End Class
