Module Guardar
    Dim sql As String
    Public Sub GServicio()
        If Principal.CBOTClientes.Text <> "" And Principal.CBPatenteOT.Text <> "" And Principal.CBCondicionOT.Text <> "" And Principal.CBTipoDocOT.Text <> "" And Principal.CBEstadoOT.Text <> "" And Principal.TCOT.RowCount > 0 Then
            Try
                sql = "INSERT INTO `ot`(`id_ot`, `cliente`, `fecha_ingreso`, `fecha_salida`, `recepcionista`, `auto`, `km`, `condicion_v`, `estado`, `abono`, `tipo_d`, `plazo`, `obs`, `t_mo`, `t_repu`, `subtotal`, `descuento`, `neto`, `iva`, `total`) VALUES ('" & general.parametros(1, 0) & "','" & Principal.CBOTClientes.Text & "','" & general.fechasVoltear(Principal.DTIngreso.Value.ToString) & "','" & general.fechasVoltear(Principal.DTSalida.Value.ToString) & "','" & general.usuario(2, 0) & "','" & Principal.CBPatenteOT.Text & "','" & Principal.TBKmOT.Text & "','" & Principal.CBCondicionOT.Text & "','" & Principal.CBEstadoOT.Text & "','" & Principal.TBAbonoOT.Text & "','" & Principal.CBTipoDocOT.Text & "','" & Principal.TBPlazo.Text & "','" & Principal.TBobs.Text & "','" & Principal.TotalMO & "','" & Principal.TotalR & "','" & Principal.SubT & "','" & Principal.dscuento & "','" & Principal.Neto & "','" & Principal.Tiva & "','" & Principal.Total & "');"
                general.IngresarDatos(sql)
                For i = 0 To Principal.TCOT.RowCount - 1
                    sql = "INSERT INTO `servicios`(`id_ot`, `t_service`, `detalle`, `repuesto`, `cantidad`, `v_repuesto`, `t_repuesto`, `v_mo`, `valor`, `mecanico`) VALUES ('" & general.parametros(1, 0) & "','" & Principal.TCOT(0, i).Value.ToString & "','" & Principal.TCOT(1, i).Value.ToString & "','" & Principal.TCOT(2, i).Value.ToString & "','" & Principal.TCOT(3, i).Value.ToString & "','" & Principal.TCOT(4, i).Value.ToString & "','" & Principal.TCOT(5, i).Value.ToString & "','" & Principal.TCOT(6, i).Value.ToString & "','" & Principal.TCOT(7, i).Value.ToString & "','" & Principal.TCOT(8, i).Value.ToString & "');"
                    general.IngresarDatos(sql)
                Next
                MessageBox.Show("Ingreso exitoso", "Ingreso de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Principal.Panel6.Enabled = False
                Principal.Panel5.Enabled = False
                Principal.Panel4.Enabled = False
                Principal.Panel3.Enabled = False
                Principal.Panel2.Enabled = False
                Principal.TCOT.Enabled = False
                Principal.BImprimirOrden.Enabled = True
                Principal.TBobs.Enabled = False
                Principal.BGuardarService.Enabled = False
                general.parametros(1, 0) = CInt(general.parametros(1, 0)) + 1
                sql = "UPDATE `parametros` SET `ot`='" & general.parametros(1, 0) & "'"
                general.IngresarDatos(sql)
                Dim suma As Integer
                If Principal.CBEstadoOT.Text = "Pagado" Or Principal.CBEstadoOT.Text = "Abonado" Then
                    If Principal.CBEstadoOT.Text = "Pagado" Then
                        suma = CInt(Principal.Total)
                    ElseIf Principal.CBEstadoOT.Text = "Abonado" Then
                        suma = CInt(Principal.TBAbonoOT.Text)
                    End If
                    Select Case Principal.CBCondicionOT.Text
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

            Catch ex As Exception
                MessageBox.Show("Ingreso fallido. Verifique que todos los datos sean opciones válidas", "Ingreso de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try


        Else
            MessageBox.Show("Ingreso fallido. Verifique que todos los datos hayan sido seleccionados y ayan servicios ingresados", "Ingreso de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub GUsers()
        Dim marca(3) As String
        sql = "DELETE FROM `usuario` WHERE 1"
        general.IngresarDatos(sql)
        If Principal.DGusuarios.RowCount > 1 Then
            For i = 0 To Principal.DGusuarios.RowCount - 2
                If Convert.ToString(Principal.DGusuarios(0, i).Value) = "" Or Convert.ToString(Principal.DGusuarios(1, i).Value) = "" Or Convert.ToString(Principal.DGusuarios(4, i).Value) = "" Then
                    MessageBox.Show("Faltan datos en la fila " & i + 1 & "Rellene los datos y vuelva a guardar o esta fila se perderá al volver a cargar", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    sql = "INSERT INTO `usuario`(`user`, `nombre`, `clave`, `rut`, `cargo`) VALUES ('" & Principal.DGusuarios(1, i).Value.ToString & "','" & Principal.DGusuarios(0, i).Value.ToString & "','" & Convert.ToString(Principal.DGusuarios(2, i).Value) & "','" & Convert.ToString(Principal.DGusuarios(3, i).Value) & "','" & Principal.DGusuarios(4, i).Value.ToString & "');"
                    general.IngresarDatos(sql)

                    For j = 5 To 8
                        If Convert.ToString(Principal.DGusuarios(j, i).Value) = "True" Then
                            marca(j - 5) = "1"
                        Else
                            marca(j - 5) = "0"
                        End If
                    Next
                    sql = "INSERT INTO `permisos`(`user`, `Servicios`, `Usuarios`, `Informes`, `Varios`) VALUES ('" & Principal.DGusuarios(1, i).Value.ToString & "'," & marca(0) & "," & marca(1) & "," & marca(2) & "," & marca(3) & ");"
                    general.IngresarDatos(sql)
                End If
            Next
            MessageBox.Show("Guardado Finalizado", "Registro de Ususarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Public Sub GParametros()
        Try
            sql = "DELETE FROM `parametros` WHERE 1"
            general.IngresarDatos(sql)

            sql = "INSERT INTO `parametros`(`iva`, `ot`) VALUES ('" & Principal.TablaParametros(1, 0).Value.ToString & "','" & Principal.TablaParametros(1, 1).Value.ToString & "');"
            general.IngresarDatos(sql)

            MessageBox.Show("Valores Guardados con éxito", "Parametros", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception

        End Try
    End Sub

End Module
