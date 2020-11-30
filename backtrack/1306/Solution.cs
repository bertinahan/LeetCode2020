public class Solution {
    public bool CanReach(int[] arr, int start) {

        return dfs(start, arr, new List<int>());
    }

    public bool dfs(int start, int[] arr, IList<int> seen)
    {
        if(seen.Contains(start)) return false;
        if(arr[start] == 0) return true;
        seen.Add(start);
        int toR = start + arr[start];
        int toL = start - arr[start];
        bool rPath = false;
        bool lPath = false;
        if(toR >= 0 && toR < arr.Length)
           rPath = dfs(toR, arr, seen);
        if(toL >= 0 && toL < arr.Length)
            lPath = dfs(toL, arr, seen);
        return rPath || lPath;
    }
}