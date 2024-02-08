Public Class VagregarAuto
    Dim sql As String
    Public patenteAnterior As String
    Public info As Integer
    Public toc As Integer
    Public cbauto As ComboBox
    Public dueno As String
    Private Sub VagregarAuto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarCB.cargarMarcas(CBMarca)
        If CBMarca.Items.Count > 0 Then
            CBMarca.SelectedIndex = 0
            CargarCB.cargarModelos(CBModelo, CBMarca.Text)
            If CBModelo.Items.Count > 0 Then
                CBModelo.SelectedIndex = 0
            Else
                CBModelo.Text = ""
            End If
        Else
            CBMarca.Text = ""
        End If

        CargarCB.llenarCBClientes(CBAsociado)
    End Sub

    Private Sub nuevoAuto()
        sql = "INSERT INTO `vehiculo`(`patente`, `rut_asociado`, `marca`, `modelo`, `anno`, `motor`, `color`) VALUES ('" & TBPatente.Text & "','" & CBAsociado.Text & "','" & CBMarca.Text & "','" & CBModelo.Text & "','" & TBAnno.Text & "','" & TBMotor.Text & "','" & TBcolor.Text & "');"
        general.IngresarDatos(sql)
        If toc = 0 Then
            CargarCB.llenarTablasAutos(Principal.TClientes(0, Principal.TClientes.CurrentRow.Index).Value.ToString, Principal.TVehiculos, 1, 1)
        Else
            CargarCB.cargarCBautos(dueno, cbauto)
        End If
        MessageBox.Show("Vehículo agregado con éxito", "Guardar Vehículo", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub editarAuto(ByVal dato As String)
        sql = "UPDATE `vehiculo` SET `patente`='" & TBPatente.Text & "',`rut_asociado`='" & CBAsociado.Text & "',`marca`='" & CBMarca.Text & "',`modelo`='" & CBModelo.Text & "',`anno`='" & TBAnno.Text & "',`motor`='" & TBMotor.Text & "',`color`='" & TBcolor.Text & "' WHERE patente='" & dato & "';"
        general.IngresarDatos(sql)
        If toc = 0 Then
            CargarCB.llenarTablasAutos(Principal.TClientes(0, Principal.TClientes.CurrentRow.Index).Value.ToString, Principal.TVehiculos, 1, 1)
        Else
            CargarCB.cargarCBautos(dueno, cbauto)
        End If
        MessageBox.Show("Vehículo actualizado con éxito", "Guardar Vehículo", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub BGCliente_Click(sender As Object, e As EventArgs) Handles BGCliente.Click
        If TBPatente.Text <> "" And CBAsociado.Text <> "" Then
            Dim respueta As DialogResult = MessageBox.Show("¿Desea guardar el vehículo " & TBPatente.Text & "?", "Guardar Vehículo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If respueta = DialogResult.Yes Then
                If info = 0 Then
                    Try
                        nuevoAuto()
                    Catch ex As Exception
                        respueta = MessageBox.Show("El vehículo " & TBPatente.Text & "ya existe. ¿Desea actualizar la información de este vehículo?", "Guardar Vehículo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        If respueta = DialogResult.Yes Then
                            editarAuto(TBPatente.Text)
                        End If
                    End Try
                Else
                    editarAuto(patenteAnterior)
                End If

            End If
        Else
            MessageBox.Show("La patente y/o el Rut Asociado no pueden quedar en blanco. Compruebe estos datos y vuelva a intentarlo.", "Guardar Vehículo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub CBMarca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBMarca.SelectedIndexChanged
        CargarCB.cargarModelos(CBModelo, CBMarca.Text)
        If CBModelo.Items.Count > 0 Then
            CBModelo.SelectedIndex = 0
        Else
            CBModelo.Text = ""
        End If
    End Sub

    Private Sub mascliente_Click(sender As Object, e As EventArgs) Handles mascliente.Click
        VagregarCliente.Show()
        VagregarCliente.toc = 1
        VagregarCliente.cbclient = CBAsociado
        VagregarCliente.info = 0
        VagregarCliente.rutAntes = ""
        VagregarCliente.TBRut.Text = ""
        VagregarCliente.TBNombre.Text = ""
        VagregarCliente.TBCorreo.Text = ""
        VagregarCliente.TBDireccion.Text = ""
        VagregarCliente.TBFono1.Text = ""
        VagregarCliente.TBFono2.Text = ""
    End Sub

    Private Sub MasMarca_Click(sender As Object, e As EventArgs) Handles MasMarca.Click
        VagregarMarca.info = 0
        VagregarMarca.cbpedido = Me.CBMarca
        VagregarMarca.toc = 1
        VagregarMarca.Show()
    End Sub

    Private Sub MasModelo_Click(sender As Object, e As EventArgs) Handles MasModelo.Click
        VagregarModelo.info = 0
        VagregarModelo.toc = 1
        VagregarModelo.cbmodelo = Me.CBModelo
        VagregarModelo.MarcaAnterior = CBMarca.Text
        VagregarModelo.modeloAnterior = CBModelo.Text
        VagregarModelo.Show()
    End Sub
End Class