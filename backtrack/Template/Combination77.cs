public class Combination77 {
    public IList<IList<int>> Combine(int n, int k) {
        var res = new List<IList<int>>();
        bt(1, n, new List<int>(), k, res);
        return res;
    }

    public void bt(int index, int n, IList<int> curr, int k, IList<IList<int>> res)
    {
        if(k ==0)
        {
            res.Add(new List<int>(curr));
            return;
        }
        for(int i = index; i <= n-k+1; i++)
        {
            curr.Add(i);
            bt(i+1, n, curr, k-1, res);
            curr.RemoveAt(curr.Count-1);
        }
    }
}