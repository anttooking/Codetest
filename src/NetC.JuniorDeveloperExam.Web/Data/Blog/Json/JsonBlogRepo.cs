using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;

namespace NetCJuniorDeveloperExam.Web.Data
{
    class JsonBlogRepo : IBlogRepo
    {
        private string JsonDataFileName { get; set; }

        private string JsonDataMappedPath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(this.JsonDataFileName);
            }
        }

        public JsonBlogRepo ()
        {
            //Move to config
            this.JsonDataFileName = @"~/App_Data/Blog-Posts.json";
        }

        public IEnumerable<IBlog> All()
        {
            string jsonFileText = File.ReadAllText(this.JsonDataMappedPath);
            var blogs = JsonConvert.DeserializeObject<BlogsJson>(jsonFileText);
            return blogs.blogPosts;
        }

        public IBlog Get(int id)
        {
            return this.All().Where(q => q.Id == id).FirstOrDefault();
        }

        public void AddComment(IBlog blog, IBlogComment comment)
        {
            var blogUpdate = this.Get(blog.Id) as JsonBlog;

            blogUpdate.BlogComments.Add(new JsonBlogComment()
            {
                Date = DateTime.Now,
                EmailAddress = comment.EmailAddress,
                Id = comment.Id,
                Message = comment.Message,
                Name = comment.Name,
                ParentReference = comment.ParentReference
            });

            this.Update(blogUpdate);
        }

        private void Update(IBlog blog)
        {

            var allBlogs = new List<IBlog>(All());
            var rem = allBlogs.RemoveAll(q => q.Id == blog.Id);

            if (rem != 1)
                throw new Exception("Blog Failed to Update");


            allBlogs.Add(blog);

            string jsonFileText = JsonConvert.SerializeObject(new BlogsJson() { 
                blogPosts = allBlogs.Cast<JsonBlog>().ToList()
            }, Formatting.Indented);

            File.WriteAllText(this.JsonDataMappedPath, jsonFileText);
        }

        private class BlogsJson
        {
            public List<JsonBlog> blogPosts { get; set; }

        }
    }
}
