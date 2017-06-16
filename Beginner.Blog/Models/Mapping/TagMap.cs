using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Beginner.Blog.Core;

namespace Beginner.Blog.Models.Mapping
{
    public class TagMap : BaseEntityTypeConfiguration<Tag>
    {
        public TagMap()
        {
            HasKey(p => p.Id);

            ToTable("Tags");

            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.TagName).HasMaxLength(50);
        }
    }
}