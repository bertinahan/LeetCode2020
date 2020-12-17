public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        var res = new List<IList<int>>();
        // no duplicates
        //bt(0, nums, res, new List<int>());
        bt2(0, new List<int>(), nums, res);
        return res;
    }
    public void bt2(int index, List<int> curr, int[] nums, IList<IList<int>> res)
    {
        res.Add(new List<int>(curr));
        for(int i = index; i < nums.Length; i++)
        {
            curr.Add(nums[i]);
            bt2(i+1, curr, nums, res);
            curr.RemoveAt(curr.Count-1);
        }
    }
    public void bt(int index, int[] nums, IList<IList<int>> res, List<int> curr)
    {
        if(index == nums.Length)
        {
            res.Add(curr);
            return;
        }
        bt(index+1, nums, res, new List<int>(curr));
        curr.Add(nums[index]);
        bt(index+1, nums, res, curr);
    }
}