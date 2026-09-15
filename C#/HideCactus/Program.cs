class Program
{
    private static void Main()
    {
        Solution s = new Solution();

        int m = int.Parse(Console.ReadLine() ?? "0"); // 사막 크기 행
        int n = int.Parse(Console.ReadLine() ?? "0"); // 사막 크기 열

        int h = int.Parse(Console.ReadLine() ?? "0"); // 선인장 구역 세로
        int w = int.Parse(Console.ReadLine() ?? "0"); // 선인장 구역 가로
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
        int[,] drops = new int[,]
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

        int[] answer = s.solution(m, n, h, w, drops);
        Console.WriteLine($"[{answer[0]}, {answer[1]}]");
    }
}