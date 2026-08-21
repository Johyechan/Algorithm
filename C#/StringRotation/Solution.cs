public class Solution
{
    public void solution()
    {
        string s = Console.ReadLine() ?? ""; // 입력 받은 값이 null 이라면 ""
        foreach(var c in s) // s 문자열 순회
        {
            Console.WriteLine(c); // 한 단어씩 출력
        }
    }
}