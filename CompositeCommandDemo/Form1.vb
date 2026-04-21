Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Reflection
Imports System.Data
Imports Atalasoft.Imaging.WinControls
Imports Atalasoft.Imaging
Imports Atalasoft.Imaging.ImageProcessing
Imports Atalasoft.Imaging.Codec
Imports WinDemoHelperMethods.WinDemoHelperMethods

Namespace CompositeCommandDemo
    ''' <summary>
    ''' Summary description for Form1.
    ''' </summary>
    Public Class Form1
        Inherits System.Windows.Forms.Form
        Private compositeCommand As CompositeCommand = New CompositeCommand()
        Private allImageCommands As Type()

        Private WithEvents listBox1 As System.Windows.Forms.ListBox
        Private splitter1 As System.Windows.Forms.Splitter
        Private panel1 As System.Windows.Forms.Panel
        Private WithEvents addCommand As System.Windows.Forms.Button
        Private WithEvents removeCommand As System.Windows.Forms.Button
        Private WithEvents properties As System.Windows.Forms.Button
        Private WithEvents chooseImage As System.Windows.Forms.Button
        Private WithEvents doCommand As System.Windows.Forms.Button
        Private imageViewer1 As Atalasoft.Imaging.WinControls.ImageViewer
        Private WithEvents clearCommands As System.Windows.Forms.Button
        Private progressBar1 As System.Windows.Forms.ProgressBar
        Private WithEvents btnAbout As System.Windows.Forms.Button
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.Container = Nothing

        Shared Sub New()
            HelperMethods.PopulateDecoders(RegisteredDecoders.Decoders)
        End Sub

        Public Sub New()
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()

            allImageCommands = GetAllImageCommands(New [Assembly]() {System.Reflection.Assembly.GetAssembly(GetType(AtalaImage))})

            compositeCommand.Progress = New ProgressEventHandler(AddressOf Form1_Progress)
        End Sub

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not components Is Nothing Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.listBox1 = New System.Windows.Forms.ListBox
            Me.splitter1 = New System.Windows.Forms.Splitter
            Me.panel1 = New System.Windows.Forms.Panel
            Me.btnAbout = New System.Windows.Forms.Button
            Me.progressBar1 = New System.Windows.Forms.ProgressBar
            Me.clearCommands = New System.Windows.Forms.Button
            Me.doCommand = New System.Windows.Forms.Button
            Me.chooseImage = New System.Windows.Forms.Button
            Me.properties = New System.Windows.Forms.Button
            Me.removeCommand = New System.Windows.Forms.Button
            Me.addCommand = New System.Windows.Forms.Button
            Me.imageViewer1 = New Atalasoft.Imaging.WinControls.ImageViewer
            Me.panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'listBox1
            '
            Me.listBox1.Dock = System.Windows.Forms.DockStyle.Left
            Me.listBox1.Location = New System.Drawing.Point(0, 0)
            Me.listBox1.Name = "listBox1"
            Me.listBox1.Size = New System.Drawing.Size(184, 589)
            Me.listBox1.TabIndex = 0
            '
            'splitter1
            '
            Me.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.splitter1.Location = New System.Drawing.Point(184, 0)
            Me.splitter1.Name = "splitter1"
            Me.splitter1.Size = New System.Drawing.Size(6, 590)
            Me.splitter1.TabIndex = 1
            Me.splitter1.TabStop = False
            '
            'panel1
            '
            Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.panel1.Controls.Add(Me.btnAbout)
            Me.panel1.Controls.Add(Me.progressBar1)
            Me.panel1.Controls.Add(Me.clearCommands)
            Me.panel1.Controls.Add(Me.doCommand)
            Me.panel1.Controls.Add(Me.chooseImage)
            Me.panel1.Controls.Add(Me.properties)
            Me.panel1.Controls.Add(Me.removeCommand)
            Me.panel1.Controls.Add(Me.addCommand)
            Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.panel1.Location = New System.Drawing.Point(190, 490)
            Me.panel1.Name = "panel1"
            Me.panel1.Size = New System.Drawing.Size(522, 100)
            Me.panel1.TabIndex = 2
            '
            'btnAbout
            '
            Me.btnAbout.Location = New System.Drawing.Point(184, 8)
            Me.btnAbout.Name = "btnAbout"
            Me.btnAbout.Size = New System.Drawing.Size(75, 23)
            Me.btnAbout.TabIndex = 8
            Me.btnAbout.Text = "About"
            '
            'progressBar1
            '
            Me.progressBar1.Location = New System.Drawing.Point(192, 56)
            Me.progressBar1.Name = "progressBar1"
            Me.progressBar1.Size = New System.Drawing.Size(312, 23)
            Me.progressBar1.TabIndex = 7
            '
            'clearCommands
            '
            Me.clearCommands.Location = New System.Drawing.Point(96, 56)
            Me.clearCommands.Name = "clearCommands"
            Me.clearCommands.Size = New System.Drawing.Size(75, 23)
            Me.clearCommands.TabIndex = 6
            Me.clearCommands.Text = "Clear All"
            '
            'doCommand
            '
            Me.doCommand.Enabled = False
            Me.doCommand.Location = New System.Drawing.Point(400, 8)
            Me.doCommand.Name = "doCommand"
            Me.doCommand.Size = New System.Drawing.Size(104, 23)
            Me.doCommand.TabIndex = 4
            Me.doCommand.Text = "Apply Commands"
            '
            'chooseImage
            '
            Me.chooseImage.Location = New System.Drawing.Point(312, 8)
            Me.chooseImage.Name = "chooseImage"
            Me.chooseImage.Size = New System.Drawing.Size(75, 23)
            Me.chooseImage.TabIndex = 3
            Me.chooseImage.Text = "Open..."
            '
            'properties
            '
            Me.properties.Enabled = False
            Me.properties.Location = New System.Drawing.Point(96, 8)
            Me.properties.Name = "properties"
            Me.properties.Size = New System.Drawing.Size(75, 23)
            Me.properties.TabIndex = 2
            Me.properties.Text = "Properties..."
            '
            'removeCommand
            '
            Me.removeCommand.Enabled = False
            Me.removeCommand.Location = New System.Drawing.Point(8, 56)
            Me.removeCommand.Name = "removeCommand"
            Me.removeCommand.Size = New System.Drawing.Size(75, 23)
            Me.removeCommand.TabIndex = 1
            Me.removeCommand.Text = "Remove"
            '
            'addCommand
            '
            Me.addCommand.Location = New System.Drawing.Point(8, 8)
            Me.addCommand.Name = "addCommand"
            Me.addCommand.Size = New System.Drawing.Size(75, 23)
            Me.addCommand.TabIndex = 0
            Me.addCommand.Text = "Add..."
            '
            'imageViewer1
            '
            Me.imageViewer1.AntialiasDisplay = Atalasoft.Imaging.WinControls.AntialiasDisplayMode.ScaleToGray
            Me.imageViewer1.AutoZoom = Atalasoft.Imaging.WinControls.AutoZoomMode.BestFit
            Me.imageViewer1.DisplayProfile = Nothing
            Me.imageViewer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.imageViewer1.Location = New System.Drawing.Point(190, 0)
            Me.imageViewer1.Magnifier.BackColor = System.Drawing.Color.White
            Me.imageViewer1.Magnifier.BorderColor = System.Drawing.Color.Black
            Me.imageViewer1.Magnifier.Size = New System.Drawing.Size(100, 100)
            Me.imageViewer1.Name = "imageViewer1"
            Me.imageViewer1.OutputProfile = Nothing
            Me.imageViewer1.Selection = Nothing
            Me.imageViewer1.Size = New System.Drawing.Size(522, 490)
            Me.imageViewer1.TabIndex = 3
            Me.imageViewer1.Text = "imageViewer1"
            '
            'Form1
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(712, 590)
            Me.Controls.Add(Me.imageViewer1)
            Me.Controls.Add(Me.panel1)
            Me.Controls.Add(Me.splitter1)
            Me.Controls.Add(Me.listBox1)
            Me.Name = "Form1"
            Me.Text = "Composite Command Demo"
            Me.panel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
#End Region

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Shared Sub Main()
            Application.Run(New Form1())
        End Sub

        Private Sub chooseImage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chooseImage.Click
            Dim ofd As OpenImageFileDialog = New OpenImageFileDialog()
            ofd.Filter = HelperMethods.CreateDialogFilter(True)

            ' try to locate images folder
            Dim imagesFolder As String = Application.ExecutablePath
            ' we assume we are running under the DotImage install folder
            Dim pos As Integer = imagesFolder.IndexOf("DotImage ")
            If pos <> -1 Then
                imagesFolder = imagesFolder.Substring(0, imagesFolder.IndexOf("\", pos)) & "\Images"
            End If

            'use this folder as starting point			
            ofd.InitialDirectory = imagesFolder

            If ofd.ShowDialog() = DialogResult.OK Then
                Dim image As AtalaImage = Nothing
                Try
                    image = New AtalaImage(ofd.FileName)
                Catch err As Exception
                    MessageBox.Show(Me, "Unable to open file: " & err.Message)
                    Return
                End Try
                imageViewer1.Image = image
                OnImageChanged(Not image Is Nothing)
            End If
        End Sub

        Private Sub listBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles listBox1.SelectedIndexChanged
            Me.removeCommand.Enabled = (listBox1.SelectedIndex <> -1)
            Me.properties.Enabled = Me.removeCommand.Enabled

        End Sub

        Private Sub OnImageChanged(ByVal hasImage As Boolean)
            Me.doCommand.Enabled = hasImage AndAlso compositeCommand.Commands.Count > 0
        End Sub

        Private Sub addCommand_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles addCommand.Click
            Dim picker As PickCommand = New PickCommand(allImageCommands)
            If picker.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim type As Type = picker.SelectedType
                If Not type Is Nothing Then
                    AddNewCommand(type)
                End If
            End If

        End Sub

        Private Function GetAllImageCommands(ByVal assemblies As System.Reflection.Assembly()) As Type()
            Dim list As ArrayList = New ArrayList()
            For Each a As System.Reflection.Assembly In assemblies
                Dim types As Type() = a.GetTypes()
                For Each type As Type In types
                    If type.IsSubclassOf(GetType(ImageCommand)) AndAlso (Not type.IsAbstract) Then
                        Dim ctorInfo As ConstructorInfo = type.GetConstructor(New Type() {})
                        If Not ctorInfo Is Nothing Then
                            list.Add(type)
                        End If
                    End If
                Next type
            Next a
            Dim finalArray As Type() = New Type(list.Count - 1) {}
            Dim i As Integer = 0
            For Each o As Object In list
                finalArray(i) = CType(o, Type)
                i += 1
            Next o
            Return finalArray
        End Function

        Private Sub AddNewCommand(ByVal type As Type)
            Dim ctorInfo As ConstructorInfo = type.GetConstructor(New Type() {})
            If ctorInfo Is Nothing Then
                MessageBox.Show(Me, "Unable to get constructor for image command of type " & type.Name)
                Return
            End If
            Dim command As ImageCommand = Nothing

            Try
                command = CType(ctorInfo.Invoke(Nothing), ImageCommand)
            Catch
                MessageBox.Show("Unable to construct image command of type " & type.Name)
            End Try

            If listBox1.SelectedIndex = -1 Then
                compositeCommand.Commands.Add(command)
                listBox1.Items.Add(type.Name)
                listBox1.SelectedIndex = 0
            Else
                compositeCommand.Commands.Insert(listBox1.SelectedIndex + 1, command)
                listBox1.Items.Insert(listBox1.SelectedIndex + 1, type.Name)
                listBox1.SelectedIndex = listBox1.SelectedIndex + 1
            End If
            OnCommandAdded()
        End Sub

        Private Sub OnCommandAdded()
            Me.doCommand.Enabled = Not imageViewer1.Image Is Nothing AndAlso compositeCommand.Commands.Count > 0
        End Sub

        Private Sub removeCommand_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles removeCommand.Click
            If listBox1.SelectedIndex = -1 Then
                Return ' should never happen
            End If
            compositeCommand.Commands.RemoveAt(listBox1.SelectedIndex)
            listBox1.Items.RemoveAt(listBox1.SelectedIndex)
            OnCommandRemoved()
        End Sub

        Private Sub OnCommandRemoved()
            Me.doCommand.Enabled = Not imageViewer1.Image Is Nothing AndAlso compositeCommand.Commands.Count > 0
        End Sub

        Private Sub properties_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles properties.Click
            If listBox1.SelectedIndex = -1 Then
                Return ' should never happen
            End If
            Dim picker As EditCommand = New EditCommand(compositeCommand.Commands(listBox1.SelectedIndex))
            picker.ShowDialog()
        End Sub

        Private Sub doCommand_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles doCommand.Click
            Dim results As ImageResults = Nothing
            Try
                results = compositeCommand.Apply(imageViewer1.Image)
                Dim oldImage As AtalaImage = imageViewer1.Image
                imageViewer1.Image = results.Image
                oldImage.Dispose()
            Catch err As Exception
                MessageBox.Show("Unable to perform command: " & err.Message)
            Finally
                progressBar1.Value = 0
            End Try
        End Sub

        Private Sub Form1_Progress(ByVal sender As Object, ByVal e As ProgressEventArgs)
            Me.progressBar1.Value = (e.Current * 100) / e.Total
        End Sub

        Private Sub listBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles listBox1.DoubleClick
            properties_Click(Me, Nothing)
        End Sub

        Private Sub clearCommands_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles clearCommands.Click
            listBox1.Items.Clear()
            compositeCommand.Commands.Clear()
            OnCommandRemoved()
        End Sub

        Private Sub btnAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAbout.Click
            Dim aboutBox As AtalaDemos.AboutBox.About = New AtalaDemos.AboutBox.About("About Atalasoft DotImage Composite Command Demo", "DotImage Composite Command Demo")
            aboutBox.Description = "Shows how to take arbitrary ImageCommands and encapsulate and compose them into one new single ImageCommand.  Uses reflection to display all image commands in all referenced assemblies."
            aboutBox.ShowDialog()
        End Sub
    End Class
End Namespace
