#include <iostream>
#include <string>

using namespace std;

class Solution
{
    public:
        void solution()
        {
            string s = "";
            cin >> s;
            for(int i = 0; i < s.size(); i++)
            {
                cout << s[i] << "\n";
            }
        }
};