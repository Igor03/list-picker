using System;
using System.Linq;

namespace JIgor.Projects.ListPicker.Extensions
{
    public static class ListPickerHelper
    {
        public static int[] GetRandomIndexes(int listSize, int numberOfIndexes)
        {
            var rnd = new Random();
            var indexesArray = new int[numberOfIndexes];

            for (int i = 0; i < numberOfIndexes; i++)
            {
                var newValue = rnd.Next(0, listSize);

                if (indexesArray.Contains(newValue)) continue;

                indexesArray[i] = newValue;
            }

            return indexesArray;
        }
    }
}
