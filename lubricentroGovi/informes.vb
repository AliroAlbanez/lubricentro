Imports Microsoft.Office.Interop

Module informes
    Public ots(0, 0) As String
    Public Sub ExportarExcelOT(ByVal dgv As DataGridView, ByVal encargado As String, ByVal fecha As String, ByVal otn As String, ByVal rut As String, ByVal nombre As String, ByVal correo As String, ByVal fono1 As String, ByVal fono2 As String, ByVal patente As String, ByVal marca As String, ByVal anno As String, ByVal km As String, ByVal modelo As String, ByVal Color As String, ByVal ingreso As String, ByVal salida As String, ByVal venta As String, ByVal documento As String, ByVal observacion As String, ByVal pago As String, ByVal abono As String, ByVal totalrep As String, ByVal totalmo As String, ByVal subtotal As String, ByVal descuento As String, ByVal neto As String, ByVal iva As String, ByVal total As String, ByVal direccion As String, ByVal motor As String, ByVal plazo As String)
        Dim doc As String
        Dim xlApp As Object = CreateObject("Excel.Application")
        'Se crea una nueva hoja de calculo
        Dim xlwB As Object = xlApp.WorkBooks.add("C:\Users\Agustin\Documents\Plantillas personalizadas de Office\otlubrigovi.xltx")
        Dim procesos As Process()
        Dim save As New SaveFileDialog


        Dim xlWS As Object = xlwB.Worksheets(1)
        xlWS.cells(3, 5).value = otn
        'cliente
        xlWS.cells(5, 4).value = rut
        xlWS.cells(6, 4).value = nombre
        xlWS.cells(7, 4).value = direccion
        xlWS.cells(8, 4).value = fono1
        xlWS.cells(9, 4).value = fono2
        xlWS.cells(10, 4).value = correo
        'vehiculo
        xlWS.cells(17, 2).value = patente
        xlWS.cells(18, 2).value = marca
        xlWS.cells(19, 2).value = anno
        xlWS.cells(20, 2).value = motor
        xlWS.cells(17, 4).value = km
        xlWS.cells(18, 4).value = modelo
        xlWS.cells(19, 4).value = Color

        'Condiciones
        xlWS.cells(15, 1).value = encargado
        xlWS.cells(14, 3).value = ingreso
        xlWS.cells(14, 4).value = salida
        xlWS.cells(21, 2).value = venta
        xlWS.cells(21, 5).value = documento
        xlWS.cells(21, 8).value = plazo
        xlWS.cells(27, 6).value = observacion
        'condicion pago
        If pago = "Pagado" Then
            xlWS.cells(32, 4).value = "X"
        ElseIf pago = "Pendiente" Then
            xlWS.cells(33, 4).value = "X"
        ElseIf pago = "Abonado" Then
            xlWS.cells(34, 4).value = "X"
            xlWS.cells(34, 6).value = abono
        ElseIf pago = "Cancelado" Then
            xlWS.cells(36, 4).value = "X"
        ElseIf pago = "Aceptado" Then
            xlWS.cells(35, 4).value = "X"
        End If

        'valores totales
        xlWS.cells(32, 8).value = totalmo
        xlWS.cells(33, 8).value = totalrep
        xlWS.cells(34, 8).value = subtotal
        xlWS.cells(35, 8).value = descuento
        xlWS.cells(36, 8).value = neto
        xlWS.cells(37, 8).value = iva
        xlWS.cells(38, 8).value = total

        'Exportamos las filas
        For r As Integer = 0 To dgv.RowCount - 1
            xlWS.rows(25).insert
            For c As Integer = 0 To dgv.Columns.Count - 2
                xlWS.cells(25, c + 1).value = dgv.Item(c, r).Value
            Next

        Next

        'Guardamos la hoja de calculo en la ruta especifada
        Try
            save.FileName = otn & " " & fecha
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


    End Sub
End Module
