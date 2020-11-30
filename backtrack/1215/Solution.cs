public class Solution {
    public IList<int> CountSteppingNumbers(int low, int high) {
        Queue<int> que = new Queue<int>();
        IList<int> res = new List<int>();
        if(low == 0) res.Add(0);
        IList<int> res2 = new List<int>();
        if(low == 0) res2.Add(0);
        for(int i = 1; i < 10; i++)
        {
            que.Enqueue(i);
            dfs(high, low, res2, i);
        }
        //Generator(high, low, res, que);

        return res2.OrderBy(x => x).ToList();
    }

    public void Generator(int max, int min, IList<int> res, Queue<int> que)
    {
        while(que.Count > 0)
        {
            int curr = que.Dequeue();
        if(curr >= min && curr <= max)
            res.Add((int)curr);
        else if(curr > max || curr > max/10)
            return;
        int lastD = curr % 10;
        int increseNum = curr*10+(lastD+1)%10;
        int decreseNum = curr*10+((lastD-1 < 0) ? 9 : lastD-1);
            if(decreseNum <= max)
                que.Enqueue(decreseNum);
            if(increseNum <= max)
                que.Enqueue(increseNum);
        }
    }

    public void dfs(int max, int min, IList<int> res, int curr)
    {
        if(curr <= max && curr >= min)
            res.Add(curr);
        if(curr > max/10) return;

        int lastD = curr % 10;
        int increseNum = curr*10+(lastD+1)%10;
        int decreseNum = curr*10+((lastD-1 < 0) ? 9 : lastD-1);
        if(lastD != 0)
        {
            dfs(max, min, res,decreseNum);
        }
        if(lastD != 9)
        {
            dfs(max, min, res,increseNum);
        }
    }
}