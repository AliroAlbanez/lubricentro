Imports MySql.Data.MySqlClient
Module general

    'variables de conexion y consultas
    Dim Configuracion_conexion As String = "server=localhost;database=lubrigovi;user id=root;password=;port=3306; SslMode=none"
    Dim Conexion As New MySqlConnection(Configuracion_conexion)
    Public dr As MySqlDataReader

    Public consultaVector(0) As String
    Public usuario(4, 0) As String
    Public parametros(0, 0) As String
    Public permisosUsuario(0, 0) As String
    'Funciones y subs de consulta e ingreso de datos
    Public Function cons(ByVal sql) As MySqlDataReader 'Funcion de consulta que retorna un reader para poder ocuparlo donde mas acomode
        Dim cm As MySqlCommand
        If Not Conexion Is Nothing Then Conexion.Close()
        Try
            Conexion.Open()

            cm = New MySqlCommand()
            cm.CommandText = sql
            cm.CommandType = CommandType.Text
            cm.Connection = Conexion
            Return cm.ExecuteReader()
        Catch ex As Exception
            MessageBox.Show("Servidor fuera de linea, consulte con su administrador", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Sub IngresarDatos(ByVal sql)
        Dim insertar As New MySqlCommand(sql, Conexion)

        If Not Conexion Is Nothing Then Conexion.Close()
        Conexion.Open()
        insertar.ExecuteNonQuery()


        Conexion.Close()
    End Sub

    Public Function fechasVoltear(ByVal fecha) As String
        Dim nuevaFecha As String

        Dim delimitadores() As String = {"-", " "}
        Dim vectoraux() As String
        vectoraux = fecha.Split(delimitadores, StringSplitOptions.None)
        nuevaFecha = vectoraux(2) + "-" + vectoraux(1) + "-" + vectoraux(0)
        Return nuevaFecha
    End Function

    Public Function fechasAcotar(ByVal fecha) As String
        Dim nuevaFecha As String

        Dim delimitadores() As String = {"-", " ", ":"}
        Dim vectoraux() As String
        vectoraux = fecha.Split(delimitadores, StringSplitOptions.None)
        nuevaFecha = vectoraux(2) + "-" + vectoraux(1) + "-" + vectoraux(0)
        Return nuevaFecha
    End Function

    Public Function fechasAcotar3(ByVal fecha) As String
        Dim nuevaFecha As String

        Dim delimitadores() As String = {"-", " ", ":"}
        Dim vectoraux() As String
        vectoraux = fecha.Split(delimitadores, StringSplitOptions.None)
        nuevaFecha = vectoraux(0) + "-" + vectoraux(1) + "-" + vectoraux(2)
        Return nuevaFecha
    End Function

    Public Function ComprobarCierre() As Boolean
        CargarCB.Rparametros()
        Dim resultado As Boolean
        Dim fecha1() As String
        Dim fecha2() As String
        Dim delimitadores() As String = {"-", " ", ":"}
        fecha1 = System.DateTime.Now.ToString.Split(delimitadores, StringSplitOptions.None)
        fecha2 = parametros(2, 0).Split(delimitadores, StringSplitOptions.None)

        If CInt(fecha1(2)) = CInt(fecha2(2)) Then

            If CInt(fecha1(1)) = CInt(fecha2(1)) Then

                If CInt(fecha1(0)) = CInt(fecha2(0)) Then
                    resultado = True

                Else
                    resultado = False
                End If
            Else
                resultado = False
            End If
        Else
            resultado = False
        End If
        If CInt(fecha1(2)) >= CInt(fecha2(2)) Then

            If CInt(fecha1(1)) >= CInt(fecha2(1)) Then

                If CInt(fecha1(0)) >= CInt(fecha2(0)) Then
                    Principal.Button4.Enabled = True

                Else
                    Principal.Button4.Enabled = False
                End If
            Else
                Principal.Button4.Enabled = False
            End If
        Else
            Principal.Button4.Enabled = False
        End If

        Return resultado
    End Function


    Public Function fechasAcotar2(ByVal fecha) As String
        Dim nuevaFecha As String
        Try
            Dim delimitadores() As String = {"-", " ", ":"}
            Dim vectoraux() As String
            vectoraux = fecha.Split(delimitadores, StringSplitOptions.None)

            nuevaFecha = "D" + vectoraux(0) + "M" + vectoraux(1) + "A" + vectoraux(2) + "h" + vectoraux(3) + "m" + vectoraux(4) + "s" + vectoraux(5)
            Return nuevaFecha
        Catch ex As Exception
            MsgBox("error en fecha")
        End Try

    End Function

    'Funcion de recuperaciones

    Public Function recuperar(ByVal sql)
        Dim num As Integer = 0 'contador para al fila
        Dim lVector As Integer = consultaVector.GetUpperBound(0) 'ultimo indice del vector para poder usar la matriz a voluntad
        Dim solu(lVector, num) As String 'se redimensiona al inicial para que se borren todos los datos
        Try
            dr = cons(sql)
            While dr.Read()
                ReDim Preserve solu(lVector, num) 'se redimensiona solo las columnas preservando los datos por lo que el numero de fila no se puede editar
                For i = 0 To lVector
                    solu(i, num) = dr(consultaVector(i)).ToString()
                Next
                num = num + 1

            End While
            Conexion.Close()
        Catch ex As Exception

        End Try

        Return solu 'devuelve la matriz llenada con los datos recuperados

    End Function
End Module