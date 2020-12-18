
public class Permutation46 {
    public IList<IList<int>> Permute(int[] nums) {
        var res = new List<IList<int>>();
        bt(new List<int>(), new Dictionary<int,int>(), nums, res);
        return res;
    }

    public void bt(List<int> curr, Dictionary<int,int> seen, int[] nums, IList<IList<int>> res)
    {
        if(curr.Count == nums.Length)
            res.Add(new List<int>(curr));
        for(int i = 0; i < nums.Length; i++)
        {
            if (seen.TryGetValue(i, out var v))
                continue;
            curr.Add(nums[i]);
            seen.Add(i, 0);
            bt(curr, seen, nums, res);
            curr.RemoveAt(curr.Count-1);
            seen.Remove(i);
        }
    }
    public IList<IList<int>> PermuteUnique(int[] nums) {
        IList<IList<int>> res = new List<IList<int>>();
        Array.Sort(nums);
        bt2(new List<int>(), new Dictionary<int,int>(), nums, res);
        return res;
    }
    public void bt2(List<int> curr, Dictionary<int, int> seen, int[] nums, IList<IList<int>> res)
    {
        if(curr.Count == nums.Length)
            res.Add(new List<int>(curr));
        for(int i = 0; i < nums.Length; i++)
        {
            if(seen.TryGetValue(i, out var v)) continue;
            if(i!=0 && !seen.TryGetValue(i-1, out var v2) && nums[i] == nums[i-1]) continue;
            curr.Add(nums[i]);
            seen.Add(i,0);
            bt2(curr, seen, nums, res);
            curr.RemoveAt(curr.Count-1);
            seen.Remove(i);
        }
    }
}