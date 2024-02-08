<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VagregarCliente
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TBNombre = New System.Windows.Forms.TextBox()
        Me.TBRut = New System.Windows.Forms.TextBox()
        Me.TBCorreo = New System.Windows.Forms.TextBox()
        Me.BGCliente = New System.Windows.Forms.PictureBox()
        Me.TBFono1 = New System.Windows.Forms.MaskedTextBox()
        Me.TBFono2 = New System.Windows.Forms.MaskedTextBox()
        Me.TBDireccion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.BGCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(51, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(51, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Rut"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(51, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Correo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(51, 197)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Teléfono 1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(51, 235)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Teléfono 2"
        '
        'TBNombre
        '
        Me.TBNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBNombre.Location = New System.Drawing.Point(155, 42)
        Me.TBNombre.MaxLength = 35
        Me.TBNombre.Name = "TBNombre"
        Me.TBNombre.Size = New System.Drawing.Size(191, 26)
        Me.TBNombre.TabIndex = 5
        '
        'TBRut
        '
        Me.TBRut.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBRut.Location = New System.Drawing.Point(155, 80)
        Me.TBRut.MaxLength = 9
        Me.TBRut.Name = "TBRut"
        Me.TBRut.Size = New System.Drawing.Size(191, 26)
        Me.TBRut.TabIndex = 6
        '
        'TBCorreo
        '
        Me.TBCorreo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBCorreo.Location = New System.Drawing.Point(155, 118)
        Me.TBCorreo.MaxLength = 35
        Me.TBCorreo.Name = "TBCorreo"
        Me.TBCorreo.Size = New System.Drawing.Size(191, 26)
        Me.TBCorreo.TabIndex = 7
        '
        'BGCliente
        '
        Me.BGCliente.BackgroundImage = Global.lubricentroGovi.My.Resources.Resources.guardar_el_archivo
        Me.BGCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BGCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.BGCliente.Location = New System.Drawing.Point(185, 273)
        Me.BGCliente.Name = "BGCliente"
        Me.BGCliente.Size = New System.Drawing.Size(50, 50)
        Me.BGCliente.TabIndex = 10
        Me.BGCliente.TabStop = False
        '
        'TBFono1
        '
        Me.TBFono1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBFono1.Location = New System.Drawing.Point(155, 194)
        Me.TBFono1.Mask = "999999999"
        Me.TBFono1.Name = "TBFono1"
        Me.TBFono1.Size = New System.Drawing.Size(191, 26)
        Me.TBFono1.TabIndex = 11
        Me.TBFono1.ValidatingType = GetType(Integer)
        '
        'TBFono2
        '
        Me.TBFono2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBFono2.Location = New System.Drawing.Point(155, 232)
        Me.TBFono2.Mask = "999999999"
        Me.TBFono2.Name = "TBFono2"
        Me.TBFono2.Size = New System.Drawing.Size(191, 26)
        Me.TBFono2.TabIndex = 12
        Me.TBFono2.ValidatingType = GetType(Integer)
        '
        'TBDireccion
        '
        Me.TBDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBDireccion.Location = New System.Drawing.Point(155, 156)
        Me.TBDireccion.MaxLength = 45
        Me.TBDireccion.Name = "TBDireccion"
        Me.TBDireccion.Size = New System.Drawing.Size(191, 26)
        Me.TBDireccion.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(51, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 20)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Dirección"
        '
        'VagregarCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(404, 335)
        Me.Controls.Add(Me.TBDireccion)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TBFono2)
        Me.Controls.Add(Me.TBFono1)
        Me.Controls.Add(Me.BGCliente)
        Me.Controls.Add(Me.TBCorreo)
        Me.Controls.Add(Me.TBRut)
        Me.Controls.Add(Me.TBNombre)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(420, 374)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(420, 374)
        Me.Name = "VagregarCliente"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Cliente"
        Me.TopMost = True
        CType(Me.BGCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TBNombre As TextBox
    Friend WithEvents TBRut As TextBox
    Friend WithEvents TBCorreo As TextBox
    Friend WithEvents BGCliente As PictureBox
    Friend WithEvents TBFono1 As MaskedTextBox
    Friend WithEvents TBFono2 As MaskedTextBox
    Friend WithEvents TBDireccion As TextBox
    Friend WithEvents Label6 As Label
End Class
