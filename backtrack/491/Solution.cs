public class Solution {
    public IList<IList<int>> FindSubsequences(int[] nums) {
        IList<IList<int>> res = new List<IList<int>>();
        if(nums.Length <= 1) return res;
        backtrack(0, new List<int>(), nums, res);
        return res;
    }

    public void backtrack(int index, List<int> curr, int[] nums, IList<IList<int>> res)
    {
        if(curr.Count >= 2)
        {
           IList<int> lst = new List<int>(curr);
            res.Add(lst);
        }
        HashSet<int> existingNum = new HashSet<int>();
        for(int i = index; i < nums.Length; i++)
        {
            if(existingNum.Contains(nums[i]))
                continue;
            if(curr.Count == 0 || curr[curr.Count-1] <= nums[i])
            {
                existingNum.Add(nums[i]);
                curr.Add(nums[i]);
                backtrack(i+1, curr, nums, res);
                curr.RemoveAt(curr.Count-1);

            }
        }


    }
}