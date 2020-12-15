
public class Solution {
    public int CoinChange(int[] coins, int amount) {

        var dp = Enumerable.Repeat(amount+1, amount+1).ToArray();
        dp[0] = 0;
        for(int i = 0; i < coins.Length; i++)
        {
            for(int j = coins[i]; j <= amount; j++)
            {
                if(dp[j-coins[i]] != amount+1)
                dp[j] = Math.Min(dp[j], dp[j-coins[i]]+1);
            }
        }
        return dp[amount] == amount+1 ? -1: dp[amount];
    }
}