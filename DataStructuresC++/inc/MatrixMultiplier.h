#pragma once
#include <Headers.h>

class MatrixMultiplier {
public:
    static std::vector<std::vector<int>> multiply(
        const std::vector<std::vector<int>>& A,
        const std::vector<std::vector<int>>& B
    );

private:
    static void computeElement(
        const std::vector<std::vector<int>>& A,
        const std::vector<std::vector<int>>& B,
        std::vector<std::vector<int>>& C,
        int row, int col
    );
};