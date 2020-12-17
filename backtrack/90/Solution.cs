public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        var res = new List<IList<int>>();
        Array.Sort(nums);
        bt(0, new List<int>(), nums, res);
        return res;
    }
    public void bt(int index, List<int> curr, int[] nums, IList<IList<int>> res)
    {
        res.Add(new List<int>(curr));
        for(int i = index; i < nums.Length; i++)
        {
            if(i!=index&& nums[i] == nums[i-1]) continue;
            curr.Add(nums[i]);
            bt(i+1, curr, nums, res);
            curr.RemoveAt(curr.Count - 1);
        }
    }
}