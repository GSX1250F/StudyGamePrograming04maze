Imports System.Numerics
Public Class Shadow
	Inherits Actor
	Sub New(ByRef game As Game)
		MyBase.New(game)
		speed = 75.0
		SetScale(0.85F)
		'アニメーションのスプライトコンポーネントを作成
		asc = New AnimSpriteComponent(Me, 40)
		Dim anims As New List(Of Image) From {
			game.GetRenderer().GetTexture("Assets/Shadow01.png"),
			game.GetRenderer().GetTexture("Assets/Shadow02.png"),
			game.GetRenderer().GetTexture("Assets/Shadow03.png"),
			game.GetRenderer().GetTexture("Assets/Shadow04.png"),
			game.GetRenderer().GetTexture("Assets/Shadow05.png"),
			game.GetRenderer().GetTexture("Assets/Shadow06.png"),
			game.GetRenderer().GetTexture("Assets/Shadow07.png"),
			game.GetRenderer().GetTexture("Assets/Shadow08.png"),
			game.GetRenderer().GetTexture("Assets/Shadow09.png"),
			game.GetRenderer().GetTexture("Assets/Shadow10.png"),
			game.GetRenderer().GetTexture("Assets/Shadow11.png"),
			game.GetRenderer().GetTexture("Assets/Shadow12.png"),
			game.GetRenderer().GetTexture("Assets/Shadow13.png"),
			game.GetRenderer().GetTexture("Assets/Shadow14.png"),
			game.GetRenderer().GetTexture("Assets/Shadow15.png"),
			game.GetRenderer().GetTexture("Assets/Shadow16.png")
		}
		asc.SetAnimTextures(anims)
		asc.SetAnimNum(0, 3, True)

		'CircleComponent作成
		cc = New CircleComponent(Me, 100)

		'NavComponent作成
		nc = New NavComponent(Me, 10)
		nc.SetSpeed(speed)
	End Sub



	Public Overrides Sub ActorInput(ByVal keyState As Boolean())
		If (GetGame().GetMaze().GetGameStart()) Then
			If (GetGame().GetRKeyUpEvent()) Then
				speed += 10
				If (speed > 145) Then speed = 145
				nc.SetSpeed(speed)
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
		'スプライトアニメーション
		Dim bg As Integer = asc.GetAnimNumBeg()
		Dim ed As Integer = asc.GetAnimNumLast()
		Dim angle As Double = nc.GetNextDirAngle()
		If (angle >= Math.PI * (-0.75) And angle < Math.PI * (-0.25)) Then
			If (bg <> 0 Or ed <> 3) Then asc.SetAnimNum(0, 3, True)
		ElseIf (angle >= Math.PI * (-0.25) And angle < Math.PI * 0.25) Then
			If (bg <> 8 Or ed <> 11) Then asc.SetAnimNum(8, 11, True)
		ElseIf (angle >= Math.PI * 0.25 And angle < Math.PI * 0.75) Then
			If (bg <> 4 Or ed <> 7) Then asc.SetAnimNum(4, 7, True)
		ElseIf ((angle >= Math.PI * (-1.0) And angle < Math.PI * (-0.75)) Or
				(angle >= Math.PI * 0.75 And angle <= Math.PI)) Then
			If (bg <> 12 Or ed <> 15) Then asc.SetAnimNum(12, 15, True)
		End If
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
	Public Function GetNav() As NavComponent
		Return nc
	End Function

	Private asc As AnimSpriteComponent
	Private cc As CircleComponent
	Private nc As NavComponent
	Private speed As Double
End Class
