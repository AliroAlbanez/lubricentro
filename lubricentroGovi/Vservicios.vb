Public Class Vservicios

    Dim sql As String
    Public toc As Integer
    Public noa As Integer
    Public valorAnterior As String


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" Then
            Try
                If noa = 0 Then
                    sql = "INSERT INTO `tservices`(`name_s`) VALUES ('" & TextBox1.Text & "');"
                    general.IngresarDatos(sql)
                    MessageBox.Show("Nuevo Servicio ingresado con éxito", "Servicios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If toc = 0 Then
                        CargarCB.llenarTablaServicios()
                    Else
                        CargarCB.RCBServices()
                    End If
                Else
                    sql = "UPDATE `tservices` SET `name_s`='" & TextBox1.Text & "' WHERE name_s='" & valorAnterior & "');"
                    general.IngresarDatos(sql)
                    MessageBox.Show("Servicio actualizado", "Servicios", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    CargarCB.llenarTablaServicios()

                End If
            Catch ex As Exception
                MessageBox.Show("Este servicio ya existe, intente con un nuevo servicio", "Servicios", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox1.Text = valorAnterior
            End Try
        Else
            MessageBox.Show("El nombre del servicio no puede quedar en blanco", "Servicios", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub

    Private Sub Vservicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = valorAnterior
    End Sub
End Class