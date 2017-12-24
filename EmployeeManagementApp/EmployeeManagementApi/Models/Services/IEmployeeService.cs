using System.Collections.Generic;
using EmployeeManagementApi.Models.Model;

namespace EmployeeManagementApi.Models.Services
{
    public interface IEmployeeService
    {
        EmployeeGenderCount GetEmployeeGenderCount(IEnumerable<EmployeeModel> employees);
    }
}
