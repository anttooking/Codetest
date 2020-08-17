using System;
using System.Collections.Generic;

namespace NetCJuniorDeveloperExam.Web.Data
{
    class JsonBlogComment : IBlogComment
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string EmailAddress { get; set; }

        public string Message { get; set; }

        public int? ParentReference { get; set; }

        public int Id { get; set; }
    }

}
