Public Class AddressBus
    Private Shared _Allocated(65535) As Boolean
    Private Shared _iDevices As New List(Of IDevice)

    Public Shared Sub InterfaceDevice(Of T)(ByRef dev As T)
        _iDevices.Add(dev)

        For i As Integer = _iDevices.Last().FirstIndex To _iDevices.Last().LastIndex
            _Allocated(i) = True
        Next
    End Sub

    Public Shared Sub DeInterfaceDevice(Of T)(ByVal dev As T)
        If _iDevices.Count = 0 Then
            Return
        End If

        Dim Findex As UInteger = _iDevices(_iDevices.IndexOf(dev)).FirstIndex
        Dim Lindex As UInteger = _iDevices(_iDevices.IndexOf(dev)).LastIndex

        For i As UInteger = Findex To Lindex
            _Allocated(i) = False
        Next

        _iDevices.Remove(dev)
    End Sub


    Public Shared Function CanAllocateAddressRange(ByVal FirstIndex As UInteger, ByVal LastIndex As UInteger) As Boolean
        Dim AllocatedMemory As Integer = 0

        For i As UInteger = FirstIndex To LastIndex
            AllocatedMemory += _Allocated(i)
        Next

        If AllocatedMemory = 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Property bits(ByVal HexIndex As String) As BitArray
        Get
            'get the data from an interfaced device'
            Dim data As New BitArray(8)
            Dim isDataRetrieved As Boolean = False 'data has not been set now
            For i As Integer = 0 To _iDevices.Count - 1
                If _iDevices(i).IsAddressAccessible(HexIndex) Then
                    data = _iDevices(i).bits(HexIndex)
                    isDataRetrieved = True
                End If
            Next

            If isDataRetrieved Then
                Return data
            Else
                Throw New Exception8085("No device has been interfaced to read data from!")
            End If
        End Get

        Set(ByVal value As BitArray)
            'set the data to an interfaced device'
            Dim isDataSet As Boolean = False 'the data has not been stored now
            For i As Integer = 0 To _iDevices.Count - 1
                If _iDevices(i).IsAddressAccessible(HexIndex) Then
                    _iDevices(i).bits(HexIndex) = value
                    isDataSet = True
                End If
            Next

            If Not isDataSet Then
                Throw New Exception8085("No device has been interfaced to write data to!")
            End If
        End Set

    End Property
End Class
