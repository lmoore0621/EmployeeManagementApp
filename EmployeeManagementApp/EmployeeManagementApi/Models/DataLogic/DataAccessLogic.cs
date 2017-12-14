using EmployeeManagement.Database.Models.Model;
using EmployeeManagementApi.Models.Model;
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

        public List<EmployeeModel> GetAllEmployees()
        {
            using (EmployeeManagementEntities db = new EmployeeManagementEntities())
            {
                List<Employee> staff = db.Employees.ToList();
                List<EmployeeModel> employees = new List<EmployeeModel>();
                for (int i = 0; i < staff.Count; i++)
                {
                    EmployeeModel emp = new EmployeeModel()
                    {
                        employee_Id = staff[i].employee_Id,
                        name = staff[i].name,
                        mobile = staff[i].mobile,
                        date_of_birth = staff[i].date_of_birth.Date,
                        gender = staff[i].gender,
                        age = (DateTime.Now - staff[i].date_of_birth.Date).Days / 365,
                        email = staff[i].email,
                        Education = new EducationModel()
                        {
                            education_Id = staff[i].Education.education_Id,
                            Degree_Type = staff[i].Education.Degree_Type
                        },
                        USAState = new States()
                        {
                            usa_state_id = staff[i].USAState.usa_state_id,
                            State = staff[i].USAState.State
                        },
                        state_Id = staff[i].USAState.usa_state_id,
                        education_Id = staff[i].education_Id
                    };

                    employees.Add(emp);
                }

                return employees;
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
        public string DeleteEmployeeInfo(int employeeId)
        {
            try
            {
                using (EmployeeManagementEntities db = new EmployeeManagementEntities())
                {
                    Employee deletedEmployee = db.Employees.FirstOrDefault(e => e.employee_Id == employeeId);
                    if (deletedEmployee != null)
                    {
                        db.Employees.Remove(deletedEmployee);
                        db.SaveChanges();
                        return "Employee has been deleted.";
                    }
                    return "Nothing Deleted";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
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
        public List<EducationModel> GetAllDegrees()
        {
            using (EmployeeManagementEntities db = new EmployeeManagementEntities())
            {
                List<EducationModel> e = new List<EducationModel>();
                List<Education> degrees = db.Educations.ToList();
                for (int i = 0; i < degrees.Count; i++)
                {
                    EducationModel em = new EducationModel()
                    {
                        education_Id = degrees[i].education_Id,
                        Degree_Type = degrees[i].Degree_Type
                    };

                    e.Add(em);
                }

                return e;
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

        public List<States> GetAllStates()
        {
            using (EmployeeManagementEntities db = new EmployeeManagementEntities())
            {
                List<States> newList = new List<States>();
                List<USAState> states = db.USAStates.ToList();
                for (int i = 0; i < states.Count; i++)
                {
                    States state = new States()
                    {
                        usa_state_id = states[i].usa_state_id,
                        State = states[i].State
                    };

                    newList.Add(state);
                }
                return newList;
            }
        }

        #endregion
    }
}