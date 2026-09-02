using System;
using System.Collections.Generic;

class Solution
{
    public int solution(string message, int[,] spoiler_ranges)
    {
        Dictionary<int, string> wordMap = new Dictionary<int, string>(); // 단어들을 저장하는 딕셔너리
        
        List<string> spoilerBlockWordList = new List<string>(); // 스포일러 방지가 적용된 단어들을 저장하는 리스트
        List<int> spoilerBlockWordCountList = new List<int>(); // 스포일러 방지가 적용된 단어들의 순서 저장하는 리스트
        List<string> notSpoilerBlockWordList = new List<string>(); // 스포일러 방지가 적용되지 않은 단어들을 저장하는 리스트
        List<string> resultWordList = new List<string>(); // 최종 결과 리스트

        string word = ""; // 단어 변수
        int wordCount = 0; // 몇 번째 단어인지
        
        foreach(var c in message)
        {
            if(c == ' ') // 공백 문자라면
            {
                wordMap.Add(wordCount, word); // 단어 추가
                wordCount++; // 다음 번째 단어로 설정
                word = ""; // 단어 초기화
                continue;
            }

            word += c; // 단어 변수에 문자 추가
        }
        wordMap.Add(wordCount, word); // 마지막 단어 추가(왜냐하면 마지막 문자는 뒤에 공백이 없기 때문에)

        foreach(var v in wordMap)
        {
            Console.WriteLine($"key: {v.Key}, word: {v.Value}");
        }
        for(int i = 0; i < spoiler_ranges.GetLength(0); i++)
        {
            int count = 0; // 몇 번째 단어인지 확인하기 위한 변수
            bool isSpoilerBlockWordChceked = false; // 스포일러 방지 단어인지 확인이 됐었는지 변수
            for(int j = 0; j < message.Length; j++)
            {
                if(spoiler_ranges[i, 1] < j) // 스포일러 방지 길이의 끝보다 j가 크면
                {
                    break; // 반복문 탈출
                }

                if(message[j] == ' ') // 현재 문자가 공백이라면
                {
                    count++;
                    isSpoilerBlockWordChceked = false; // 단어가 달라질 때마다 초기화
                    continue;
                }

                if(spoiler_ranges[i, 0] <= j)
                {
                    if(!isSpoilerBlockWordChceked)
                    {
                        string spoilerBlockWord = wordMap[count]; // 현재 count번째 단어를 스포일러 방지 단어로 지정
                        spoilerBlockWordList.Add(spoilerBlockWord);
                        spoilerBlockWordCountList.Add(count);
                        isSpoilerBlockWordChceked = true;
                    }
                }
            }
        }

        foreach(var v in wordMap)
        {
            bool isSpoilerBlockWord = false; // 스포일러 방지가 적용된 단어인지 여부
            foreach(var key in spoilerBlockWordCountList) // 스포일러 방지가 적용된 단어의 순서? ID? 몇 번째 단어인지를 저장한 리스트 순회
            {
                if(v.Key == key) // 스포일러 방지가 적용된 단어의 순서와 현재 단어의 순서가 같다면
                {
                    isSpoilerBlockWord = true; // 스포일러 방지가 적용됨
                    break; // 반복문 탈출
                }
            }

            if(!isSpoilerBlockWord) // 스포일러 방지가 적용되지 않은 단어라면
            {
                notSpoilerBlockWordList.Add(v.Value);
            }
        }
        
        foreach(var sbw in spoilerBlockWordList) // 스포일러 방지가 적용된 단어들 순회
        {
            bool same = false; // 같은 단어인지 여부
            foreach(var nsbw in notSpoilerBlockWordList) // 스포일러 방지가 적용되지 않은 단어들 순회
            {
                if(sbw == nsbw) // 스포일러 방지가 된 단어와 스포일러 방지가 되지 않은 단어가 같다면
                {
                    same = true; // 같은 단어를 찾음
                    break; // 반복문 탈출
                }
            }
            if(!same) // 스포일러 방지가 적용된 단어와 스포일러 방지가 적용되지 않은 단어 중 같은 단어가 없다면
            {
                if(!resultWordList.Contains(sbw)) // 이전에 스포일러 방지가 적용된 단어와 중복되는 단어가 아니라면
                {
                    resultWordList.Add(sbw);
                }
            }
        }

        foreach(var v in resultWordList)
        {
            Console.WriteLine($"resultWord: {v}");
        }

        return resultWordList.Count;
    }
}