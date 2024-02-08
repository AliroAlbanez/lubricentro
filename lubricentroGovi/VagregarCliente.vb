Public Class VagregarCliente
    Dim sql As String
    Public rutAntes As String
    Public info As Integer
    Public toc As Integer
    Public cbclient As ComboBox
    Private Sub BGCliente_Click(sender As Object, e As EventArgs) Handles BGCliente.Click
        If TBNombre.Text <> "" And TBRut.Text <> "" Then
            Dim respuesta As DialogResult = MessageBox.Show("¿Desea Guardar los datos del cliente " & TBNombre.Text & "?", "Guardar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If respuesta = DialogResult.Yes Then
                Try
                    If TBRut.Text.Length = 9 And CInt(TBRut.Text.Substring(0, 8)) > 0 And (TBRut.Text.Substring(8, 1) = "k" Or TBRut.Text.Substring(8, 1) = "0" Or TBRut.Text.Substring(8, 1) = "1" Or TBRut.Text.Substring(8, 1) = "2" Or TBRut.Text.Substring(8, 1) = "3" Or TBRut.Text.Substring(8, 1) = "4" Or TBRut.Text.Substring(8, 1) = "5" Or TBRut.Text.Substring(8, 1) = "6" Or TBRut.Text.Substring(8, 1) = "7" Or TBRut.Text.Substring(8, 1) = "8" Or TBRut.Text.Substring(8, 1) = "9") Then
                        If info = 0 Then
                            Try
                                nuevoCliente()
                            Catch ex As Exception
                                respuesta = MessageBox.Show("Este Cliente ya existe ¿Desea actualizar los datos del cliente " & TBNombre.Text & "?", "Guardar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                                If respuesta = DialogResult.Yes Then
                                    cambiarCliente(TBRut.Text)
                                End If
                            End Try
                        Else
                            cambiarCliente(rutAntes)
                        End If

                    ElseIf TBRut.Text.Length = 8 And CInt(TBRut.Text.Substring(0, 7)) > 0 And (TBRut.Text.Substring(7, 1) = "k" Or TBRut.Text.Substring(7, 1) = "0" Or TBRut.Text.Substring(7, 1) = "1" Or TBRut.Text.Substring(7, 1) = "2" Or TBRut.Text.Substring(7, 1) = "3" Or TBRut.Text.Substring(7, 1) = "4" Or TBRut.Text.Substring(7, 1) = "5" Or TBRut.Text.Substring(7, 1) = "6" Or TBRut.Text.Substring(7, 1) = "7" Or TBRut.Text.Substring(7, 1) = "8" Or TBRut.Text.Substring(7, 1) = "9") Then
                        If info = 0 Then
                            Try
                                nuevoCliente()
                            Catch ex As Exception
                                respuesta = MessageBox.Show("Este Cliente ya existe ¿Desea actualizar los datos del cliente " & TBNombre.Text & "?", "Guardar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                                If respuesta = DialogResult.Yes Then
                                    cambiarCliente(TBRut.Text)
                                End If
                            End Try
                        Else
                            cambiarCliente(rutAntes)
                        End If
                    Else
                        MessageBox.Show("El rut no es correcto. Debe tener un largo de 8 o 9 caracteres y debe finalizar con un número o k. No agregue ni puntos ni guión", "Guardar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("El rut no es correcto. Debe tener un largo de 8 o 9 caracteres y debe finalizar con un número o k. No agregue ni puntos ni guión", "Guardar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("El nombre y el RUT no pueden quedar en blanco. Complete estos datos antes de guardar", "Guardar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub nuevoCliente()
        sql = "INSERT INTO `cliente`(`rut`, `nombre`, `correo`, `direccion`, `telefono1`, `telefono2`) VALUES ('" & TBRut.Text & "','" & TBNombre.Text & "','" & TBCorreo.Text & "','" & TBDireccion.Text & "','" & TBFono1.Text & "','" & TBFono2.Text & "');"
        general.IngresarDatos(sql)
        Principal.TBBcliente.Text = ""
        If toc = 0 Then
            CargarCB.llenarTablaClientes(Principal.TBBcliente.Text)
        Else
            CargarCB.llenarCBClientes(cbclient)
        End If
        MessageBox.Show("Nuevo cliente guardado con éxito", "Guardar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub cambiarCliente(ByVal rute)
        sql = "UPDATE `cliente` SET `rut`='" & TBRut.Text & "',`nombre`='" & TBNombre.Text & "',`correo`='" & TBCorreo.Text & "',`correo`='" & TBCorreo.Text & "',`direccion`='" & TBDireccion.Text & "',`telefono1`='" & TBFono1.Text & "',`telefono2`='" & TBFono2.Text & "' WHERE rut='" & rute & "';"
        general.IngresarDatos(sql)
        Principal.TBBcliente.Text = ""
        If toc = 0 Then
            CargarCB.llenarTablaClientes(Principal.TBBcliente.Text)
        Else
            CargarCB.llenarCBClientes(cbclient)
        End If
        MessageBox.Show("Cliente actualizado con éxito", "Guardar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

End Class