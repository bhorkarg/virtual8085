'Programmer - Gaurav Bhorkar
'This interface provides all the methods that a device should contain
'All the devices to be interfaced with V8085 must contain these members!

Interface IDevice
    Function IsAddressAccessible(ByVal HexAddr As String) As Boolean
    Property bits(ByVal HexString As String) As BitArray
    ReadOnly Property FirstIndex As UInteger
    ReadOnly Property LastIndex As UInteger
End Interface