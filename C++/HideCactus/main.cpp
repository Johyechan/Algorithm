#include <iostream>
#include <vector>
#include "Solution.cpp"

using namespace std;

int main()
{
    int m = 0;
    int n = 0;
    int h = 0;
    int w = 0;

    cin >> m >> n >> h >> w;

    /*
        {0, 0}, 
        {3, 1}, 
        {1, 3}, 
        {2, 4},
        {1, 1},
        {2, 2},
        {2, 3},
        {0, 4},
    */
    /*
        {0, 0}, 
        {0, 1}, 
        {0, 2}, 
        {1, 0},
    */
    /*
        {1, 2},
    */
    /*
        {0, 1},
        {0, 3},
        {0, 5},
        {1, 1},
        {1, 3},
        {1, 5},
        {2, 1},
        {2, 3},
        {2, 5},
        {3, 1},
        {3, 3},
        {3, 5},
    */
    /*
        {0, 0},
        {0, 1},
        {1, 1},
        {1, 0},
    */
    /*
        {2, 0},
        {1, 3},
        {3, 2},
        {0, 1},
    */
    
    vector<vector<int>> drops = 
    {
        {0, 0}, 
        {3, 1}, 
        {1, 3}, 
        {2, 4},
        {1, 1},
        {2, 2},
        {2, 3},
        {0, 4},
    };

    Solution s;
    vector<int> result = s.solution(m, n, h, w, drops);

    cout << "[" << result[0] << ", " << result[1] << "]";
    return 0;
}