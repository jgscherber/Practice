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
        Me.ExpertButton = New System.Windows.Forms.Button()
        Me.MovesLeftLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MinesLeftLabel = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
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
        'ExpertButton
        '
        Me.ExpertButton.Location = New System.Drawing.Point(3, 3)
        Me.ExpertButton.Name = "ExpertButton"
        Me.ExpertButton.Size = New System.Drawing.Size(75, 23)
        Me.ExpertButton.TabIndex = 1
        Me.ExpertButton.Text = "Expert"
        Me.ExpertButton.UseVisualStyleBackColor = True
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
End Class
