using System;
using System.Collections.Generic;

namespace NetCJuniorDeveloperExam.Web.Data
{
    interface IBlogComment
    { 
        int Id { get; }
        DateTime Date { get;  }
        string EmailAddress { get;  }
        string Message { get;  }
        string Name { get; }

        int? ParentReference { get; }
    }
     


}