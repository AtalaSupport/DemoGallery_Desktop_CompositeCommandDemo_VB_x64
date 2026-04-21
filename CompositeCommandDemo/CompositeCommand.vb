' This source code is property of Atalasoft, Inc. (www.atalasoft.com)
' Permission for usage and modification of this code is only permitted 
' with the purchase of a DotImage source code license.

' Change History:


Imports Microsoft.VisualBasic
Imports System
Imports Atalasoft.Imaging
Imports Atalasoft.Imaging.ImageProcessing
Imports System.Runtime.Serialization
Imports System.Security.Permissions

Namespace CompositeCommandDemo

	' this command implements a composite command that is capable of encapsulating
	' any number of ImageCommands.

	<Serializable> _
	Public Class CompositeCommand
		Inherits ImageCommand
		Implements ISerializable
		Private _commands As ImageCommandCollection = New ImageCommandCollection()

		#Region "ISerializable Members"

		<SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.SerializationFormatter)> _
		Public Overridable Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements ISerializable.GetObjectData
			If info Is Nothing Then
				Throw New ArgumentNullException("info", "The parameter 'info' can't be null.")
			End If
			ImageCommandGetObjectData(info, context)
			info.AddValue("Commands", _commands)
		End Sub

		Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
			If info Is Nothing Then
				Throw New ArgumentNullException("info", "The parameter 'info' can't be null.")
			End If
			Dim val As Object = Nothing
			val = info.GetValue("Commands", GetType(ImageCommandCollection)) ' may throw
			_commands = CType(val, ImageCommandCollection)
		End Sub

		#End Region

		Public Sub New()
		End Sub

		' nothing to do - this gets done by the commands
		Protected Overrides Sub VerifyProperties(ByVal image As Atalasoft.Imaging.AtalaImage)
		End Sub

		Private Shared _allFormats As PixelFormat() = New PixelFormat() { PixelFormat.Pixel16bppGrayscale, PixelFormat.Pixel16bppGrayscaleAlpha, PixelFormat.Pixel1bppIndexed, PixelFormat.Pixel24bppBgr, PixelFormat.Pixel32bppBgr, PixelFormat.Pixel32bppBgra, PixelFormat.Pixel32bppCmyk, PixelFormat.Pixel48bppBgr, PixelFormat.Pixel4bppIndexed, PixelFormat.Pixel64bppBgra, PixelFormat.Pixel8bppGrayscale, PixelFormat.Pixel8bppIndexed }

		' the SupportedPixelFormats are either everything if there are no commands
		' or the SupportedPixelFormats of the first command 
		Public Overrides ReadOnly Property SupportedPixelFormats() As Atalasoft.Imaging.PixelFormat()
			Get
				If _commands.Count = 0 Then
					Return _allFormats
				End If
				Return _commands(0).SupportedPixelFormats
			End Get
		End Property

		' don't let the base class allocate the final image
		' it will be done when the command is performed

		Protected Overrides Function ConstructFinalImage(ByVal image As AtalaImage) As AtalaImage
			Return Nothing
		End Function

		Protected Overrides Function PerformActualCommand(ByVal source As AtalaImage, ByVal dest As AtalaImage, ByVal imageArea As System.Drawing.Rectangle, ByRef results As ImageResults) As AtalaImage
			' always work on a copy of the source image

			dest = CType(source.Clone(), AtalaImage)
			Dim count As Integer = _commands.Count

			For i As Integer = 0 To count - 1
				Dim command As ImageCommand = _commands(i)

				' apply the command to the image (dest is actually the source here)
				Dim localresults As ImageResults = command.Apply(dest)

				' determine if we need to dispose dest
				If (Not localresults.IsImageSourceImage) Then
					dest.Dispose()
					dest = localresults.Image
				End If
				' handle progress
				If Not Progress Is Nothing Then
                    Progress.Invoke(Me, New ProgressEventArgs(i + 1, count, command.GetType().Name))
				End If
			Next i
			' return the final image
			Return dest
		End Function


		Public ReadOnly Property Commands() As ImageCommandCollection
			Get
				Return _commands
			End Get
		End Property
	End Class
End Namespace
