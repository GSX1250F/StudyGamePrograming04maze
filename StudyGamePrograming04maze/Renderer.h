#pragma once
#include <string>
#include <vector>
#include <unordered_map>
#include <SDL.h>
#include "Math.h"

class Renderer
{
public:
	Renderer(class Game* game);
	~Renderer();

	bool Initialize(float screenWidth, float screenHeight);
	void UnloadData();
	void Shutdown();

	void Draw();

	void AddSprite(class SpriteComponent* sprite);
	void RemoveSprite(class SpriteComponent* sprite);

	SDL_Texture* GetTexture(const std::string& fileName);

	float GetScreenWidth() const { return mScreenWidth; }
	float GetScreenHeight() const { return mScreenHeight; }
private:
	// テクスチャのマップ
	std::unordered_map<std::string, SDL_Texture*> mTextures;

	// スプライトコンポーネントの配列
	std::vector<class SpriteComponent*> mSprites;

	// Game
	class Game* mGame;

	// Width/height of screen
	float mScreenWidth;
	float mScreenHeight;

	// SDL_Window
	SDL_Window* mWindow;
	// SDL Renderer
	SDL_Renderer* mRenderer;
};