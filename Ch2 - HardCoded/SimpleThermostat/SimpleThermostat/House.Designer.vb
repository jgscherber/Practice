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
        Me.SetPointUpDown = New System.Windows.Forms.NumericUpDown()
        Me.StatusLabel = New System.Windows.Forms.Label()
        CType(Me.AmbientUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SetPointUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ambient"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(79, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Set Point"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(152, 13)
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
        'SetPointUpDown
        '
        Me.SetPointUpDown.Location = New System.Drawing.Point(82, 28)
        Me.SetPointUpDown.Name = "SetPointUpDown"
        Me.SetPointUpDown.Size = New System.Drawing.Size(47, 20)
        Me.SetPointUpDown.TabIndex = 4
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.BackColor = System.Drawing.Color.White
        Me.StatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.StatusLabel.Location = New System.Drawing.Point(152, 30)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(58, 15)
        Me.StatusLabel.TabIndex = 5
        Me.StatusLabel.Text = "Undefined"
        '
        'House
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 132)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.SetPointUpDown)
        Me.Controls.Add(Me.AmbientUpDown)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "House"
        Me.Text = "House Simulator"
        CType(Me.AmbientUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SetPointUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents AmbientUpDown As NumericUpDown
    Friend WithEvents SetPointUpDown As NumericUpDown
    Friend WithEvents StatusLabel As Label
End Class
