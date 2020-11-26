public class Solution {
    public IList<int> KillProcess(IList<int> pid, IList<int> ppid, int kill) {
        //build a tree

        IDictionary<int, IList<int>> tree = new Dictionary<int, IList<int>>();
        int head = 0;
        for(int i = 0; i < ppid.Count; i++)
        {
            if(ppid[i] == 0)
            {
                head = pid[i];
                continue;
            }
            if(tree.TryGetValue(ppid[i], out var parentId))
            {
                parentId.Add(pid[i]);
            }
            else
            {
                tree.Add(ppid[i], new List<int>{pid[i]});
            }
        }
        // dfs on tree to find node to kill
        Stack stack = new Stack();
        stack.Push(kill);
        IList<int> res = new List<int>();
        while(stack.Count > 0)
        {
            int list = (int)stack.Pop();
            res.Add(list);
            if(tree.TryGetValue(list, out var subArr))
            {
                foreach(int sub in subArr)
                {
                    stack.Push(sub);
                }
            }

        }
        return res;
    }

}