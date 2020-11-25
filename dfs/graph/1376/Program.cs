
public class Solution {
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime) {
        Dictionary<int, List<int>> tree = new Dictionary<int, List<int>>();
        for(int i = 0; i < n; i++)
        {
            if(tree.TryGetValue(manager[i], out var subList))
            {
                subList.Add(i);
            }else if (manager[i] != -1)
            {
                tree.Add(manager[i], new List<int>{i});
            }
        }
        int time = dfs(headID, tree, informTime)+informTime[headID];
        return time;
    }

    public int dfs(int headID, Dictionary<int, List<int>> tree, int[] informTime)
    {
        if(!tree.TryGetValue(headID, out var subArr)) return 0;
        int time = 0;
        foreach(int employee in subArr)
        {
            int currentTime = informTime[employee] + dfs(employee, tree, informTime);
            if(currentTime > time) time = currentTime;
        }
        return time;
    }
}