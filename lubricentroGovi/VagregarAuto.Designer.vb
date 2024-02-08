<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VagregarAuto
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
        Me.TBAnno = New System.Windows.Forms.MaskedTextBox()
        Me.TBPatente = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CBAsociado = New System.Windows.Forms.ComboBox()
        Me.TBcolor = New System.Windows.Forms.TextBox()
        Me.CBMarca = New System.Windows.Forms.ComboBox()
        Me.CBModelo = New System.Windows.Forms.ComboBox()
        Me.MasModelo = New System.Windows.Forms.PictureBox()
        Me.MasMarca = New System.Windows.Forms.PictureBox()
        Me.mascliente = New System.Windows.Forms.PictureBox()
        Me.BGCliente = New System.Windows.Forms.PictureBox()
        Me.TBMotor = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.MasModelo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MasMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mascliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BGCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TBAnno
        '
        Me.TBAnno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBAnno.Location = New System.Drawing.Point(157, 189)
        Me.TBAnno.Mask = "9999"
        Me.TBAnno.Name = "TBAnno"
        Me.TBAnno.Size = New System.Drawing.Size(191, 26)
        Me.TBAnno.TabIndex = 5
        Me.TBAnno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TBAnno.ValidatingType = GetType(Integer)
        '
        'TBPatente
        '
        Me.TBPatente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBPatente.Location = New System.Drawing.Point(157, 75)
        Me.TBPatente.MaxLength = 8
        Me.TBPatente.Name = "TBPatente"
        Me.TBPatente.Size = New System.Drawing.Size(191, 26)
        Me.TBPatente.TabIndex = 2
        Me.TBPatente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(53, 268)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 20)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Color"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(53, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 20)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Año"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(53, 154)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 20)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Modelo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(53, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 20)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Marca"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(53, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 20)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Patente"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(53, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 20)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Rut Cliente"
        '
        'CBAsociado
        '
        Me.CBAsociado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CBAsociado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CBAsociado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBAsociado.FormattingEnabled = True
        Me.CBAsociado.Location = New System.Drawing.Point(157, 37)
        Me.CBAsociado.Name = "CBAsociado"
        Me.CBAsociado.Size = New System.Drawing.Size(191, 28)
        Me.CBAsociado.TabIndex = 1
        '
        'TBcolor
        '
        Me.TBcolor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBcolor.Location = New System.Drawing.Point(157, 265)
        Me.TBcolor.MaxLength = 20
        Me.TBcolor.Name = "TBcolor"
        Me.TBcolor.Size = New System.Drawing.Size(191, 26)
        Me.TBcolor.TabIndex = 6
        Me.TBcolor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CBMarca
        '
        Me.CBMarca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CBMarca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CBMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBMarca.FormattingEnabled = True
        Me.CBMarca.Location = New System.Drawing.Point(157, 113)
        Me.CBMarca.Name = "CBMarca"
        Me.CBMarca.Size = New System.Drawing.Size(191, 28)
        Me.CBMarca.TabIndex = 25
        '
        'CBModelo
        '
        Me.CBModelo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CBModelo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CBModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBModelo.FormattingEnabled = True
        Me.CBModelo.Location = New System.Drawing.Point(157, 151)
        Me.CBModelo.Name = "CBModelo"
        Me.CBModelo.Size = New System.Drawing.Size(191, 28)
        Me.CBModelo.TabIndex = 26
        '
        'MasModelo
        '
        Me.MasModelo.BackgroundImage = Global.lubricentroGovi.My.Resources.Resources.mas
        Me.MasModelo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.MasModelo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MasModelo.Location = New System.Drawing.Point(354, 154)
        Me.MasModelo.Name = "MasModelo"
        Me.MasModelo.Size = New System.Drawing.Size(23, 23)
        Me.MasModelo.TabIndex = 29
        Me.MasModelo.TabStop = False
        '
        'MasMarca
        '
        Me.MasMarca.BackgroundImage = Global.lubricentroGovi.My.Resources.Resources.mas
        Me.MasMarca.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.MasMarca.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MasMarca.Location = New System.Drawing.Point(354, 116)
        Me.MasMarca.Name = "MasMarca"
        Me.MasMarca.Size = New System.Drawing.Size(23, 23)
        Me.MasMarca.TabIndex = 28
        Me.MasMarca.TabStop = False
        '
        'mascliente
        '
        Me.mascliente.BackgroundImage = Global.lubricentroGovi.My.Resources.Resources.mas
        Me.mascliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.mascliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.mascliente.Location = New System.Drawing.Point(354, 40)
        Me.mascliente.Name = "mascliente"
        Me.mascliente.Size = New System.Drawing.Size(23, 23)
        Me.mascliente.TabIndex = 27
        Me.mascliente.TabStop = False
        '
        'BGCliente
        '
        Me.BGCliente.BackgroundImage = Global.lubricentroGovi.My.Resources.Resources.guardar_el_archivo
        Me.BGCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BGCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.BGCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BGCliente.Location = New System.Drawing.Point(184, 299)
        Me.BGCliente.Name = "BGCliente"
        Me.BGCliente.Size = New System.Drawing.Size(50, 50)
        Me.BGCliente.TabIndex = 21
        Me.BGCliente.TabStop = False
        '
        'TBMotor
        '
        Me.TBMotor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBMotor.Location = New System.Drawing.Point(157, 227)
        Me.TBMotor.MaxLength = 20
        Me.TBMotor.Name = "TBMotor"
        Me.TBMotor.Size = New System.Drawing.Size(191, 26)
        Me.TBMotor.TabIndex = 30
        Me.TBMotor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(53, 230)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 20)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Motor"
        '
        'VagregarAuto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(404, 361)
        Me.Controls.Add(Me.TBMotor)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.MasModelo)
        Me.Controls.Add(Me.MasMarca)
        Me.Controls.Add(Me.mascliente)
        Me.Controls.Add(Me.CBModelo)
        Me.Controls.Add(Me.CBMarca)
        Me.Controls.Add(Me.TBcolor)
        Me.Controls.Add(Me.CBAsociado)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TBAnno)
        Me.Controls.Add(Me.BGCliente)
        Me.Controls.Add(Me.TBPatente)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(420, 400)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(420, 400)
        Me.Name = "VagregarAuto"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Vehiculo"
        Me.TopMost = True
        CType(Me.MasModelo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MasMarca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mascliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BGCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TBAnno As MaskedTextBox
    Friend WithEvents BGCliente As PictureBox
    Friend WithEvents TBPatente As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents CBAsociado As ComboBox
    Friend WithEvents TBcolor As TextBox
    Friend WithEvents CBMarca As ComboBox
    Friend WithEvents CBModelo As ComboBox
    Friend WithEvents mascliente As PictureBox
    Friend WithEvents MasMarca As PictureBox
    Friend WithEvents MasModelo As PictureBox
    Friend WithEvents TBMotor As TextBox
    Friend WithEvents Label7 As Label
End Class
