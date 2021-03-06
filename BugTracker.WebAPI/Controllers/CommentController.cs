﻿using BugTracker.Data;
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
    public class CommentController : ApiController
    {
        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetComments();
            return Ok(comments);

        }

        public IHttpActionResult Post(Comment comment)
        {
            if (!ModelState.IsValid)
                return BadRequest($"Your ModelState is invalid and set to {ModelState}");

            var service = CreateCommentService();
            if (!service.CreateComment(comment))
                return InternalServerError();
            return Ok("You posted a comment!");
        }


        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userId);
            return commentService;
        }


        public IHttpActionResult Get (int id)
        {
            CommentService commentService = CreateCommentService();
            var comment = commentService.GetCommentById(id);
            return Ok($"Here is the requested comment: {comment}");
        }

        public IHttpActionResult Put(CommentEdit comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.UpdateComment(comment))
                return InternalServerError();

            return Ok("You updated the comment!");
        }

        public IHttpActionResult Delete (int id)
        {
            var service = CreateCommentService();

            if (!service.DeleteComment(id))
                return InternalServerError();
            return Ok("You deleted the comment!");
        }
    }
}
