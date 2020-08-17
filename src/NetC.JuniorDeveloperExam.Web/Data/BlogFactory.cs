using NetCJuniorDeveloperExam.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetC.JuniorDeveloperExam.Web.Data
{
    class BlogFactory
    {
        public static IBlogRepo CreateIBlogRepo()
        {
            return new JsonBlogRepo();
        }

        public static IBlogComment CreateComment(DateTime Date, String Name, string Email, String Message, int ?Parent, int Id )
        {
            return new JsonBlogComment() { Date = Date, Name = Name, EmailAddress = Email, Message = Message, ParentReference = Parent, Id = Id };
        }
    }
}