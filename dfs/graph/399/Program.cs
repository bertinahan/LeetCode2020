using System;
using System.Collections.Generic;

namespace _399
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      IList<IList<string>> equations = new List<IList<string>>
      {
          new List<string>{"x1","x2"},
          new List<string>{"x2","x3"},
          new List<string>{"x1","x4"},
          new List<string>{"x2","x5"},
      };
      var value = new double[]{3.0, 0.5, 3.4, 5.6};
      var query = new List<IList<string>>
      {
          new List<string>{"x2", "x4"},
      };
      var result = CalcEquation(equations, value, query);
      foreach(var res in result)
      Console.Write($"{res}\t");
    }

    public static double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
      var dic = new Dictionary<string, Dictionary<string, double>>();
      for (int i = 0; i < values.Length; i++)
      {
        var pair = equations[i];
        if(dic.TryGetValue(pair[0], out var ele1))
        {
          ele1.Add(pair[1], values[i]);
        }
        else
        {
          dic.Add(pair[0], new Dictionary<string, double>{{pair[1], values[i]}});
        }
        if(dic.TryGetValue(pair[1], out var ele2))
        {
          ele2.Add(pair[0], 1/values[i]);
        }
        else
        {
          dic.Add(pair[1], new Dictionary<string, double>{{pair[0], 1/values[i]}});
        }
      }
      var res = new List<double>();
      for (int i = 0; i < queries.Count; i++)
      {
        var ele1 = queries[i][0];
        var ele2 = queries[i][1];
        res.Add( dfs(ele1, ele2, new List<string>{ele1}, dic));
      }
      return res.ToArray();

    }

    public static double dfs(string ele1, string ele2, List<string> visited, Dictionary<string, Dictionary<string, double>> dic)
    {
      if(!dic.TryGetValue(ele1, out var var1) || !dic.TryGetValue(ele2, out var var2)) return -1;
      if(dic[ele1].TryGetValue(ele2, out var target)) return target;
      if(ele1.Equals(ele2)) return 1;
      visited.Add(ele1);
      foreach(KeyValuePair<string, double> division in dic[ele1])
      {
        if (visited.Contains(division.Key)) continue;
        var result = division.Value * dfs(division.Key, ele2, visited, dic);
         if(result > 0) return result;
        // return result;
      }
      return -1;
    }
  }
}
