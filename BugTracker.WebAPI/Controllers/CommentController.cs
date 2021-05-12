using BugTracker.Data;
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

        public IHttpActionResult Post(Comment comment)//it's public for access modifier. return type is IHttp..the name is a Post and a pramater it
            //takes is Comment object called comment

        {
            if (!ModelState.IsValid)
                return BadRequest($"Your ModelState is invalid and set to {ModelState}");
            // does Comment meets the requrements that is in CommentCreate class

            var service = CreateCommentService(); // if it is valid it returns to this line. we call the method and set it equla to CommentService object
            //(service) (what gets return by a method and that method return CommentService)
           
            if (!service.CreateComment(comment)) // we called a method that lives in CommentService that takes in Comment
                //if we get false InternalServerlError
                return InternalServerError();
            
            return Ok("You posted a comment!");
        }// if it creates and saves into the database we get ok


        private CommentService CreateCommentService() // returns CommentService called CreateCommentService
        {
            var userId = Guid.Parse(User.Identity.GetUserId()); //local variable called userId. call the method user.Identity 
            //Gets the current application user signed in  Parses it into to Guid then saves it as UserId
            
            var commentService = new CommentService(userId); // create instance of CommentService class. Because our CommentService requires a guid
            // passed in. userId the time it is created  
            return commentService; //then return that instance of commentService
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
