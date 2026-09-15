using System;
using System.Collections.Generic;

class Solution
{
    public int[] solution(int m, int n, int h, int w, int[,] drops)
    {
        int[,] rain = new int[m, n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                rain[i, j] = int.MaxValue;
            }
        }

        for (int i = 0; i < drops.GetLength(0); i++)
        {
            rain[drops[i, 0], drops[i, 1]] = i;
        }


        // 가로 방향 최소값
        int[,] row = new int[m, n - w + 1];

        for (int i = 0; i < m; i++)
        {
            LinkedList<int> deque = new LinkedList<int>();

            for (int j = 0; j < n; j++)
            {
                // 현재 윈도우에서 빠진 인덱스 제거
                while (deque.Count > 0 &&
                    deque.First.Value <= j - w)
                {
                    deque.RemoveFirst();
                }

                // 새 값보다 크거나 같은 후보 제거
                while (deque.Count > 0 &&
                    rain[i, deque.Last.Value] >= rain[i, j])
                {
                    deque.RemoveLast();
                }

                // 새 값 추가
                deque.AddLast(j);

                // 윈도우가 완성되었으면 최소값 저장
                if (j >= w - 1)
                {
                    row[i, j - w + 1] = rain[i, deque.First.Value];
                }
            }
        }


        // 세로 방향 최소값
        int[,] col = new int[m - h + 1, row.GetLength(1)];

        for (int i = 0; i < col.GetLength(1); i++)
        {
            LinkedList<int> deque = new LinkedList<int>();

            for (int j = 0; j < m; j++)
            {
                // 현재 윈도우에서 빠진 인덱스 제거
                while (deque.Count > 0 &&
                    deque.First.Value <= j - h)
                {
                    deque.RemoveFirst();
                }

                // 새 값보다 크거나 같은 후보 제거
                while (deque.Count > 0 &&
                    row[deque.Last.Value, i] >= row[j, i])
                {
                    deque.RemoveLast();
                }

                // 새 값 추가
                deque.AddLast(j);

                // 윈도우가 완성되었으면 최소값 저장
                if (j >= h - 1)
                {
                    col[j - h + 1, i] = row[deque.First.Value, i];
                }
            }
        }


        // 최댓값 탐색
        int[] result = new int[2];
        int big = -1;

        for (int i = 0; i < col.GetLength(0); i++)
        {
            for (int j = 0; j < col.GetLength(1); j++)
            {
                if (col[i, j] == int.MaxValue)
                {
                    result[0] = i;
                    result[1] = j;
                    return result;
                }

                if (col[i, j] > big)
                {
                    big = col[i, j];
                    result[0] = i;
                    result[1] = j;
                }
            }
        }

        return result;
    }
    /*private void Check(int[,] rainDropCountCheck, int[,] rainDropCheck, int tempCount, 
                        ref int answerCheck, int minM, int minN, int maxM, int maxN, int[] answer)
    {
        if(rainDropCountCheck[minM, minN] == -1)
        {
            tempCount = int.MaxValue;
            for(int j = minM; j <= maxM; j++)
            {
                for(int k = minN; k <= maxN; k++)
                {
                    if(rainDropCheck[j, k] < tempCount)
                    {
                        tempCount = rainDropCheck[j, k];
                    }
                }
            }
            rainDropCountCheck[minM, minN] = tempCount;
            if(tempCount < int.MaxValue)
            {
                if(answerCheck < tempCount)
                {
                    answerCheck = tempCount;
                    answer[0] = minM;
                    answer[1] = minN;
                }
            }
        }
    }

    public int[] solution(int m, int n, int h, int w, int[,] drops)
    {
        int[] answer = new int[2];
        int answerCheck = -1;

        // 비가 내린 위치를 저장하는 전체 지도
        int[,] rainDropCheck = new int[m, n];

        // 비를 처음 맞는 순서를 기록하는 지도
        int[,] rainDropCountCheck = new int[m, n];

        // 각 칸을 전부 -1로 초기화
        for(int i = 0; i < m; i++)
        {
            for(int j = 0; j < n; j++)
            {
                rainDropCheck[i, j] = int.MaxValue;
                rainDropCountCheck[i, j] = -1;
            }
        }

        // 비 내린 위치에 몇 번째로 비가 내렸는지 저장
        for(int i = 0; i < drops.GetLength(0); i++)
        {
            rainDropCheck[drops[i, 0], drops[i, 1]] = i;
        }

        for(int i = 0; i < drops.GetLength(0); i++)
        {
            int dropM = drops[i, 0];
            int dropN = drops[i, 1];
            int minM = dropM - (h - 1);
            int minN = dropN - (w - 1);
            int maxM = dropM + (h - 1);
            int maxN = dropN + (w - 1);
            int tempCount = int.MaxValue;
            if(minM >= 0)
            {
                if(minN >= 0)
                {
                    Check(rainDropCountCheck, rainDropCheck, tempCount, ref answerCheck, 
                        minM, minN, dropM, dropN, answer);
                }
                if(maxN < n)
                {
                    Check(rainDropCountCheck, rainDropCheck, tempCount, ref answerCheck, 
                        minM, dropN, dropM, maxN, answer);
                }
            }
            if(maxM < m)
            {
                if(minN >= 0)
                {
                    Check(rainDropCountCheck, rainDropCheck, tempCount, ref answerCheck, 
                        dropM, minN, maxM, dropN, answer);
                }
                if(maxN < n)
                {
                    Check(rainDropCountCheck, rainDropCheck, tempCount, ref answerCheck, 
                        dropM, dropN, maxM, maxN, answer);
                }
            }
        }

        for(int i = 0; i < m - h; i++)
        {
            for(int j = 0; j < n - w; j++)
            {
                if(rainDropCountCheck[i, j] == -1)
                {
                    answer[0] = i;
                    answer[1] = j;
                    return answer;
                }
            }
        }

        return answer;
    }*/

    /*public int[] solution(int m, int n, int h, int w, int[,] drops)
    {
            int[] answer = new int[2]; // 정답 변수
            // 선인장 구역이 비 맞은 위치와 그 맞은 비의 내린 순서를 저장하는 맵
            Dictionary<(int, int), int> cactusHitDropMap = new Dictionary<(int, int), int>();

            int startM = 0; // 시작 행
            int startN = 0; // 시작 열
            int endM = h; // 시작 높이
            int endN = w; // 시작 넓이
            int order = -1; // 비 맞은 순서

            bool end = false; // while문 종료 여부 변수
            
            // end가 false라면 반복해라
            while(!end)
            {
                bool isHit = false; // 비를 맞았는지 여부

                for(int i = 0; i < drops.GetLength(0); i++) // 비 내리는 위치 순회
                {
                    // 비 내리는 위치가 선인장 구역의 높이 내에 있고 선인장 구역 넓이 내에 있다면
                    if((startM <= drops[i,0] && endM > drops[i,0]) 
                        && (startN <= drops[i,1] && endN > drops[i,1]))
                    {
                        isHit = true; // 비 맞았고
                        // 이미 해당 비 위치가 맵에 없다면
                        if(!cactusHitDropMap.ContainsKey((startM, startN)))
                        {
                            // 시작 위치가 비 내리는 순서로 비를 맞았다
                            // 무슨 말이냐 비 맞은 위치를 키로 두어 중복을 막고
                            // 맞은 순서를 저장하여 해당 위치가 몇 번째로 맞았는지 저장
                            cactusHitDropMap.Add((startM, startN), i);
                            // 저장된 비 맞은 순서가 현재 확인 중인 비 맞은 순서보다 더 빠르다면
                            if(order < i)
                            {
                                // 비 맞은 순서를 더 낮게 맞은 순서로 변경하고
                                order = i;
                                // 가장 늦게 비를 맞는 위치도 변경
                                answer[0] = startM;
                                answer[1] = startN;
                            }
                        }

                        // 구역 넓이의 끝을 한 칸 오른쪽으로 이동하려는데 최대 크기를 넘어간다면
                        if(endN + 1 > n)
                        {
                            // 구역 높이의 끝을 한 칸 아래로 이동하려는데 최대 크기를 넘어간다면
                            if(endM + 1 > m)
                            {
                                // 반복 종료
                                end = true;
                            }
                            else // 넘어가지 않는다면 선인장 구역 높이 한 칸 아래로 이동
                            {
                                startN = 0;
                                endN = w;
                                startM++;
                                endM++;
                            }
                        }
                        else // 넘어가지 않는다면 선인장 구역 넓이 한 칸 오른쪽으로 이동
                        {
                            startN++;
                            endN++;
                        }
                        break;
                    }
                }

                // 비를 안 맞았다면
                if(!isHit)
                {
                    // 현재 선인장 구역의 시작 위치를 가장 늦게 비를 맞는 위치로 반환
                    answer[0] = startM;
                    answer[1] = startN;
                    return answer;
                }
            }

            // 가장 늦게 비를 맞는 위치를 반환
            return answer;
    }*/
}
