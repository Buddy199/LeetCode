//寻找两个有序数组的中位数，第一个数组中有m个数，第二个数组中有n个数，假设两个数组不同时为空
//两个有序数组求中位数，问题一般化为，求两个有序数组的第k个数，当k = (m+n)/2时为原问题的解。
//怎么求第k个数？分别求出第一个和第二个数组的第 k / 2个数 a 和 b，然后比较 a 和 b。
//当a < b ，说明第 k 个数位于 a数组的第 k / 2个数后半段，或者b数组的 第 k / 2 个数前半段，问题规模缩小了一半，然后递归处理就行。
//时间复杂度是 O(log(m+n))

using System;

namespace ConsoleApplication1
{
    public class FindTwoSortedArrayMidNumber
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int m = nums1.Length;
            int n = nums2.Length;

            if (m == 0)
            {
                if (n % 2 != 0)
                    return 1.0 * nums2[n / 2];
                return (nums2[n / 2] + nums2[n / 2 - 1]) / 2.0;
            }
            
            if (n == 0)
            {
                if (m % 2 != 0)
                    return 1.0 * nums1[m / 2];
                return (nums1[m / 2] + nums1[m / 2 - 1]) / 2.0;
            }

            int total = m + n;
            if ((total & 1) == 1)
            {
                return FindKNumber(nums1, 0, nums2, 0, total / 2 + 1);
            }

            return (FindKNumber(nums1, 0, nums2, 0, total / 2) + FindKNumber(nums1, 0, nums2, 0, total / 2 + 1)) / 2.0;
        }

        private static double FindKNumber(int[] a, int aBegin, int[] b, int bBegin, int k)
        {
            //当a或者b超过数组长度，则第k个数为另外一个数组的第k个数
            if (aBegin >= a.Length)
            {
                return b[bBegin + k - 1];
            }

            if (bBegin >= b.Length)
            {
                return a[aBegin + k - 1];
            }
            
            //当k为1时，第k个数是两个数组第一个数中最小的
            if (k == 1)
            {
                return Math.Min(a[aBegin], b[bBegin]);
            }
            
            //midA和midB分别表示数组a和数组b中的第k/2个数
            int midA = Int32.MaxValue;
            int midB = Int32.MaxValue;
            if (aBegin + k / 2 - 1 < a.Length)
            {
                midA = a[aBegin + k / 2 - 1];
            }

            if (bBegin + k / 2 - 1 < b.Length)
            {
                midB = b[bBegin + k / 2 - 1];
            }
            
            //如果a数组的第 k / 2 个数小于b数组的第 k / 2 个数，表示总的第 k 个数位于 a的第k / 2个数的后半段，或者是b的第 k / 2个数的前半段
            //由于范围缩小了 k / 2 个数，此时总的第 k 个数实际上等于新的范围内的第 k - k / 2个数，依次递归
            if (midA < midB)
            {
                return FindKNumber(a, aBegin + k / 2, b, bBegin, k - k / 2);
            }

            return FindKNumber(a, aBegin, b, bBegin + k / 2, k - k / 2);

        }
    }
}