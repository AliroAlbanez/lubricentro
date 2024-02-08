Public Class VEditarEstadoOT
    Public monto As Integer
    Public total As Integer
    Public ot As String
    Dim sql As String
    Dim respuesta As DialogResult
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Abonado" Then
            Label2.Visible = True
            TBCantidad.Visible = True
        Else
            Label2.Visible = False
            TBCantidad.Visible = False
            TBCantidad.Text = "0"
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Try
            If ComboBox1.Text = "Abonado" Or ComboBox1.Text = "Pagado" Or ComboBox1.Text = "Cancelado" Or ComboBox1.Text = "Pendiente" Or ComboBox1.Text = "Aceptado" Then
                If ComboBox1.Text = "Abonado" And CInt(TBCantidad.Text) < monto Then
                    MessageBox.Show("El nuevo monto abonado no puede ser inferior al registrado con anterioridad", "Abonar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf ComboBox1.Text = "Abonado" And CInt(TBCantidad.Text) > total Then
                    MessageBox.Show("El nuevo monto abonado no puede ser superior al total de la Orden de Trabajo", "Abonar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    respuesta = MessageBox.Show("¿Desea Cambiar el estado de la " & Label1.Text & "", "Guardar cambio estado", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If respuesta = DialogResult.Yes Then
                        sql = "UPDATE `ot` SET `estado`='" & ComboBox1.Text & "',`abono`='" & TBCantidad.Text & "' WHERE id_ot='" & ot & "';"
                        general.IngresarDatos(sql)
                        If ComboBox1.Text = "Abonado" Or ComboBox1.Text = "Pagado" Then
                            Dim suma As Integer
                            If ComboBox1.Text = "Abonado" Then
                                suma = CInt(TBCantidad.Text) - monto
                            Else
                                suma = total - monto
                            End If
                            Select Case ComboBox2.Text
                                Case "Crédito"
                                    sql = "UPDATE `sumascaja` SET `credito`=credito+" & suma & " WHERE 1;"
                                    general.IngresarDatos(sql)
                                Case "Efectivo"
                                    sql = "UPDATE `sumascaja` SET `efectivo`=efectivo+" & suma & " WHERE 1;"
                                    general.IngresarDatos(sql)
                                Case "Targeta Débito"
                                    sql = "UPDATE `sumascaja` SET `tdebito`=tdebito+" & suma & " WHERE 1;"
                                    general.IngresarDatos(sql)
                                Case "Targeta Crédito"
                                    sql = "UPDATE `sumascaja` SET `tcredito`=tcredito+" & suma & " WHERE 1;"
                                    general.IngresarDatos(sql)
                                Case "Transferencia"
                                    sql = "UPDATE `sumascaja` SET `transferencia`=transferencia+" & suma & " WHERE 1;"
                                    general.IngresarDatos(sql)
                                Case Else
                            End Select
                        End If
                        MessageBox.Show("Cambio guardado con éxito", "Cambio de Estado", MessageBoxButtons.OK, MessageBoxIcon.Information)



                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class