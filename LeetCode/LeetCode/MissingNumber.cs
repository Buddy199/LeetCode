namespace LeetCode
{
    public class MissingNumber
    {
        public int MissingNumbers(int[] nums)
        {
            var arr = new int[10001];
            for (var i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                arr[num]++;
            }

            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}