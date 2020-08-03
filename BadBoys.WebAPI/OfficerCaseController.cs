using BadBoys.Models.OfficerCaseModels;
using BadBoys.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BadBoys.WebAPI
{
    public class OfficerCaseController : ApiController
    {
        private OfficerCaseService CreateOfficerCaseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var officerCaseService = new OfficerCaseService(userId);
            return officerCaseService;
        }
        [HttpPost]
        [Route("api/OfficerCase")]
        public IHttpActionResult Post(OfficerCaseCreate officerCase)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateOfficerCaseService();
            if (!service.CreateOfficerCase(officerCase))
                return InternalServerError();
            return Ok();
        }
    }
}