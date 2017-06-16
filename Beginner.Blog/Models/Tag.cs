using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beginner.Blog.Core;

namespace Beginner.Blog.Models
{
    public class Tag : BaseEntity
    {
        public string TagName { get; set; }

        public DateTime CreateTime { get; set; }
    }
}