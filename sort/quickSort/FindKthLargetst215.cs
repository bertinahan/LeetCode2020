public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        qsort(0, nums.Length-1, nums, k);
        return nums[nums.Length-k];
    }
    public void qsort(int lo, int hi, int[] nums, int k)
    {
        if(lo>=hi) return;
        int piv = nums[lo];
        int smallIndex = lo;
        int replaceIndex = hi;
        for(int i = lo+1; i <= replaceIndex; i++)
        {
            if(nums[i]<= piv)
                smallIndex ++;
            else
            {
                swap(i, replaceIndex, nums);
                replaceIndex --;
                i--;
            }
        }
        swap(lo, smallIndex, nums);
        if(smallIndex == nums.Length - k)
            return;
        else if (smallIndex > nums.Length - k)
        qsort(lo, smallIndex-1, nums, k);
        else
        qsort(smallIndex+1, hi, nums, k);
    }
    public void swap(int i1, int i2, int[] nums)
    {
        int tmp = nums[i1];
        nums[i1] = nums[i2];
        nums[i2] = tmp;
    }
}