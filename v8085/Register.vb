'Programmer - Gaurav Bhorkar
'Class Name - Register

'Description - 
'A must inherit base class for all registers (8 bit or 16 bit)
'By inheriting this class from Label we don't need to main a overhead of
'different labels to display the contents of each Register
'Thus we just add BITS to a label


Public MustInherit Class Register
    Inherits Label

    Protected mBits As BitArray

    Public Event BitsChanged()


    Private Sub UpdateText()
        MyBase.Text = Conversion.FromBinToHex(mBits)
    End Sub

#Region "Properties"
    Public Property bits() As BitArray
        Get
            Return mBits
        End Get
        Set(ByVal value As BitArray)
            mBits = value
            UpdateText()
            RaiseEvent BitsChanged()
        End Set
    End Property

    Public ReadOnly Property lsb4() As BitArray
        Get
            Dim _lsb4 As New BitArray(8)
            For i As Integer = 4 To 7
                _lsb4(i) = mBits(i)
            Next
            Return _lsb4
        End Get
    End Property

    Public ReadOnly Property msb4() As BitArray
        Get
            Dim _msb4 As New BitArray(8)
            For i As Integer = 4 To 7
                _msb4(i) = mBits(i - 4)
            Next
            Return _msb4
        End Get
    End Property

    Overrides Property Text() As String
        Get
            Return Conversion.FromBinToHex(mBits)
        End Get
        Set(ByVal value As String)
            'do not set anything. 'no need
        End Set
    End Property
#End Region
End Class
