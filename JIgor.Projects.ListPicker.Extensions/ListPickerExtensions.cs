using System;
using System.Collections.Generic;
using JIgor.Projects.ListPicker.Extensions.Exceptions;

namespace JIgor.Projects.ListPicker.Extensions
{
    public static class ListPickerExtensions
    {
        /// <summary>
        /// This extension allows the user to remove, randomly,
        /// any number of elements from a object instance that inherits from IEnumerable
        /// </summary>
        /// <typeparam name="T"> Generic type T </typeparam>
        /// <param name="list">Object instance that inherits from IEnumerable.</param>
        /// <param name="numberOfPicks">Number of elements that suppose to be removed from the instance of IEnumerable.</param>
        /// <returns> An updated instance of IEnumerable </returns>
        public static IEnumerable<T> RemoveRandomly<T>(this IEnumerable<T> list,
            int numberOfPicks)
            where T : notnull
        {
            if (numberOfPicks <= 0)
            {
                throw new InvalidNumberOfPicksException(
                    "Number of picks should be greater than 0");
            }

            List<T> updatedList = (List<T>) list;

            if (updatedList.Count == default)
            {
                throw new EmptyListException(
                    "List cannot be empty in this scenario");
            }

            if (updatedList.Count < numberOfPicks)
            {
                throw new InvalidNumberOfPicksException(
                    "Number of picks should not be greater than the number of elements the list object has");
            }

            Random rnd = new Random();

            for (int i = 0; i < numberOfPicks; i++)
            {
                updatedList.RemoveAt(rnd.Next(0,
                    updatedList.Count));
            }

            return updatedList;
        }

        /// <summary>
        /// This extension allows the user to remove, randomly,
        /// any number of elements from a object instance that inherits from IEnumerable.
        /// </summary>
        /// <typeparam name="T"> Generic type T </typeparam>
        /// <param name="list">Object instance that inherits from IEnumerable.</param>
        /// <param name="numberOfPicks">Number of elements that suppose to be removed from the instance of IEnumerable.</param>
        /// <param name="removalCondition">Removal condition delegate that determines whether or not the random selected element will be removed</param>
        /// <returns>An updated instance of IEnumerable.</returns>
        public static IEnumerable<T> RemoveRandomly<T>(this IEnumerable<T> list,
            int numberOfPicks, Func<T, bool> removalCondition)
            where T : notnull
        {
            if (numberOfPicks <= 0)
            {
                throw new InvalidNumberOfPicksException(
                    "Number of picks should be greater than 0");
            }

            List<T> updatedList = (List<T>)list;

            if (updatedList.Count == default)
            {
                throw new EmptyListException(
                    "List cannot be empty in this scenario");
            }

            if (updatedList.Count < numberOfPicks)
            {
                throw new InvalidNumberOfPicksException(
                    "Number of picks should not be greater than the number of elements the list object has");
            }

            Random rnd = new Random();
            List<T> visitedElements = new List<T>();

            for (int i = 0; i < numberOfPicks; i++)
            {
                T element = updatedList[rnd.Next(0, updatedList.Count)];
                visitedElements.Add(element);

                while (visitedElements.Contains(element))
                {
                    element = updatedList[rnd.Next(0, updatedList.Count)];
                    visitedElements.Add(element);
                }

                if (removalCondition(element))
                {
                    updatedList.Remove(element);
                }
            }

            return updatedList;
        }
    }
}