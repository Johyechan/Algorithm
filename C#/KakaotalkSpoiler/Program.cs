using System;

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        string message = Console.ReadLine() ?? "";
        string[] input = Console.ReadLine().Split();

        int row = int.Parse(input[0]);
        int col = int.Parse(input[1]);

        Console.WriteLine($"message = {message}");
        Console.WriteLine($"row = {row}, col = {col}");
        int[,] spoiler_ranges = new int[row, col];

        for(int i = 0; i < row; i++)
        {
            for(int j = 0; j < col; j++)
            {
                spoiler_ranges[i, j] = int.Parse(Console.ReadLine() ?? "0");
            }
        }
        
        int result = solution.solution(message, spoiler_ranges);
        Console.WriteLine(result);
    }
}