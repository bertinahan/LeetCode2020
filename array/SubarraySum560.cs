/**
Given an array of integers nums and an integer k, return the total number of continuous subarrays whose sum equals to k.
Example 1:

Input: nums = [1,1,1], k = 2
Output: 2
Example 2:

Input: nums = [1,2,3], k = 3
Output: 2
Constraints:

1 <= nums.length <= 2 * 104
-1000 <= nums[i] <= 1000
-107 <= k <= 107
**/
package array;

public class SubarraySum {
  public static void Main(string[] args)
  {

  }
  public int subArraySum(int[] arr, int k)
  {
    int result = 0;
    int currentSum = 0;
    Dictionary<int, int> map = new Dictionary<int, int>(){{0, 1}};
    foreach(int num in arr)
    {
      currentSum += num;
      if(map.TryGetValue(currentSum-k) out var count)
      {
        result += count;
      }
      map[currentSum] = map.GetOrDefaultValue(currentSum, 0)++;
    }
  }
}
