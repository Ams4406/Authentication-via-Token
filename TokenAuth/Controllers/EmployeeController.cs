using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using TokenAuth.DAL;
using TokenAuth.Models;

namespace TokenAuth.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeRepository _ourEmployeeRepository;
        public EmployeeController()
        {
            _ourEmployeeRepository = new EmployeeRepository();
        }

        //GET: api/login
        [Authorize(Roles = "admin, user")]
        [HttpGet]
        [Route("api/login")]
        public IHttpActionResult GetLogin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            return Ok("Name : " + identity.Name + " & Role : " + string.Join(",", roles.ToList()));
        }

        // GET: api/assets
        [Route("api/assets")]
        [HttpGet]
        public List<Employee> DisplayAll()
        {
            return _ourEmployeeRepository.DisplayEmployees();
        }

        // GET: api/assets/10
        [Route("api/assets/{ID}")]
        [HttpGet]
        public Employee Get(int ID)
        {
            return _ourEmployeeRepository.SearchEmployeeByID(ID);
        }

        // GET: api/assets/Ams
        /*[Route("api/assets/{Name}")]
        [HttpGet]
        public Employee GetName(string Name)
        {
            return _ourEmployeeRepository.SearchEmployeeByName(Name);
        }*/

        //GET: api/assets?registration_date[gt]={Date}
        /*[Route("api/assets?registration_date[gt] = {RegistrationDate}")]
        [HttpGet]
        public Employee GetRegistrationDate(DateTime RegistrationDate)
        {
            return _ourEmployeeRepository.SearchEmployeeByDate(RegistrationDate);
        }
        */

        // POST: api/assets
        [Route("api/assets")]
        [HttpPost]
        public bool Post([FromBody]Employee ourEmployee)
        {
            return _ourEmployeeRepository.InsertEmployee(ourEmployee);
        }

        // PUT: api/assets
        [Route("api/assets")]
        [HttpPut]
        public bool Put([FromBody]Employee ourEmployee)
        {
            return _ourEmployeeRepository.UpdateEmployee(ourEmployee);
        }

        // DELETE: api/assets/10
        [Route("api/assets/{ID}")]
        [HttpDelete]
        public bool Delete(int ID)
        {
            return _ourEmployeeRepository.DeleteEmployee(ID);
        }
    }
}
