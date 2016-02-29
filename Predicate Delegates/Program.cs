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
            Employee emp4 = new Employee("Lukas", "Rolf", "Code monkey");
            Employee emp5 = new Employee("Sif", "Jensen", "CEO");

            // Create list and populate with employees
            List<Employee> empList = new List<Employee> {emp1, emp2, emp3, emp4, emp5};

            // Declare a predicate delegate that points to the function EmpSearch
            Predicate<Employee> pred = new Predicate<Employee>(EmpSearch);

            // The traditional way:
            Employee empLin = FindEmp("Lisa", empList);
            Console.WriteLine("Traditional way....");
            Console.WriteLine("Employee Found: {0}", empLin.FirstName);
            Console.WriteLine("");


            // Call Find() on the list and pass delegate as argument
            Employee emp = empList.Find(pred);

            Console.WriteLine("Using Find() on list with delegate as argument");
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

            Employee empAssistant = new Employee();
            empAssistant = empList.Find(delegate(Employee e)
            {
                if (e.Designation == "Manager")
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
            Console.WriteLine("Employee with designation 'Manager' = {0}", empAssistant.FirstName);
            Console.WriteLine("");


            // Reducing the code even further by using lambda expressions

            emp = new Employee();
            emp = empList.Find((e) => { return (e.FirstName == "Lisa"); });

            Employee empLambda = new Employee();
            empLambda = empList.Find((e) => { return (e.Designation == "Code monkey" && e.LastName == "Rolf"); });
             

            Console.WriteLine("Using lambda expressions....");
            Console.WriteLine("Employee Found: {0}", emp.FirstName);
            Console.WriteLine("Employee with designation 'Code monkey' = {0}", empLambda.FirstName);
            Console.WriteLine("");

            
            // Using FindAll() to return a collection of objects
            List<Employee> listOfEmployees = new List<Employee>();
            listOfEmployees = empList.FindAll((e) => { return (e.FirstName.Contains("i")); });

            Console.WriteLine("List of employees with the letter i in Firstname:");
            foreach (Employee e in listOfEmployees)
            {
                Console.WriteLine("{0} {1}", e.FirstName, e.LastName);
            }
            Console.WriteLine("");


            // Find all employees called Lukas Rolf that has the designation "Code Monkey"
            List<Employee> listEmp = FindAllEmp("Lukas", "Rolf", "Code monkey", empList);
            foreach (Employee e in listEmp)
            {
                Console.WriteLine("{0} {1} {2}", e.FirstName, e.LastName, e.Designation);
            }
            Console.WriteLine("");

            // A search using a lambda that return a list of employee with a given name (firstname and last name) and designation. 
            List<Employee> lambdaList = new List<Employee>();
            lambdaList = empList.FindAll((e) =>
            {
                return (e.FirstName == "Sif" &&
                        e.LastName == "Jensen" &&
                        e.Designation == "CEO");
            });
            foreach (Employee e in lambdaList)
            {
                Console.WriteLine("{0} {1} {2}", e.FirstName, e.LastName, e.Designation);
            }
            Console.WriteLine("");

            // A search to find the last employee with letter i in their name
            Employee empLast = empList.FindLast(e => e.FirstName.Contains("i"));
            Console.WriteLine("Found: {0}", empLast.FirstName);
            Console.WriteLine("");

            // Remove all employees with letter i in their name
            int removed = empList.RemoveAll(x => x.FirstName.Contains("i"));
            foreach (Employee e in empList)
            {
                Console.WriteLine("{0} {1} {2}", e.FirstName, e.LastName, e.Designation);
            }
            Console.WriteLine("{0} employees were removed", removed);
            Console.WriteLine("");



            Console.ReadKey();

        }

        private static bool EmpSearch(Employee emp)
        {
            if (emp.Designation == "CTO")
            {
                return true;
            }
            return false;
        }

        public static Employee FindEmp(string firstName, List<Employee> list)
        {
            foreach (Employee e in list)
            {
                if (e.FirstName == firstName)
                {
                    return e;
                }
            }
            return null;
        }

        // Traditional way of returning a list of objects that meet the parameters
        public static List<Employee> FindAllEmp(string firstname, string lastname, string designation, List<Employee> list)
        {
            List<Employee> collectedEmployees = new List<Employee>();
            foreach (Employee e in list)
            {
                if (e.FirstName == firstname && e.LastName == lastname && e.Designation == designation)
                {
                    collectedEmployees.Add(e);
                    return collectedEmployees;
                }
            }
            return null;
        }



         
    }
}

