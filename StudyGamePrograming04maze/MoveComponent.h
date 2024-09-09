#pragma once
#include "Component.h"
#include "Math.h"

class MoveComponent : public Component
{
public:
	MoveComponent(class Actor* owner, int updateOrder = 10);
	void Update(float deltaTime) override;
	// ���i�ړ����x
	void SetVelocity(Vector2 vel) { mVelocity = vel; }
	Vector2 GetVelocity() { return mVelocity; }
	// ��]���x
	void SetRotSpeed(float rotspeed) { mRotSpeed = rotspeed; }
	float GetRotSpeed() { return mRotSpeed; }


private:
	Vector2 mVelocity;		// ���i�ړ����x
	float mRotSpeed;		// ��]���x
};