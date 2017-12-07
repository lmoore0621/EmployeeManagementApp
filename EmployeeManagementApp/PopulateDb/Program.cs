using EmployeeManagementApp.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateDb
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Add 1k Employees
            //using (EmployeeManagementEntities db =  new EmployeeManagementEntities())
            //{
            //    Employee employee;
            //    Random rdm;

            //    for (int i = 0; i < 1000; i++)
            //    {
            //        employee = new Employee();
            //        rdm = new Random();

            //        employee.name = $"name: {i}";
            //        employee.mobile = rdm.Next(111111111, 999999999);
            //        employee.date_of_birth = DateTime.Now;
            //        employee.gender = rdm.Next(1, 2);
            //        employee.age = i;
            //        employee.email = $"email:{i}@gmail.com";
            //        employee.education_Id = rdm.Next(1,4);
            //        employee.state_Id = rdm.Next(1,35);

            //        db.Employees.Add(employee);
            //    }
            //    db.SaveChanges();
            //    Console.WriteLine("You added 1000 names to the Database");
            //    Console.ReadLine();
            //}
            #endregion
        }
    }
}
