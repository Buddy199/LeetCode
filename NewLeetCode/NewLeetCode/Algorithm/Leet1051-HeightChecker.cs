namespace LeetCode
{
    public class Leet1051_HeightChecker
    {
        public int HeightChecker(int[] heights)
        {
            var newHeights = new int[heights.Length];
            for (var i = 0; i < heights.Length; i++)
            {
                newHeights[i] = heights[i];
            }
            
            for (var i = 0; i < heights.Length; i++)
            {
                for (var j = 0; j < heights.Length - i - 1; j++)
                {
                    if (heights[j] > heights[j+1])
                    {
                        var temp = heights[j];
                        heights[j] = heights[j + 1];
                        heights[j + 1] = temp;
                    }
                }
            }

            var step = 0;
            for (var i = 0; i < newHeights.Length; i++)
            {
                if (heights[i] != newHeights[i])
                {
                    step++;
                }
            }

            return step;
        }
    }
}