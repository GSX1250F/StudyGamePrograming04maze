Imports System.Numerics

Public Class MoveComponent
    Inherits Component
    Sub New(ByRef owner As Actor, ByVal updateOrder As Integer)
        MyBase.New(owner, updateOrder)
        mVelocity = Vector2.Zero
        mRotSpeed = 0.0
    End Sub

    Public Overrides Sub Update(deltaTime As Double)
        mOwner.SetPosition(mOwner.GetPosition() + mVelocity * deltaTime)    ' Actorの位置を更新
        mOwner.SetRotation(mOwner.GetRotation() + mRotSpeed * deltaTime)    ' Actorの方向を更新
    End Sub

    Public Sub SetVelocity(ByVal v)
        mVelocity = v
    End Sub
    Public Sub SetRotSpeed(ByVal v As Double)
        mRotSpeed = v
    End Sub

    Private mVelocity As Vector2     '並進移動速度
    Private mRotSpeed As Double      '回転速度
End Class