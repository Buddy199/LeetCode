namespace LeetCode
{
    /// <summary>
    /// 寻找数组中心索引
    /// </summary>
    public class FindArryCentralIndex
    {
        public int PivotIndex(int[] nums) {
            var sums = 0;
            var leftSum = 0;
            for(var i = 0; i < nums.Length;i++)
            {
                sums += nums[i];
            }
            for(var i = 0; i< nums.Length;i++)
            {
                if(leftSum == sums - nums[i] - leftSum)
                {
                    return i;
                }

                leftSum += nums[i];
            }
        
            return -1;
        }
    }
}