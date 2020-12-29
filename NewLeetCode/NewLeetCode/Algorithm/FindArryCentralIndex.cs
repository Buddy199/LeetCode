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
        
        //寻找合适的插入索引
        public int SearchInsert(int[] nums, int target) {
            var length = nums.Length;
            var left = 0;
            var right = length - 1;
            while(left<=right)
            {
                var mid = (left + right)/2;
                if(target > nums[mid])
                {
                    left = mid+1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return left;
        }
    }
}