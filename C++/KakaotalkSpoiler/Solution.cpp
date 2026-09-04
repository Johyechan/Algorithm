#include <string>
#include <vector>
#include <set>
#include <unordered_set>
#include <map>
#include <unordered_map>

using namespace std;

class Solution
{
    public:
        int solution(string message, vector<vector<int>> spoiler_ranges)
        {
            vector<string> wordVec;
            vector<bool> isSpoilerVec;
            vector<pair<int, int>> wordSizeVec;

            string word = "";
            int wordStartIndex = 0;
            for(int i = 0; i < message.size(); i++)
            {
                if(message[i] == ' ')
                {
                    wordVec.push_back(word);
                    wordSizeVec.push_back({wordStartIndex, i - 1});
                    isSpoilerVec.push_back(false);
                    word = "";
                    wordStartIndex = i + 1;
                    continue;
                }
                word += message[i];
            }

            wordVec.push_back(word);
            wordSizeVec.push_back({wordStartIndex, message.size() - 1});
            isSpoilerVec.push_back(false);

            for(int i = 0; i < spoiler_ranges.size(); i++)
            {
                for(int j = 0; j < wordSizeVec.size(); j++)
                {
                    if(spoiler_ranges[i][1] < wordSizeVec[j].first)
                    {
                        break;
                    }

                    // 스포 방지의 시작점이 단어의 시작점 이상이고 단어의 끝점 이하일때
                    if(spoiler_ranges[i][0] <= wordSizeVec[j].second)
                    {
                        isSpoilerVec[j] = true;
                    }
                }
            }

            unordered_set<string> spoilerWord;
            unordered_set<string> notSpoilerWord;

            for(int i = 0; i < isSpoilerVec.size(); i++)
            {
                if(isSpoilerVec[i]) // 스포일러 단어라면
                {
                    spoilerWord.insert(wordVec[i]);
                }
                else // 스포일러 단어가 아니라면
                {
                    notSpoilerWord.insert(wordVec[i]);
                }
            }

            for(const auto& notSpoiler : notSpoilerWord)
            {
                // 스포일러가 아닌 단어가 스포일러 단어중에 있다면
                if(spoilerWord.find(notSpoiler) != spoilerWord.end())
                {
                    spoilerWord.erase(notSpoiler);
                }
            }

            return spoilerWord.size();
        }
};