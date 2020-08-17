using NetC.JuniorDeveloperExam.Web.Data;
using NetC.JuniorDeveloperExam.Web.Models;
using NetCJuniorDeveloperExam.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace NetC.JuniorDeveloperExam.Web
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        [Route("Blog/{id}")]
        public ActionResult ViewEntry(int id)
        {
            var rep = BlogFactory.CreateIBlogRepo();
            var blog = rep.Get(id);
             

            var model = new BlogViewModel() { 
                Id = blog.Id,
                Date = blog.Date,
                HtmlContent = blog.HtmlContent,
                Image = blog.Image,
                Title = blog.Title,
                Comments = new List<BlogCommentModel>()
            };

            blog.Comments.ForEach(p => model.Comments.Add(new BlogCommentModel() { 
            
                EmailAddress = p.EmailAddress,
                Message = p.Message,
                Name = p.Name,
                Id = p.Id,
                ParentId = p.ParentReference,
                Date = p.Date
            }));

            return View(model);
        } 

        [Route("Blog/AddComment")]
        public ActionResult AddComment(BlogAddCommentModel model)
        {
            if (!ModelState.IsValid)
            {
                //Some kind of error messaging would go here 
                //rolling a generic handler is a bit excessive for a tech test :) 
                throw new Exception("Exception Handling here");

            }
            else
            {
                var rep = BlogFactory.CreateIBlogRepo();
                var blog = rep.Get(model.BlogId);

                var id = blog.Comments.Count;
                rep.AddComment(blog, BlogFactory.CreateComment(DateTime.Now, model.Name, model.EmailAddress, model.Message, model.ParentReference, id));

                return Redirect($"/Blog/{ blog.Id }");
            }
        }


    }
}