using EmployeeManagement.Database.Models.DataLogic;
using EmployeeManagement.Database.Models.Model;
using EmployeeManagementApi.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EmployeeManagement.Database.Controllers
{
    [EnableCors("*", "*", "*")]
    public class EducationsController : ApiController
    {
        private DataAccessLogic _dal = new DataAccessLogic();

        // GET: api/Educations
        public string Get()
        {
            return "hello world";
        }

        // GET: api/Educations/getall
        [Route("api/educations/getall")]
        public IEnumerable<EducationModel> GetAll()
        {
            return _dal.GetAllDegrees();
        }

        // GET: api/Educations/5
        [NotFoundFilter]
        public Education Get(int id)
        {
            return _dal.GetDegree(id);
        }
    }
}
