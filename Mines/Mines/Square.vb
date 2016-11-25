Public Class Square
    Inherits System.Windows.Forms.Button

    Public Enum HiddenValue
        Uninitialized
        Safe
        Mine
    End Enum

    ' Create immutable variables (Const)
    Public Const ShowMine As String = "@"
    Public Const ShowFlag As String = "F"
    Public Const ShowBrokenFlag As String = "X"

    Private contents As HiddenValue ' what does the square hold? (Enum above)
    Private actualNearMines As Integer ' how many nearby mines?


    Dim Row, Col As Integer 'global variables in the class
    ' initialization subroutine
    Public Sub New(R As Integer, C As Integer)
        ' MyBase is the super class, create a new super class object
        MyBase.New()
        ' Set properties from the superclass
        Me.Font = New System.Drawing.Font("Arial", 0.9, FontStyle.Bold)
        Me.BackColor = Color.White

        ' Row and Col declared above, remaining must be declared in superclass?
        Row = R
        Col = C
        Height = 30
        Width = 30
        Text = ""
        FlatStyle = System.Windows.Forms.FlatStyle.Standard
        contents = HiddenValue.Uninitialized ' Enums like self-contain class attributes (dot operator)

    End Sub

End Class
