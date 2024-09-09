#include "Tile.h"
#include "SomeSpriteComponent.h"
#include "Game.h"
#include "Renderer.h"
#include "CircleComponent.h"
#include "SquareComponent.h"

Tile::Tile(class Game* game)
	:Actor(game)
	, mTileState(EDefault)
	, mParent(nullptr)
{
	//�X�v���C�g�R���|�[�l���g���쐬
	ssc = new SomeSpriteComponent(this, 10);
	ssc->TextureFiles = {
		"Assets/Default.png",
		"Assets/Wall.png"
	};
	ssc->SetSomeTextures(ssc->TextureFiles);
	mTexSize = ssc->GetTexWidth();
	
	//CircleComponent�쐬
	cc = new CircleComponent(this);	

	//SquareComponent�쐬
	//sq = new SquareComponent(this);
}

void Tile::UpdateActor(float deltaTime)
{
	UpdateTexture();
}

void Tile::SetTileState(TileState state)
{
	mTileState = state;
	UpdateTexture();
}

void Tile::UpdateTexture()
{
	switch (mTileState)
	{
		case EWall:
			ssc->SelectTexture(ssc->TextureFiles[1]);
			break;
		default:
			ssc->SelectTexture(ssc->TextureFiles[0]);
	}
}