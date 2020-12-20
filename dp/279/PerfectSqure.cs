
public class PerfectSquare {
    private int m = 0;
    public int NumSquares(int n) {
        var arr = new List<int>();
        for(int i = 1; i*i<=n; i++)
        {
            arr.Add(i*i);
        }
        int[] dp = Enumerable.Repeat(Int32.MaxValue, n+1).ToArray();
        dp[0] = 0;
        for(int i = 0; i < arr.Count; i++)
        {
            for(int j = arr[i]; j <=n; j++)
            {
                dp[j] = Math.Min(dp[j], 1+dp[j-arr[i]]);
            }
        }
        return dp[n];
    }

}