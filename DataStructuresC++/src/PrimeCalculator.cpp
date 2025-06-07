#include <Headers.h>
#include <PrimeCalculator.h>

bool IsPrime(long long number) {
	if (number <= 1) return false;
	if (number <= 3) return true;
	if (number % 2 == 0 || number % 3 == 0) return false;
	for (long long i = 5; i * i <= number; i += 6) {
		if (number % i == 0 || number % (i + 2) == 0) return false;
	}
	return true;
}

void calculatePrimesThread(long long start, long long end, long long& count, std::mutex& mtx) {
	long long localCount = 0;
	for (long long i = start; i <= end; ++i) {
		if (IsPrime(i)) ++localCount; 
	}
	std::lock_guard <std::mutex> lock(mtx);
	count += localCount;
}

void runPrimeThreaded(long long limit, int numThreads) {
	long long totalPrimes = 0;
	std::mutex mtx;
	std::vector<std::thread> threads;
	long long chunk = limit / numThreads;
	
	auto startTime = std::chrono::high_resolution_clock::now();

	for (int i = 0; i < numThreads; ++i) {
		long long start = i * chunk + (i == 0 ? 2 : 1);
		long long end = (i == numThreads - 1) ? limit : (i + 1) * chunk;
		threads.emplace_back(calculatePrimesThread, start, end, std::ref(totalPrimes), std::ref(mtx));
	}

	for (auto& t : threads) t.join();

	auto endTime = std::chrono::high_resolution_clock::now();
	std::chrono::duration<double> elapsed = endTime - startTime;

	std::cout << "C++ Total Primes: " << totalPrimes << "\n";
	std::cout << "C++ time Taken: " << elapsed.count() << "seconds\n";
}
