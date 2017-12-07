using System.Collections.Generic;

namespace EmployeeManagement.Api.Models.Model
{
    public class Degree
    {
        public Degree()
        {
            Employees = new List<EmployeeModel>();
        }

        public int education_Id { get; set; }
        public string Degree_Type { get; set; }

        public List<EmployeeModel> Employees { get; set; }
    }
}