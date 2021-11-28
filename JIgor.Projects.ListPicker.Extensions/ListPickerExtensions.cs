using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JIgor.Projects.ListPicker.Extensions.Exceptions;
using static JIgor.Projects.ListPicker.Extensions.ListPickerHelper;

namespace JIgor.Projects.ListPicker.Extensions
{
    public static class ListPickerExtensions
    {
        public static IEnumerable<T> RemoveRandomly<T>(this IEnumerable list, int numberOfPicks) 
            where T : IEnumerable
        {
            if (numberOfPicks <= 0)
            {
                throw new InvalidNumberOfPicksException("Number of picks should be greater than 0");
            }
            
            List<T> newList = list.Cast<T>().ToList();

            if (newList.Count == 0)
            {
                throw new EmptyListException("List cannot be empty in this scenario");
            }
            
            int[] indexesArray = GetRandomIndexes(newList.Count, numberOfPicks);

            foreach (int index in indexesArray)
            {
                newList.RemoveAt(index);
            }

            return newList;
        }
    }
}
