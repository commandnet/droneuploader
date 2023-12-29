<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Button1 = New Button()
        Label1 = New Label()
        TextBox1 = New TextBox()
        GroupBox1 = New GroupBox()
        ListBox1 = New ListBox()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        Button2 = New Button()
        classify_files = New ComponentModel.BackgroundWorker()
        Label2 = New Label()
        Button3 = New Button()
        GroupBox2 = New GroupBox()
        ComboBox2 = New ComboBox()
        Label5 = New Label()
        ComboBox1 = New ComboBox()
        Label4 = New Label()
        GroupBox3 = New GroupBox()
        Label8 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        Label3 = New Label()
        ProgressBar1 = New ProgressBar()
        ProgressBar2 = New ProgressBar()
        upload_files = New ComponentModel.BackgroundWorker()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button1.Location = New Point(6, 26)
        Button1.Name = "Button1"
        Button1.Size = New Size(1902, 29)
        Button1.TabIndex = 0
        Button1.Text = "Quell Ordner auswählen ..."
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(6, 65)
        Label1.Name = "Label1"
        Label1.Size = New Size(91, 20)
        Label1.TabIndex = 1
        Label1.Text = "Quellordner:"
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TextBox1.Location = New Point(103, 62)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(1805, 27)
        TextBox1.TabIndex = 2
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GroupBox1.Controls.Add(TextBox1)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1920, 106)
        GroupBox1.TabIndex = 3
        GroupBox1.TabStop = False
        GroupBox1.Text = "Quelle"
        ' 
        ' ListBox1
        ' 
        ListBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 20
        ListBox1.Location = New Point(6, 101)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(1902, 164)
        ListBox1.TabIndex = 5
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button2.Location = New Point(6, 54)
        Button2.Name = "Button2"
        Button2.Size = New Size(1902, 29)
        Button2.TabIndex = 6
        Button2.Text = "Bilder finden"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' classify_files
        ' 
        classify_files.WorkerReportsProgress = True
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label2.AutoSize = True
        Label2.Location = New Point(6, 286)
        Label2.Name = "Label2"
        Label2.Size = New Size(18, 20)
        Label2.TabIndex = 7
        Label2.Text = "..."
        ' 
        ' Button3
        ' 
        Button3.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button3.Enabled = False
        Button3.Location = New Point(6, 26)
        Button3.Name = "Button3"
        Button3.Size = New Size(1902, 29)
        Button3.TabIndex = 8
        Button3.Text = "Hochladen"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        GroupBox2.Controls.Add(ComboBox2)
        GroupBox2.Controls.Add(Label5)
        GroupBox2.Controls.Add(ComboBox1)
        GroupBox2.Controls.Add(Label4)
        GroupBox2.Controls.Add(ListBox1)
        GroupBox2.Controls.Add(Button2)
        GroupBox2.Controls.Add(Label2)
        GroupBox2.Location = New Point(12, 124)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(1920, 309)
        GroupBox2.TabIndex = 9
        GroupBox2.TabStop = False
        GroupBox2.Text = "Identifizieren"
        ' 
        ' ComboBox2
        ' 
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.FormattingEnabled = True
        ComboBox2.Items.AddRange(New Object() {"Nicht hochladen", "InfraredCamera", "WideCamera", "ZoomCamera"})
        ComboBox2.Location = New Point(343, 20)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(151, 28)
        ComboBox2.TabIndex = 11
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(252, 23)
        Label5.Name = "Label5"
        Label5.Size = New Size(85, 20)
        Label5.TabIndex = 10
        Label5.Text = "Viewquelle:"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"Nicht hochladen", "InfraredCamera", "WideCamera", "ZoomCamera"})
        ComboBox1.Location = New Point(95, 20)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(151, 28)
        ComboBox1.TabIndex = 9
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(6, 23)
        Label4.Name = "Label4"
        Label4.Size = New Size(83, 20)
        Label4.TabIndex = 8
        Label4.Text = "Ortoquelle:"
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        GroupBox3.Controls.Add(Label8)
        GroupBox3.Controls.Add(Label7)
        GroupBox3.Controls.Add(Label6)
        GroupBox3.Controls.Add(Label3)
        GroupBox3.Controls.Add(ProgressBar1)
        GroupBox3.Controls.Add(ProgressBar2)
        GroupBox3.Controls.Add(Button3)
        GroupBox3.Location = New Point(12, 439)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(1920, 174)
        GroupBox3.TabIndex = 10
        GroupBox3.TabStop = False
        GroupBox3.Text = "Hochladen"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(1750, 142)
        Label8.Name = "Label8"
        Label8.Size = New Size(18, 20)
        Label8.TabIndex = 15
        Label8.Text = "..."
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(1750, 87)
        Label7.Name = "Label7"
        Label7.Size = New Size(18, 20)
        Label7.TabIndex = 14
        Label7.Text = "..."
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(6, 61)
        Label6.Name = "Label6"
        Label6.Size = New Size(177, 20)
        Label6.TabIndex = 13
        Label6.Text = "Fortschritt einzelne Datei:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(6, 116)
        Label3.Name = "Label3"
        Label3.Size = New Size(132, 20)
        Label3.TabIndex = 11
        Label3.Text = "Fortschritt Gesamt:"
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ProgressBar1.Location = New Point(6, 139)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(1738, 29)
        ProgressBar1.TabIndex = 9
        ' 
        ' ProgressBar2
        ' 
        ProgressBar2.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ProgressBar2.Location = New Point(6, 84)
        ProgressBar2.Name = "ProgressBar2"
        ProgressBar2.Size = New Size(1738, 29)
        ProgressBar2.TabIndex = 12
        ' 
        ' upload_files
        ' 
        upload_files.WorkerReportsProgress = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1940, 625)
        Controls.Add(GroupBox3)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Name = "Form1"
        Text = "Form1"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Button2 As Button
    Friend WithEvents classify_files As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label2 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents upload_files As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
End Class
