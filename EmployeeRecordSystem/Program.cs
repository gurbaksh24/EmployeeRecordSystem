using System;
using System.Collections.Generic;
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
            int empId;
            string empName,deptName,qualification,dept;
            
            Console.WriteLine("Enter Number of Employees to be Added");
            _numberOfEmp = int.Parse(Console.ReadLine());
            
            Employee []employee = new Employee[_numberOfEmp];
            emp = new Employee();
            addDepartment addDept = new addDepartment(AddDepartment);
            displayMessage dispMessage = new displayMessage(DisplayMessage);

            for (int index = 0; index < _numberOfEmp && choice.Equals("1") && !choice.Equals("exit"); index++)
            {

                Console.WriteLine("Enter Employee ID");
                empId= int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Employee Name");
                empName = Console.ReadLine();
                Console.WriteLine("Enter Qualification");
                qualification = Console.ReadLine();
                dept = addDept(qualification);
                Console.WriteLine(dispMessage(dept));
                Console.WriteLine("Press 1 to add employees\nTo Exit type exit");
                employee[index].EmpId = (int)empId;
                employee[index].EmpName = empName;
                employee[index].Qualification = qualification;
                employee[index].EmpDeptName = dept;
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
            }
            return _departmentName;
        }
    }
}
