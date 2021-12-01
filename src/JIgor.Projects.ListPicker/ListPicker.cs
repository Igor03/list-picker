using JIgor.Projects.ListPicker.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace JIgor.Projects.ListPicker
{
    public class ListPicker
    {
        /// <summary>
        /// This extension allows the user to remove, randomly,
        /// any number of elements from a object instance that inherits from IEnumerable
        /// </summary>
        /// <typeparam name="T"> Generic type T </typeparam>
        /// <param name="list">Object instance that inherits from IEnumerable.</param>
        /// <param name="numberOfPicks">Number of elements that suppose to be removed from the instance of IEnumerable.</param>
        /// <returns> An updated instance of IEnumerable </returns>
        public IEnumerable<T> PickElements<T>([NotNull] IEnumerable<T> list,
            int numberOfPicks)
            where T : notnull
        {
            if (numberOfPicks <= 0)
            {
                throw new InvalidNumberOfPicksException(
                    "Number of picks should be greater than 0");
            }

            List<T> castedList = (List<T>) list;

            if (castedList.Count == default)
            {
                throw new EmptyListException(
                    "List cannot be empty in this scenario");
            }

            if (castedList.Count < numberOfPicks)
            {
                throw new InvalidNumberOfPicksException(
                    "Number of picks should not be greater than the number of elements the list object has");
            }

            Random rnd = new Random();
            List<T> removedElements = new List<T>();

            for (int i = 0; i < numberOfPicks; i++)
            {
                T element = castedList[rnd.Next(0,
                    castedList.Count)];

                removedElements.Add(element);

                castedList.Remove(element);

            }

            return removedElements;
        }

        /// <summary>
        /// This extension allows the user to remove, randomly,
        /// any number of elements from a object instance that inherits from IEnumerable.
        /// </summary>
        /// <typeparam name="T"> Generic type T </typeparam>
        /// <param name="list">Object instance that inherits from IEnumerable.</param>
        /// <param name="numberOfPicks">Number of elements that suppose to be removed from the instance of IEnumerable.</param>
        /// <param name="pickCondition">Removal condition delegate that determines whether or not the random selected element will be removed</param>
        /// <returns>An updated instance of IEnumerable.</returns>
        public IEnumerable<T> PickElements<T>([NotNull] IEnumerable<T> list,
            int numberOfPicks,
            [NotNull] Func<T, bool> pickCondition)
            where T : notnull
        {
            if (numberOfPicks <= 0)
            {
                throw new InvalidNumberOfPicksException(
                    "Number of picks should be greater than 0");
            }

            List<T> castedList = (List<T>) list;

            if (castedList.Count == default)
            {
                throw new EmptyListException(
                    "List cannot be empty in this scenario");
            }

            if (castedList.Count < numberOfPicks)
            {
                throw new InvalidNumberOfPicksException(
                    "Number of picks should not be greater than the number of elements the list object has");
            }

            Random rnd = new Random();
            List<T> pickedElements = new List<T>();
            List<T> visitedElements = (List<T>) CopyList(castedList);

            while (visitedElements.Count > 0 && numberOfPicks != pickedElements.Count)
            {
                T element = castedList[rnd.Next(0,
                    castedList.Count)];

                if (pickCondition(element))
                {
                    pickedElements.Add(element);
                    castedList.Remove(element);
                }

                visitedElements.Remove(element);
            }

            return pickedElements;
        }

        [ExcludeFromCodeCoverage]
        private IEnumerable<T> CopyList<T>(List<T> sourceList)
        {
            List<T> elements = new List<T>();

            foreach (T element in sourceList)
            {
                elements.Add(element);
            }

            return elements;
        }
    }
}