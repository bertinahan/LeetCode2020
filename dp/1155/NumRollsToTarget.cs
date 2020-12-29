public class Solution {
    public int NumRollsToTarget(int d, int f, int target) {
        if(target > d*f || target < d) return 0;
        int[,] dp = new int[d+1, target+1];
        for(int i = 1; i <= f && i<=target; i++)
            dp[1,i] = 1;
        int divisor = (int)Math.Pow(10,9)+7;
        for(int dice = 1; dice <=d; dice++)
            for(int i = dice; i <= target && i <= dice*f; i++)
            {
                for(int face = 1; face <= f && face <i; face++)
                {
                    dp[dice,i] = (dp[dice-1, i-face] % divisor + dp[dice,i]) % divisor;
                }
            }
        return dp[d,target];
    }
}