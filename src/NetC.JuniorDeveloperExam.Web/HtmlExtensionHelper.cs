using NetC.JuniorDeveloperExam.Web.Models;
using NetCJuniorDeveloperExam.Web.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace NetC.JuniorDeveloperExam.Web
{
    public class HtmlExtensionHelper
    {
        /// <summary>
        /// Turns the list of Comments from a tree into an ordered list with depth for formatting within view.
        /// </summary>
        /// <param name="comments"></param>
        /// <param name="depth"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static List<Tuple<int, BlogCommentModel>> Tree( IEnumerable<BlogCommentModel> comments, int depth = 0, int? parentId = null)
        {
            
            List<Tuple<int, BlogCommentModel>> commentsOrd = new List<Tuple<int, BlogCommentModel>>();

            var roots = comments.Where(t => t.ParentId == parentId);

            foreach (var root in roots)
            {
                commentsOrd.Add(new Tuple<int, BlogCommentModel>(depth, root));
                var children = comments.Where(t => t.ParentId == root.Id);
                var recursive = Tree(comments, depth + 1, root.Id);
                commentsOrd.AddRange(recursive);
            }

            return commentsOrd;
        }
         
    }
}