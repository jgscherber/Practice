<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Monster
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
        Me.SeePlayerCheck = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CurrentHealth = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ThoughtsText = New System.Windows.Forms.TextBox()
        Me.ThinkButton = New System.Windows.Forms.Button()
        CType(Me.CurrentHealth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SeePlayerCheck
        '
        Me.SeePlayerCheck.AutoSize = True
        Me.SeePlayerCheck.Location = New System.Drawing.Point(13, 31)
        Me.SeePlayerCheck.Name = "SeePlayerCheck"
        Me.SeePlayerCheck.Size = New System.Drawing.Size(60, 17)
        Me.SeePlayerCheck.TabIndex = 0
        Me.SeePlayerCheck.Text = "Players"
        Me.SeePlayerCheck.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Health"
        '
        'CurrentHealth
        '
        Me.CurrentHealth.Location = New System.Drawing.Point(13, 72)
        Me.CurrentHealth.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.CurrentHealth.Name = "CurrentHealth"
        Me.CurrentHealth.Size = New System.Drawing.Size(120, 20)
        Me.CurrentHealth.TabIndex = 2
        Me.CurrentHealth.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(259, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Thoughts"
        '
        'ThoughtsText
        '
        Me.ThoughtsText.Location = New System.Drawing.Point(262, 31)
        Me.ThoughtsText.Multiline = True
        Me.ThoughtsText.Name = "ThoughtsText"
        Me.ThoughtsText.ReadOnly = True
        Me.ThoughtsText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ThoughtsText.Size = New System.Drawing.Size(465, 218)
        Me.ThoughtsText.TabIndex = 4
        '
        'ThinkButton
        '
        Me.ThinkButton.Location = New System.Drawing.Point(16, 225)
        Me.ThinkButton.Name = "ThinkButton"
        Me.ThinkButton.Size = New System.Drawing.Size(75, 23)
        Me.ThinkButton.TabIndex = 5
        Me.ThinkButton.Text = "Think"
        Me.ThinkButton.UseVisualStyleBackColor = True
        '
        'Monster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 261)
        Me.Controls.Add(Me.ThinkButton)
        Me.Controls.Add(Me.ThoughtsText)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CurrentHealth)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SeePlayerCheck)
        Me.Name = "Monster"
        Me.Text = "Monster"
        CType(Me.CurrentHealth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SeePlayerCheck As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CurrentHealth As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents ThoughtsText As TextBox
    Friend WithEvents ThinkButton As Button
End Class
