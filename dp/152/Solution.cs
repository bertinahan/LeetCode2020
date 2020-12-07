
public class Solution {
    public int MaxProduct(int[] nums) {
        IList<IList<int>> dp = new List<IList<int>>();
        if(nums.Length == 0) return 0;
        dp.Add(new List<int>{1,1});
        for(int i = 0; i < nums.Length; i++)
        {
            int maxVal = Math.Max(nums[i], Math.Max(dp[i][0] * nums[i], dp[i][1] * nums[i]));
            int minVal = Math.Min(nums[i], Math.Min(dp[i][0] * nums[i], dp[i][1] * nums[i]));
            dp.Add(new List<int>{maxVal, minVal});
        }
        int max = dp[1][0];
        for(int i = 1; i < dp.Count; i++)
        {
            max = Math.Max(max, dp[i][0]);
        }
        return max;
    }
}