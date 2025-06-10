namespace Algorithms.Chapter_1
{
    public class BinarySearch
    {
        public static int Search(int[] array, int value)
        {
            var start = 0;
            var end = array.Length - 1;

            while (start <= end)
            {
                int middle = (start + end) / 2;

                var kick = array[middle];

                if (kick == value)
                {
                    return middle;
                }

                if (kick < value)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }

            return -1;
        }
    }
}
