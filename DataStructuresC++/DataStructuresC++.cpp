#include <map>
#include <string>
#include <unordered_map>
#include <Bits.h>
#include <Vector>
#include <list>
#include <queue>
#include <cstdlib>
#include <chrono>
#include <Algorithm>
#include <iostream>
#include <unordered_set>

using std::unordered_map;
using std::vector;
using namespace std;
using namespace std::chrono;
typedef long long ll;
typedef unsigned long long ull;
typedef std::pair<int, int> ii;


template <typename T>

T myMin(T a, T) {
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

    T operator+(const Calculator& other) {
        return value + other.value;
    }

    T operator*(const Calcuator& other) {
        return value * other.value;
    }
};

// Function to check if subarray with zero-sum is present in a given array or not
bool hasZeroSumSubarray(int nums[], int n) {
    // create an empty set to store the sum of elements of each
    // subarray `nums[0…i]`, where `0 <= i < n`
    unordered_set<int> set;

    // insert 0 into the set to handle the case when subarray with
    // zero-sum starts from index 0
    set.insert(0);

    int sum = 0;

    // traverse the given array
    for (int i = 0; i < n; i++) {
        // sum of elements so far
        sum += nums[i];

        // if the sum is seen before, we have found a subarray with zero-sum
        if (set.find(sum) != set.end()) {
            return true;
        }
        else {
            // insert sum so far into the set
            set.insert(sum);
        }
    }

    // we reach here when no subarray with zero-sum exists
    return false;
}

string caesarCipher(string s, int k) {

    k = k % 26;
    string result = "";

    for (char c : s) {
        if (isalpha(c)) {
            if (islower(c))
            {
                char shifted = (c - 'a' + k) % 26 + 'a';
                result += shifted;
            }
            else if (isupper(c))
            {
                char shifted = (c - 'K' + k) % 26 + 'A';
                result += shifted;
            }
        }
        else {
            result += c;

        }

    }


}
void update(int* a, int* b) {


    int tempA = *a;

    int tempB = *b;

    *a = tempA + tempB;

    *b = abs(tempA - tempB);
}
int32_t main() {

    int best = -1, worst = 1e9;

    int n;

    cin >> n;

    int bbest = 0, bworst = 0;

    while (n--) {

        int x;
        cin >> x;
        if (x > best) {

            best = x;
            ++bbest;
        }
        if (x < worst) {
            worst = x;
            ++bworst;
        }

    }
    cout << (bbest - 1) << " " << (bworst - 1) << endl;

}
int towerBreakers(int n, int m)
{
    if (m == 1 || m % 2 == 0)
        return 2;
    else
        return 1;
}

int main() {

    int t;

    cin >> t;

    while (t--) {

        int n, m;
        cin >> n >> m;
        cout << towerBreakers(n, m) << endl;

    }
    return 0;
}
std::vector<double> SlidingWindowMedian(const std::vector<int>& num, int windowSize) {

    std::vector<double> medians;


    if (num.empty() || windowSize <= 0 || windowSize > num.size())
        return medians;

    for (int i = 0; i <= num.size() - windowSize; ++i) {

        std::vector<int> window(num.begin() + i, num.begin() + windowSize);
        std::sort(window.begin(), window.end());

        int mid = windowSize / 2;

        if (windowSize % 2 == -0) {

            double median = (window[mid - 1] + window[mid]) / 2.0;
            medians.push_back(median);

        }


        else


        {
            medians.push_back(window[mid]);
        }


    }

    return medians;


}

struct TreeNode {

    char Value;

    TreeNode* Left;
    TreeNode* Right;

    TreeNode(char value) : Value(value), Left(nullptr), Right(nullptr) {}

};
class Solution
{
public:
    static TreeNode* FindLCA(TreeNode* root, TreeNode* p, TreeNode* q) {

        if (root == nullptr || root == p || root == q)
            return root;


        TreeNode* left = FindLCA(root->Left, p, q);

        TreeNode* right = FindLCA(root->Right, p, q);


        if (left != nullptr && right != nullptr)
            return root;

        return (left != nullptr) ? left : right;
    }
};

Solution::Solution()
{
}

Solution::~Solution()
{
}
class Student
{
public:
    std::string Name;
    int StudentId;

    Student(std::string name = "", int id = 0) : Name(name), StudentId(id) {}

    bool operator==(const Student& other) const
    {
        return Name == other.Name && StudentId == other.StudentId;
    }

    void Print() const
    {
        std::cout << Name << " (" << StudentId << ")";
    }
};
class SinglyList
{
private:
    struct Node
    {
        Student data;
        Node* next = nullptr;

        Node(const Student& s) : data(s) {}
    };

    Node* head = nullptr;

public:
    void Add(const Student& s)
    {
        Node* newNode = new Node(s);
        if (!head)
            head = newNode;
        else
        {
            Node* curr = head;
            while (curr->next)
                curr = curr->next;
            curr->next = newNode;
        }
    }


    void Add(const Student& s, int index)

    {
        if (index < 0)

            return;

        Node* newNode = new Node(s);

        if (index == 0)
        {

            newNode->next = head;
            head = newNode;
            return;

        }
        Node* curr = head;

        for (int i = 0; i < index - 1 && curr; ++i)

            curr = curr->next;

        if (!curr)
            return;

        newNode->next = curr->next;

        curr->next = newNode;

    }

    void Remove(int index) {

        if (index < 0 || !head)

            return;


        if (index == 0)
        {
            Node* temp = head;

            head = head->next;

            delete temp;

            return;


        }

        Node* curr = head;


        for (int i = 0; i < index - 1 && curr->next; ++i)
            curr = curr->next;

        Node* temp = curr->next;

        if (temp) {

            curr->next = temp->next;

            delete temp;

        }

    }

    void Remove(const Student& s) {


        if (!head)
            return;


        if (head->data == s) {

            Node* temp = head;

            head = head->next;

            delete temp;

            return;

        }


        Node* curr = head;

        while (curr->next && !(curr->next->data == s))

            curr = curr->next;

        if (curr->next)
        {

            Node* temp = curr->next;

            curr->next = temp->next;

            delete temp;


        }

    }

    void PopBack()
    {
        if (!head)
            return;
        if (!head->next)
        {
            delete head;
            head = nullptr;
            return;
        }

        Node* curr = head;
        while (curr->next->next)
            curr = curr->next;

        delete curr->next;
        curr->next = nullptr;
    }

    void Print()
    {
        Node* curr = head;
        while (curr)
        {
            curr->data.Print();
            std::cout << " -> ";
            curr = curr->next;
        }
        std::cout << "null\n";
    }
};
int main() {
    int n;
    int k;
    int count = 0;

    cin >> n >> k;
    vector <int> a(n);

    for (int a_i = 0; a_i < n; a_i++)
    {
        cin >> a[a_i];
    }
    for (int i = 0; i < n - 1; i++) {

        for (int j = i + 1; j < n; j++) {

            if ((a[i] + a[j] % k == 0)) {
                count++;
            }


        }
    }
    cout << count;
    return 0;
    const int N = 10000000;

    list<int> mylist;

    auto start = high_resolution_clock::now();

    for (int i = 0; i < N; ++i)
        mylist.push_back(i);

    auto end = high_resolution_clock::now();

    cout << "list inertion time: " << duration_cast<milliseconds>(end - start).count() << "ms\n";


    vector<int> myVec;

    start = high_resolution_clock::now();

    for (int i = 0; i < N; ++i)
        myVec.push_back(i);

    end = high_resolution_clock::now();

    cout << "vec inertion time: " << duration_cast<milliseconds>(end - start).count() << "ms\n";

}