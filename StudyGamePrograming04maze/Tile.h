#pragma once
#include "Actor.h"
#include <vector>
class Tile : public Actor
{
public:
	enum TileState
	{
		EDefault,
		EWall,
		EStart,
		EGoal
	};

	Tile(class Game* game);
	void UpdateActor(float deltaTime) override;

	void UpdateTexture();

	class SomeSpriteComponent* GetSprite() { return ssc; }
	class CircleComponent* GetCircle() { return cc; }
	TileState GetTileState() { return mTileState; }
	float GetTexSize() { return mTexSize; }
	void SetTileState(TileState);
	
	std::vector<class Tile*> mAdjacent;	//隣接ノード配列
	Tile* mParent;	//親ノード


private:
	class SomeSpriteComponent* ssc;
	class CircleComponent* cc;

	TileState mTileState;
	float mTexSize;
};