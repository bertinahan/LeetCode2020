public class Solution {
    public IList<IList<int>> Generate(int numRows) {

        IList<IList<int>> res = new List<IList<int>>();
        if(numRows == 0) return res;
        res.Add(new List<int>{1});
        if(numRows == 1) return res;
        for(int row = 1; row < numRows; row++)
        {
            var rowVal = new List<int>();
            var store = new LinkedList<int>();
           for(int col = 0; col <= (row)/2; col++)
           {
               if(col == 0)
               {
                   rowVal.Add(1);
                   store.AddFirst(1);
               }
               else
               {
                   var val = res[row-1][col-1]+res[row-1][col];
                   rowVal.Add(val);
                   if(col != row/2 || row%2 == 1)
                       store.AddFirst(val);
               }

           }
            rowVal.AddRange(store);
            res.Add(rowVal);
        }
        return res;
    }
}