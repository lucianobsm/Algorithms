namespace Algorithms.Chapter_2
{
    public class SortSelection
    {
        public static int[] Sort(int[] arr)
        {
            int arrLength = arr.Length;

            for (int i = 0; i < (arrLength - 1); i++)
            {
                var lowestIndex = i;

                for (int j = (i + 1); j < arrLength; j++)
                {
                    if (arr[j] < arr[lowestIndex])
                    {
                        lowestIndex = j;
                    }
                }

                (arr[i], arr[lowestIndex]) = (arr[lowestIndex], arr[i]);
            }

            return arr;
        }
    }
}
