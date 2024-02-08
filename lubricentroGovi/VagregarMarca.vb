Public Class VagregarMarca
    Dim sql As String
    Public info As Integer
    Public marcaPrevia As String
    Public cbpedido As ComboBox
    Public toc As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" Then
            If info = 0 Then
                Try
                    sql = "INSERT INTO `marcas`(`nombre_marca`) VALUES ('" & TextBox1.Text & "');"
                    general.IngresarDatos(sql)
                    MessageBox.Show("Marca ingresada con éxito", "Ingresar Marca", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If toc = 0 Then
                        CargarCB.llenarTablaMarcas()
                    Else
                        CargarCB.cargarMarcas(cbpedido)
                    End If

                Catch ex As Exception
                    MessageBox.Show("Marca ya existe. Intente con otra marca", "Ingresar Marca", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    TextBox1.Text = ""
                End Try
            Else
                Try
                    sql = "UPDATE `marcas` SET `nombre_marca`='" & TextBox1.Text & "' WHERE nombre_marca='" & marcaPrevia & "';"
                    general.IngresarDatos(sql)
                    MessageBox.Show("Marca editada con éxito", "Editar Marca", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If toc = 0 Then
                        CargarCB.llenarTablaMarcas()
                    Else
                        CargarCB.cargarMarcas(cbpedido)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Marca ya existe. Intente con otra marca", "Editar Marca", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    TextBox1.Text = marcaPrevia
                End Try

            End If
        Else
            MessageBox.Show("El nombre de marca no puede estar vacío", "Marca", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub

    Private Sub VagregarMarca_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If info = 0 Then
            TextBox1.Text = ""
            Button1.Text = "Agregar"
            Me.Text = "Agregar Marca"
        Else
            TextBox1.Text = marcaPrevia
            Button1.Text = "Editar"
            Me.Text = "Editar Marca"
        End If
    End Sub
End Class