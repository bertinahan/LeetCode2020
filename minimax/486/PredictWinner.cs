public class PredictWinner {
    public bool PredictTheWinner(int[] arr) {
//        int[,] dp = new int[arr.Length, arr.Length];
//        for(int i = 0; i < arr.Length; i++)
//        {
//            dp[i,i] = arr[i];
//        }
//        for(int len = 1; len < arr.Length; len++)
//            for(int i = 0; i + len < arr.Length; i++)
//            {
//                dp[i, i+len] = Math.Max(arr[i] - dp[i+1, i+len], arr[i+len] - dp[i, i+len-1]);
//            }
//        return dp[0, dp.GetLength(1)-1] >= 0;
        return dfs(0, arr.Length-1, new Dictionary<(int,int),int>(), arr) >= 0;
    }
    public int dfs(int i, int j, Dictionary<(int,int), int> memo, int[] arr)
    {
        if(memo.TryGetValue((i,j), out var res))
            return res;
        if( i == j) return arr[i];
        int result = Math.Max(arr[i] - dfs(i+1, j, memo, arr), arr[j] - dfs(i, j-1, memo, arr));
        memo.Add((i,j), result);
        return result;
    }
}