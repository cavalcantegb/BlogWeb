using BlogWeb1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogWeb1.Infra
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("name=blog")
        {

        }
        public DbSet<Post> Posts { get; set; }
    }
}