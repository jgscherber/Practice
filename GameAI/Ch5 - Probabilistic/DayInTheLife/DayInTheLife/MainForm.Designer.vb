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
        Me.GaryButton = New System.Windows.Forms.Button()
        Me.MikeButton = New System.Windows.Forms.Button()
        Me.CarlButton = New System.Windows.Forms.Button()
        Me.LarryButton = New System.Windows.Forms.Button()
        Me.BarryButton = New System.Windows.Forms.Button()
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
        'GaryButton
        '
        Me.GaryButton.Location = New System.Drawing.Point(13, 43)
        Me.GaryButton.Name = "GaryButton"
        Me.GaryButton.Size = New System.Drawing.Size(75, 23)
        Me.GaryButton.TabIndex = 2
        Me.GaryButton.Text = "Gary"
        Me.GaryButton.UseVisualStyleBackColor = True
        '
        'MikeButton
        '
        Me.MikeButton.Location = New System.Drawing.Point(13, 73)
        Me.MikeButton.Name = "MikeButton"
        Me.MikeButton.Size = New System.Drawing.Size(75, 23)
        Me.MikeButton.TabIndex = 3
        Me.MikeButton.Text = "Mike"
        Me.MikeButton.UseVisualStyleBackColor = True
        '
        'CarlButton
        '
        Me.CarlButton.Location = New System.Drawing.Point(13, 103)
        Me.CarlButton.Name = "CarlButton"
        Me.CarlButton.Size = New System.Drawing.Size(75, 23)
        Me.CarlButton.TabIndex = 4
        Me.CarlButton.Text = "Carl"
        Me.CarlButton.UseVisualStyleBackColor = True
        '
        'LarryButton
        '
        Me.LarryButton.Location = New System.Drawing.Point(13, 133)
        Me.LarryButton.Name = "LarryButton"
        Me.LarryButton.Size = New System.Drawing.Size(75, 23)
        Me.LarryButton.TabIndex = 5
        Me.LarryButton.Text = "Larry"
        Me.LarryButton.UseVisualStyleBackColor = True
        '
        'BarryButton
        '
        Me.BarryButton.Location = New System.Drawing.Point(13, 163)
        Me.BarryButton.Name = "BarryButton"
        Me.BarryButton.Size = New System.Drawing.Size(75, 23)
        Me.BarryButton.TabIndex = 6
        Me.BarryButton.Text = "Barry"
        Me.BarryButton.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 411)
        Me.Controls.Add(Me.BarryButton)
        Me.Controls.Add(Me.LarryButton)
        Me.Controls.Add(Me.CarlButton)
        Me.Controls.Add(Me.MikeButton)
        Me.Controls.Add(Me.GaryButton)
        Me.Controls.Add(Me.ThoughtsTextBox)
        Me.Controls.Add(Me.EddyButton)
        Me.Name = "MainForm"
        Me.Text = "Day In The Life"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents EddyButton As Button
    Friend WithEvents ThoughtsTextBox As TextBox
    Friend WithEvents GaryButton As Button
    Friend WithEvents MikeButton As Button
    Friend WithEvents CarlButton As Button
    Friend WithEvents LarryButton As Button
    Friend WithEvents BarryButton As Button
End Class
