using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beginner.Blog.Core.Messaging
{
    public class GetPagesResponse<T> : ResponseBase where T : BaseEntity
    {
        public PagedList<T> Pages { get; set; }
    }
}