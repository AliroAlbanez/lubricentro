Module CargarCB
    Dim sql As String
    Public servicios(0, 0) As String
    Public empleados(0, 0) As String
    Public usuarios(0, 0) As String
    Public services(0, 0) As String
    Public clientes(0, 0) As String
    Public autos(0, 0) As String
    Dim marcas(0, 0) As String
    Dim modelos(0, 0) As String

    'Comboboxs de Panel Ingresar Servicios
    Public Sub RCBEmpleados()
        sql = "SELECT nombre FROM usuario;"
        ReDim general.consultaVector(0)
        general.consultaVector(0) = "nombre"

        empleados = general.recuperar(sql)
        Principal.CBMecaOT.Items.Clear()

        If empleados(0, 0) <> "" Then
            For i = 0 To empleados.GetUpperBound(1)
                Principal.CBMecaOT.Items.Add(empleados(0, i))
            Next
        End If
    End Sub

    Public Sub Rservicios()
        sql = "SELECT * FROM tservices;"
        ReDim general.consultaVector(0)
        general.consultaVector(0) = "name_s"

        servicios = general.recuperar(sql)
    End Sub

    Public Sub llenarTablaServicios()
        Rservicios()
        Principal.TablaServicios.RowCount = 0
        Principal.BEliminarSer.Enabled = False
        Principal.BEditarSer.Enabled = False
        If servicios(0, 0) <> "" Then
            For i = 0 To servicios.GetUpperBound(1)
                Principal.TablaServicios.RowCount = i + 1
                Principal.TablaServicios(0, i).Value = servicios(0, i)
            Next
            Principal.BEliminarSer.Enabled = True
            Principal.BEditarSer.Enabled = True
        End If
    End Sub

    Public Sub llenarTablaParametros()
        Rparametros()
        Principal.TablaParametros.RowCount = 0
        Principal.TablaParametros.RowCount = 3
        Principal.TablaParametros(0, 0).Value = "% IVA"
        Principal.TablaParametros(0, 1).Value = "N° OT"
        Principal.TablaParametros(0, 2).Value = "Cierre Caja"
        Principal.TablaParametros(1, 0).Value = general.parametros(0, 0)
        Principal.TablaParametros(1, 1).Value = general.parametros(1, 0)
        Principal.TablaParametros(1, 2).Value = general.parametros(2, 0)
    End Sub

    Public Sub Rparametros()
        sql = "SELECT * FROM parametros;"
        ReDim general.consultaVector(3)
        general.consultaVector(0) = "iva"
        general.consultaVector(1) = "ot"
        general.consultaVector(2) = "c_caja"
        general.consultaVector(3) = "usuario"
        general.parametros = general.recuperar(sql)
    End Sub

    Public Sub RCBServices()
        Rservicios()
        Principal.CBTServiceOT.Items.Clear()

        If servicios(0, 0) <> "" Then
            For i = 0 To servicios.GetUpperBound(1)
                Principal.CBTServiceOT.Items.Add(servicios(0, i))
            Next
        End If
    End Sub
    '-------------------------------------------------------------------------------

    Public Sub RTUsers()
        sql = "SELECT u.*, p.Servicios, p.Usuarios, p.Informes, p.Varios, p.caja FROM usuario u INNER JOIN permisos p ON u.user=p.user;"
        ReDim general.consultaVector(9)
        general.consultaVector(0) = "nombre"
        general.consultaVector(1) = "user"
        general.consultaVector(2) = "clave"
        general.consultaVector(3) = "rut"
        general.consultaVector(4) = "cargo"
        general.consultaVector(5) = "Servicios"
        general.consultaVector(6) = "Usuarios"
        general.consultaVector(7) = "Informes"
        general.consultaVector(8) = "Varios"
        general.consultaVector(9) = "caja"

        usuarios = general.recuperar(sql)
        Principal.DGusuarios.RowCount = 1
        If usuarios(0, 0) <> "" Then
            For i = 0 To usuarios.GetUpperBound(1)
                Principal.DGusuarios.RowCount = i + 2
                For j = 0 To 4
                    Principal.DGusuarios(j, i).Value = usuarios(j, i)
                Next
                For j = 5 To 9
                    If usuarios(j, i) = "False" Then
                        Principal.DGusuarios(j, i).Value = False
                    Else
                        Principal.DGusuarios(j, i).Value = True
                    End If
                Next
            Next

        End If
    End Sub


    '-------------------------------------------------------------------------------------
    'Panel Informes
    Public Sub BuscarInformesServicios(ByVal desde, ByVal hasta, ByVal dato)

        sql = "SELECT s.*, o.auto, o.fecha_ingreso, o.cliente FROM servicios s INNER JOIN ot o ON o.id_ot=s.id_ot WHERE (repuesto LIKE '%" & dato & "%' OR t_service LIKE '%" & dato & "%' OR cliente LIKE '" & dato & "%' OR mecanico LIKE '%" & dato & "%' OR auto LIKE '%" & dato & "%') AND (o.fecha_ingreso BETWEEN '" & desde & " 00:00:00' AND '" & hasta & " 23:59:59');"

        ReDim general.consultaVector(12)
        general.consultaVector(0) = "t_service"
        general.consultaVector(1) = "detalle"
        general.consultaVector(2) = "id_ot"
        general.consultaVector(3) = "fecha_ingreso"
        general.consultaVector(4) = "cliente"
        general.consultaVector(5) = "auto"
        general.consultaVector(6) = "mecanico"
        general.consultaVector(7) = "valor"
        general.consultaVector(8) = "v_mo"
        general.consultaVector(9) = "repuesto"
        general.consultaVector(10) = "v_repuesto"
        general.consultaVector(11) = "cantidad"
        general.consultaVector(12) = "t_repuesto"

        services = general.recuperar(sql)
        llenarInformes(12)
        For i = 0 To Principal.DGInformes.RowCount - 1
            Principal.DGInformes(3, i).Value = general.fechasAcotar3(Principal.DGInformes(3, i).Value.ToString)
        Next
        Try
            Principal.DGInformes(0, 0).OwningColumn.HeaderText = "servicio"
            Principal.DGInformes(2, 0).OwningColumn.HeaderText = "O.T."
            Principal.DGInformes(3, 0).OwningColumn.HeaderText = "fecha"
            Principal.DGInformes(7, 0).OwningColumn.HeaderText = "total"
            Principal.DGInformes(12, 0).OwningColumn.HeaderText = "total repuesto"
        Catch ex As Exception

        End Try

    End Sub

    Public Sub BuscarInformesVehiculos(ByVal Dato As String)
        sql = "SELECT * FROM vehiculo WHERE patente LIKE '%" & Dato & "%' OR rut_asociado LIKE '" & Dato & "%' OR marca LIKE '%" & Dato & "%' OR anno LIKE '%" & Dato & "%';"
        ReDim general.consultaVector(6)
        general.consultaVector(0) = "patente"
        general.consultaVector(1) = "rut_asociado"
        general.consultaVector(2) = "marca"
        general.consultaVector(3) = "modelo"
        general.consultaVector(4) = "anno"
        general.consultaVector(5) = "motor"
        general.consultaVector(6) = "color"

        services = general.recuperar(sql)

        llenarInformes(6)
        Try
            Principal.DGInformes(1, 0).OwningColumn.HeaderText = "dueño"
            Principal.DGInformes(4, 0).OwningColumn.HeaderText = "año"
        Catch ex As Exception

        End Try

    End Sub

    Public Sub buscarInformesClientes(ByVal dato As String)
        sql = "SELECT c.*, COUNT(v.rut_asociado) As vehiculos FROM `cliente` c INNER JOIN vehiculo v ON c.rut=v.rut_asociado WHERE c.nombre LIKE '%" & dato & "%' OR c.rut LIKE '" & dato & "%' GROUP BY c.nombre;"
        ReDim general.consultaVector(6)
        general.consultaVector(0) = "nombre"
        general.consultaVector(1) = "rut"
        general.consultaVector(2) = "direccion"
        general.consultaVector(3) = "vehiculos"
        general.consultaVector(4) = "correo"
        general.consultaVector(5) = "telefono1"
        general.consultaVector(6) = "telefono2"

        services = general.recuperar(sql)

        llenarInformes(6)
    End Sub

    Public Sub buscarInformesCierres(ByVal dato As String, ByVal desde As String, ByVal hasta As String)
        sql = "SELECT * FROM caja WHERE id LIKE '" & dato & "%' AND (fecha BETWEEN '" & desde & " 00:00:00' AND '" & hasta & " 23:59:59');"
        ReDim general.consultaVector(17)
        general.consultaVector(0) = "id"
        general.consultaVector(1) = "fecha"
        general.consultaVector(2) = "entrada_credito"
        general.consultaVector(3) = "entrada_efectivo"
        general.consultaVector(4) = "entrada_targeta_credito"
        general.consultaVector(5) = "entrada_targeta_debito"
        general.consultaVector(6) = "entrada_transferencia"
        general.consultaVector(7) = "salida_credito"
        general.consultaVector(8) = "salida_efectivo"
        general.consultaVector(9) = "salida_targeta_credito"
        general.consultaVector(10) = "salida_targeta_debito"
        general.consultaVector(11) = "salida_transferencia"
        general.consultaVector(12) = "total_credito"
        general.consultaVector(13) = "total_efectivo"
        general.consultaVector(14) = "total_targeta_credito"
        general.consultaVector(15) = "total_targeta_debito"
        general.consultaVector(16) = "total_transferencia"
        general.consultaVector(17) = "total"

        services = general.recuperar(sql)
        llenarInformes(17)
        For i = 0 To Principal.DGInformes.RowCount - 1
            Principal.DGInformes(1, i).Value = general.fechasAcotar3(Principal.DGInformes(1, i).Value.ToString)
        Next

    End Sub

    Public Sub llenarInformes(ByVal x As Integer)
        Principal.DGInformes.ColumnCount = 0
        For i = 0 To x
            Principal.DGInformes.Columns.Add(general.consultaVector(i), general.consultaVector(i))

        Next
        Principal.DGInformes.RowCount = 0
        If services(0, 0) <> "" Then
            For i = 0 To services.GetUpperBound(1)
                Principal.DGInformes.RowCount = i + 1
                For j = 0 To x
                    Principal.DGInformes(j, i).Value = services(j, i)
                Next
            Next
        End If
    End Sub


    Public Sub CargarClientes(ByVal dato As String)
        sql = "SELECT c.* FROM `cliente` c WHERE rut LIKE '" & dato & "%' OR nombre LIKE '%" & dato & "%';"
        ReDim general.consultaVector(5)
        general.consultaVector(0) = "rut"
        general.consultaVector(1) = "nombre"
        general.consultaVector(2) = "correo"
        general.consultaVector(3) = "direccion"
        general.consultaVector(4) = "telefono1"
        general.consultaVector(5) = "telefono2"

        clientes = general.recuperar(sql)

    End Sub

    Public Sub llenarTablaClientes(ByVal dato As String)
        CargarClientes(dato)
        Principal.TClientes.RowCount = 0
        If clientes(0, 0) <> "" Then
            For i = 0 To clientes.GetUpperBound(1)
                Principal.TClientes.RowCount = i + 1
                For j = 0 To 5
                    Principal.TClientes(j, i).Value = clientes(j, i)
                Next
            Next
        End If
    End Sub

    Public Sub llenarCBClientes(ByVal caja As ComboBox)
        CargarClientes("")
        caja.Items.Clear()
        If clientes(0, 0) <> "" Then
            For i = 0 To clientes.GetUpperBound(1)
                caja.Items.Add(clientes(0, i))
            Next
        End If
    End Sub

    Public Sub CargarAutos(ByVal dato As String)
        sql = "SELECT * FROM vehiculo WHERE patente LIKE '%" & dato & "%' OR rut_asociado LIKE '%" & dato & "%' OR marca LIKE '%" & dato & "%' OR modelo LIKE '%" & dato & "%' OR anno LIKE '%" & dato & "%';"
        ReDim general.consultaVector(6)
        general.consultaVector(0) = "rut_asociado"
        general.consultaVector(1) = "patente"
        general.consultaVector(2) = "marca"
        general.consultaVector(3) = "modelo"
        general.consultaVector(4) = "anno"
        general.consultaVector(5) = "motor"
        general.consultaVector(6) = "color"

        autos = general.recuperar(sql)
    End Sub

    Public Sub llenarTablasAutos(ByVal dato As String, ByVal tabla As DataGridView, ByVal a As Integer, ByVal b As Integer)
        CargarAutos(dato)
        tabla.RowCount = 0
        If autos(0, 0) <> "" Then
            For i = 0 To autos.GetUpperBound(1)
                tabla.RowCount = i + 1
                For j = 0 To (6 - b)
                    tabla(j, i).Value = autos(j + a, i)
                Next
            Next
        End If
    End Sub

    Public Sub cargarCBautos(ByVal dato As String, ByVal caja As ComboBox)
        CargarAutos(dato)
        caja.Items.Clear()

        If autos(0, 0) <> "" Then
            For i = 0 To autos.GetUpperBound(1)
                caja.Items.Add(autos(1, i))
            Next
        End If
    End Sub

    Public Sub cargarMarcas(ByVal caja As ComboBox)
        buscarMarcas()

        caja.Items.Clear()
        If marcas(0, 0) <> "" Then
            For i = 0 To marcas.GetUpperBound(1)
                caja.Items.Add(marcas(0, i))
            Next
        End If
    End Sub

    Public Sub cargarModelos(ByVal caja As ComboBox, ByVal marcaid As String)
        buscarModelos(marcaid)


        caja.Items.Clear()
        If modelos(0, 0) <> "" Then
            For i = 0 To modelos.GetUpperBound(1)
                caja.Items.Add(modelos(0, i))
            Next
        End If
    End Sub

    Public Sub buscarModelos(ByVal marcaid As String)
        sql = "SELECT * FROM modelos WHERE marca='" & marcaid & "';"
        ReDim general.consultaVector(0)
        general.consultaVector(0) = "nombre_modelo"
        modelos = general.recuperar(sql)
    End Sub

    Public Sub buscarMarcas()
        sql = "SELECT * FROM marcas;"
        ReDim general.consultaVector(0)
        general.consultaVector(0) = "nombre_marca"
        marcas = general.recuperar(sql)
    End Sub

    Public Sub llenarTablaMarcas()
        buscarMarcas()
        Principal.TMarcas.RowCount = 0
        If marcas(0, 0) <> "" Then
            For i = 0 To marcas.GetUpperBound(1)
                Principal.TMarcas.RowCount = i + 1
                Principal.TMarcas(0, i).Value = marcas(0, i)
            Next
            Principal.PictureBox4.Enabled = True
            Principal.PictureBox2.Enabled = True
        End If
    End Sub

    Public Sub llenarTablaModelos(ByVal marcaid As String)
        buscarModelos(marcaid)
        Principal.TModelos.RowCount = 0
        If marcas(0, 0) <> "" Then
            For i = 0 To modelos.GetUpperBound(1)
                Principal.TModelos.RowCount = i + 1
                Principal.TModelos(0, i).Value = modelos(0, i)
            Next
            Principal.PictureBox6.Enabled = True
            Principal.PictureBox5.Enabled = True
        End If
    End Sub

    Public Sub llenarTablaOts(ByVal dato As String, ByVal fecha1 As String, ByVal fecha2 As String)
        sql = "SELECT o.* FROM `ot` o WHERE (o.id_ot LIKE '" & dato & "%' OR o.auto LIKE '" & dato & "%' OR o.cliente LIKE '" & dato & "%' OR o.condicion_v LIKE '" & dato & "%' OR o.estado LIKE '" & dato & "%' OR o.tipo_d LIKE '" & dato & "%' OR o.recepcionista LIKE '" & dato & "%') AND (o.fecha_ingreso BETWEEN '" & fecha1 & " 00:00:00' AND '" & fecha2 & " 23:59:59');"
        ReDim general.consultaVector(18)
        general.consultaVector(0) = "id_ot"
        general.consultaVector(1) = "cliente"
        general.consultaVector(2) = "auto"
        general.consultaVector(3) = "fecha_ingreso"
        general.consultaVector(4) = "fecha_salida"
        general.consultaVector(5) = "recepcionista"
        general.consultaVector(6) = "condicion_v"
        general.consultaVector(7) = "tipo_d"
        general.consultaVector(8) = "plazo"
        general.consultaVector(9) = "estado"
        general.consultaVector(10) = "abono"
        general.consultaVector(11) = "t_mo"
        general.consultaVector(12) = "t_repu"
        general.consultaVector(13) = "subtotal"
        general.consultaVector(14) = "descuento"
        general.consultaVector(15) = "neto"
        general.consultaVector(16) = "iva"
        general.consultaVector(17) = "total"
        general.consultaVector(18) = "obs"

        informes.ots = general.recuperar(sql)
        Principal.DGVerOTS.RowCount = 0
        If informes.ots(0, 0) <> "" Then
            For i = 0 To informes.ots.GetUpperBound(1)
                Principal.DGVerOTS.RowCount = i + 1
                For j = 0 To 18
                    Principal.DGVerOTS(j, i).Value = informes.ots(j, i)
                Next
            Next
        End If
    End Sub


    Public Sub llenarTablaServiciosOts(ByVal rut As String, ByVal patente As String, ByVal ot As String)
        Dim servicioOT(0, 0) As String
        Dim km(0, 0) As String
        CargarClientes(rut)
        Principal.DGClienteOT.Rows.Clear()
        Principal.DGClienteOT.RowCount = 1
        For i = 0 To 4
            Principal.DGClienteOT(i, 0).Value = clientes(i + 1, 0)
        Next

        CargarAutos(patente)
        Principal.DGAutoOT.Rows.Clear()
        Principal.DGAutoOT.RowCount = 1
        For i = 0 To 5
            Principal.DGAutoOT(i, 0).Value = autos(i + 1, 0)
        Next
        sql = "SELECT km FROM ot WHERE id_ot='" & ot & "';"
        ReDim general.consultaVector(0)
        general.consultaVector(0) = "km"
        km = general.recuperar(sql)
        Principal.DGAutoOT(6, 0).Value = km(0, 0)
        sql = "SELECT * FROM servicios WHERE id_ot='" & ot & "';"
        ReDim general.consultaVector(8)
        general.consultaVector(0) = "t_service"
        general.consultaVector(1) = "detalle"
        general.consultaVector(2) = "repuesto"
        general.consultaVector(3) = "cantidad"
        general.consultaVector(4) = "v_repuesto"
        general.consultaVector(5) = "t_repuesto"
        general.consultaVector(6) = "v_mo"
        general.consultaVector(7) = "valor"
        general.consultaVector(8) = "mecanico"

        servicioOT = general.recuperar(sql)
        Principal.DGDetalleOTS.RowCount = 0
        If servicioOT(0, 0) <> "" Then
            For i = 0 To servicioOT.GetUpperBound(1)
                Principal.DGDetalleOTS.RowCount = i + 1
                For j = 0 To 8
                    Principal.DGDetalleOTS(j, i).Value = servicioOT(j, i)
                Next
            Next
        End If
    End Sub
End Module
