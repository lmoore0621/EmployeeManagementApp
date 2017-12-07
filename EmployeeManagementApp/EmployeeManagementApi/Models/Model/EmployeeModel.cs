using EmployeeManagement.Database.Models.Model;
using System;

namespace EmployeeManagementApi.Models.Model
{
    public class EmployeeModel
    {
        public int employee_Id { get; set; }
        public string name { get; set; }
        public int mobile { get; set; }
        public System.DateTime date_of_birth { get; set; }
        public int gender { get; set; }
        public Nullable<int> age { get; set; }
        public string email { get; set; }
        public int education_Id { get; set; }
        public int state_Id { get; set; }

        public virtual EducationModel Education { get; set; }
        public virtual States USAState { get; set; }
    }
}