using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace EmployeeRecordSystem
{
    public delegate string displayMessage(string message);
    public delegate string addDepartment(string dept);
    class EmptyDepartment:Exception
    {
        public EmptyDepartment(string message) : base(message) { }
    }
    class Program
    {
        static int _numberOfEmp;
        static Employee emp;
        static string filePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\log.txt";
    
        public static string DisplayMessage(string departmentName)
        {
            string displayMessage="";
            if (departmentName.Equals("IT"))
                displayMessage= "Employee added under IT department";
            else if(departmentName.Equals("Accounts"))
                displayMessage= "Employee added under Accounts department";
            return displayMessage;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("-----------------Employee Record System------------------");
            AddEmployee();
        }

        private static void AddEmployee()
        {
            string choice = "1";
            
            Console.WriteLine("Enter Number of Employees to be Added");
            _numberOfEmp = int.Parse(Console.ReadLine());
            
            emp = new Employee();
            addDepartment addDept = new addDepartment(AddDepartment);
            displayMessage dispMessage = new displayMessage(DisplayMessage);

            Employee[] employee = new Employee[_numberOfEmp];
            for (int index = 0; index < _numberOfEmp && choice.Equals("1") && !choice.Equals("exit"); index++)
            {
                employee[index] = new Employee();
                Console.WriteLine("Enter Employee ID");
                employee[index].EmpId= int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Employee Name");
                employee[index].EmpName = Console.ReadLine();
                Console.WriteLine("Enter Qualification");
                employee[index].Qualification = Console.ReadLine();
                employee[index].EmpDeptName = addDept(employee[index].Qualification);
                Console.WriteLine(dispMessage(employee[index].EmpDeptName));
                Console.WriteLine("Press 1 to add employees\nTo Exit type exit");
                choice = Console.ReadLine();
            }

        }
        private static string AddDepartment(string qualification)
        {
            string _departmentName = "";
            try
            {
                if (qualification.Equals("BE") || qualification.Equals("BCA") || qualification.Equals("BSC"))
                    _departmentName = "IT";
                else if (qualification.Equals("BCom") || qualification.Equals("MCom") || qualification.Equals("CA"))
                    _departmentName = "Accounts";
                else
                    throw new EmptyDepartment("Qualification Can't Be Empty");

            }
            catch (EmptyDepartment e)
            {
                Console.WriteLine(e.Message);
                using(StreamWriter streamWriter=new StreamWriter(filePath,true))
                {
                    streamWriter.WriteLine("Exception:" + e.Message + "\n Stack Trace:"+e.StackTrace);
                }
            }
            finally
            {
                Console.WriteLine("Please enter a valid qualification");
            }
            return _departmentName;
        }
    }
}
