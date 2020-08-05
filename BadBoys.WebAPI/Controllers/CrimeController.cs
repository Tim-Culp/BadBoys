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
    public class CrimeController : ApiController
    {
        private CrimeService CreateCrimeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var crimeService = new CrimeService(userId);
            return crimeService;
        }

        public IHttpActionResult Get()
        {
            CrimeService crimeService = CreateCrimeService();
            var crimes = crimeService.GetCrimes();
            return Ok(crimes);
        }

        public IHttpActionResult Post(CrimeCreate crime)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateCrimeService();

            if (!service.CreateCrime(crime))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            CrimeService service = CreateCrimeService();
            var crime = service.GetCrimeByCrimeId(id);
            return Ok(crime);
        }

        public IHttpActionResult Put(CrimeEdit crime)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CrimeService service = CreateCrimeService();

            if(!service.EditCrime(crime))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            CrimeService service = CreateCrimeService();
            
            if (!service.DeleteCrime(id))
            {
                return InternalServerError();
            }

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