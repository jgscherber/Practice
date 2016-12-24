<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Board
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.FoxButton = New System.Windows.Forms.Button()
        Me.HoundButton = New System.Windows.Forms.Button()
        Me.UndoButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ResetButton
        '
        Me.ResetButton.Location = New System.Drawing.Point(57, 456)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(75, 23)
        Me.ResetButton.TabIndex = 0
        Me.ResetButton.Text = "RESET"
        Me.ResetButton.UseVisualStyleBackColor = True
        '
        'FoxButton
        '
        Me.FoxButton.Location = New System.Drawing.Point(138, 456)
        Me.FoxButton.Name = "FoxButton"
        Me.FoxButton.Size = New System.Drawing.Size(75, 23)
        Me.FoxButton.TabIndex = 1
        Me.FoxButton.Text = "Fox"
        Me.FoxButton.UseVisualStyleBackColor = True
        '
        'HoundButton
        '
        Me.HoundButton.Location = New System.Drawing.Point(219, 456)
        Me.HoundButton.Name = "HoundButton"
        Me.HoundButton.Size = New System.Drawing.Size(75, 23)
        Me.HoundButton.TabIndex = 2
        Me.HoundButton.Text = "Hounds"
        Me.HoundButton.UseVisualStyleBackColor = True
        '
        'UndoButton
        '
        Me.UndoButton.Location = New System.Drawing.Point(300, 456)
        Me.UndoButton.Name = "UndoButton"
        Me.UndoButton.Size = New System.Drawing.Size(75, 23)
        Me.UndoButton.TabIndex = 3
        Me.UndoButton.Text = "Undo"
        Me.UndoButton.UseVisualStyleBackColor = True
        '
        'Board
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.OldLace
        Me.ClientSize = New System.Drawing.Size(434, 491)
        Me.Controls.Add(Me.UndoButton)
        Me.Controls.Add(Me.HoundButton)
        Me.Controls.Add(Me.FoxButton)
        Me.Controls.Add(Me.ResetButton)
        Me.Name = "Board"
        Me.Text = "Fox and Hounds"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ResetButton As Button
    Friend WithEvents FoxButton As Button
    Friend WithEvents HoundButton As Button
    Friend WithEvents UndoButton As Button
End Class
