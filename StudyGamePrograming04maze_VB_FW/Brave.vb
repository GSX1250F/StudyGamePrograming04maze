Imports System.Numerics
Public Class Brave
	Inherits Actor
	Sub New(ByRef game As Game)
		MyBase.New(game)
		speed = 150.0
		SetScale(0.85F)
		'アニメーションのスプライトコンポーネントを作成
		asc = New AnimSpriteComponent(Me, 45)
		Dim anims As New List(Of Image) From {
			game.GetRenderer().GetTexture("/Assets/Brave01.png"),
			game.GetRenderer().GetTexture("/Assets/Brave02.png"),
			game.GetRenderer().GetTexture("/Assets/Brave03.png"),
			game.GetRenderer().GetTexture("/Assets/Brave04.png"),
			game.GetRenderer().GetTexture("/Assets/Brave05.png"),
			game.GetRenderer().GetTexture("/Assets/Brave06.png"),
			game.GetRenderer().GetTexture("/Assets/Brave07.png"),
			game.GetRenderer().GetTexture("/Assets/Brave08.png"),
			game.GetRenderer().GetTexture("/Assets/Brave09.png"),
			game.GetRenderer().GetTexture("/Assets/Brave10.png"),
			game.GetRenderer().GetTexture("/Assets/Brave11.png"),
			game.GetRenderer().GetTexture("/Assets/Brave12.png"),
			game.GetRenderer().GetTexture("/Assets/Brave13.png"),
			game.GetRenderer().GetTexture("/Assets/Brave14.png"),
			game.GetRenderer().GetTexture("/Assets/Brave15.png"),
			game.GetRenderer().GetTexture("/Assets/Brave16.png")
		}
		asc.SetAnimTextures(anims)
		asc.SetAnimNum(0, 3, True)

		'CircleComponent作成
		cc = New CircleComponent(Me, 100)

		'MoveComponent作成
		mc = New MoveComponent(Me, 10)
	End Sub
	Public Overrides Sub ActorInput(ByVal keyState As Boolean())
		If (GetGame().GetMaze().GetGameStart()) Then
			'入力に応じて、アニメーションの設定と移動
			Dim bg As Integer = asc.GetAnimNumBeg()
			Dim ed As Integer = asc.GetAnimNumLast()

			If (keyState(Keys.Down) = True) Then
				If (bg <> 0 Or ed <> 3) Then asc.SetAnimNum(0, 3, True)
				Dim v = New Vector2(0.0, 1.0)
				mc.SetVelocity(speed * v)
			ElseIf (keyState(Keys.Up) = True) Then
				If (bg <> 4 Or ed <> 7) Then asc.SetAnimNum(4, 7, True)
				Dim v = New Vector2(0.0, -1.0)
				mc.SetVelocity(speed * v)
			ElseIf (keyState(Keys.Right) = True) Then
				If (bg <> 8 Or ed <> 11) Then asc.SetAnimNum(8, 11, True)
				Dim v = New Vector2(1.0, 0.0)
				mc.SetVelocity(speed * v)
			ElseIf (keyState(Keys.Left) = True) Then
				If (bg <> 12 Or ed <> 15) Then asc.SetAnimNum(12, 15, True)
				Dim v = New Vector2(-1.0, 0.0)
				mc.SetVelocity(speed * v)
			Else
				' 何も操作していないとき
				mc.SetVelocity(Vector2.Zero)
			End If
		End If
	End Sub
	Public Overrides Sub UpdateActor(ByVal deltaTime As Double)
		If (GetGame().GetMaze().GetGameStart()) Then
			If (Intersect(cc, GetGame().GetMaze().GetTreasure().GetCircle())) Then
				' ゴール
				GetGame().GetMaze().SetGameClear(True)
			End If
		End If

		For Each tilecol In GetGame().GetMaze().GetTiles()
			For Each tile In tilecol
				If (tile.GetTileState() = Tile.TileState.EWall) Then
					'壁に衝突していたら離す。
					If (Intersect(cc, tile.GetCircle())) Then
						'２つの中心を結ぶ線分上で、２つの半径だけ離す
						Dim diff As Vector2 = Vector2.Normalize(Me.GetPosition() - tile.GetPosition())
						Me.SetPosition(tile.GetPosition() + diff * (Me.GetRadius() + tile.GetRadius()))
					End If
				End If
			Next
		Next
	End Sub

	Public Function GetSprite() As AnimSpriteComponent
		Return asc
	End Function
	Public Function GetCircle() As CircleComponent
		Return cc
	End Function
	Public Function GetSpeed() As Double
		Return speed
	End Function

	Private asc As AnimSpriteComponent
	Private cc As CircleComponent
	Private mc As MoveComponent
	Private speed As Double
End Class
