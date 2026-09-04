#include <iostream>
#include <string>
#include <vector>
#include "Solution.cpp"

using namespace std;

int main()
{
    Solution solution;

    string message;
    getline(cin, message);

    int size = 0;

    cin >> size;

    vector<vector<int>> spoiler_ranges;

    for(int i = 0; i < size; i++)
    {
        int start = 0;
        int end = 0;
        cin >> start >> end;
        spoiler_ranges.push_back({start, end});
    }

    int result = solution.solution(message, spoiler_ranges);
    cout << result;
    return 0;
}