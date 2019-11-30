using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public enum Type { Land, Water, Air}

    public class Activity : IComparable
    {
        // properties
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Type Type { get; set; }
        public decimal Cost { get; set; }

        // constructors
        public Activity(string name, string description, DateTime date, Type type, decimal cost)
        {
            Name = name;
            Date = date;
            Type = type;
            Description = description;
            Cost = cost;
        }

        // methods
        public override string ToString()
        {
            return $"{Name} - {Date.ToShortDateString()}";
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
