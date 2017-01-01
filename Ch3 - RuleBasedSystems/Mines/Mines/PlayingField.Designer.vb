<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlayingField
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ThoughtsTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MinesLeftLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MovesLeftLabel = New System.Windows.Forms.Label()
        Me.ExpertButton = New System.Windows.Forms.Button()
        Me.AutoButton = New System.Windows.Forms.Button()
        Me.BookButton = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.BookButton)
        Me.Panel1.Controls.Add(Me.AutoButton)
        Me.Panel1.Controls.Add(Me.ThoughtsTextBox)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.MinesLeftLabel)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.MovesLeftLabel)
        Me.Panel1.Controls.Add(Me.ExpertButton)
        Me.Panel1.Location = New System.Drawing.Point(0, 490)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(906, 124)
        Me.Panel1.TabIndex = 0
        '
        'ThoughtsTextBox
        '
        Me.ThoughtsTextBox.Location = New System.Drawing.Point(487, 3)
        Me.ThoughtsTextBox.Multiline = True
        Me.ThoughtsTextBox.Name = "ThoughtsTextBox"
        Me.ThoughtsTextBox.ReadOnly = True
        Me.ThoughtsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ThoughtsTextBox.Size = New System.Drawing.Size(416, 118)
        Me.ThoughtsTextBox.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(81, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Mines Remaining"
        '
        'MinesLeftLabel
        '
        Me.MinesLeftLabel.AutoSize = True
        Me.MinesLeftLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MinesLeftLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinesLeftLabel.Location = New System.Drawing.Point(204, 29)
        Me.MinesLeftLabel.Name = "MinesLeftLabel"
        Me.MinesLeftLabel.Size = New System.Drawing.Size(31, 18)
        Me.MinesLeftLabel.TabIndex = 4
        Me.MinesLeftLabel.Text = "999"
        Me.MinesLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(81, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Moves Remaining"
        '
        'MovesLeftLabel
        '
        Me.MovesLeftLabel.AutoSize = True
        Me.MovesLeftLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MovesLeftLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MovesLeftLabel.Location = New System.Drawing.Point(204, 3)
        Me.MovesLeftLabel.Name = "MovesLeftLabel"
        Me.MovesLeftLabel.Size = New System.Drawing.Size(31, 18)
        Me.MovesLeftLabel.TabIndex = 2
        Me.MovesLeftLabel.Text = "888"
        Me.MovesLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ExpertButton
        '
        Me.ExpertButton.Location = New System.Drawing.Point(3, 3)
        Me.ExpertButton.Name = "ExpertButton"
        Me.ExpertButton.Size = New System.Drawing.Size(75, 23)
        Me.ExpertButton.TabIndex = 1
        Me.ExpertButton.Text = "Expert"
        Me.ExpertButton.UseVisualStyleBackColor = True
        '
        'AutoButton
        '
        Me.AutoButton.Location = New System.Drawing.Point(281, 2)
        Me.AutoButton.Name = "AutoButton"
        Me.AutoButton.Size = New System.Drawing.Size(75, 23)
        Me.AutoButton.TabIndex = 7
        Me.AutoButton.Text = "AI Auto"
        Me.AutoButton.UseVisualStyleBackColor = True
        '
        'BookButton
        '
        Me.BookButton.Location = New System.Drawing.Point(281, 32)
        Me.BookButton.Name = "BookButton"
        Me.BookButton.Size = New System.Drawing.Size(75, 23)
        Me.BookButton.TabIndex = 8
        Me.BookButton.Text = "AI Book"
        Me.BookButton.UseVisualStyleBackColor = True
        '
        'PlayingField
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 611)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "PlayingField"
        Me.Text = "Mines"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ExpertButton As Button
    Friend WithEvents MovesLeftLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents MinesLeftLabel As Label
    Friend WithEvents ThoughtsTextBox As TextBox
    Friend WithEvents BookButton As Button
    Friend WithEvents AutoButton As Button
End Class
