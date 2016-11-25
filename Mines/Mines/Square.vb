Public Class Square
    Inherits System.Windows.Forms.Button
    Dim Row, Col As Integer 'global variables in the class
    ' initialization method
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


    End Sub

End Class
