Imports System.Numerics

Public Class ClearPict
    Inherits Actor

    Sub New(ByRef game As Game)
        MyBase.New(game)
        SetState(State.EPaused)
        Dim pos = New Vector2(game.mWindowWidth * 0.5, game.mWindowHeight * 0.5)
        SetPosition(pos)

        'スプライトコンポーネント作成、テクスチャ設定
        sc = New SpriteComponent(Me, 100)
        sc.SetTexture(game.GetRenderer().GetTexture("Assets\ClearPict.png"))
        sc.SetVisible(False)
    End Sub

    Public Function GetSprite() As SpriteComponent
        Return sc
    End Function

    Private sc As SpriteComponent

End Class
