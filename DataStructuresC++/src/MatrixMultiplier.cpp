#include "MatrixMultiplier.h"

void MatrixMultiplier::computeElement(
	const std::vector<std::vector<int>>& A,
	const std::vector<std::vector<int>>& B,
	std::vector<std::vector<int>>& C,
	int row, int col
	) {
	int sum = 0;
	for (size_t k = 0; k < B.size(); ++k) {
		sum += A[row][k] * B[k][col];
	}
	C[row][col] = sum;
}

std::vector<std::vector<int>> MatrixMultiplier::multiply(
	const std::vector<std::vector<int>>& A,
	const std::vector<std::vector<int>>& B

	) {
	int N = A.size(), M = B.size(), P = B[0].size();
	std::vector<std::vector<int>> C(N, std::vector<int>(P, 0));
	std::vector<std::thread> threads;

	for (int i = 0; i < N; ++i) {
		for (int j = 0; j < P; ++j) {
			threads.emplace_back(computeElement, std::cref(A), std::cref(B), std::ref(C), i, j);
		}
	}
	for (auto& t : threads) t.join();
	return C;
}
