public class Solution
{
  public IList<int> GetRow(int rowIndex)
  {
    IList<int> res = new List<int>();
    Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();
    // Method 1, too slow
    // for(int i = 0 ; i <= rowIndex; i++)
    // {
    //    res.Add(GetNum(rowIndex, i, memo));
    // }
    res.Add(1);
    if (rowIndex == 0)
      return res;
    for (int i = 1; i <= rowIndex; i++)
    {
      res.Add(1);
      int prev = 1;
      for (int j = 1; j < i; j++)
      {
        int tmp = res[j];
        res[j] += prev;
        prev = tmp;
      }
    }
    return res;
  }
  public int GetNum(int row, int col, Dictionary<(int, int), int> memo)
  {
    if (memo.TryGetValue((row, col), out var value))
      return value;
    if (row == 0) return 1;
    if (col == 0 || col == row) return 1;
    value = GetNum(row - 1, col - 1, memo) + GetNum(row - 1, col, memo);
    memo.Add((row, col), value);
    return value;
  }
}