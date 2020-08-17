using System;
using System.Collections.Generic;

namespace NetCJuniorDeveloperExam.Web.Data
{
    
    interface IBlogRepo
    {
        IEnumerable<IBlog> All();
         

        void AddComment(IBlog blog, IBlogComment comment);

        IBlog Get(int id);
    }
}
