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
    public class GitFileErrorController : ApiController
    {
        public IHttpActionResult Get()
        {
            GitFileErrorService gitFileErrorService = CreateGitFileErrorService();
            var gitFileErrors = gitFileErrorService.GetGitFileErrors();
            return Ok(gitFileErrors);
        }

        public IHttpActionResult Post(GitFileErrorCreate gitFileError)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGitFileErrorService();

            if (!service.CreateGitFileError(gitFileError))
                return InternalServerError();

            return Ok();
        }

        private GitFileErrorService CreateGitFileErrorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var gitFileErrorService = new GitFileErrorService(userId);
            return gitFileErrorService;
        }

        public IHttpActionResult Get(int id)
        {
            GitFileErrorService gitFileErrorService = CreateGitFileErrorService();
            var gitFileError = gitFileErrorService.GetGitFileErrorById(id);
            return Ok(gitFileError);
        }

        public IHttpActionResult Put(GitFileErrorEdit gitFileError)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGitFileErrorService();

            if (!service.UpdateGitFileError(gitFileError))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateGitFileErrorService();

            if (!service.DeleteGitFileError(id))
                return InternalServerError();

            return Ok();
        }
    }
}
