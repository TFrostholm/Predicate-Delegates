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
            // Declare employees
            Employee emp1 = new Employee("John", "Doe", "Manager");
            Employee emp2 = new Employee("Lisa", "Manelli", "Assistant");
            Employee emp3 = new Employee("Niels", "Larsen", "CTO");

            // Create list and populate with employees
            List<Employee> empList = new List<Employee> {emp1, emp2, emp3};

            // Declare a predicate delegate that points to the function EmpSearch
            Predicate<Employee> pred = new Predicate<Employee>(EmpSearch);

            // Call Find() on the list and pass delegate as argument
            Employee emp = empList.Find(pred);

            Console.WriteLine("Traditional way....");
            Console.WriteLine("Employee Found: {0}", emp.FirstName);
            Console.WriteLine("");


            // A better way: Using anonymous functions

            emp = new Employee();
            emp = empList.Find(delegate(Employee e)
            {
                if (e.FirstName == "Lisa")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });

            Console.WriteLine("Using anonymous functions....");
            Console.WriteLine("Employee Found: {0}", emp.FirstName);
            Console.WriteLine("");


            // Reducing the code even further by using lambda expressions

            emp = new Employee();
            emp = empList.Find((e) => { return (e.FirstName == "Lisa"); });

            Console.WriteLine("Using lambda expressions....");
            Console.WriteLine("Employee Found: {0}", emp.FirstName);
            Console.WriteLine("");

            
            // Using FindAll() to return a collection of objects

            List<Employee> employees = new List<Employee>();
            employees = empList.FindAll((e) => { return (e.FirstName.Contains("i")); });

            // Prints the result:
            Console.WriteLine("List of employees with the letter i in Firstname:");
            foreach (Employee e in employees)
            {
                Console.WriteLine("{0} {1}", e.FirstName, e.LastName);
            }

            Console.ReadKey();

        }

        private static bool EmpSearch(Employee emp)
        {
            if (emp.FirstName == "Lisa")
            {
                return true;
            }
            return false;
        }
    }
}

