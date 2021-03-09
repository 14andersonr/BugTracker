using BugTracker.Models;
using BugTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BugTracker.WebAPI.Controllers
{
    public class RunTimeErrorController : ApiController
    {
        public IHttpActionResult Get()
        {
            RunTimeErrorService runTimeErrorService = CreateRunTimeErrorService();
            var runTimeErrors = runTimeErrorService.GetRunTimeErrors();
            return Ok(runTimeErrors);
        }

        public IHttpActionResult Post(RunTimeErrorCreate runTimeError)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRunTimeErrorService();

            if (!service.CreateRunTimeError(runTimeError))
                return InternalServerError();

            return Ok();
        }

        private RunTimeErrorService CreateRunTimeErrorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var runTimeErrorService = new RunTimeErrorService(userId);
            return runTimeErrorService;
        }

        public IHttpActionResult Get(int id)
        {
            RunTimeErrorService runTimeErrorService = CreateRunTimeErrorService();
            var runTimeError = runTimeErrorService.GetRunTimeErrorById(id);
            return Ok(runTimeError);
        }

        public IHttpActionResult Put(RunTimeErrorEdit runTimeError)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRunTimeErrorService();

            if (!service.UpdateRunTimeError(runTimeError))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateRunTimeErrorService();

            if (!service.DeleteRunTimeError(id))
                return InternalServerError();

            return Ok();
        }
    }
}
