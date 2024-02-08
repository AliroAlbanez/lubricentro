Public Class VagregarModelo
    Public info As Integer
    Public modeloAnterior As String
    Dim sql As String
    Dim modelo(0, 0) As String
    Public MarcaAnterior As String
    Public cbmodelo As ComboBox
    Public toc As Integer

    Private Sub VagregarModelo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarCB.cargarMarcas(ComboBox1)

        If info = 0 Then
            Button1.Text = "Agregar"
            Me.Text = "Agregar Modelo"
            TextBox1.Text = ""
            ComboBox1.Text = MarcaAnterior
        Else
            Button1.Text = "Editar"
            Me.Text = "Editar Modelo"
            TextBox1.Text = modeloAnterior
            ComboBox1.Text = MarcaAnterior
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        VagregarMarca.cbpedido = Me.ComboBox1
        VagregarMarca.info = 0
        VagregarMarca.toc = 1
        VagregarMarca.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text <> "" And TextBox1.Text <> "" Then
            sql = "SELECT * FROM modelos WHERE nombre_modelo='" & TextBox1.Text & "' AND marca='" & ComboBox1.Text & "';"
            ReDim general.consultaVector(0)
            general.consultaVector(0) = "nombre_modelo"

            modelo = general.recuperar(sql)
            If modelo(0, 0) = "" Then
                If info = 0 Then
                    sql = "INSERT INTO `modelos`(`nombre_modelo`, `marca`) VALUES ('" & TextBox1.Text & "','" & ComboBox1.Text & "');"
                    general.IngresarDatos(sql)
                    MessageBox.Show("Nuevo Modelo ingresado con éxito", "Nuevo Modelo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    sql = "UPDATE `modelos` SET `nombre_modelo`='" & TextBox1.Text & "',`marca`='" & ComboBox1.Text & "' WHERE nombre_modelo='" & modeloAnterior & "' AND marca='" & MarcaAnterior & "';"
                    general.IngresarDatos(sql)
                    MessageBox.Show("Modelo editado con éxito", "Editar Modelo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                If toc = 0 Then
                    CargarCB.llenarTablaModelos(MarcaAnterior)
                Else
                    CargarCB.cargarModelos(cbmodelo, MarcaAnterior)
                End If
            Else
                MessageBox.Show("Este modelo ya existe para esta marca. Compruebe que la marca o modelo sea correcto", "Modelos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Falta Marca y/o Modelo. Debe seleccionar una marca y completar el recuadro de modelo para continuar", "Modelos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class