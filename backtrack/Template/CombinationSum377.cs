public class Solution {
    public int CombinationSum4(int[] nums, int target) {
        var memo = new Dictionary<int,int>();
        memo.Add(0, 1);
        return bt(target, nums, memo);
    }
    public int bt(int left, int[] nums, Dictionary<int,int> memo)
    {
        if(memo.TryGetValue(left, out var val))
        {
            return val;
        }
        int res = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] <= left)
            {
                int tmp = bt(left-nums[i], nums, memo);
                res += tmp;
            }
        }
        memo.Add(left, res);
        return res;
    }
}