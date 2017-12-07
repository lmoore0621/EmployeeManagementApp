using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagementApi.Models.Model
{
    public class EducationModel
    {
        public EducationModel()
        {
            this.Employees = new List<EmployeeModel>();
        }

        public int education_Id { get; set; }
        public string Degree_Type { get; set; }

        public virtual ICollection<EmployeeModel> Employees { get; set; }
    }
}
