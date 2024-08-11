#pragma once
#include <vector>

// width行height列の配列を返す。
// path = 0, wall = 1, start = 2,goal = 3
std::vector<std::vector<int>> MazeCreate(int& width, int& height);