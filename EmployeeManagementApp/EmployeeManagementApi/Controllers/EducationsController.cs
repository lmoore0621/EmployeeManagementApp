using EmployeeManagement.Database.Models.DataLogic;
using EmployeeManagement.Database.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagement.Database.Controllers
{
    public class EducationsController : ApiController
    {
        private DataAccessLogic _dal = new DataAccessLogic();

        // GET: api/Educations
        public IEnumerable<Education> Get()
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
