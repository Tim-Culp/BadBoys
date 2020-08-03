using BadBoys.Models;
using BadBoys.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BadBoys.WebAPI
{
    [Authorize]
    public class CaseController : ApiController
    {
        public IHttpActionResult Get()
        {
            CaseService caseService = CreateCaseService();
            var crimes = caseService.GetCases();
            return Ok(cases);
        }
        public IHttpActionResult Post(CaseCreate suspect)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCaseService();

            if (!service.CreateCase(CaseId))
                return InternalServerError();

            return Ok();
        }
        private CaseService CreateCaseService()
        {
            var officerId = Guid.Parse(User.Identity.officerId());
            var suspectCase = new CaseService(officerId);
            return suspectCase;
        }

        public IHttpActionResult GetCase(int CaseId)
        {
            CaseService caseService = CreateCaseService();
            var suspect = caseService.GetCaseById(CaseId);
            return Ok(CaseId);
        }

        public IHttpActionResult PutCase(CaseEdit case)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCaseService();

            if (!service.UpdateSuspect(case))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult DeleteCase(int id)
        {
            var service = CreateCaseService();

            if (!service.DeleteCase(id))
                return InternalServerError();

            return Ok();
        }
    }
}
