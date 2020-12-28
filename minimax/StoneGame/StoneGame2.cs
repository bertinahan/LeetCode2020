public class Solution {
    public int StoneGameII(int[] piles) {
        int[] prefixSum = (int[])piles.Clone();
        for(int i = piles.Length - 2; i >= 0; i--)
            prefixSum[i]+= prefixSum[i+1];
        return dfs(0, 1, piles, prefixSum, new Dictionary<(int, int),int>());
    }
    public int dfs(int index, int M, int[] piles, int[] pre, Dictionary<(int, int),int> memo)
    {
        if(memo.TryGetValue((index, M), out var r)) return r;
        if(index + 2*M >= piles.Length) return pre[index];
        int res=0;
        for(int i = 1; i <= 2*M; i++)
        {
            // take
            res = Math.Max(pre[index] - dfs(index+i, Math.Max(M, i), piles, pre,memo), res);
        }
        memo.Add((index, M), res);
        return res;
    }
}