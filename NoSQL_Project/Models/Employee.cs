using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQL_Project.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public Image Photo { get; set; }
        public List<Employee> Subordinates { get; set; }

        public Employee(string name, string position, Image photo)
        {
            Name = name;
            Position = position;
            Photo = photo;
            Subordinates = new List<Employee>();
        }
    }
}
