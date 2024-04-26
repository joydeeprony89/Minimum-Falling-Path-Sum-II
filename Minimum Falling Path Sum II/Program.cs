using System.Runtime.Intrinsics.Arm;

namespace Minimum_Falling_Path_Sum_II
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var grid = new int[3][] { [1, 2, 3], [4, 5, 6], [7, 8, 9] };
            var sol = new Solution();
            var ans = sol.MinFallingPathSum_TLE(grid);
            Console.WriteLine(ans);
        }
    }
}

public class Solution
{
    // O(N^3) - Time
    // O(N2) - Space
    public int MinFallingPathSum_TLE(int[][] grid)
    {
        int N = grid.Length;
        var cache = new Dictionary<(int, int), int>();
        int Helper(int r, int c)
        {
            // base case
            if (r == N - 1)
            {
                return grid[r][c];
            }
            var key = (r, c);
            if (cache.ContainsKey(key)) return cache[key];
            int res = int.MaxValue;
            for (int next_c = 0; next_c < N; next_c++)
            {
                if (next_c != c)
                {
                    res = Math.Min(res, grid[r][c] + Helper(r + 1, next_c));
                }
            }

            cache[key] = res;
            return res;
        }

        int res = int.MaxValue;
        for (int c = 0; c < N; c++)
        {
            res = Math.Min(res, Helper(0, c));
        }
        return res;
    }
}

// O(N3)
// O(N)
class Solution(object) :
    def minFallingPathSum(self, grid):
        N = len(grid)
        dp = grid[0]

        for r in range(1, N):
            new_dp = [float("inf")] * N
            for cur_c in range(N):
                for prev_c in range(N):
                    if (cur_c != prev_c): 
                        new_dp[cur_c] = min(new_dp[cur_c], dp[prev_c] + grid[r][cur_c])
            dp = new_dp
        return min(dp)

        