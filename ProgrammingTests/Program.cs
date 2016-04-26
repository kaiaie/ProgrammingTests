using System;
using System.Linq;
using Data;
using Data.Interfaces;
using System.Text;

namespace ProgrammingTests
{
    public class Program
    {
        private static ITestRepository _testRepository; 

        private static void Main(string[] args)
        {
            // instantiate the Test Repo
            _testRepository = new TestRepository();

            /*
             * Object Model redesign and implementation tasks
             * 
             * 1. Read through the object model and data used to create our test repository DONE
             * 2. Write an abstract class from which IrishCompany, SoleTrader and ForeignCompany will inherit DONE
             * 3. Write an Interface for the Address Class, implement it and refactor 
             *    all classes which require an address to use the new interface instead. DONE
             * 4. Implement FindAllCompanies method in Test Repository DONE
             * 5. Implement NumberOfYearsEmployed property on Employment. DONE
             */

            /*
             *  Linq queries and Algorithms
             * 
             * 1. Get Count of all Companies(Sole traders, Irish and Foreign Companies) in the "Database"
             * 2. Write a linq query to find all Employees still employed by Company "Irish1" and write out their names
             * 3. Write a query to find the total number of years that all employees (still employed or not) have worked.               
             * 
             * 4. Implement the FizzBuzz method below exactly to requirements
             * 5. Implement ReverseWords to requirements, taking case that it 
             *    doesn't fail for any of the cases in TestAlgorithms
             * 
             */

            TestAlgorithms();
            TestLinqQueries();
        }

        public static void TestLinqQueries()
        {
            // 1. Get Count of all Companies(Sole traders, Irish and Foreign Companies) in the "Database"
            Console.WriteLine(_testRepository.FindAllCompanies().Count);
            // 2. Write a linq query to find all Employees still employed by Company "Irish1" and write out their names
            var company = _testRepository.FindAllCompanies().FirstOrDefault(c => c.Name == "Irish1");
            if (company != null)
            {
                foreach (var emp in company.Employments.Where(e => !e.EmploymentEndDate.HasValue || e.EmploymentEndDate.Value > DateTime.Now))
                {
                    Console.WriteLine(emp.Employee.Name);
                }
            }

            // 3. Write a query to find the total number of years that all employees(still employed or not) have worked.
            Console.WriteLine(company.Employments.Sum(e => e.NumberOfYearsEmployed));
        }

        public static void TestAlgorithms()
        {
            FizzBuzz();
            Console.ReadLine();

            ReverseWords("This is a programming test");
            Console.ReadLine();

            ReverseWords("");
            Console.ReadLine();

            ReverseWords(null);
            Console.ReadLine();

        }


        /// <summary>
        /// </summary>
        public static void FizzBuzz()
        {
            /*
                Fizz Buzz
             * 
             * using an array from 1 - 100
             * 
             * Print the word "Fizz" for each multiple of 3
             * Print the word "Buzz" for each multiple of 5
             * Print the word "FizzBuzz" for each multiple of 3 & 5
             * else print the number
             * 
             */
            var result = new StringBuilder();
            foreach (var value in Enumerable.Range(1, 100))
            {
                result.Clear();
                if ((value % 3 == 0) || (value % 5 == 0))
                {
                    if ((value % 3) == 0)
                    {
                        result.Append("Fizz");
                    }
                    if ((value % 5) == 0)
                    {
                        result.Append("Buzz");
                    }
                }
                else
                {
                    result.Append(value);
                }
                Console.WriteLine(result.ToString());
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sentence"></param>
        public static string ReverseWords(string sentence)
        {
            /*
             * write a function to reverse the words in a string which 
             * does not use a framework reverse method
             * 
             * should test for nulls, empty string etc
             * 
             * Bonus Points if you can write this as an Extension Method
             */
            var result = sentence.ReverseWords();
            Console.WriteLine(result);
            return result;
        }
    }
}