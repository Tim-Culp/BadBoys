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
    [Authorize] 
    public class OfficerController : ApiController
    {
        [HttpGet]
        [Route("api/Officer")]
        public IHttpActionResult Get()
        {
            OfficerService officerService = CreateOfficerService();
            var officers = officerService.ReadOfficers();
            return Ok(officers);
        }
        [HttpPost]
        [Route("api/Officer")]
        public IHttpActionResult Post(OfficerCreate officer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateOfficerService();
            if (!service.CreateOfficer(officer))
                return InternalServerError();
            return Ok();
        }
        private OfficerService CreateOfficerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var officerService = new OfficerService(userId);
            return officerService;
        }

        [HttpGet]
        [Route("api/Officer/{id}")]
        public IHttpActionResult Get(int id)
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
        public IHttpActionResult Delete(int id)
        {
            var service = CreateOfficerService();

            if (!service.DeleteOfficer(id))
                return InternalServerError();
            return Ok();
        }
    }
}