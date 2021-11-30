using System;
using System.Collections.Generic;
using System.Linq;
using JIgor.Projects.ListPicker.Samples.SampleObjects;

namespace JIgor.Projects.ListPicker.Samples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var picker = new ListPicker();

            for (int i = 0; i < 10; i++)
            {
                var myList = new List<User>()
                {
                    new User(1, "Manning"),
                    new User(2, "Igor"),
                    new User(4, "Igor"),
                    new User(5, "Brady"),
                    new User(6, "Manning"),
                    new User(7, "Favre"),
                    new User(8, "Manning"),
                };

                // var removedValues = picker.Pick(myList, 1);

                var removedValues = picker.PickElements(myList, 6, p => (p.Id == 5 || p.Name == "Favre" || p.Name == "Manning"));

                // var newList = myList.RemoveRandomly(4, p => p.Id == 2);

                // newList.ToList().ForEach(p => Console.WriteLine(p.ToString()));
                removedValues.ToList().ForEach(p => Console.WriteLine(p.ToString()));

                // Console.WriteLine(newList.Count());
                Console.WriteLine("-----------------");
            }
        }
    }
}
