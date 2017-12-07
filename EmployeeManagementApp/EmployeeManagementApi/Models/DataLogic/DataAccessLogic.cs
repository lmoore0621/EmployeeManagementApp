using EmployeeManagement.Database.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Database.Models.DataLogic
{
    public class DataAccessLogic
    {
        #region Employee Data Logic
        public Employee GetEmployee(int employeeId)
        {
            using (var db = new EmployeeManagementEntities())
            {
                Employee emp = db.Employees.FirstOrDefault(e => e.employee_Id == employeeId);
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
        public bool AddEmployeeInfo(Employee employee)
        {
            using (EmployeeManagementEntities db = new EmployeeManagementEntities())
            {
                Employee emp = new Employee()
                {
                    employee_Id = employee.employee_Id,
                    name = employee.name,
                    mobile = employee.mobile,
                    date_of_birth = employee.date_of_birth,
                    gender = employee.gender,
                    age = employee.age,
                    email = employee.email,
                    education_Id = employee.education_Id,
                    state_Id = employee.state_Id
                };

                db.Employees.Add(emp);
                db.SaveChanges();
                return true;
            }
        }
        public bool DeleteEmployeeInfo(int employeeId)
        {
            using (EmployeeManagementEntities db = new EmployeeManagementEntities())
            {
                Employee employee = db.Employees.FirstOrDefault(e => e.employee_Id == employeeId);

                db.Employees.Remove(employee);
                db.SaveChanges();
                return true;
            }
        }
        public bool UpdateEmployeeInfo(Employee employee)
        {
            using (EmployeeManagementEntities db = new EmployeeManagementEntities())
            {
                Employee e = db.Employees.FirstOrDefault(emp => emp.employee_Id == employee.employee_Id);
                e.name = employee.name;
                e.mobile = employee.mobile;
                e.date_of_birth = employee.date_of_birth;
                e.gender = employee.gender;
                e.age = employee.age;
                e.email = employee.email;
                e.education_Id = employee.education_Id;
                e.state_Id = employee.state_Id;

                //db.Entry(employeeToUpdate).CurrentValues.SetValues(employee);
                db.SaveChanges();
                return true;
            }
        }
        #endregion

        #region Education Data Logic
        public Education GetDegree(int degreeId)
        {
            using (EmployeeManagementEntities db = new EmployeeManagementEntities())
            {
                Education degree = db.Educations.FirstOrDefault(e => e.education_Id == degreeId);
                Education education = new Education()
                {
                    education_Id = degree.education_Id,
                    Degree_Type = degree.Degree_Type
                };

                return education;
            }
        }
        public List<Education> GetAllDegrees()
        {
            using (EmployeeManagementEntities db = new EmployeeManagementEntities())
            {
                List<Education> degrees = db.Educations.ToList();

                return degrees;
            }
        }
        #endregion

        #region States Data Logic

        public USAState GetState(int stateId)
        {
            using (EmployeeManagementEntities db = new EmployeeManagementEntities())
            {
                USAState state = db.USAStates.FirstOrDefault(s => s.usa_state_id == stateId);
                USAState usaState = new USAState()
                {
                    usa_state_id = state.usa_state_id,
                    State = state.State
                };
                return usaState;
            }
        }

        public List<USAState> GetAllStates()
        {
            using (EmployeeManagementEntities db = new EmployeeManagementEntities())
            {
                List<USAState> newList = new List<USAState>();
                List<USAState> states = db.USAStates.ToList();
                for (int i = 0; i < states.Count; i++)
                {
                    USAState state = new USAState()
                    {
                        usa_state_id = states[i].usa_state_id,
                        State = states[i].State
                    };

                    newList.Add(state);
                }
                return states;
            }
        }

        #endregion
    }
}