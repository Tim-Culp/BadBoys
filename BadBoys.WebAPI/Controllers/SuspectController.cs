using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BadBoys.Models;
using BadBoys.Services;
using Microsoft.AspNet.Identity;

namespace BadBoys.WebAPI
{
    [Authorize]
    public class SuspectController : ApiController
    {
        public IHttpActionResult Get()
        {
            SuspectService suspectService = CreateSuspectService();
            var suspects = suspectService.GetSuspects();
            return Ok(suspects);
        }
        public IHttpActionResult Post(SuspectCreate suspect)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSuspectService();

            if (!service.CreateSuspect(suspect))
                return InternalServerError();

            return Ok();
        }
        private SuspectService CreateSuspectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var suspectService = new SuspectService(userId);
            return suspectService;
        }

        public IHttpActionResult Get(int id)
        {
            SuspectService suspectService = CreateSuspectService();
            var suspect = suspectService.GetSuspectById(id);
            return Ok(suspect);
        }

        public IHttpActionResult Put(SuspectEdit suspect)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSuspectService();

            if (!service.UpdateSuspect(suspect))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateSuspectService();

            if (!service.DeleteSuspect(id))
                return InternalServerError();

            return Ok();
        }
    }
}