using System;
using System.Collections.Generic;

namespace NetCJuniorDeveloperExam.Web.Data
{
    interface IBlog
    {
        List<IBlogComment> Comments { get;  }
        DateTime Date { get; }
        string HtmlContent { get; }
        int Id { get;  }
        string Image { get;  }
        string Title { get; }
    }
}