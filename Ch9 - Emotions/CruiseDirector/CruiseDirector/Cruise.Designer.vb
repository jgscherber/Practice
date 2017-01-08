<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cruise
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
        Me.Button1Time = New System.Windows.Forms.Button()
        Me.Button100Times = New System.Windows.Forms.Button()
        Me.DumpButton = New System.Windows.Forms.Button()
        Me.PeopleButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1Time
        '
        Me.Button1Time.Location = New System.Drawing.Point(197, 13)
        Me.Button1Time.Name = "Button1Time"
        Me.Button1Time.Size = New System.Drawing.Size(75, 23)
        Me.Button1Time.TabIndex = 0
        Me.Button1Time.Text = "1 Time"
        Me.Button1Time.UseVisualStyleBackColor = True
        '
        'Button100Times
        '
        Me.Button100Times.Location = New System.Drawing.Point(196, 43)
        Me.Button100Times.Name = "Button100Times"
        Me.Button100Times.Size = New System.Drawing.Size(75, 23)
        Me.Button100Times.TabIndex = 1
        Me.Button100Times.Text = "100 Times"
        Me.Button100Times.UseVisualStyleBackColor = True
        '
        'DumpButton
        '
        Me.DumpButton.Location = New System.Drawing.Point(13, 42)
        Me.DumpButton.Name = "DumpButton"
        Me.DumpButton.Size = New System.Drawing.Size(75, 23)
        Me.DumpButton.TabIndex = 2
        Me.DumpButton.Text = "Dump"
        Me.DumpButton.UseVisualStyleBackColor = True
        '
        'PeopleButton
        '
        Me.PeopleButton.Location = New System.Drawing.Point(13, 13)
        Me.PeopleButton.Name = "PeopleButton"
        Me.PeopleButton.Size = New System.Drawing.Size(75, 23)
        Me.PeopleButton.TabIndex = 3
        Me.PeopleButton.Text = "People"
        Me.PeopleButton.UseVisualStyleBackColor = True
        '
        'Cruise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.PeopleButton)
        Me.Controls.Add(Me.DumpButton)
        Me.Controls.Add(Me.Button100Times)
        Me.Controls.Add(Me.Button1Time)
        Me.Name = "Cruise"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1Time As Button
    Friend WithEvents Button100Times As Button
    Friend WithEvents DumpButton As Button
    Friend WithEvents PeopleButton As Button
End Class
