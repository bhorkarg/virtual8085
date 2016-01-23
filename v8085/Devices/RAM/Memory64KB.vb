'Programmer - Gaurav Bhorkar
'Class Name - Memory64KB

'Description-
'64KB means 65536 locations of 8 bits each
'Inherited from ListBox to reduce the overhead of maintaining another listbox to display memory
'By inheriting we have just added 65535 memory locations to the ListBox


Public Class Memory64KB
    Inherits ListBox

    Private _FirstIndex As Integer
    Private _LastIndex As Integer

    Private mLocations(65535) As BitArray '65535 is the last index

    Property bits(ByVal HexIndex As String) As BitArray
        Get
            'select the memory location in the list box
            Dim newIndex As UInteger = Conversion.FromHexToDec(HexIndex) - _FirstIndex
            MyBase.SelectedItem = MyBase.Items.Item(newIndex)

            Return mLocations(Conversion.FromHexToDec(HexIndex))
        End Get

        Set(ByVal value As BitArray)
            Dim index As UInteger = Conversion.FromHexToDec(HexIndex)
            mLocations(index) = value

            'the index of the list box is different than the mLocation index, so calculating the index for the listbox
            Dim newIndex As UInteger = index - _FirstIndex

            Items.Item(newIndex) = index.ToString("X4") & " -" & ControlChars.Tab & Conversion.FromBinToHex(value)
            MyBase.SelectedItem = MyBase.Items.Item(newIndex)
        End Set
    End Property


    Property FirstIndex As Integer
        Get
            Return _FirstIndex
        End Get

        Set(ByVal value As Integer)
            _FirstIndex = value
        End Set
    End Property


    Property LastIndex As Integer
        Get
            Return _LastIndex
        End Get

        Set(ByVal value As Integer)
            _LastIndex = value
        End Set
    End Property


    Public Sub New()
        Dim Rnd As New Random
        Dim RandomHex As String
        For i As UInteger = 0 To 65535
            RandomHex = Rnd.Next(0, 255).ToString("X2") ''8 bit random hexadecimal number
            mLocations(i) = Conversion.FromHexToBin(RandomHex) 'initializing to an 8bit random value
        Next
    End Sub

    Public Sub InitializeDisplay(ByRef Progress As ProgressBar, ByVal _mSize As Integer)
        Me.Hide()
        Items.Clear()
        Progress.Minimum = _FirstIndex
        Progress.Value = _FirstIndex
        Progress.Maximum = _LastIndex
        For i As UInteger = _FirstIndex To _LastIndex
            Progress.Increment(1)
            Items.Add(i.ToString("X4") & " - " & Conversion.FromBinToHex(mLocations(i)))
        Next
        Me.Show()
    End Sub

End Class
