namespace Algorithms.Chapter_4
{
    public class QuickSort
    {
        public static List<int> Sort(List<int> list)
        {
            if (list.Count <= 1) return list;

            int pivot = list[0];
            List<int> less = [];
            List<int> greater = [];

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] <= pivot)
                {
                    less.Add(list[i]);
                }
                else
                {
                    greater.Add(list[i]);
                }
            }

            return [.. Sort(less), pivot, .. Sort(greater)];
        }
    }
}
