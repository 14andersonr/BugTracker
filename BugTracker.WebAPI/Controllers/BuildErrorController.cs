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
    public class BuildErrorController : ApiController
    {
        public IHttpActionResult Get()
        {
            BuildErrorService buildErrorService = CreateBuildErrorService();
            var buildErrors = buildErrorService.GetBuildErrors();
            return Ok(buildErrors);
        }

        public IHttpActionResult Post(BuildErrorCreate buildError)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBuildErrorService();

            if (!service.CreateBuildError(buildError))
                return InternalServerError();

            return Ok();
        }

        private BuildErrorService CreateBuildErrorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var buildErrorService = new BuildErrorService(userId);
            return buildErrorService;
        }

        public IHttpActionResult Get(int id)
        {
            BuildErrorService buildErrorService = CreateBuildErrorService();
            var buildError = buildErrorService.GetBuildErrorById(id);
            return Ok(buildError);
        }

        public IHttpActionResult Put(BuildErrorEdit buildError)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBuildErrorService();

            if (!service.UpdateBuildError(buildError))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateBuildErrorService();

            if (!service.DeleteBuildError(id))
                return InternalServerError();

            return Ok();
        }
    }
}
