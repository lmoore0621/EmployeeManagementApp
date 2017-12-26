using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EmployeeManagementApi.Models.Model;
using EmployeeManagementApi.Models.Services;

namespace EmployeeManagement.NUnitTests
{
    [TestFixture]
    public class EmployeeManagementTests
    {
        [Test]
        public void GetGenderCountTest()
        {
            int expected = 1;
            int expectedTwo = 2;

            //Get employees from Data Source
            IEnumerable<EmployeeModel> employees = GetEmployeesFromDataSource();

            //Determine how many employees are of each gender
            IEmployeeService service = new EmployeeService();
            EmployeeGenderCount genderCount = service.GetEmployeeGenderCount(employees);

            //Test our case
            Assert.AreEqual(expected, genderCount.MaleCount);
            Assert.AreEqual(expectedTwo, genderCount.FemaleCount);
        }

        #region Helper Methods

        public IEnumerable<EmployeeModel> GetEmployeesFromDataSource()
        {
            //Imagine these employee objects are coming from the database
            IEnumerable<EmployeeModel> employees = new List<EmployeeModel>()
            {
                //Create 2 Female Employees
                new EmployeeModel { name = "Jessica Mortimer", gender_id = 2 },
                new EmployeeModel { name = "Jane Doe", gender_id = 2 },

                //Create 1 Male Employee
                new EmployeeModel { name = "Jonathan Mortimer", gender_id = 1 }

            };

            return employees;
        }

        #endregion
    }
}
