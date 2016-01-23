Imports System.Windows.Forms

Public Class DlgWriteData
    Private _ROM As ROM

    Public Sub New(ByRef parent As ROM)
        InitializeComponent()

        _ROM = parent
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            If txtData.Text.Length = 2 Then
                'get the memory address!
                Dim HexString As String = _ROM.Memory.SelectedItem.ToString().Substring(0, 4)

                _ROM.Memory.bits(HexString) = Conversion.FromHexToBin(txtData.Text)
            End If
        Catch ex As Exception
            MessageBox.Show("Enter a Hexadecimal Number of 8 bits", "Incorrect Data!")
            Return
        End Try

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class
