using System;
using System.Web.Http;
using sample_api_app_key.Models;

namespace sample_api_app_key.Controllers
{
    [RoutePrefix("api/persons")]
    public class PersonsController : ApiController
    {
        [HttpGet]
        [Route("getbyid")]
        [AllowAnonymous]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                return Ok(new
                {
                    Data = new Person
                    {
                        Id = 1,
                        FullName = "Xuan Do Thanh",
                        PayRate = 12,
                        StartDate = DateTime.MinValue,
                        EndDate = DateTime.MaxValue
                    }
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
