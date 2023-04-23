namespace RestoreTheArray
{
    internal class Program
    {
        public class RestoreTheArray
        {
            private int DFS(string s, int start, int k, int[] dp)
            {
                if (start == s.Length)
                {
                    return 1;
                }
                if (dp[start] != 0)
                {
                    return dp[start];
                }
                if (s[start] == '0')
                {
                    return 0;
                }
                int totalWays = 0;
                for (int end = start; end < s.Length; ++end)
                {
                    if (long.Parse(s[start..(end + 1)]) > k)
                    {
                        break;
                    }
                    totalWays = (totalWays + DFS(s, end + 1, k, dp)) % 1000000007;
                }
                dp[start] = totalWays;
                return dp[start];
            }

            public int NumberOfArrays(string s, int k)
            {
                int n = s.Length;
                int[] dp = new int[n + 1];
                return DFS(s, 0, k, dp);
            }
        }

        static void Main(string[] args)
        {
            RestoreTheArray restoreTheArray = new();
            Console.WriteLine(restoreTheArray.NumberOfArrays("1000", 10000));
            Console.WriteLine(restoreTheArray.NumberOfArrays("1000", 10));
            Console.WriteLine(restoreTheArray.NumberOfArrays("1317", 2000));
        }
    }
}