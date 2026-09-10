using System;
using System.Collections.Generic;

class Solution
{
    public int[] solution(int m, int n, int h, int w, int[,] drops)
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
    }
}
