using EmployeeManagementApp.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmployeeManagementApp.DataSource.Employee;

namespace EmployeeManagementApp.Data
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Add Employee
            //using (EmployeeManagementEntities db = new EmployeeManagementEntities())
            //{
            //    Employee employee = new Employee()
            //    {
            //        name = "Leon Moore",
            //        mobile = 6473160,
            //        date_of_birth = new DateTime(1990, 06, 21),
            //        gender = Gender.Male.GetHashCode(),
            //        age = 27,
            //        email = "lmoore0621@gmail.com",
            //        education_Id = 1,
            //        state_Id = 32
            //    };

            //    Employee employee = new Employee()
            //{
            //    name = "Jaimie Gonzalez",
            //    mobile = 421434,
            //    date_of_birth = new DateTime(1993, 10, 30),
            //    gender = Gender.Male.GetHashCode(),
            //    age = 24,
            //    email = "Jaime.Gonzalez@infosys.com",
            //    education_Id = 1,
            //    state_Id = 13
            //};

            //    Employee employee = new Employee()
            //    {
            //        name = "Jaimie Gonzalez",
            //        mobile = 421434,
            //        date_of_birth = new DateTime(1993, 10, 30),
            //        gender = Gender.Male.GetHashCode(),
            //        age = 24,
            //        email = "Jaime.Gonzalez@infosys.com",
            //        education_Id = 1,
            //        state_Id = 13
            //    };


            //    db.Employees.Add(employee);
            //    db.SaveChanges();
            //    Console.WriteLine($"Employee {employee.name} added");
            //    Console.ReadLine();
            //}
            #endregion

            #region GET Employee
            //using (EmployeeManagementEntities db = new EmployeeManagementEntities())
            //{
            //    Employee employee = db.Employees.FirstOrDefault(e => e.employee_Id == 1);
            //    Console.WriteLine($"Name: {employee.name}\nMobile: {employee.mobile}\nDOB: {employee.date_of_birth}\nGender: {Gender.Male}\nAge: {employee.age}\nEducation: {employee.education_Id.ToString()}\nState: {employee.state_Id.ToString()}");
            //    Console.ReadLine();
            //}
            #endregion

            #region Add Degree

            //using (EmployeeManagementEntities db = new EmployeeManagementEntities())
            //{
            //    Education education = new Education
            //    {
            //        Degree_Type = "B.S"
            //    };

            //    db.Educations.Add(education);
            //    db.SaveChanges();
            //    Console.WriteLine($"Education {education.Degree_Type} added");
            //    Console.ReadLine();
            //}

            #endregion

            #region Update Employee

            //using (EmployeeManagementEntities db = new EmployeeManagementEntities())
            //{
            //    Employee employee = db.Employees.FirstOrDefault(e => e.employee_Id == 3);

            //    employee.name = "Anthony Ramoslebron";
            //    employee.mobile = 3274928;
            //    employee.date_of_birth = new DateTime(1990, 05, 17);
            //    employee.gender = Gender.Female.GetHashCode();
            //    employee.age = 27;
            //    employee.email = "Anthony.Ramos@Infosys.com";
            //    employee.education_Id = 2;
            //    employee.state_Id = 7;

            //    db.SaveChanges();
            //    Console.WriteLine($"Employee {employee.name} Updated");
            //    Console.ReadLine();
            //}

            #endregion

            #region Delete Employee

            //using (EmployeeManagementEntities db = new EmployeeManagementEntities())
            //{
            //    Employee employee = db.Employees.FirstOrDefault(e => e.employee_Id == 2);

            //    db.Employees.Remove(employee);
            //    db.SaveChanges();

            //    Console.WriteLine($"You deleted {employee.name} from the database.");
            //    Console.ReadLine();
            //}

            #endregion
        }
    }
}
