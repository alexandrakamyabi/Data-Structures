#include <Headers.h>
#include "PrimeCalculator.h"
#include "MatrixMultiplier.h"
using namespace std;

typedef long long ll;
typedef unsigned long long ull;
typedef pair<int, int> ii;


// ---------------------------- TEMPLATES ----------------------------
template <typename T>
T myMin(T a, T b) {
    return (a < b) ? a : b;
}


template <typename T>
T myMax(T a, T b) {
    return (a > b) ? a : b;
}


template <typename T>
class Calculator {
public:
    T value;
    Calculator(T val) : value(val) {}
    T operator+(const Calculator& other) { return value + other.value; }
    T operator*(const Calculator& other) { return value * other.value; }
};


// ---------------------------- FUNCTIONS ----------------------------


bool hasZeroSumSubarray(int nums[], int n) {
    unordered_set<int> set;
    set.insert(0);
    int sum = 0;
    for (int i = 0; i < n; i++) {
        sum += nums[i];
        if (set.find(sum) != set.end()) return true;
        set.insert(sum);
    }
    return false;
}


string angryProfessor(int k, const vector<int>& a) {
    int onTimeCount = 0;
    for (int arrival : a) {
        if (arrival <= 0) onTimeCount++;
        if (onTimeCount >= k) return "No";

    }
    return "Yes";
}


void testAngryProfessor() {
    cout << angryProfessor(3, {-1, -3, 4, 2}) << endl;
    cout << angryProfessor(2, { 0, -1, 2, 1 }) << endl;
}


int formingMagicSquare(vector<vector<int>> s) {
    vector<vector<vector<int>>> magicSquares = {
        {{8,1,6},{3,5,7},{4,9,2}},
        {{6,1,8},{7,5,3},{2,9,4}},
        {{4,9,2},{3,5,7},{8,1,6}},
        {{2,9,4},{7,5,3},{6,1,8}},
        {{8,3,4},{1,5,9},{6,7,2}},
        {{4,3,8},{9,5,1},{2,7,6}},
        {{6,7,2},{1,5,9},{8,3,4}},
        {{2,7,6},{9,5,1},{4,3,8}}
    };

    int minCost = INT_MAX;

    for (const auto& magic : magicSquares) {
        int cost = 0;
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                cost += abs(s[i][j] - magic[i][j]);
        minCost = min(minCost, cost);
    }

    return minCost;
}


void testFormingMagicSquare() {
    vector<vector<int>> s = {
        {5, 3, 4},
        {1, 5, 8},
        {6, 4, 2}
    };

    int cost = formingMagicSquare(s);
    cout << "minimum cost to form magic square: " << cost << endl;
}


string caesarCipher(string s, int k) {
    k = k % 26;
    string result = "";
    for (char c : s) {
        if (isalpha(c)) {
            if (islower(c)) result += (c - 'a' + k) % 26 + 'a';
            else result += (c - 'A' + k) % 26 + 'A';
        }
        else result += c;
    }
    return result;
}


string catAndMouse(int x, int y, int z) {
    int distA = abs(x - z), distB = abs(y - z);
    if (distA < distB) return "Cat A";
    else if (distB < distA) return "Cat B";
    else return "Mouse C";
}


int howManyGames(int p, int d, int m, int s) {
    int gamesBought = 0;
    int currentPrice = p;

    while (s >= currentPrice) {
        s -= currentPrice;
        gamesBought++;
        currentPrice = max(currentPrice - d, m);
    }

    return gamesBought;
}


void update(int* a, int* b) {
    int tempA = *a, tempB = *b;
    *a = tempA + tempB;
    *b = abs(tempA - tempB);
}


int towerBreakers(int n, int m) {
    return (m == 1 || m % 2 == 0) ? 2 : 1;
}


int beautifulTriplets(int d, vector<int> arr) {
    unordered_set<int> elements(arr.begin(), arr.end());
    int count = 0;

    for (int num : arr) {
        if (elements.count(num + d) && elements.count(num + 2 * d))
            count++;
    }
    return count;
}


void testBeautifulTriplets() {
    vector<int> arr = { 1, 2, 4, 5, 7, 8, 10 };
    int d = 3;

    cout << "there are: " << beautifulTriplets(d, arr) << "Beautiful Triplets" << endl;
}


void testMatrixMultiplier() {
    std::vector<std::vector<int>> A = {
          {1, 2, 3},
          {4, 5, 6}
    };

    std::vector<std::vector<int>> B = {
        {7, 8},
        {9, 10},
        {11, 12}
    };

    std::vector<std::vector<int>> result = MatrixMultiplier::multiply(A, B);

    std::cout << "Resulting Matrix C:\n";
    for (const auto& row : result) {
        for (int value : row) {
            std::cout << value << " ";
        }
        std::cout << "\n";
    }
}


void testPrimeCalculator() {
    long long limit;
    int threads;
    std::cout << "Enter upper limit: ";
    std::cin >> limit;
    std::cout << "Enter number of threads: ";
    std::cin >> threads;
    runPrimeThreaded(limit, threads);
}


vector<double> SlidingWindowMedian(const vector<int>& num, int windowSize) {
    vector<double> medians;
    if (num.empty() || windowSize <= 0 || windowSize > num.size()) return medians;
    for (int i = 0; i <= num.size() - windowSize; ++i) {
        vector<int> window(num.begin() + i, num.begin() + i + windowSize);
        sort(window.begin(), window.end());
        int mid = windowSize / 2;
        if (windowSize % 2 == 0)
            medians.push_back((window[mid - 1] + window[mid]) / 2.0);
        else
            medians.push_back(window[mid]);
    }
    return medians;
}


string encryption(string s) {
    // remove all spaces from input
    s.erase(remove(s.begin(), s.end(), ' '), s.end());
    int len = s.length();

    // compute grid dimensions
    int rows = floor(sqrt(len));
    int cols = ceil(sqrt(len));
    if (rows * cols < len) rows++; // ensure grid can hold all chars

    string result;
    for (int c = 0; c < cols; ++c) {
        for (int r = 0; r < rows; ++r) {
            int idx = r * cols + c;
            if (idx < len)
                result += s[idx];
        }
        result += ' ';
    }

    result.pop_back(); // remove trailing space
    return result;
}


void testEncryption() {
    vector<pair<string, string>> tests = {
        {"haveaniceday", "hae and via ecy"},
        {"feedthedog", "fto ehg ee dd"},
        {"chillout", "clu hlt io"},
        {"iffactsdontfittotheorychangethefacts", "isieae fdtonf fotrga anoyec cttctt tfhhhs"}
    };

    for (const auto& [input, expected] : tests) {
        string output = encryption(input);
        cout << "input: \"" << input << "\"\nexpected: \"" << expected << "\"\noutput:   \"" << output << "\"\n\n";
        assert(output == expected);
    }

    cout << "all tests passed!\n";
}


// ---------------------------- CLASS STRUCTURES ----------------------------


struct TreeNode {
    char Value;
    TreeNode* Left;
    TreeNode* Right;
    TreeNode(char value) : Value(value), Left(nullptr), Right(nullptr) {}
};


class Solution {
public:
    static TreeNode* FindLCA(TreeNode* root, TreeNode* p, TreeNode* q) {
        if (!root || root == p || root == q) return root;
        TreeNode* left = FindLCA(root->Left, p, q);
        TreeNode* right = FindLCA(root->Right, p, q);
        if (left && right) return root;
        return left ? left : right;
    }
};


class Student {
public:
    string Name;
    int StudentId;
    Student(string name = "", int id = 0) : Name(name), StudentId(id) {}
    bool operator==(const Student& other) const {
        return Name == other.Name && StudentId == other.StudentId;
    }
    void Print() const { cout << Name << " (" << StudentId << ")"; }
};


class NonDivisibleSubsetSolver {
private:
    int k;
    vector<int> elements;

public:
    NonDivisibleSubsetSolver(int divisor, const vector<int>& s)
        : k(divisor), elements(s) {
    }

    int getMaxSubsetSize() {
        vector<int> remainderCount(k, 0);

        for (int num : elements) {
            remainderCount[num % k]++;
        }

        int result = min(remainderCount[0], 1);

        for (int r = 1; r <= k / 2; r++) {
            if (r == k - r) {
                // For k even
                result += 1;
            }
            else {
                result += max(remainderCount[r], remainderCount[k - r]);
            }
        }

        return result;
    }
};


class BallOrganizer {
public:
    static string checkPossibility(const vector<vector<int>>& containers) {
        int n = containers.size();
        vector<long long> containerCap(n, 0);
        vector<long long> typeCount(n, 0);

        for (int i = 0; i < n; ++i)
            for (int j = 0; j < n; ++j) {
                containerCap[i] += containers[i][j];
                typeCount[j] += containers[i][j];
            }
        sort(containerCap.begin(), containerCap.end());
        sort(typeCount.begin(), typeCount.end());

        return containerCap == typeCount ? "possible" : "impossible";
    
    }
};


void testBallOrganizer() {
    int q;
    cin >> q;

    while (q--) {
        int n;
        cin >> n;
        vector<vector<int>> containers(n, vector<int>(n));

        for (int i = 0; i < n; ++i)
            for (int j = 0; j < n; ++j)
                cin >> containers[i][j];
        cout << BallOrganizer::checkPossibility(containers) << '\n';
    }
}


int nonDivisibleSubset(int k, vector<int> s) {
    NonDivisibleSubsetSolver solver(k, s);
    return solver.getMaxSubsetSize();
}


void testNonDivisibleSubset() {
    int n, k;
    cin >> n >> k;
    vector<int> s(n);
    for (int i = 0; i < n; i++) cin >> s[i];

    cout << nonDivisibleSubset(k, s) << endl;

}


class SinglyList {
private:
    struct Node {
        Student data;
        Node* next = nullptr;
        Node(const Student& s) : data(s) {}
    };
    Node* head = nullptr;
public:
    void Add(const Student& s);
    void Add(const Student& s, int index);
    void Remove(int index);
    void Remove(const Student& s);
    void PopBack();
    void Print();
};


void SinglyList::Add(const Student& s) {
    Node* newNode = new Node(s);
    if (!head) head = newNode;
    else {
        Node* curr = head;
        while (curr->next) curr = curr->next;
        curr->next = newNode;
    }
}


void SinglyList::Add(const Student& s, int index) {
    if (index < 0) return;
    Node* newNode = new Node(s);
    if (index == 0) { newNode->next = head; head = newNode; return; }
    Node* curr = head;
    for (int i = 0; i < index - 1 && curr; ++i) curr = curr->next;
    if (!curr) return;
    newNode->next = curr->next;
    curr->next = newNode;
}


void SinglyList::Remove(int index) {
    if (index < 0 || !head) return;
    if (index == 0) { Node* temp = head; head = head->next; delete temp; return; }
    Node* curr = head;
    for (int i = 0; i < index - 1 && curr->next; ++i) curr = curr->next;
    Node* temp = curr->next;
    if (temp) { curr->next = temp->next; delete temp; }
}


void SinglyList::Remove(const Student& s) {
    if (!head) return;
    if (head->data == s) { Node* temp = head; head = head->next; delete temp; return; }
    Node* curr = head;
    while (curr->next && !(curr->next->data == s)) curr = curr->next;
    if (curr->next) { Node* temp = curr->next; curr->next = temp->next; delete temp; }
}


vector<int> climbingLeaderboard(vector<int> ranked, vector<int> player) {
    vector<int> result;
    // remove duplicates and sort descending
    vector<int> unique;
    unique.push_back(ranked[0]);
    for (int i = 1; i < ranked.size(); ++i) {
        if (ranked[i] != ranked[i - 1])
            unique.push_back(ranked[i]);
    }

    int index = unique.size() - 1;

    for (int score : player) {
        while (index >= 0 && score >= unique[index])
            --index;
        result.push_back(index + 2); // rank is index + 1, adding 1 more for 1-based
    }

    return result;
}


void testClimbingLeaderboard() {
    vector<int> ranked = { 100, 100, 50, 40, 40, 20, 10 };
    vector<int> player = { 5, 25, 50, 120 };

    vector<int> result = climbingLeaderboard(ranked, player);

    cout << "player ranks: ";
    for (int rank : result) {
        cout << rank << " ";
    }
    cout << endl;
}


void SinglyList::PopBack() {
    if (!head) return;
    if (!head->next) { delete head; head = nullptr; return; }
    Node* curr = head;
    while (curr->next->next) curr = curr->next;
    delete curr->next;
    curr->next = nullptr;
}


int queensAttack(int n, int k, int r_q, int c_q, vector<vector<int>> obstacles) {
    unordered_set<string> obs;
    for (auto& o : obstacles) {
        obs.insert(to_string(o[0]) + "," + to_string(o[1]));
    }
    int directions[8][2] = {
        {-1,  0}, // up
        { 1,  0}, // down
        { 0, -1}, // left
        { 0,  1}, // right
        {-1, -1}, // up-left
        {-1,  1}, // up-right
        { 1, -1}, // down-left
        { 1,  1}  // down-right
    };

    int count = 0;
    for (auto& dir : directions) {
        int r = r_q + dir[0];
        int c = c_q + dir[1];
        while (r >= 1 && r <= n && c >= 1 && c <= n && !obs.count(to_string(r))) {
            ++count;
            r += dir[0];
            c += dir[1];
        }
    }
    return count;
}


void testQueensAttack() {
    // Test 1
    int n1 = 4, k1 = 0, r_q1 = 4, c_q1 = 4;
    vector<vector<int>> obs1 = {};
    cout << "Test 1: " << (queensAttack(n1, k1, r_q1, c_q1, obs1) == 9 ? "Passed" : "Failed") << endl;

    // Test 2
    int n2 = 5, k2 = 3, r_q2 = 4, c_q2 = 3;
    vector<vector<int>> obs2 = { {5, 5}, {4, 2}, {2, 3} };
    cout << "Test 2: " << (queensAttack(n2, k2, r_q2, c_q2, obs2) == 10 ? "Passed" : "Failed") << endl;

    // Test 3
    int n3 = 1, k3 = 0, r_q3 = 1, c_q3 = 1;
    vector<vector<int>> obs3 = {};
    cout << "Test 3: " << (queensAttack(n3, k3, r_q3, c_q3, obs3) == 0 ? "Passed" : "Failed") << endl;
}


void SinglyList::Print() {
    Node* curr = head;
    while (curr) { curr->data.Print(); cout << " -> "; curr = curr->next; }
    cout << "null\n";
}


// ---------------------------- MAIN ----------------------------


int main() {


    // Caesar Cipher
    cout << caesarCipher("middle-Outz", 2) << endl;

    // Tower Breakers (HackerRank)
    cout << towerBreakers(1, 4) << endl;

    // Sliding Window Median
    auto medians = SlidingWindowMedian({1,2,3,4,5}, 3);
    for (auto m : medians) cout << m << " ";

    //Cat and Mouse (HackerRank)
    cout << catAndMouse(1, 3, 2) << endl;

    // Beautiful Triplets
    testBeautifulTriplets();

    // Angry Professor
    testAngryProfessor();

    // Prime Calculator
    testPrimeCalculator();

    // Matrix Multiplier
    testMatrixMultiplier();

    // Magic Square
    testFormingMagicSquare();

    //Climbing Leaderboard
    testClimbingLeaderboard();

    //Queen's Attack
    testQueensAttack();

    //Encryption
    testEncryption();
    
    //Divisible Subset
    testNonDivisibleSubset();

    //Ball Organizer 
    testBallOrganizer();

    return 0;
}