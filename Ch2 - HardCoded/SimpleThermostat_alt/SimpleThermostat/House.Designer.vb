<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class House
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AmbientUpDown = New System.Windows.Forms.NumericUpDown()
        Me.DayUpDown = New System.Windows.Forms.NumericUpDown()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DayDateTime = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NightTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.NightUpDown = New System.Windows.Forms.NumericUpDown()
        CType(Me.AmbientUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DayUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NightUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ambient"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(111, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Day Set Point"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(92, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Status"
        '
        'AmbientUpDown
        '
        Me.AmbientUpDown.Location = New System.Drawing.Point(12, 29)
        Me.AmbientUpDown.Name = "AmbientUpDown"
        Me.AmbientUpDown.Size = New System.Drawing.Size(46, 20)
        Me.AmbientUpDown.TabIndex = 3
        '
        'DayUpDown
        '
        Me.DayUpDown.Location = New System.Drawing.Point(114, 75)
        Me.DayUpDown.Name = "DayUpDown"
        Me.DayUpDown.Size = New System.Drawing.Size(47, 20)
        Me.DayUpDown.TabIndex = 4
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.BackColor = System.Drawing.Color.White
        Me.StatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.StatusLabel.Location = New System.Drawing.Point(93, 31)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(58, 15)
        Me.StatusLabel.TabIndex = 5
        Me.StatusLabel.Text = "Undefined"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Day Start Time"
        '
        'DayDateTime
        '
        Me.DayDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DayDateTime.Location = New System.Drawing.Point(13, 75)
        Me.DayDateTime.Name = "DayDateTime"
        Me.DayDateTime.Size = New System.Drawing.Size(86, 20)
        Me.DayDateTime.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Night Start Time"
        '
        'NightTimePicker
        '
        Me.NightTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.NightTimePicker.Location = New System.Drawing.Point(12, 131)
        Me.NightTimePicker.Name = "NightTimePicker"
        Me.NightTimePicker.Size = New System.Drawing.Size(87, 20)
        Me.NightTimePicker.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(114, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Night Set Point"
        '
        'NightUpDown
        '
        Me.NightUpDown.Location = New System.Drawing.Point(114, 130)
        Me.NightUpDown.Name = "NightUpDown"
        Me.NightUpDown.Size = New System.Drawing.Size(47, 20)
        Me.NightUpDown.TabIndex = 11
        '
        'House
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(227, 189)
        Me.Controls.Add(Me.NightUpDown)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.NightTimePicker)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DayDateTime)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.DayUpDown)
        Me.Controls.Add(Me.AmbientUpDown)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "House"
        Me.Text = "House Simulator"
        CType(Me.AmbientUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DayUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NightUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents AmbientUpDown As NumericUpDown
    Friend WithEvents DayUpDown As NumericUpDown
    Friend WithEvents StatusLabel As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents DayDateTime As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents NightTimePicker As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents NightUpDown As NumericUpDown
End Class
