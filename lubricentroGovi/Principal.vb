Public Class Principal

    Dim respuesta As DialogResult
    Dim desde As String
    Dim hasta As String
    Dim sql As String
    Dim busqueda As Integer
    Public TotalMO As Integer
    Public TotalR As Integer
    Public SubT As Integer
    Public Neto As Integer
    Public Tiva As Integer
    Public Total As Integer
    Public dscuento As Integer
    Private Sub BService_Click(sender As Object, e As EventArgs) Handles BService.Click
        PServicioIngreso.Visible = True
        PUsers.Visible = False
        PInformes.Visible = False
        PClientes.Visible = False
        PCierreCaja.Visible = False
        PMarcasModelos.Visible = False
        PDatos.Visible = False
        PVerOTS.Visible = False
        CargarCB.RCBEmpleados()
        CargarCB.RCBServices()
        CargarCB.llenarCBClientes(CBOTClientes)

    End Sub

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarCB.Rparametros()
        PServicioIngreso.Visible = False
        PUsers.Visible = False
        PInformes.Visible = False
        PClientes.Visible = False
        PCierreCaja.Visible = False
        PMarcasModelos.Visible = False
        PDatos.Visible = False
        PVerOTS.Visible = False
        If general.ComprobarCierre() Then
            CargarCB.RCBEmpleados()
            CargarCB.RCBServices()
            CargarCB.llenarCBClientes(CBOTClientes)
            Label1.Text = general.usuario(2, 0)
            DTIngreso.MinDate = System.DateTime.Now
            DTSalida.MinDate = System.DateTime.Now

            EtiNOT.Text = "OT N°: " & general.parametros(1, 0)
            PServicioIngreso.Visible = True
        Else
            cierrecajaactuar()
            BService.Enabled = False
        End If
        If general.permisosUsuario(0, 0) = "True" Then
            PServicioIngreso.Enabled = True
        Else
            PServicioIngreso.Enabled = False
        End If

        If general.permisosUsuario(1, 0) = "True" Then
            PUsers.Enabled = True
        Else
            PUsers.Enabled = False
        End If

        If general.permisosUsuario(2, 0) = "True" Then
            PInformes.Enabled = True
            PVerOTS.Enabled = True
        Else
            PInformes.Enabled = False
            PVerOTS.Enabled = False
        End If

        If general.permisosUsuario(3, 0) = "True" Then
            PClientes.Enabled = True
            PMarcasModelos.Enabled = True
            PDatos.Enabled = True
        Else
            PClientes.Enabled = False
            PMarcasModelos.Enabled = False
            PDatos.Enabled = False
        End If

        If general.permisosUsuario(4, 0) = "True" Then
            PCierreCaja.Enabled = True
        Else
            PCierreCaja.Enabled = False
        End If
    End Sub

    Private Sub BGuardarService_Click(sender As Object, e As EventArgs) Handles BGuardarService.Click
        respuesta = MessageBox.Show("¿Desea Guardar este servicio?", "Ingresar Servicio", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta = DialogResult.Yes Then
            Guardar.GServicio()
        End If
    End Sub

    Private Sub BUsers_Click(sender As Object, e As EventArgs) Handles BUsers.Click
        PServicioIngreso.Visible = False
        PUsers.Visible = True
        PInformes.Visible = False
        PClientes.Visible = False
        PCierreCaja.Visible = False
        PMarcasModelos.Visible = False
        PDatos.Visible = False
        PVerOTS.Visible = False
        CargarCB.RTUsers()

    End Sub

    Private Sub BGuardarUsers_Click(sender As Object, e As EventArgs) Handles BGuardarUsers.Click
        DGusuarios.EndEdit()
        respuesta = MessageBox.Show("¿Desea Guardar los cambios en Ususarios?", "registro de Ususarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta = DialogResult.Yes Then
            Guardar.GUsers()
        End If

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Cambiocontraus.Show()
    End Sub

    Private Sub BBuscar_Click(sender As Object, e As EventArgs) Handles BBuscar.Click
        Select Case busqueda
            Case 0 'servicios
                If CBDesde.Checked = True Then
                    desde = general.fechasAcotar(DTDesde.Value.ToString)
                Else
                    desde = "1900-01-01"
                End If
                If CBHasta.Checked = True Then
                    hasta = general.fechasAcotar(DTHasta.Value.ToString)
                Else
                    hasta = "4000-12-31"
                End If

                CargarCB.BuscarInformesServicios(desde, hasta, TBBuscar.Text)

            Case 1
                CargarCB.BuscarInformesVehiculos(TBBuscar.Text)

            Case 2

                CargarCB.buscarInformesClientes(TBBuscar.Text)
            Case 3
                If CBDesde.Checked = True Then
                    desde = general.fechasAcotar(DTDesde.Value.ToString)
                Else
                    desde = "1900-01-01"
                End If
                If CBHasta.Checked = True Then
                    hasta = general.fechasAcotar(DTHasta.Value.ToString)
                Else
                    hasta = "4000-12-31"
                End If
                CargarCB.buscarInformesCierres(TBBuscar.Text, desde, hasta)
            Case Else

        End Select

    End Sub

    Private Sub BInformes_Click(sender As Object, e As EventArgs) Handles BInformes.Click
        Label34.Text = "Servicios"
        PInformes.Visible = True
        PServicioIngreso.Visible = False
        PUsers.Visible = False
        PClientes.Visible = False
        PVerOTS.Visible = False
        PCierreCaja.Visible = False
        PMarcasModelos.Visible = False
        PDatos.Visible = False
        CBDesde.Enabled = True
        CBHasta.Enabled = True
        busqueda = 0
        CargarCB.BuscarInformesServicios("1900-01-01", "4000-12-31", "")
    End Sub

    Private Sub CBDesde_CheckedChanged(sender As Object, e As EventArgs) Handles CBDesde.CheckedChanged
        If CBDesde.Checked = True Then
            DTDesde.Enabled = True
        Else
            DTDesde.Enabled = False
        End If

    End Sub

    Private Sub CBHasta_CheckedChanged(sender As Object, e As EventArgs) Handles CBHasta.CheckedChanged
        If CBHasta.Checked = True Then
            DTHasta.Enabled = True
        Else
            DTHasta.Enabled = False
        End If
    End Sub

    Private Sub BClientes_Click(sender As Object, e As EventArgs) Handles BClientes.Click
        PInformes.Visible = False
        PServicioIngreso.Visible = False
        PDatos.Visible = False
        PUsers.Visible = False
        PCierreCaja.Visible = False
        PMarcasModelos.Visible = False
        PVerOTS.Visible = False
        PClientes.Visible = True
        TBBcliente.Text = ""
        CargarCB.llenarTablaClientes("")
        If TClientes.RowCount > 0 Then
            EdCliente.Enabled = True
            ECliente.Enabled = True
            CargarCB.llenarTablasAutos(TClientes(0, TClientes.CurrentRow.Index).Value.ToString, TVehiculos, 1, 1)
        Else
            EdCliente.Enabled = False
            ECliente.Enabled = False
            TVehiculos.RowCount = 0
        End If
        If TVehiculos.RowCount > 0 Then
            EdAuto.Enabled = True
            EAuto.Enabled = True
        Else
            EdAuto.Enabled = False
            EAuto.Enabled = False
        End If
    End Sub

    Private Sub BBuscarCliente_Click(sender As Object, e As EventArgs) Handles BBuscarCliente.Click
        CargarCB.llenarTablaClientes(TBBcliente.Text)
        If TClientes.RowCount > 0 Then
            EdCliente.Enabled = True
            ECliente.Enabled = True
            CargarCB.llenarTablasAutos(TClientes(0, TClientes.CurrentRow.Index).Value.ToString, TVehiculos, 1, 1)
        Else
            EdCliente.Enabled = False
            ECliente.Enabled = False
            TVehiculos.RowCount = 0
        End If
        If TVehiculos.RowCount > 0 Then
            EdAuto.Enabled = True
            EAuto.Enabled = True
        Else
            EdAuto.Enabled = False
            EAuto.Enabled = False
        End If
    End Sub

    Private Sub TClientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles TClientes.CellClick
        If TClientes.RowCount > 0 Then
            CargarCB.llenarTablasAutos(TClientes(0, TClientes.CurrentRow.Index).Value.ToString, TVehiculos, 1, 1)
        End If
    End Sub

    Private Sub ACliente_Click(sender As Object, e As EventArgs) Handles ACliente.Click
        VagregarCliente.Show()
        VagregarCliente.info = 0
        VagregarCliente.toc = 0
        VagregarCliente.rutAntes = ""
        VagregarCliente.TBRut.Text = ""
        VagregarCliente.TBNombre.Text = ""
        VagregarCliente.TBCorreo.Text = ""
        VagregarCliente.TBDireccion.Text = ""
        VagregarCliente.TBFono1.Text = ""
        VagregarCliente.TBFono2.Text = ""
    End Sub

    Private Sub EdCliente_Click(sender As Object, e As EventArgs) Handles EdCliente.Click

        Dim i As Integer = TClientes.CurrentRow.Index

        VagregarCliente.Show()
        VagregarCliente.info = 1
        VagregarCliente.toc = 0
        VagregarCliente.rutAntes = TClientes(0, i).Value.ToString
        VagregarCliente.TBRut.Text = TClientes(0, i).Value.ToString
        VagregarCliente.TBNombre.Text = TClientes(1, i).Value.ToString
        VagregarCliente.TBCorreo.Text = TClientes(2, i).Value.ToString
        VagregarCliente.TBDireccion.Text = TClientes(3, i).Value.ToString
        VagregarCliente.TBFono1.Text = TClientes(4, i).Value.ToString
        VagregarCliente.TBFono2.Text = TClientes(5, i).Value.ToString

    End Sub

    Private Sub AAuto_Click(sender As Object, e As EventArgs) Handles AAuto.Click
        VagregarAuto.Show()
        VagregarAuto.info = 0
        VagregarAuto.toc = 0
        VagregarAuto.TBPatente.Text = ""
        VagregarAuto.TBAnno.Text = ""
        VagregarAuto.TBMotor.Text = ""
        VagregarAuto.TBcolor.Text = ""
    End Sub

    Private Sub EdAuto_Click(sender As Object, e As EventArgs) Handles EdAuto.Click
        Dim i As Integer = TVehiculos.CurrentRow.Index
        VagregarAuto.Show()
        VagregarAuto.info = 1
        VagregarAuto.toc = 0
        VagregarAuto.patenteAnterior = TVehiculos(0, i).Value.ToString
        VagregarAuto.TBPatente.Text = TVehiculos(0, i).Value.ToString
        VagregarAuto.TBAnno.Text = TVehiculos(3, i).Value.ToString
        VagregarAuto.TBMotor.Text = TVehiculos(4, i).Value.ToString
        VagregarAuto.TBcolor.Text = TVehiculos(5, i).Value.ToString
        VagregarAuto.CBAsociado.Text = TClientes(0, TClientes.CurrentRow.Index).Value.ToString
        VagregarAuto.CBMarca.Text = TVehiculos(1, i).Value.ToString
        VagregarAuto.CBModelo.Text = TVehiculos(2, i).Value.ToString
    End Sub

    Private Sub ECliente_Click(sender As Object, e As EventArgs) Handles ECliente.Click
        Dim i As Integer = TClientes.CurrentRow.Index
        respuesta = MessageBox.Show("Se eliminará el cliente de rut " & TClientes(0, i).Value.ToString & " y todos sus vehículos asociados. Esto será permanente ¿Desea continuar?", "Eliminar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If respuesta = DialogResult.Yes Then
            sql = "DELETE FROM `cliente` WHERE rut='" & TClientes(0, i).Value.ToString & "';"
            IngresarDatos(sql)
            TClientes.Rows.Remove(TClientes.CurrentRow)
            TVehiculos.RowCount = 0
            EdAuto.Enabled = False
            EAuto.Enabled = False
            If TClientes.RowCount = 0 Then
                EdCliente.Enabled = False
                ECliente.Enabled = False
            End If
        End If

    End Sub

    Private Sub EAuto_Click(sender As Object, e As EventArgs) Handles EAuto.Click
        Dim i As Integer = TVehiculos.CurrentRow.Index
        respuesta = MessageBox.Show("Se eliminará el vehículo patente " & TVehiculos(0, i).Value.ToString & ". Esto será permanente ¿Desea continuar?", "Eliminar Vehículo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If respuesta = DialogResult.Yes Then
            sql = "DELETE FROM `vehiculo` WHERE patente='" & TVehiculos(0, i).Value.ToString & "';"
            IngresarDatos(sql)
            TVehiculos.Rows.Remove(TVehiculos.CurrentRow)
            If TVehiculos.RowCount = 0 Then
                EdAuto.Enabled = False
                EAuto.Enabled = False
            End If
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        VagregarMarca.info = 0
        VagregarMarca.toc = 0
        VagregarMarca.Show()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        VagregarModelo.info = 0
        VagregarModelo.toc = 0
        VagregarModelo.MarcaAnterior = TMarcas(0, TMarcas.CurrentRow.Index).Value.ToString
        VagregarModelo.modeloAnterior = ""
        VagregarModelo.Show()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        VagregarMarca.info = 1
        VagregarMarca.toc = 0
        VagregarMarca.marcaPrevia = TMarcas(0, TMarcas.CurrentRow.Index).Value.ToString
        VagregarMarca.Show()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        VagregarModelo.info = 1
        VagregarModelo.toc = 0
        VagregarModelo.MarcaAnterior = TMarcas(0, TMarcas.CurrentRow.Index).Value.ToString
        VagregarModelo.modeloAnterior = TModelos(0, TModelos.CurrentRow.Index).Value.ToString
        VagregarModelo.Show()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim i As Integer = TMarcas.CurrentRow.Index
        respuesta = MessageBox.Show("Se eliminará la marca " & TMarcas(0, i).Value.ToString & " y Todos los modelos asociados. Esto será permanente ¿Desea continuar?", "Eliminar Marca", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If respuesta = DialogResult.Yes Then
            sql = "DELETE FROM `marcas` WHERE nombre_marca='" & TMarcas(0, i).Value.ToString & "';"
            IngresarDatos(sql)
            TMarcas.Rows.Remove(TMarcas.CurrentRow)
            If TMarcas.RowCount = 0 Then
                PictureBox4.Enabled = False
                PictureBox2.Enabled = False
            End If
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Dim i As Integer = TModelos.CurrentRow.Index
        respuesta = MessageBox.Show("Se eliminará el Modelo " & TModelos(0, i).Value.ToString & ". Esto será permanente ¿Desea continuar?", "Eliminar Modelo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If respuesta = DialogResult.Yes Then
            sql = "DELETE FROM `modelos` WHERE nombre_modelo='" & TModelos(0, i).Value.ToString & "';"
            IngresarDatos(sql)
            TModelos.Rows.Remove(TModelos.CurrentRow)
            If TModelos.RowCount = 0 Then
                PictureBox6.Enabled = False
                PictureBox5.Enabled = False
            End If
        End If
    End Sub

    Private Sub BotonMarcas_Click(sender As Object, e As EventArgs) Handles BotonMarcas.Click
        PInformes.Visible = False
        PServicioIngreso.Visible = False
        PUsers.Visible = False
        PDatos.Visible = False
        PCierreCaja.Visible = False
        PClientes.Visible = False
        PMarcasModelos.Visible = True
        PVerOTS.Visible = False
        PictureBox6.Enabled = False
        PictureBox5.Enabled = False
        PictureBox4.Enabled = False
        PictureBox2.Enabled = False

        CargarCB.llenarTablaMarcas()
        If TMarcas.RowCount > 0 Then
            CargarCB.llenarTablaModelos(TMarcas(0, TMarcas.CurrentRow.Index).Value.ToString)
        End If
    End Sub

    Private Sub TMarcas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles TMarcas.CellClick
        If TMarcas.RowCount > 0 Then
            CargarCB.llenarTablaModelos(TMarcas(0, TMarcas.CurrentRow.Index).Value.ToString)
        End If
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        VagregarCliente.Show()
        VagregarCliente.toc = 1
        VagregarCliente.cbclient = CBOTClientes
        VagregarCliente.info = 0
        VagregarCliente.rutAntes = ""
        VagregarCliente.TBRut.Text = ""
        VagregarCliente.TBNombre.Text = ""
        VagregarCliente.TBCorreo.Text = ""
        VagregarCliente.TBDireccion.Text = ""
        VagregarCliente.TBFono1.Text = ""
        VagregarCliente.TBFono2.Text = ""
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        VagregarAuto.Show()
        VagregarAuto.info = 0
        VagregarAuto.toc = 1
        VagregarAuto.cbauto = CBPatenteOT
        VagregarAuto.dueno = CBOTClientes.Text
        VagregarAuto.TBPatente.Text = ""
        VagregarAuto.TBAnno.Text = ""
        VagregarAuto.TBMotor.Text = ""
        VagregarAuto.TBcolor.Text = ""
    End Sub

    Private Sub CBOTClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBOTClientes.SelectedIndexChanged
        If CBOTClientes.Items.Count > 0 And CBOTClientes.Text <> "" Then
            Dim i As Integer = CBOTClientes.SelectedIndex

            CBPatenteOT.Enabled = True
            PictureBox9.Enabled = True
            CargarCB.cargarCBautos(CBOTClientes.Text, CBPatenteOT)
            TBNombreOT.Text = CargarCB.clientes(1, i)
            TBCorreoOT.Text = CargarCB.clientes(2, i)
            TBdireccion.Text = CargarCB.clientes(3, i)
            TBFono1OT.Text = CargarCB.clientes(4, i)
            TBFono2OT.Text = CargarCB.clientes(5, i)
            If CBPatenteOT.Items.Count > 0 Then
                CBPatenteOT.SelectedIndex = 0
            Else
                CBPatenteOT.Text = ""
                TBMarcaOT.Text = ""
                TBModeloOT.Text = ""
                TBAnnoOT.Text = ""
                TBColorOT.Text = ""
                TBMotor.Text = ""
            End If
        End If
    End Sub

    Private Sub CBPatenteOT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBPatenteOT.SelectedIndexChanged
        If CBPatenteOT.Items.Count > 0 And CBPatenteOT.Text <> "" Then
            Dim i As Integer = CBPatenteOT.SelectedIndex

            TBMarcaOT.Text = CargarCB.autos(2, i)
            TBModeloOT.Text = CargarCB.autos(3, i)
            TBAnnoOT.Text = CargarCB.autos(4, i)
            TBMotor.Text = CargarCB.autos(5, i)
            TBColorOT.Text = CargarCB.autos(6, i)
        End If
    End Sub

    Private Sub BAnadirService_Click(sender As Object, e As EventArgs) Handles BAnadirService.Click
        Dim cantidad As Integer
        Dim Valor As Integer
        Dim Repuesto As String

        If TBRepuesto.Text <> "" Then
            Repuesto = TBRepuesto.Text
            If CInt(TBCanR.Text) > 0 Then
                cantidad = 1
            Else
                cantidad = 0
            End If
            If CInt(TBValorR.Text) >= 0 Then
                Valor = 1
            Else
                Valor = 0
            End If
        Else
            TBCanR.Text = 0
            TBValorR.Text = 0
            cantidad = 1
            Valor = 1
        End If

        If CBMecaOT.Text <> "" And CBTServiceOT.Text <> "" And TBMoValor.Text <> "" And cantidad = 1 And Valor = 1 Then
            Dim filas As Integer = TCOT.RowCount
            TCOT.RowCount = filas + 1

            TotalMO = 0
            TotalR = 0
            SubT = 0
            dscuento = 0
            Neto = 0
            Tiva = 0
            Total = 0

            TCOT(0, filas).Value = CBTServiceOT.Text
            TCOT(1, filas).Value = TBDetalle.Text
            TCOT(2, filas).Value = TBRepuesto.Text
            TCOT(3, filas).Value = TBCanR.Text
            TCOT(4, filas).Value = TBValorR.Text
            TCOT(5, filas).Value = CInt(TBCanR.Text) * CInt(TBValorR.Text)
            TCOT(6, filas).Value = TBMoValor.Text
            TCOT(7, filas).Value = CInt(TBMoValor.Text) + CInt(TCOT(5, filas).Value.ToString)
            TCOT(8, filas).Value = CBMecaOT.Text

            For i = 0 To TCOT.RowCount - 1
                TotalMO = TotalMO + CInt(TCOT(6, i).Value)
                TotalR = TotalR + CInt(TCOT(5, i).Value)
            Next

            SubT = TotalR + TotalMO
            dscuento = (SubT * CInt(TBDescuento.Text)) / 100
            Neto = SubT - dscuento
            Tiva = (Neto * CInt(general.parametros(0, 0))) / 100
            Total = Neto + Tiva


            EtiTRepu.Text = "Total Repuestos: $" & TotalR
            EtiTMO.Text = "Total MO: $" & TotalMO
            EtiStotal.Text = "Subtotal: $" & SubT
            EtiDes.Text = "Descuento: $" & dscuento
            EtiNeto.Text = "Neto: $" & Neto
            EtiIVa.Text = "Total IVA: $" & Tiva
            EtiTotal.Text = "Total: $" & Total
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TotalMO = 0
        TotalR = 0
        SubT = 0
        dscuento = 0
        Neto = 0
        Tiva = 0
        Total = 0

        If TCOT.RowCount > 0 Then
            For i = 0 To TCOT.RowCount - 1
                TotalMO = TotalMO + CInt(TCOT(6, i).Value)
                TotalR = TotalR + CInt(TCOT(5, i).Value)
            Next

            SubT = TotalR + TotalMO
            dscuento = (SubT * CInt(TBDescuento.Text)) / 100
            Neto = SubT - dscuento
            Tiva = (Neto * CInt(general.parametros(0, 0))) / 100
            Total = Neto + Tiva


            EtiTRepu.Text = "Total Repuestos: $" & TotalR
            EtiTMO.Text = "Total MO: $" & TotalMO
            EtiStotal.Text = "Subtotal: $" & SubT
            EtiDes.Text = "Descuento: $" & dscuento
            EtiNeto.Text = "Neto: $" & Neto
            EtiIVa.Text = "Total IVA: $" & Tiva
            EtiTotal.Text = "Total: $" & Total
        End If
    End Sub

    Private Sub CBEstadoOT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBEstadoOT.SelectedIndexChanged
        If CBEstadoOT.Text = "Abonado" Then
            TBAbonoOT.Enabled = True
        Else
            TBAbonoOT.Text = 0
            TBAbonoOT.Enabled = False
        End If
    End Sub

    Private Sub BNOT_Click(sender As Object, e As EventArgs) Handles BNOT.Click
        Panel6.Enabled = True
        Panel5.Enabled = True
        Panel4.Enabled = True
        Panel3.Enabled = True
        Panel2.Enabled = True
        TCOT.Enabled = True
        BImprimirOrden.Enabled = False
        TBobs.Enabled = True
        BGuardarService.Enabled = True

        TCOT.RowCount = 0
        EtiTRepu.Text = "Total Repuestos: $"
        EtiTMO.Text = "Total MO: $"
        EtiStotal.Text = "Subtotal: $"
        EtiDes.Text = "Descuento: $"
        EtiNeto.Text = "Neto: $"
        EtiIVa.Text = "Total IVA: $"
        EtiTotal.Text = "Total: $"
        EtiNOT.Text = "OT N°: " & general.parametros(1, 0)

        TBobs.Text = ""
        TBAbonoOT.Text = 0
        TBCanR.Text = 0
        TBDescuento.Text = 0
        TBDetalle.Text = ""
        TBMoValor.Text = 0
        TBValorR.Text = 0
        TBRepuesto.Text = ""
    End Sub

    Private Sub BImprimirOrden_Click(sender As Object, e As EventArgs) Handles BImprimirOrden.Click
        informes.ExportarExcelOT(TCOT, Label1.Text, fechasAcotar2(System.DateTime.Now.ToString), EtiNOT.Text, CBOTClientes.Text, TBNombreOT.Text, TBCorreoOT.Text, TBFono1OT.Text, TBFono2OT.Text, CBPatenteOT.Text, TBMarcaOT.Text, TBAnnoOT.Text, TBKmOT.Text, TBModeloOT.Text, TBColorOT.Text, DTIngreso.Value.ToString, DTSalida.Value.ToString, CBCondicionOT.Text, CBTipoDocOT.Text, TBobs.Text, CBEstadoOT.Text, TBAbonoOT.Text, EtiTRepu.Text, EtiTMO.Text, EtiStotal.Text, EtiDes.Text, EtiNeto.Text, EtiIVa.Text, EtiTotal.Text, TBdireccion.Text, TBMotor.Text, TBPlazo.Text)
    End Sub

    Private Sub BDatos_Click(sender As Object, e As EventArgs) Handles BDatos.Click
        PInformes.Visible = False
        PServicioIngreso.Visible = False
        PUsers.Visible = False
        PClientes.Visible = False
        PMarcasModelos.Visible = False
        PVerOTS.Visible = False
        PDatos.Visible = True
        PCierreCaja.Visible = False
        CargarCB.llenarTablaServicios()
        CargarCB.llenarTablaParametros()
    End Sub

    Private Sub BGuardarPara_Click(sender As Object, e As EventArgs) Handles BGuardarPara.Click
        TablaParametros.EndEdit()
        Try
            If CInt(TablaParametros(1, 0).Value) >= 0 And CInt(TablaParametros(1, 1).Value) >= 0 Then
                respuesta = MessageBox.Show("¿Desea Guardar los cambios en Parametros?", "Parametros", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If respuesta = DialogResult.Yes Then
                    Guardar.GParametros()
                End If
            Else
                MessageBox.Show("Los valores deben ser mayores o igual a 0", "Parametros", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Los valores deben ser numéricos mayores o igual a 0", "Parametros", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BEliminarSer_Click(sender As Object, e As EventArgs) Handles BEliminarSer.Click
        Dim i As Integer = TablaServicios.CurrentRow.Index
        respuesta = MessageBox.Show("Se eliminará el servicio " & TablaServicios(0, i).Value.ToString & ". Esto será permanente ¿Desea continuar?", "Eliminar Servicio", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If respuesta = DialogResult.Yes Then
            sql = "DELETE FROM `tservice` WHERE name_s='" & TablaServicios(0, i).Value.ToString & "';"
            IngresarDatos(sql)
            TablaServicios.Rows.Remove(TablaServicios.CurrentRow)
            If TModelos.RowCount = 0 Then
                BEditarSer.Enabled = False
                BEliminarSer.Enabled = False
            End If
        End If
    End Sub

    Private Sub BNuevoSer_Click(sender As Object, e As EventArgs) Handles BNuevoSer.Click
        Vservicios.toc = 0
        Vservicios.noa = 0
        Vservicios.valorAnterior = ""
        Vservicios.Show()

    End Sub

    Private Sub BEditarSer_Click(sender As Object, e As EventArgs) Handles BEditarSer.Click
        Vservicios.toc = 0
        Vservicios.noa = 1
        Vservicios.valorAnterior = TablaServicios(0, TablaServicios.CurrentRow.Index).Value.ToString
        Vservicios.Show()
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        Vservicios.toc = 1
        Vservicios.noa = 0
        Vservicios.valorAnterior = ""
        Vservicios.Show()
    End Sub

    Private Sub BInformesServicios_Click(sender As Object, e As EventArgs) Handles BInformesServicios.Click
        Label34.Text = "Servicios"
        CBDesde.Enabled = True
        CBHasta.Enabled = True
        busqueda = 0
        CargarCB.BuscarInformesServicios("1900-01-01", "4000-12-31", "")

    End Sub

    Private Sub BInformeVehiculos_Click(sender As Object, e As EventArgs) Handles BInformeVehiculos.Click
        Label34.Text = "Vehiculos"
        CBDesde.Enabled = False
        CBHasta.Enabled = False
        DTDesde.Enabled = False
        DTHasta.Enabled = False
        busqueda = 1
        CargarCB.BuscarInformesVehiculos("")
    End Sub

    Private Sub BInformesClientes_Click(sender As Object, e As EventArgs) Handles BInformesClientes.Click
        Label34.Text = "Clientes"
        CBDesde.Enabled = False
        CBHasta.Enabled = False
        DTDesde.Enabled = False
        DTHasta.Enabled = False
        busqueda = 2
        CargarCB.buscarInformesClientes("")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DGInformes.RowCount > 0 Then
            Dim doc As String
            Dim xlApp As Object = CreateObject("Excel.Application")
            'Se crea una nueva hoja de calculo
            Dim xlwB As Object = xlApp.WorkBooks.add()
            Dim procesos As Process()
            Dim save As New SaveFileDialog


            Dim xlWS As Object = xlwB.Worksheets(1)
            'Exportamos los caracteres de las columnas
            For c As Integer = 0 To DGInformes.Columns.Count - 1
                xlWS.cells(1, c + 1).value = DGInformes.Columns(c).HeaderText
            Next

            'Exportamos las cabeceras de columnas
            For r As Integer = 0 To DGInformes.RowCount - 1
                For c As Integer = 0 To DGInformes.Columns.Count - 1
                    xlWS.cells(r + 2, c + 1).value = DGInformes.Item(c, r).Value
                Next
            Next

            'Guardamos la hoja de calculo en la ruta especifada
            Try
                save.FileName = Label34.Text & " " & general.fechasAcotar2(System.DateTime.Now().ToString)
                save.Filter = "Archivo Excel | *.xlsx"
                If save.ShowDialog = Windows.Forms.DialogResult.OK Then
                    doc = save.FileName
                    xlwB.saveas(save.FileName)

                    MsgBox("Documento creado")

                End If
            Catch ex As Exception

            End Try
            Try
                xlwB.Close()
                xlApp.Quit()
                procesos = Process.GetProcessesByName("EXCEL")
                If procesos.Length > 0 Then
                    For i = procesos.Length - 1 To 0 Step -1
                        procesos(i).Kill()
                    Next
                End If

                xlWS = Nothing
                xlwB = Nothing
                xlApp = Nothing
                Process.Start(doc)
            Catch ex As Exception

            End Try


        End If
    End Sub

    Private Sub CBTipoDocOT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBTipoDocOT.SelectedIndexChanged
        If CBTipoDocOT.SelectedIndex > 0 Then
            TBPlazo.Text = 0
            TBPlazo.Enabled = True
        Else
            TBPlazo.Text = 0
            TBPlazo.Enabled = False
        End If
    End Sub

    Private Sub BInfoOTS_Click(sender As Object, e As EventArgs) Handles BInfoOTS.Click
        PInformes.Visible = False
        PServicioIngreso.Visible = False
        PUsers.Visible = False
        PClientes.Visible = False
        PMarcasModelos.Visible = False
        PVerOTS.Visible = True
        PDatos.Visible = False
        PCierreCaja.Visible = False
        CargarCB.llenarTablaOts(TBVerOTS.Text, "1900-01-01", "4000-12-31")

        DGClienteOT.RowCount = 0
        DGDetalleOTS.RowCount = 0
        DGAutoOT.RowCount = 0
        If DGVerOTS.RowCount > 0 Then
            CargarCB.llenarTablaServiciosOts(DGVerOTS(1, 0).Value.ToString, DGVerOTS(2, 0).Value.ToString, DGVerOTS(0, 0).Value.ToString)
        End If
    End Sub

    Private Sub CDesdeVerOTS_CheckedChanged(sender As Object, e As EventArgs) Handles CDesdeVerOTS.CheckedChanged
        If CDesdeVerOTS.Checked = True Then
            DTDesdeVerOTS.Enabled = True
        Else
            DTDesdeVerOTS.Enabled = False
            desde = "1900-01-01"
        End If
    End Sub

    Private Sub CHastVerOTS_CheckedChanged(sender As Object, e As EventArgs) Handles CHastVerOTS.CheckedChanged
        If CHastVerOTS.Checked = True Then
            DTHastaVerOTS.Enabled = True
        Else
            DTHastaVerOTS.Enabled = False
            hasta = "4000-12-31"
        End If
    End Sub

    Private Sub BBuscarVerOTS_Click(sender As Object, e As EventArgs) Handles BBuscarVerOTS.Click
        If CDesdeVerOTS.Checked = True Then
            desde = general.fechasVoltear(DTDesdeVerOTS.Value.ToString)
        End If
        If CHastVerOTS.Checked = True Then
            hasta = general.fechasVoltear(DTHastaVerOTS.Value.ToString)
        End If

        CargarCB.llenarTablaOts(TBVerOTS.Text, desde, hasta)

        DGClienteOT.RowCount = 0
        DGDetalleOTS.RowCount = 0
        DGAutoOT.RowCount = 0
        If DGVerOTS.RowCount > 0 Then
            CargarCB.llenarTablaServiciosOts(DGVerOTS(1, 0).Value.ToString, DGVerOTS(2, 0).Value.ToString, DGVerOTS(0, 0).Value.ToString)
        End If
    End Sub

    Private Sub DGVerOTS_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVerOTS.CellContentClick
        Dim x As Integer
        x = DGVerOTS.CurrentRow.Index
        CargarCB.llenarTablaServiciosOts(DGVerOTS(1, x).Value.ToString, DGVerOTS(2, x).Value.ToString, DGVerOTS(0, x).Value.ToString)
    End Sub

    Private Sub BExportarOTS_Click(sender As Object, e As EventArgs) Handles BExportarOTS.Click
        If DGVerOTS.RowCount > 0 Then
            Dim doc As String
            Dim xlApp As Object = CreateObject("Excel.Application")
            'Se crea una nueva hoja de calculo
            Dim xlwB As Object = xlApp.WorkBooks.add()
            Dim procesos As Process()
            Dim save As New SaveFileDialog


            Dim xlWS As Object = xlwB.Worksheets(1)
            'Exportamos los caracteres de las columnas
            For c As Integer = 0 To DGVerOTS.Columns.Count - 1
                xlWS.cells(1, c + 1).value = DGVerOTS.Columns(c).HeaderText
            Next

            'Exportamos las cabeceras de columnas
            For r As Integer = 0 To DGVerOTS.RowCount - 1
                For c As Integer = 0 To DGVerOTS.Columns.Count - 1
                    xlWS.cells(r + 2, c + 1).value = DGVerOTS.Item(c, r).Value
                Next
            Next

            'Guardamos la hoja de calculo en la ruta especifada
            Try
                save.FileName = "ListaOTS " & general.fechasAcotar2(System.DateTime.Now().ToString)
                save.Filter = "Archivo Excel | *.xlsx"
                If save.ShowDialog = Windows.Forms.DialogResult.OK Then
                    doc = save.FileName
                    xlwB.saveas(save.FileName)

                    MsgBox("Documento creado")

                End If
            Catch ex As Exception

            End Try
            Try
                xlwB.Close()
                xlApp.Quit()
                procesos = Process.GetProcessesByName("EXCEL")
                If procesos.Length > 0 Then
                    For i = procesos.Length - 1 To 0 Step -1
                        procesos(i).Kill()
                    Next
                End If

                xlWS = Nothing
                xlwB = Nothing
                xlApp = Nothing
                Process.Start(doc)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub BExportarDetalleOTS_Click(sender As Object, e As EventArgs) Handles BExportarDetalleOTS.Click

        If DGVerOTS.RowCount > 0 Then
            Dim x As Integer
            x = DGVerOTS.CurrentRow.Index

            informes.ExportarExcelOT(DGDetalleOTS, DGVerOTS(5, x).Value.ToString, DGVerOTS(3, x).Value.ToString, "OT N°" & DGVerOTS(0, x).Value.ToString, DGVerOTS(1, x).Value.ToString, DGClienteOT(0, x).Value.ToString, DGClienteOT(1, x).Value.ToString, DGClienteOT(3, x).Value.ToString, DGClienteOT(4, x).Value.ToString, DGAutoOT(0, 0).Value.ToString, DGAutoOT(1, 0).Value.ToString, DGAutoOT(3, 0).Value.ToString, DGAutoOT(6, 0).Value.ToString, DGAutoOT(2, 0).Value.ToString, DGAutoOT(5, 0).Value.ToString, DGVerOTS(3, x).Value.ToString, DGVerOTS(4, x).Value.ToString, DGVerOTS(6, x).Value.ToString, DGVerOTS(7, x).Value.ToString, DGVerOTS(18, x).Value.ToString, DGVerOTS(9, x).Value.ToString, DGVerOTS(10, x).Value.ToString, DGVerOTS(12, x).Value.ToString, DGVerOTS(11, x).Value.ToString, DGVerOTS(13, x).Value.ToString, DGVerOTS(14, x).Value.ToString, DGVerOTS(15, x).Value.ToString, DGVerOTS(16, x).Value.ToString, DGVerOTS(17, x).Value.ToString, DGClienteOT(2, x).Value.ToString, DGAutoOT(4, x).Value.ToString, DGVerOTS(8, x).Value.ToString)
        End If
    End Sub

    Private Sub BEditarEstadoOTS_Click(sender As Object, e As EventArgs) Handles BEditarEstadoOTS.Click

        If DGVerOTS.RowCount > 0 Then

            Dim x As Integer
            x = DGVerOTS.CurrentRow.Index
            If DGVerOTS(9, x).Value.ToString = "Aceptado" Then
                VEditarEstadoOT.ComboBox1.Items.Clear()
                VEditarEstadoOT.ComboBox1.Items.Add("Aceptado")
                VEditarEstadoOT.ComboBox1.Items.Add("Abonado")
                VEditarEstadoOT.ComboBox1.Items.Add("Pagado")
                VEditarEstadoOT.ComboBox1.SelectedIndex = 0
                VEditarEstadoOT.Label2.Visible = False
                VEditarEstadoOT.TBCantidad.Visible = False
                VEditarEstadoOT.TBCantidad.Text = "0"
                VEditarEstadoOT.monto = 0
                VEditarEstadoOT.total = CInt(DGVerOTS(17, x).Value.ToString)
                VEditarEstadoOT.ot = DGVerOTS(0, x).Value.ToString
                VEditarEstadoOT.Show()
            ElseIf DGVerOTS(9, x).Value.ToString = "Abonado" Then
                VEditarEstadoOT.ComboBox1.Items.Clear()
                VEditarEstadoOT.ComboBox1.Items.Add("Abonado")
                VEditarEstadoOT.ComboBox1.Items.Add("Pagado")
                VEditarEstadoOT.ComboBox1.SelectedIndex = 0
                VEditarEstadoOT.Label2.Visible = True
                VEditarEstadoOT.TBCantidad.Visible = True
                VEditarEstadoOT.TBCantidad.Text = DGVerOTS(10, x).Value.ToString
                VEditarEstadoOT.monto = CInt(DGVerOTS(10, x).Value.ToString)
                VEditarEstadoOT.total = CInt(DGVerOTS(17, x).Value.ToString)
                VEditarEstadoOT.ot = DGVerOTS(0, x).Value.ToString
                VEditarEstadoOT.Show()
            ElseIf DGVerOTS(9, x).Value.ToString = "Pendiente" Then
                VEditarEstadoOT.ComboBox1.Items.Clear()
                VEditarEstadoOT.ComboBox1.Items.Add("Aceptado")
                VEditarEstadoOT.ComboBox1.Items.Add("Abonado")
                VEditarEstadoOT.ComboBox1.Items.Add("Pagado")
                VEditarEstadoOT.ComboBox1.Items.Add("Cancelado")
                VEditarEstadoOT.ComboBox1.SelectedIndex = 0
                VEditarEstadoOT.Label2.Visible = False
                VEditarEstadoOT.TBCantidad.Visible = False
                VEditarEstadoOT.TBCantidad.Text = "0"
                VEditarEstadoOT.monto = 0
                VEditarEstadoOT.total = CInt(DGVerOTS(17, x).Value.ToString)
                VEditarEstadoOT.ot = DGVerOTS(0, x).Value.ToString
                VEditarEstadoOT.Show()
            End If
            CargarCB.llenarTablaOts(TBVerOTS.Text, desde, hasta)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        cierrecajaactuar()
    End Sub

    Public Sub cierrecajaactuar()
        DGCaja.RowCount = 6
        Dim parametro(4) As String
        Dim valor(0, 0) As String
        parametro(0) = "Crédito"
        parametro(1) = "Efectivo"
        parametro(2) = "Targeta Crédito"
        parametro(3) = "Targeta Débito"
        parametro(4) = "Transferencia"

        ReDim general.consultaVector(4)
        general.consultaVector(0) = "credito"
        general.consultaVector(1) = "efectivo"
        general.consultaVector(2) = "tcredito"
        general.consultaVector(3) = "tdebito"
        general.consultaVector(4) = "transferencia"
        sql = "SELECT * FROM sumascaja;"

        valor = general.recuperar(sql)
        DGCaja(0, 5).Value = "Total"
        DGCaja(1, 5).Value = "0"
        DGCaja(2, 5).Value = "0"
        DGCaja(3, 5).Value = "0"
        DGCaja(4, 5).Value = "0"
        For i = 0 To 4
            DGCaja(0, i).Value = parametro(i)
            DGCaja(1, i).Value = valor(i, 0)
            DGCaja(2, i).Value = "0"
            DGCaja(3, i).Value = "0"
            DGCaja(4, i).Value = "0"
            DGCaja(1, 5).Value = CInt(DGCaja(1, 5).Value.ToString) + CInt(valor(i, 0))


            DGCaja(4, i).Value = CInt(DGCaja(1, i).Value.ToString) + CInt(DGCaja(2, i).Value.ToString) - CInt(DGCaja(3, i).Value.ToString)


        Next

        DateTimePicker1.Value = general.parametros(2, 0)

        DGCaja(4, 5).Value = CInt(DGCaja(1, 5).Value.ToString) + CInt(DGCaja(2, 5).Value.ToString) - CInt(DGCaja(3, 5).Value.ToString)
        PInformes.Visible = False
        PServicioIngreso.Visible = False
        PUsers.Visible = False
        PClientes.Visible = False
        PMarcasModelos.Visible = False
        PVerOTS.Visible = False
        PDatos.Visible = False
        PCierreCaja.Visible = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DGCaja.EndEdit()
        respuesta = MessageBox.Show("Al cerrar caja no podrá ingresar más OTs por el día " & DateTimePicker1.Text & " ¿Quiere continuar con el cerrado de caja?", "Cerrar Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If respuesta = DialogResult.Yes Then
            Try


                sql = "INSERT INTO `caja`(`fecha`, `entrada_credito`, `entrada_efectivo`, `entrada_targeta_credito`, `entrada_targeta_debito`, `entrada_transferencia`, `salida_credito`, `salida_efectivo`, `salida_targeta_credito`, `salida_targeta_debito`, `salida_transferencia`, `total_credito`, `total_efectivo`, `total_targeta_credito`, `total_targeta_debito`, `total_transferencia`, `total`) VALUES ('" & general.fechasAcotar(DateTimePicker1.Text) & "','" & CInt(DGCaja(1, 0).Value.ToString) + CInt(DGCaja(2, 0).Value.ToString) & "','" & CInt(DGCaja(1, 1).Value.ToString) + CInt(DGCaja(2, 1).Value.ToString) & "','" & CInt(DGCaja(1, 2).Value.ToString) + CInt(DGCaja(2, 2).Value.ToString) & "','" & CInt(DGCaja(1, 3).Value.ToString) + CInt(DGCaja(2, 3).Value.ToString) & "','" & CInt(DGCaja(1, 4).Value.ToString) + CInt(DGCaja(2, 4).Value.ToString) & "','" & CInt(DGCaja(3, 0).Value.ToString) & "','" & CInt(DGCaja(3, 1).Value.ToString) & "','" & CInt(DGCaja(3, 2).Value.ToString) & "','" & CInt(DGCaja(3, 3).Value.ToString) & "','" & CInt(DGCaja(3, 4).Value.ToString) & "','" & CInt(DGCaja(4, 0).Value.ToString) & "','" & CInt(DGCaja(4, 1).Value.ToString) & "','" & CInt(DGCaja(4, 2).Value.ToString) & "','" & CInt(DGCaja(4, 3).Value.ToString) & "','" & CInt(DGCaja(4, 4).Value.ToString) & "','" & CInt(DGCaja(4, 5).Value.ToString) & "');"
                general.IngresarDatos(sql)
                DateTimePicker1.Value = DateTimePicker1.Value.AddDays(1)
                sql = "UPDATE `parametros` SET `c_caja`='" & DateTimePicker1.Text & "',`usuario`='" & general.usuario(0, 0) & "' WHERE 1"
                general.IngresarDatos(sql)
                sql = "UPDATE `sumascaja` SET `credito`=0,`efectivo`=0,`tdebito`=0,`tcredito`=0,`transferencia`=0 WHERE 1;"
                general.IngresarDatos(sql)
                If general.ComprobarCierre() Then
                    BService.Enabled = True
                Else
                    BService.Enabled = False
                End If
            Catch ex As Exception
                MessageBox.Show("Todos los valores deben ser numéricos", "ERROR de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub BCaja_Click(sender As Object, e As EventArgs) Handles BCaja.Click
        Label34.Text = "Cierres de Caja"
        CBDesde.Enabled = True
        CBHasta.Enabled = True
        busqueda = 3
        CargarCB.buscarInformesCierres("", "1900-01-01", "4000-12-31")
    End Sub

    Private Sub DGCaja_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGCaja.CellEndEdit
        Dim numero As Integer

        For i = 0 To 5
            For j = 2 To 3
                Try
                    numero = CInt(Convert.ToString(DGCaja(j, i).Value))
                Catch ex As Exception
                    DGCaja(j, i).Value = "0"
                End Try
            Next
        Next

        Try
            For i = 0 To 4
                DGCaja(4, i).Value = CInt(Convert.ToString(DGCaja(1, i).Value)) + CInt(DGCaja(2, i).Value.ToString) - CInt(DGCaja(3, i).Value.ToString)
            Next

            For i = 1 To 5
                DGCaja(i, 5).Value = "0"
                For j = 0 To 4
                    DGCaja(i, 5).Value = CInt(DGCaja(i, 5).Value.ToString) + CInt(DGCaja(i, j).Value.ToString)
                Next
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Principal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        respuesta = MessageBox.Show("¿Desea cerrar el programa por completo? Presione Sí para cerrar, No para cerrar sesión o Cancelar para continuar en el programa", "Cerrar Programa", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
        If respuesta = DialogResult.Yes Then
            End
        ElseIf respuesta = DialogResult.No Then
            Form1.Show()
        Else
            e.Cancel = True
        End If
    End Sub

    'Mensaje de referencia sobre objeto
    Public Sub Cayuda(ByVal objeto As Object, ByVal mensaje As String)
        Ayuda.RemoveAll()
        Ayuda.SetToolTip(objeto, mensaje)
        Ayuda.InitialDelay = 500
        Ayuda.IsBalloon = False
    End Sub

    Private Sub BService_MouseEnter(sender As Object, e As EventArgs) Handles BService.MouseEnter
        Cayuda(BService, "Ingresar OTs")
    End Sub

    Private Sub BInfoOTS_MouseEnter(sender As Object, e As EventArgs) Handles BInfoOTS.MouseEnter
        Cayuda(BInfoOTS, "Ver OTs")
    End Sub

    Private Sub BInformes_MouseEnter(sender As Object, e As EventArgs) Handles BInformes.MouseEnter
        Cayuda(BInformes, "Informes")
    End Sub

    Private Sub BClientes_MouseEnter(sender As Object, e As EventArgs) Handles BClientes.MouseEnter
        Cayuda(BClientes, "Clientes")
    End Sub

    Private Sub BotonMarcas_MouseEnter(sender As Object, e As EventArgs) Handles BotonMarcas.MouseEnter
        Cayuda(BotonMarcas, "Marcas y Modelos")
    End Sub

    Private Sub BUsers_MouseEnter(sender As Object, e As EventArgs) Handles BUsers.MouseEnter
        Cayuda(BUsers, "Administrar Usuarios")
    End Sub

    Private Sub BDatos_MouseEnter(sender As Object, e As EventArgs) Handles BDatos.MouseEnter
        Cayuda(BDatos, "Parámetros")
    End Sub

    Private Sub PictureBox3_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox3.MouseEnter
        Cayuda(PictureBox3, "Cambiar Contraseña")
    End Sub
End Class