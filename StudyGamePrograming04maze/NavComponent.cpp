#include "NavComponent.h"
#include "Tile.h"

NavComponent::NavComponent(class Actor* owner, int updateOrder)
	: MoveComponent(owner, updateOrder)
	, mNextNode(nullptr)
{}

void NavComponent::Update(float deltaTime)
{
	if (mNextNode)
	{
		Vector2 diff = mNextNode->GetPosition() - mOwner->GetPosition();
		mNextDirVector = diff;
		mNextDirVector.Normalize();
		mNextDirAngle = Math::Atan2(-mNextDirVector.y, mNextDirVector.x);
		SetVelocity(speed * mNextDirVector);

		if (Math::NearZero(diff.Length(), 2.0f))
		{
			mNextNode = mNextNode->mParent;
		}
	}

	MoveComponent::Update(deltaTime);
}

void NavComponent::SetStartNode(class Tile* start)
{
	if (start) {
		mNextNode = start->mParent;
	}
}

