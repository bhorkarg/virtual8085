'Programmer - Gaurav Bhorkar
'Class Name - Register16

'Description -
'To initialize the class Register to 16 bits (hence inherited from Register)

Public Class Register16
    Inherits Register

    Public Sub New()
        bits = New BitArray(16)
    End Sub

    Public ReadOnly Property H() As BitArray
        Get
            Dim _H As New BitArray(8)
            For i As Integer = 0 To 7
                _H(i) = bits(i)
            Next
            Return _H
        End Get
    End Property

    Public ReadOnly Property L() As BitArray
        Get
            Dim _L As New BitArray(8)
            For i As Integer = 8 To 15
                _L(i - 8) = bits(i)
            Next
            Return _L
        End Get
    End Property
End Class
