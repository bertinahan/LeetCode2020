
public class Solution {
    public int MinCost(int[][] costs) {
        if(costs.Length == 0)
            return 0;
        int colors = costs[0].Length;
        IList<int> colorLst = new List<int>();
        for(int i = 0; i < colors; i++)
        {
            colorLst.Add(i);
        }
        Dictionary<(int, int), int> memo = new Dictionary<(int,int), int>();
        // Method 1
        int res = Math.Min(bt(0,0,memo,costs), Math.Min(bt(0,1,memo,costs), bt(0,2,memo,costs));
        // Method 2
        int redSum = 0;
        int blueSum = 0;
        int greenSum = 0;
        for(int i = 1 ; i < costs.Length; i++)
        {
            costs[i][0] =Math.Min(costs[i-1][1], costs[i-1][2]) + costs[i][0];
            costs[i][1] = Math.Min(costs[i-1][0], costs[i-1][2]) + costs[i][1];
            costs[i][2] = Math.Min(costs[i-1][0], costs[i-1][1]) + costs[i][2];
        }
        return Math.Min(costs[costs.Length-1][0], Math.Min(costs[costs.Length-1][1], costs[costs.Length-1][2]));
    }
   // TLE
    public int bt(int index, int color, Dictionary<(int, int), int> memo, int[][] costs)
    {
        if(memo.TryGetValue((index, color), out var res))
        {
            return res;
        }
        if(index == costs.Length)
            return 0;
        res = costs[index][color];
        if(color == 0)
        {
            return res + Math.Min(bt(index+1, 1, memo, costs), bt(index+1, 2, memo, costs));
        }
        else if (color == 1)
        {
            return res + Math.Min(bt(index+1, 0, memo, costs), bt(index+1, 2, memo, costs));
        }
        else
        {
            return res + Math.Min(bt(index+1, 0, memo, costs), bt(index+1, 1, memo, costs));

        }
           memo.Add((index, color), res);
        return res;
    }
}