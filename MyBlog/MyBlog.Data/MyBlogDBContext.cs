using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Data
{
    public class MyBlogDBContext : DbContext
    {
        public MyBlogDBContext(DbContextOptions<MyBlogDBContext> options) : base(options)
        {

        }

        public virtual DbSet<Blog> BlogsDB { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
