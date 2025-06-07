#pragma once
bool IsPrime(long long number);
void calculatePrimesThread(long long start, long long end, long long& count, std::mutex& mtx);
void runPrimeThreaded(long long limit, int numThreads);