Imports System.Windows.Forms

Public Class DlgConfirmSizeStartIndex
    Private _MemorySize As Integer
    Private _StartAddress As Integer

    ReadOnly Property MemorySize As Integer
        Get
            Return _MemorySize
        End Get
    End Property

    ReadOnly Property StartAddress As Integer
        Get
            Return _StartAddress
        End Get
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            _MemorySize = CInt(listSize.SelectedItem)
            _StartAddress = Conversion.FromHexToDec(txtHexAddress.Text) 'this will throw an exception if the text in the textbox is wrong

            Dim lastaddr As Integer = _StartAddress + ((_MemorySize * 1024) - 1)
            If lastaddr > 65535 Then
                MessageBox.Show("Out of address range! Please move your start address up", "Oops!", MessageBoxButtons.OK)
                Return
            End If

            If Not AddressBus.CanAllocateAddressRange(_StartAddress, lastaddr) Then
                MessageBox.Show("Address range is overlapping with other devices!", "Oops!", MessageBoxButtons.OK)
                Return
            End If

        Catch ex As Exception
            MessageBox.Show("Please select the size and enter the start address correctly!", "Error!", MessageBoxButtons.OK)
            Return
        End Try

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub DlgConfirmSizeStartIndex_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.DialogResult <> Windows.Forms.DialogResult.OK Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub DlgConfirmSizeStartIndex_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        listSize.SelectedIndex = 0
    End Sub
End Class