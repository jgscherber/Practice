Public Class FaHButton
    Inherits Button

    Private MySubscript As Integer ' only this class has access to this variable
    Protected HoundNumber As Integer ' available to this class and subclasses

    Public ReadOnly Property Subscript() As Integer
        Get
            Return MySubscript
        End Get
    End Property

    Public Sub New(ss As Integer)
        MySubscript = ss

        AllowDrop = True ' attribute of the Button class that it's inheriting from
        Me.Font = New System.Drawing.Font("Arial", 9, FontStyle.Bold)
    End Sub


End Class
