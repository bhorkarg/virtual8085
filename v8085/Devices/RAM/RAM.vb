Public Class RAM
    Implements IDevice

    Private _size As Integer
    Private _startAddress As Integer

    Private Sub tbAddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbAddress.TextChanged
        If tbAddress.TextLength > 0 Then
            Try
                Dim Index As UInteger = Conversion.FromHexToDec(tbAddress.Text) - _startAddress
                Memory.SelectedIndex = Index
            Catch ex As Exception
                'do nothing! 
            End Try
        End If
    End Sub

    Public Overridable Property bits(ByVal HexString As String) As System.Collections.BitArray Implements IDevice.bits
        Get
            'first focus on this form
            Me.Focus()

            Return Memory.bits(HexString)
        End Get

        Set(ByVal value As System.Collections.BitArray)
            Me.Focus()
            Memory.bits(HexString) = value
        End Set
    End Property


    Public ReadOnly Property FirstIndex As UInteger Implements IDevice.FirstIndex
        Get
            Return _startAddress
        End Get
    End Property

    Public ReadOnly Property LastIndex As UInteger Implements IDevice.LastIndex
        Get
            Return _startAddress + ((_size * 1024) - 1)
        End Get
    End Property


    Public Function IsAddressAccessible(ByVal HexAddr As String) As Boolean Implements IDevice.IsAddressAccessible
        Dim address As Integer = Conversion.FromHexToDec(HexAddr)
        Dim lastaddress As Integer = _startAddress + ((_size * 1024) - 1)

        If (address >= _startAddress) And (address <= lastaddress) Then
            Return True
        Else
            Return False
        End If
    End Function


    ''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private isDeviceInterfaced As Boolean

    Private Sub RAM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim RequirementsDialog As New DlgConfirmSizeStartIndex
        If Not RequirementsDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            isDeviceInterfaced = False
            Return
        End If

        _size = RequirementsDialog.MemorySize
        _startAddress = RequirementsDialog.StartAddress

        'now setting the memory
        Memory.FirstIndex = _startAddress
        Memory.LastIndex = _startAddress + ((_size * 1024) - 1)

        'not interface this device to the AddressBus
        AddressBus.InterfaceDevice(Me)
        isDeviceInterfaced = True

        'now load the display
        btnRefresh.PerformClick()
        Me.Text = "RAM - " & _size.ToString() & "KB"
        gbMemory.Text = "Memory (" & Memory.FirstIndex.ToString("X4") & " - " & Memory.LastIndex.ToString("X4") & " )"
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Memory.InitializeDisplay(ProgressBarMemory, _size)
    End Sub

    Private Sub RAM_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If isDeviceInterfaced Then
            AddressBus.DeInterfaceDevice(Me)
        End If
    End Sub

    Private Sub RAM_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        If isDeviceInterfaced = False Then
            Me.Close()
        End If
    End Sub
End Class