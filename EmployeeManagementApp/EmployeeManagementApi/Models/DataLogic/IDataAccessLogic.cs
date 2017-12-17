using System.Collections.Generic;
using EmployeeManagement.Database.Models.Model;
using EmployeeManagementApi.Models.Model;

namespace EmployeeManagement.Database.Models.DataLogic
{
    public interface IDataAccessLogic
    {
        bool AddEmployeeInfo(Employee employee);
        string DeleteEmployeeInfo(int employeeId);
        List<EducationModel> GetAllDegrees();
        List<EmployeeModel> GetAllEmployees();
        IEnumerable<GenderModel> getAllGenders();
        List<States> GetAllStates();
        Education GetDegree(int degreeId);
        Employee GetEmployee(int employeeId);
        USAState GetState(int stateId);
        bool UpdateEmployeeInfo(Employee employee);
    }
}