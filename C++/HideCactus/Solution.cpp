#include <vector>
#include <deque>

using namespace std;

class Solution
{
    public:
        vector<int> solution(int m, int n, int h, int w, vector<vector<int>> drops)
        {
            vector<int> answer(2);
            vector<vector<int>> rain(m, vector<int>(n));
            int maxValue = m * n + 1;

            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    rain[i][j] = maxValue;
                }
            }

            for(int i = 0; i < drops.size(); i++)
            {
                rain[drops[i][0]][drops[i][1]] = i;
            }

            vector<vector<int>> row;

            for(int i = 0; i < m; i++)
            {
                deque<int> deque;
                row.push_back(vector<int>());
                for(int j = 0; j < n; j++)
                {
                    while(deque.size() > 0 && deque.front() <= j - w)
                    {
                        deque.pop_front();
                    }

                    while(deque.size() > 0 && rain[i][deque.back()] >= rain[i][j])
                    {
                        deque.pop_back();
                    }

                    deque.push_back(j);

                    if(j >= w - 1)
                    {
                        row[i].push_back(rain[i][deque.front()]);
                    }
                }
            }

            vector<vector<int>> col(m - h + 1, vector<int>(row[0].size()));

            for(int i = 0; i < row[0].size(); i++)
            {
                deque<int> deque;
                for(int j = 0; j < m; j++)
                {
                    while(deque.size() > 0 && deque.front() <= j - h)
                    {
                        deque.pop_front();
                    }

                    while(deque.size() > 0 && row[deque.back()][i] >= row[j][i])
                    {
                        deque.pop_back();
                    }

                    deque.push_back(j);

                    if(j >= h - 1)
                    {
                        col[j - h + 1][i] = row[deque.front()][i];
                    }
                }
            }

            int big = -1;
            for(int i = 0; i < col.size(); i++)
            {
                for(int j = 0; j < col[i].size(); j++)
                {
                    if(col[i][j] == maxValue)
                    {
                        answer[0] = i;
                        answer[1] = j;
                        return answer;
                    }
                    else if(big < col[i][j])
                    {
                        big = col[i][j];
                        answer[0] = i;
                        answer[1] = j;
                    }
                }
            }

            return answer;
        }
};