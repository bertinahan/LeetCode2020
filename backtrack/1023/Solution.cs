public class Solution {
    public IList<bool> CamelMatch(string[] queries, string pattern) {
      IList<bool> res = new List<bool>();
      char[] patternArr = pattern.ToCharArray();
      foreach (string query in queries)
      {
        int posP = 0;
        if (query.Length < pattern.Length)
        {
            res.Add(false);
            continue;
        }
        char[] queryArr = query.ToCharArray();
        bool isValid = true;
        for (int i = 0; i < queryArr.Length; i++)
        {
          if (Char.IsUpper(queryArr[i]))
          {
            if (posP >= pattern.Length)
            {
              isValid = false;
              break;
            }
            else if (pattern[posP] != queryArr[i])
            {
              isValid = false;
              break;
            }
            else
            {
              posP++;
            }
          }
          else if(posP < pattern.Length && pattern[posP] == queryArr[i]) posP ++;
        }
        if (isValid && posP >= pattern.Length) res.Add(true);
        else res.Add(false);
      }
        IList<bool> res2 = new List<bool>();
        foreach(string query in queries)
        {
            if(query.Length < pattern.Length) res2.Add(false);
            else
              res2.Add(bt(query, pattern));
        }
      return res2;
    }

    public bool bt(string query, string pattern)
    {
        if(string.IsNullOrEmpty(pattern))
        {
            if(!string.IsNullOrEmpty(query))
            {
                foreach(char a in query.ToCharArray())
                {
                    if(Char.IsUpper(a)) return false;
                }
            }
            return true;
        }
        if(string.IsNullOrEmpty(query)) return false;
        if(query[0] == pattern[0])
        {
            // get rid of first ele
            var newQ = query.Length > 1 ? query.Substring(1) : string.Empty;
            var newP = pattern.Length > 1 ? pattern.Substring(1) : string.Empty;
            return bt(newQ,newP);
        }
        else if (Char.IsLower(query[0]))
        {
            var newQ = query.Length > 1 ? query.Substring(1) : string.Empty;
            return bt(newQ, pattern);
        }
        else return false;
    }
}
