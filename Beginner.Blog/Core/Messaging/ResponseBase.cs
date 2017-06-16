using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beginner.Blog.Core.Messaging
{
    public class ResponseBase
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}