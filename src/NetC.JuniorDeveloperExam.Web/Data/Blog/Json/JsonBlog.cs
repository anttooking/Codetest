using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCJuniorDeveloperExam.Web.Data
{
    class JsonBlog : IBlog
    {

        public JsonBlog()
        {
            this.BlogComments = new List<JsonBlogComment>();
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

        public string HtmlContent { get; set; }

        [JsonProperty("comments")]
        public List<JsonBlogComment> BlogComments { get; set; }

        [JsonIgnore]
        List<IBlogComment> IBlog.Comments => BlogComments.Cast<IBlogComment>().ToList();
    }

}
