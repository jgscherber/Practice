<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Level = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MageRadio = New System.Windows.Forms.RadioButton()
        Me.ThiefRadio = New System.Windows.Forms.RadioButton()
        Me.ClericRadio = New System.Windows.Forms.RadioButton()
        Me.FighterRadio = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.HitPointsLabel = New System.Windows.Forms.Label()
        CType(Me.Level, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Character Level"
        '
        'Level
        '
        Me.Level.Location = New System.Drawing.Point(12, 29)
        Me.Level.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.Level.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Level.Name = "Level"
        Me.Level.Size = New System.Drawing.Size(120, 20)
        Me.Level.TabIndex = 1
        Me.Level.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Class"
        '
        'MageRadio
        '
        Me.MageRadio.AutoSize = True
        Me.MageRadio.Location = New System.Drawing.Point(12, 73)
        Me.MageRadio.Name = "MageRadio"
        Me.MageRadio.Size = New System.Drawing.Size(52, 17)
        Me.MageRadio.TabIndex = 3
        Me.MageRadio.TabStop = True
        Me.MageRadio.Text = "Mage"
        Me.MageRadio.UseVisualStyleBackColor = True
        '
        'ThiefRadio
        '
        Me.ThiefRadio.AutoSize = True
        Me.ThiefRadio.Location = New System.Drawing.Point(12, 97)
        Me.ThiefRadio.Name = "ThiefRadio"
        Me.ThiefRadio.Size = New System.Drawing.Size(49, 17)
        Me.ThiefRadio.TabIndex = 4
        Me.ThiefRadio.TabStop = True
        Me.ThiefRadio.Text = "Thief"
        Me.ThiefRadio.UseVisualStyleBackColor = True
        '
        'ClericRadio
        '
        Me.ClericRadio.AutoSize = True
        Me.ClericRadio.Location = New System.Drawing.Point(12, 121)
        Me.ClericRadio.Name = "ClericRadio"
        Me.ClericRadio.Size = New System.Drawing.Size(51, 17)
        Me.ClericRadio.TabIndex = 5
        Me.ClericRadio.TabStop = True
        Me.ClericRadio.Text = "Cleric"
        Me.ClericRadio.UseVisualStyleBackColor = True
        '
        'FighterRadio
        '
        Me.FighterRadio.AutoSize = True
        Me.FighterRadio.Location = New System.Drawing.Point(12, 145)
        Me.FighterRadio.Name = "FighterRadio"
        Me.FighterRadio.Size = New System.Drawing.Size(57, 17)
        Me.FighterRadio.TabIndex = 6
        Me.FighterRadio.TabStop = True
        Me.FighterRadio.Text = "Fighter"
        Me.FighterRadio.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(166, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Maximum Hit Points"
        '
        'HitPointsLabel
        '
        Me.HitPointsLabel.AutoSize = True
        Me.HitPointsLabel.BackColor = System.Drawing.Color.White
        Me.HitPointsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HitPointsLabel.Location = New System.Drawing.Point(169, 35)
        Me.HitPointsLabel.Name = "HitPointsLabel"
        Me.HitPointsLabel.Size = New System.Drawing.Size(27, 15)
        Me.HitPointsLabel.TabIndex = 8
        Me.HitPointsLabel.Text = "888"
        '
        'GameForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.HitPointsLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.FighterRadio)
        Me.Controls.Add(Me.ClericRadio)
        Me.Controls.Add(Me.ThiefRadio)
        Me.Controls.Add(Me.MageRadio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Level)
        Me.Controls.Add(Me.Label1)
        Me.Name = "GameForm"
        Me.Text = "Hit Points Calculator"
        CType(Me.Level, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Level As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents MageRadio As RadioButton
    Friend WithEvents ThiefRadio As RadioButton
    Friend WithEvents ClericRadio As RadioButton
    Friend WithEvents FighterRadio As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents HitPointsLabel As Label
End Class
