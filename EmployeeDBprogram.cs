//////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Shawn Wu, TINFO-200A,Programming II for ITS
// EmployeeDB assignment - Employee Class program.
// This assignment has the following purpose: It will show the use of 
//  instance variables , as well as demostrate the use of multiple classes
///////////////////////////////////////////////////////////////////////////////////////////
// Change History
// Date         Developer        Description
// 2022-02-11   ShawnW           Some description having to do with the creation and use of this file.
// 2022-02-11   ShawnW           Creation of test driver program.
// 2022-02-11   ShawnW           Created 3 different employees.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB
{
    internal class Program
    {

        // Main
        static void Main(string[] args)
        {
            Console.WriteLine(@"
*****************************************************
       Welcome to the AI Teacher program!
*****************************************************
This app will generate 3 different employees and display
their salary after a 10% raise. 
");

            // 3 employees

            Employee employee1 = new Employee("Mike", "Burg", (decimal)5000.99);
            Employee employee2 = new Employee("Tom", "Brady", (decimal)-1900.11);
            Employee employee3 = new Employee("Kevin", "Hart", (decimal)9200.19);


            Console.WriteLine("Employee 1 First Name: {0}", employee1.FirstName);
            Console.WriteLine("Employee 1 Last Name: {0}", employee1.LastName);
            Console.WriteLine("Employee 1 Monthly Salary: {0}", employee1.Salary);

            Console.WriteLine("Employee 2 First Name: {0}", employee2.FirstName);
            Console.WriteLine("Employee 2 Last Name: {0}", employee2.LastName);
            Console.WriteLine("Employee 2 Monthly Salary: {0}", employee2.Salary);

            Console.WriteLine("Employee 3 First Name: {0}", employee3.FirstName);
            Console.WriteLine("Employee 3 Last Name: {0}", employee3.LastName);
            Console.WriteLine("Employee 3 Monthly Salary: {0}", employee3.Salary);

            // The 10% raise

            Console.WriteLine();
            Console.WriteLine("After 10% raise");
            Console.WriteLine();

            // Calculation formula

            employee1.Salary = employee1.Salary * (decimal)1.1;
            employee2.Salary = employee2.Salary * (decimal)1.1;
            employee3.Salary = employee3.Salary * (decimal)1.1;

            Console.WriteLine("Employee 1 new Salary: {0:C}", employee1.Salary);
            Console.WriteLine("Employee 2 new Salary: {0:C}", employee2.Salary);
            Console.WriteLine("Employee 3 new Salary: {0:C}", employee3.Salary);


            Console.ReadLine();
        }
    }
}
