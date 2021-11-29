using System;
using System.Collections.Generic;
using System.Linq;
using JIgor.Projects.ListPicker.Extensions;


namespace Consoles
{
    public class Program
    {
        public static void Main(string[] args)
        {


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


                var newList = myList.RemoveRandomly(4, p => p.Id == 2);

                newList.ToList().ForEach(p => Console.WriteLine(p.ToString()));

                // Console.WriteLine(newList.Count());
                Console.WriteLine("-----------------");
            }
        }
    }
}
