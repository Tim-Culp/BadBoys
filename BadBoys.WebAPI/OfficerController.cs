using BadBoys.Models;
using BadBoys.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BadBoys.WebAPI
{
    public class OfficerController : ApiController
    {
        private OfficerService CreateOfficerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var officerService = new OfficerService(userId);
            return officerService;
        }
        [HttpPost]
        [Route("api/Officer")]
        public IHttpActionResult Post(OfficerCreate officer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateOfficerService();
            var userId = Guid.Parse(User.Identity.GetUserId());
            if (!(service.ReadOfficerById(userId).OfficerId == userId))
            {
                if (!service.CreateOfficer(officer))
                    return InternalServerError();
                return Ok();
            }
            return InternalServerError();
        }
        [HttpGet]
        [Route("api/Officer")]
        public IHttpActionResult Get()
        {
            OfficerService officerService = CreateOfficerService();
            var officers = officerService.ReadOfficers();
            return Ok(officers);
        }
        [HttpGet]
        [Route("api/Officer/{id}")]
        public IHttpActionResult Get(Guid id)
        {
            OfficerService officerService = CreateOfficerService();
            var officer = officerService.ReadOfficerById(id);
            return Ok(officer);
        }
        [HttpPut]
        [Route("api/Officer")]
        public IHttpActionResult Put(OfficerEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateOfficerService();
            if (!service.EditOfficer(model))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        [Route("api/Officer/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            var service = CreateOfficerService();

            if (!service.DeleteOfficer(id))
                return InternalServerError();
            return Ok();
        }
        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}