public class Solution {
    public string[] Expand(string S) {
        IList<string> res = new List<string>();
        bt(0, S, new List<char>(), res);
        var final = res.OrderBy(s => s).ToArray();
        return final;
    }

    public void bt(int index, string s, IList<char> curr, IList<string> result)
    {
        if(index == s.Length)
        {
            result.Add(new string(curr.ToArray()));
            return;
        }
        if(s[index] == '{')
        {
           int point = index+1;
            string tmp = string.Empty;
            while(s[point]!='}')
            {
               if(s[point]!=',')
                   tmp += s[point];
                point++;
            }
            foreach(var c in tmp)
            {
               curr.Add(c);
                bt(point+1, s, new List<char>(curr), result);
                curr.RemoveAt(curr.Count-1);
            }
        }
        else
        {
            curr.Add(s[index]);
           bt(index+1, s, curr, result);
        }
    }
}