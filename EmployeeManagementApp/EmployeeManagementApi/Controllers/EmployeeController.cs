using EmployeeManagement.Database.Models.DataLogic;
using EmployeeManagement.Database.Models.Model;
using EmployeeManagementApi.Models.Model;
using Newtonsoft.Json;
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
    public class EmployeeController : ApiController
    {
        private DataAccessLogic _dah = new DataAccessLogic();

        // GET: api/Employee
        [HttpGet]
        [Route("api/employee")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello World" };
        }

        [HttpGet]
        [Route("api/employee/getall")]
        public IEnumerable<EmployeeModel> GetAll()
        {
            return _dah.GetAllEmployees();
        }

        // GET: api/Employee/5
        [HttpGet]
        [Route("api/employee/{id}")]
        [NotFoundFilter]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _dah.GetEmployee(id));
        }

        // POST: api/Employee
        [HttpPost]
        [Route("api/employee")]
        public HttpResponseMessage Post([FromBody]Employee employee)
        {
            try
            {
                if (_dah.AddEmployeeInfo(employee))
                    return Request.CreateResponse(HttpStatusCode.OK, "Employee Created");
                return Request.CreateResponse(HttpStatusCode.NotFound, "Adding Employee info failed");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message, e);
            }
        }

        // PUT: api/Employee/5
        [HttpPut]
        [Route("api/employee/{id}")]
        [NotFoundFilter]
        public HttpResponseMessage Put([FromBody]Employee employee)
        {
            try
            {
                if (_dah.UpdateEmployeeInfo(employee))
                    return Request.CreateResponse(HttpStatusCode.OK,"Employee Updated");
                return Request.CreateResponse(HttpStatusCode.NotFound, "Employee Update Failed");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message, e);
            }
        }

        // DELETE: api/Employee/5
        [HttpDelete]
        [Route("api/employee/{id}")]
        [NotFoundFilter]
        public string Delete(int id)
        {
            return _dah.DeleteEmployeeInfo(id);
        }
    }
}
