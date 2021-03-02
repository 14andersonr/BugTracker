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
    [Authorize]
    public class ErrorController : ApiController
    {
        private ErrorService CreateErrorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var errorService = new ErrorService(userId);
            return errorService;
        }
        public IHttpActionResult Get()
        {
            ErrorService errorService = CreateErrorService();
            var errors = errorService.GetErrors();
            return Ok(errors);
        }
        public IHttpActionResult Post(ErrorCreate error)
        {
            if (!ModelState.IsValid)
                return BadRequest($"Your ModelState is invalid and set to {ModelState}");

            var service = CreateErrorService();

            if (!service.CreateError(error))
                return InternalServerError();

            return Ok("Your error has been posted.");
        }
        public IHttpActionResult Get(int id)
        {
            ErrorService errorService = CreateErrorService();
            var error = errorService.GetErrorById(id);
            return Ok($"Here is the error you requested: {error}");
        }
        public IHttpActionResult Put(ErrorEdit error)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateErrorService();

            if (!service.UpdateError(error))
                return InternalServerError();

            return Ok("You've sucessfully updated the error.");
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateErrorService();

            if (!service.DeleteError(id))
                return InternalServerError();

            return Ok("You deleted the error! Nice work!");
        }
    }
}
