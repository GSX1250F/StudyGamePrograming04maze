#include "AnimSpriteComponent.h"
#include "Math.h"
#include <iostream>

AnimSpriteComponent::AnimSpriteComponent(Actor* owner, int drawOrder)
	:SpriteComponent(owner, drawOrder)
	, mCurrFrame(0.0f)
	, mAnimFPS(5.0f)
	, mAnimNumBeg(0)
	, mAnimNumLast(0)
	, mLoopFlag(false)
{}

void AnimSpriteComponent::Update(float deltaTime)
{
	SpriteComponent::Update(deltaTime);

	if (mAnimTextures.size() > 0)
	{
		mCurrFrame += mAnimFPS * deltaTime;		// ���݂̃t���[�����X�V����

		// ���[�v�����Ȃ��A�j���[�V�������I�������~�߂�B
		if (mLoopFlag == false) {
			if (mCurrFrame >= mAnimNumLast + 1)
			{
				mIsAnimating = false;	// �A�j���[�V�������~�܂���
				mCurrFrame = mAnimNumLast;
			}
			else
			{
				mIsAnimating = true;		// �A�j���[�V������
			}
		}
		else {
			mIsAnimating = true;		// ���[�v�A�j���̓A�j���[�V�������Ƃ���B
			if (mCurrFrame >= mAnimNumLast + 1)
			{
				mCurrFrame = mAnimNumBeg;				// �K�v�ɉ����Č��݂̃t���[���������߂�
			}
		}
		SetTexture(mAnimTextures[static_cast<int>(mCurrFrame)]);		// �����_�ł̃e�N�X�`����ݒ肷��
	}
}

void AnimSpriteComponent::SetAnimTextures(const std::vector<SDL_Texture*>& textures)
{
	mAnimTextures = textures;
	if (mAnimTextures.size() > 0)
	{
		SetTexture(mAnimTextures[0]);		// �ŏ��̃t���[���̃e�N�X�`���ŏ����ݒ�
	}
}
void AnimSpriteComponent::SetAnimNum(int beg, int last, bool loop_flag)
{
	if (last == -1)last = mAnimTextures.size();		//last��-1�̏ꍇ���ׂĂ͈̔͂��A�j���[�V�����Ƃ���
	mCurrFrame = static_cast<float>(beg);
	mAnimNumBeg = beg;
	mAnimNumLast = last;
	mLoopFlag = loop_flag;
}