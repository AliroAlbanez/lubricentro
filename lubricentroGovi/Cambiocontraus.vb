Public Class Cambiocontraus
    Dim ver As Image = My.Resources.ver
    Dim nover As Image = My.Resources.Nover
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs)
        Form1.Show()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If PictureBox3.BackgroundImage Is ver Then
            PictureBox3.BackgroundImage = nover
            TextBox2.UseSystemPasswordChar = True
        Else
            PictureBox3.BackgroundImage = ver
            TextBox2.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        If PictureBox4.BackgroundImage Is ver Then
            PictureBox4.BackgroundImage = nover
            TextBox3.UseSystemPasswordChar = True
        Else
            PictureBox4.BackgroundImage = ver
            TextBox3.UseSystemPasswordChar = False
        End If
    End Sub



    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.TextLength < 6 Then
            PictureBox2.Visible = True
        Else
            PictureBox2.Visible = False
        End If

        If TextBox3.Text <> TextBox2.Text Then
            PictureBox5.Visible = True
        Else
            PictureBox5.Visible = False
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text <> TextBox2.Text Then
            PictureBox5.Visible = True
        Else
            PictureBox5.Visible = False
        End If
    End Sub

    Private Sub Cambiocontraadmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label5.Text = "Usuario: " & general.usuario(2, 0)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If TextBox1.Text <> General.usuario(1, 0) Then
            MessageBox.Show("Contraseña actual errónea, compruebe que su contraseña ingresada sea la correcta", "Error de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf PictureBox2.Visible Then
            MessageBox.Show("La nueva contraseña no cumple con el largo mínimo requerido (6 caracteres)", "Error nueva contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf PictureBox5.Visible Then
            MessageBox.Show("La nueva contraseña y su repetición no coinciden", "Error Repetir contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim sql As String = "UPDATE usuario SET clave='" & TextBox2.Text & "' WHERE user='" & general.usuario(0, 0) & "';"
            general.IngresarDatos(sql)
            MessageBox.Show("Contraseña cambiada con exito, vuelva a iniciar sesión", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ReDim general.usuario(3, 0)
            Me.Close()
            Principal.Close()
            Form1.Show()
        End If
    End Sub
End Class