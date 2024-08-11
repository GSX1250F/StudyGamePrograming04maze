#pragma once
#include "SpriteComponent.h"
#include <vector>

class AnimSpriteComponent : public SpriteComponent
{
public:
	AnimSpriteComponent(class Actor* owner, int drawOrder = 100);
	void Update(float deltaTime) override;
	
	// �A�j���[�V�����Ɏg���e�N�X�`����ݒ肷��
	void SetAnimTextures(const std::vector<SDL_Texture*>& textures);
	// �A�j���[�V�����Ɏg���e�N�X�`���͈̔͂�ݒ肷��Blast��-1�Ȃ�S�͈͂Ƃ���B
	void SetAnimNum(int beg, int last, bool loop_flag);
	// �A�j���[�V�����̃t���[�����[�g��ݒ� / �擾
	float GetAnimFPS() const { return mAnimFPS; }
	void SetAnimFPS(float fps) { mAnimFPS = fps; }
	// ���ݕ\�����̃A�j���[�V�����̏��擾
	int GetAnimNumBeg() { return mAnimNumBeg; }
	int GetAnimNumLast() { return mAnimNumLast; }
	int GetAnimNumCurr() { return static_cast<int>(mCurrFrame); }

	
private:
	std::vector<SDL_Texture*> mAnimTextures;	// �A�j���[�V�����ł̂��ׂẴe�N�X�`��
	int mAnimNumBeg;	//�A�j���[�V�����̍ŏ��̔z��ԍ�
	int mAnimNumLast;	//�A�j���[�V�����̍Ō�̔z��ԍ�
	float mCurrFrame;	//���݂̃t���[��
	float mAnimFPS;		// �A�j���[�V�����̃t���[�����[�g
	bool mLoopFlag;		// �A�j���[�V���������[�v�����邩���Ȃ���
	bool mIsAnimating;	// �A�j���[�V���������ǂ���
};

