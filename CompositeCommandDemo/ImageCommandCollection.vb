' This source code is property of Atalsoft, Inc. (www.atalasoft.com)
' Permission for usage and modification of this code is only permitted 
' with the purchase of a DotImage source code license.

' Change History:


Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports Atalasoft.Imaging.ImageProcessing

Namespace CompositeCommandDemo
	' simple implementation of an collection of image commands
	<Serializable> _
	Public Class ImageCommandCollection
		Inherits CollectionBase
		Public Sub New()
		End Sub

		Default Public Property Item(ByVal index As Integer) As ImageCommand
			Get
				Return CType(List(index), ImageCommand)
			End Get
			Set
				List(index) = Value
			End Set
		End Property
		Public Function Add(ByVal value As ImageCommand) As Integer
			Return(List.Add(value))
		End Function

		Public Function IndexOf(ByVal value As ImageCommand) As Integer
			Return(List.IndexOf(value))
		End Function

		Public Sub Insert(ByVal index As Integer, ByVal value As ImageCommand)
			List.Insert(index, value)
		End Sub

		Public Sub Remove(ByVal value As ImageCommand)
			List.Remove(value)
		End Sub

		Public Function Contains(ByVal value As ImageCommand) As Boolean
			' If value is not of type Int16, this will return false.
			Return(List.Contains(value))
		End Function
		Public Sub CopyTo(ByVal array As ImageCommand(), ByVal index As Integer)
			CType(Me, ICollection).CopyTo(array, index)
		End Sub
	End Class
End Namespace
