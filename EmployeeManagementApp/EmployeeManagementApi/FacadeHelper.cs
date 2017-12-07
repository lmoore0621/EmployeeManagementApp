using EmployeeManagement.Database.Models.DataLogic;
using EmployeeManagement.Database.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Database
{
    public class FacadeHelper
    {
        private DataAccessLogic _dah;
        private static FacadeHelper _instance;

        public static FacadeHelper Instance
        {
            get
            {
                if (_instance == null) _instance = new FacadeHelper();
                return _instance;
            }
        }
        public Employee GetEmployee(int employeeId)
        {
            Employee emp = _dah.GetEmployee(employeeId);
            Employee employee = new Employee()
            {
                employee_Id = emp.employee_Id,
                name = emp.name,
                mobile = emp.mobile,
                date_of_birth = emp.date_of_birth,
                gender = emp.gender,
                age = emp.age,
                email = emp.email,
                education_Id = emp.education_Id,
                state_Id = emp.state_Id
            };

            return employee;
        }
    }
}