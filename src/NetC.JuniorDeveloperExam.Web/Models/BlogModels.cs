using NetCJuniorDeveloperExam.Web.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NetC.JuniorDeveloperExam.Web.Models
{
    public class BlogViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

        public string HtmlContent { get; set; }

        public List<BlogCommentModel> Comments { get; set; }


        public string FormatedDate
        {
            get
            {
                return this.Date.ToString("MMMM d , yyyy ");
            }
        }

    }

    public class BlogCommentModel
    {
        public int Id { get; set; }

        public int ? ParentId { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }

        public DateTime Date { get; set; }

        public bool IsReponse { get => ParentId != null; }

        public string FormatedDate 
        { 
            get
            {
                return this.Date.ToString("MMMM d , yyyy - HH:mm");
            } 
        }
    }

    public sealed class BlogAddCommentModel
    { 
        [Required]
        public string Name { get; set; }

        [Required]
        public int BlogId { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Message { get; set; }

        public int? ParentReference { get; set; }
    }
}