namespace LeetCode
{
    public class QuickSort
    {
        public static void QSort(int[] array, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            var pivotIndex = Partition(array, startIndex, endIndex);
            QSort(array,startIndex,pivotIndex - 1);
            QSort(array, pivotIndex + 1, endIndex);
        }

        public static int Partition(int[] array, int startIndex, int endIndex)
        {
            var pivot = array[startIndex];
            var mark = startIndex;
            for (var i = startIndex + 1; i < endIndex; i++)
            {
                if (array[i] < pivot)
                {
                    mark++;
                    var tmp = array[mark];
                    array[mark] = array[i];
                    array[i] = tmp;
                }
            }
            
            array[startIndex] = array[mark];
            array[mark] = pivot;
            return mark;
        }
    }
}