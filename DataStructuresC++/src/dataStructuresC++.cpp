
#include <algorithm>
#include <cmath>
#include <iostream>
#include <map>
#include <queue>
#include <set>
#include <stack>
#include <string>
#include <unordered_map>
#include <unordered_set>
#include <vector>

using namespace std;
using namespace std::chrono;

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

void update(int* a, int* b) {
    int tempA = *a, tempB = *b;
    *a = tempA + tempB;
    *b = abs(tempA - tempB);
}

int towerBreakers(int n, int m) {
    return (m == 1 || m % 2 == 0) ? 2 : 1;
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

void SinglyList::PopBack() {
    if (!head) return;
    if (!head->next) { delete head; head = nullptr; return; }
    Node* curr = head;
    while (curr->next->next) curr = curr->next;
    delete curr->next;
    curr->next = nullptr;
}

void SinglyList::Print() {
    Node* curr = head;
    while (curr) { curr->data.Print(); cout << " -> "; curr = curr->next; }
    cout << "null\n";
}

// ---------------------------- MAIN ----------------------------
int main() {
    // You can call whichever feature you want to test below

    // Example: Caesar Cipher
    // cout << caesarCipher("middle-Outz", 2) << endl;

    // Example: Tower Breakers
    // cout << towerBreakers(1, 4) << endl;

    // Example: Sliding Window Median
    // auto medians = SlidingWindowMedian({1,2,3,4,5}, 3);
    // for (auto m : medians) cout << m << " ";

    // Example: Cat and Mouse
    cout << catAndMouse(1, 3, 2) << endl;

    return 0;
}
