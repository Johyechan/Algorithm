class Program
{
    private static void Main()
    {
        Solution s = new Solution();

        int m = int.Parse(Console.ReadLine() ?? "0"); // 사막 크기 행
        int n = int.Parse(Console.ReadLine() ?? "0"); // 사막 크기 열

        int h = int.Parse(Console.ReadLine() ?? "0"); // 선인장 구역 세로
        int w = int.Parse(Console.ReadLine() ?? "0"); // 선인장 구역 가로

        int[,] drops = new int[,]
        {
            {2, 0}, 
            {1, 3}, 
            {3, 2}, 
            {0, 1}
        };

        int[] answer = s.solution(m, n, h, w, drops);
        Console.WriteLine($"[{answer[0]}, {answer[1]}]");
    }
}