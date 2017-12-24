using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeManagementApi.Models.Model;

namespace EmployeeManagementApi.Models.Services
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeGenderCount GetEmployeeGenderCount(IEnumerable<EmployeeModel> employees)
        {
            //Get gender count for employees
            EmployeeGenderCount genderCount = new EmployeeGenderCount();

            //Get the amount of employees that are male
            genderCount.MaleCount = employees.Count(emp => emp.gender_id == 1);

            //Get the amount of employees that are female
            genderCount.FemaleCount = employees.Count(emp => emp.gender_id == 2);


            return genderCount;
        }
    }
}