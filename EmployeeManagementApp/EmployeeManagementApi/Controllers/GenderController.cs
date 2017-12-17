using EmployeeManagement.Database.Models.DataLogic;
using EmployeeManagementApi.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EmployeeManagementApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class GenderController : ApiController
    {
        private DataAccessLogic _dal = new DataAccessLogic();

        // GET: Gender
        [HttpGet]
        [Route("api/gender/getall")]
        public IEnumerable<GenderModel> GetAll()
        {
            return _dal.getAllGenders();
        }
    }
}