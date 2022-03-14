Public Class Shape

    Public Centre As Vector
    Public StartingState() As Vector
    Public anglex, angley, anglez As Single

    Public Type As String

    'speeds here

    Public Sub New(TypeOfShape As String,
                   ObjectCentre As Vector,
                   ArrayOfVerticies() As Vector)

        Me.Type = TypeOfShape
        Me.Centre = ObjectCentre
        Me.StartingState = ArrayOfVerticies
    End Sub

    Public Function CurrentState() As Vector()
        Dim State() As Vector
        Dim i As Integer = 0
        For Each V In Me.StartingState
            ReDim Preserve State(i)
            State(i) = Rotate(V)
            i += 1
        Next
        Return State
    End Function

    Public Function Rotate(Vin As Vector) As Vector
        Vin = Mat.mul(MatrixType("x"), Vin)
        Vin = Mat.mul(MatrixType("y"), Vin)
        Vin = Mat.mul(MatrixType("z"), Vin)
        Return Vin
    End Function


    Public Function MatrixType(type As Char) As Single(,)
        type = UCase(type)
        If type = "Z" Then
            Return {
        {Math.Cos(Me.anglez), -Math.Sin(Me.anglez), 0},
        {Math.Sin(Me.anglez), Math.Cos(Me.anglez), 0},
        {0, 0, 1}
        }
        ElseIf type = "X" Then
            Return {
                {1, 0, 0},
        {0, Math.Cos(Me.anglex), -Math.Sin(Me.anglex)},
        {0, Math.Sin(Me.anglex), Math.Cos(Me.anglex)}
        }
        ElseIf type = "Y" Then
            Return {
        {Math.Cos(Me.angley), 0, -Math.Sin(Me.angley)},
        {0, 1, 0},
        {Math.Sin(Me.angley), 0, Math.Cos(Me.angley)}
        }
        Else
            Return {
        {1, 1, 1},
        {1, 1, 1},
        {1, 1, 1}
        }
        End If
    End Function

    Public Class Mat 'rix

        'FIX THIS
        Public Shared Function mul(matrix(,) As Single, Vector As Vector) As Vector

            If matrix.GetLength(0) = 2 Then


                Vector = New Vector(matrix(0, 0) * Vector.x +
                                     matrix(0, 1) * Vector.y +
                                     matrix(0, 2) * Vector.z,
                                     matrix(1, 0) * Vector.x +
                                     matrix(1, 1) * Vector.y +
                                     matrix(1, 2) * Vector.z,
                                     Vector.z)

            ElseIf matrix.GetLength(0) = 3 Then

                Vector = New Vector(matrix(0, 0) * Vector.x +
                                     matrix(0, 1) * Vector.y +
                                     matrix(0, 2) * Vector.z,
                                     matrix(1, 0) * Vector.x +
                                     matrix(1, 1) * Vector.y +
                                     matrix(1, 2) * Vector.z,
                                     matrix(2, 0) * Vector.x +
                                     matrix(2, 1) * Vector.y +
                                     matrix(2, 2) * Vector.z)
            End If

            Return Vector
        End Function
    End Class

End Class
