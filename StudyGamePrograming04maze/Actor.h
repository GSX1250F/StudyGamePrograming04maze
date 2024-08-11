#pragma once
#include <vector>
#include "Math.h"
#include <SDL.h>

class Actor
{
public:
	enum State
	{
		EActive,		//�ғ���
		EPaused,		//�X�V��~��
		EDead			//�폜�Ώ�
	};

	Actor(class Game* game);
	virtual ~Actor();

	void ProcessInput(const SDL_Event& event);
	virtual void ActorInput(const SDL_Event& event);

	void Update(float deltaTime);
	void UpdateComponents(float deltaTime);
	virtual void UpdateActor(float deltaTime);

	const Vector2& GetPosition() const { return mPosition; }
	void SetPosition(const Vector2& pos) { mPosition = pos; }
	float GetScale() const { return mScale; }
	void SetScale(float scale) { mScale = scale; }
	const float& GetRotation() const { return mRotation; }
	void SetRotation(const float& rotation) { mRotation = rotation; }
	float GetRadius() const { return mRadius * mScale; }
	void SetRadius(float radius) { mRadius = radius; }
	Vector2 GetForward() const { return Vector2(Math::Cos(mRotation), -Math::Sin(mRotation)); }
	State GetState() const { return mState; }
	void SetState(State state) { mState = state; }
	class Game* GetGame() { return mGame; }
	void AddComponent(class Component* component);
	void RemoveComponent(class Component* component);


private:
	State mState;			//�A�N�^�[���
	Vector2 mPosition;		//��ʏ�̈ʒu
	float mScale;			//�g�嗦
	float mRotation;		//��]
	float mRadius;			//���a�i�g�嗦�͖����j
	std::vector<class Component*> mComponents;
	class Game* mGame;
};
