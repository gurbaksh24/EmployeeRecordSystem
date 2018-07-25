using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeRecordSystem
{
    class Employee
    {
        public int _empId;
        string _empName;
        string _empDeptName;
        string _qualification;

        public string Qualification
        {
            get { return _qualification; }
            set { _qualification = value; }
        }
        public int EmpId
        {
            get { return _empId; }
            set { _empId = value; }
        }
        public string EmpName
        {
            get { return _empName; }
            set { _empName = value; }
        }
        public string EmpDeptName
        {
            get { return _empDeptName; }
            set { _empDeptName = value; }
        }
        
           
    }
}
