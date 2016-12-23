<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.EddyButton = New System.Windows.Forms.Button()
        Me.ThoughtsTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'EddyButton
        '
        Me.EddyButton.Location = New System.Drawing.Point(13, 13)
        Me.EddyButton.Name = "EddyButton"
        Me.EddyButton.Size = New System.Drawing.Size(75, 23)
        Me.EddyButton.TabIndex = 0
        Me.EddyButton.Text = "Eddy"
        Me.EddyButton.UseVisualStyleBackColor = True
        '
        'ThoughtsTextBox
        '
        Me.ThoughtsTextBox.BackColor = System.Drawing.Color.White
        Me.ThoughtsTextBox.Location = New System.Drawing.Point(95, 15)
        Me.ThoughtsTextBox.Multiline = True
        Me.ThoughtsTextBox.Name = "ThoughtsTextBox"
        Me.ThoughtsTextBox.ReadOnly = True
        Me.ThoughtsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ThoughtsTextBox.Size = New System.Drawing.Size(807, 384)
        Me.ThoughtsTextBox.TabIndex = 1
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 411)
        Me.Controls.Add(Me.ThoughtsTextBox)
        Me.Controls.Add(Me.EddyButton)
        Me.Name = "MainForm"
        Me.Text = "Day In The Life"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents EddyButton As Button
    Friend WithEvents ThoughtsTextBox As TextBox
End Class
