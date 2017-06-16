﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beginner.Blog.ViewModels
{
    public class ArticleTopModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Hits { get; set; }
        public bool IsTop { get; set; }
    }
}