using MyBlog.Data;
//using MyBlog.Models;
using MyBlog.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Repository
{
    public class BlogRepositoryEF : IBlogRepository
    {
        public MyBlogDBContext Context { get; set; }

        public BlogRepositoryEF(MyBlogDBContext context)
        {
            Context = context;
        }

        public void Add(Blog blog)
        {
            blog.DateCreated = DateTime.Now;
            Context.BlogsDB.Add(blog);
            Context.SaveChanges();
        }

        public List<Blog> GetAll()
        {
            return Context.BlogsDB.ToList()
;        }

        public Blog GetById(int id)
        {
            return Context.BlogsDB.FirstOrDefault(x => x.BlogID == id);
        }

        public List<Blog> GetBySection(string section)
        {
            var blogs = Context.BlogsDB.AsQueryable();
            if (!string.IsNullOrEmpty(section))
            {
                blogs = blogs.Where(x => x.Title.Contains(section));
                
            }
            return blogs.ToList();
        }

        public void Delete(int id)
        {
            var blog = new Blog()
            {
                BlogID = id
            };
            Context.BlogsDB.Remove(blog);
            Context.SaveChanges();

        }

        

        public void Update(Blog blog)
        {
            Context.BlogsDB.Update(blog);
            Context.SaveChanges();
            
            
        }
    }
}
