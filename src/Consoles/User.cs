using System;
using System.Collections.Generic;
using System.Text;

namespace Consoles
{
    public class User
    {
        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{this.Id} - {this.Name}";
        }
    }
}
