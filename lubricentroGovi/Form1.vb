Public Class Form1
    Dim sql As String
    Private Sub BIngresar_Click(sender As Object, e As EventArgs) Handles BIngresar.Click
        'preparar el sql que utilizaremos para consultar y hacer la verificacion del usuario
        sql = "SELECT * from usuario WHERE usuario.user='" & TBUser.Text & "' AND usuario.clave='" & TBKey.Text & "';"
        'redimension consultaVector a la cantidad de datos que se necesita
        ReDim general.consultaVector(2)
        general.consultaVector(0) = "user"
        general.consultaVector(1) = "clave"
        general.consultaVector(2) = "nombre"

        'Igualamos la matriz donde se quieren guardar los datos  con la funcion General.recuperar(sql)
        general.usuario = general.recuperar(sql)

        'si el usuario y contraseña coinciden ingresa al sistema y muestra la ventana del menu
        If general.usuario(0, 0) <> "" Then
            Me.Visible = False
            permisosdados(general.usuario(0, 0))
            Principal.Show()

        Else

            MessageBox.Show("Usuario o Contraseña incorrectos.", " Error de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TBKey.Text = ""

        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TBUser.Text = ""
        TBKey.Text = ""
    End Sub

    Public Sub permisosdados(ByVal user As String)
        sql = "SELECT * FROM permisos WHERE user='" & user & "';"
        ReDim general.consultaVector(4)

        general.consultaVector(0) = "Servicios"
        general.consultaVector(1) = "Usuarios"
        general.consultaVector(2) = "Informes"
        general.consultaVector(3) = "Varios"
        general.consultaVector(4) = "caja"

        'general.permisosUsuario = general.recuperar(sql)
    End Sub
End Class
