﻿using Beginner.Blog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beginner.Blog.Models.Mapping
{
    public class LoginLogMap : BaseEntityTypeConfiguration<LoginLog>
    {
        public LoginLogMap()
        {
            //Key
            HasKey(p => p.Id);

            //Table
            ToTable("LoginLogs");
        }
    }
}