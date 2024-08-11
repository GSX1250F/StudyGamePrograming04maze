#include "MoveComponent.h"
#include "Actor.h"

MoveComponent::MoveComponent(Actor* owner, int updateOrder)
	: Component(owner)
	, mVelocity(Vector2::Zero)		// ���i�ړ����x
	, mRotSpeed(0.0f)				// ��]���x
{}

void MoveComponent::Update(float deltatime)
{
	// �ʒu�ƌ������X�V
	mOwner->SetPosition(mOwner->GetPosition() + mVelocity * deltatime);		//x = xo + vt
	mOwner->SetRotation(mOwner->GetRotation() + mRotSpeed * deltatime);		//�� = ��o + ��t
}