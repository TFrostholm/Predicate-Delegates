using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicate_Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee("John", "Doe", "Manager");
            Employee emp2 = new Employee("Lisa", "Manelli", "Assistant");
            Employee emp3 = new Employee("Niels", "Larsen", "CTO");

            List<Employee> empList = new List<Employee> {emp1, emp2, emp3};


        }
    }
}
