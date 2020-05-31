using MyBlog.Data;
//using MyBlog.Models;
using MyBlog.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Repository
{
    public class BlogRepositoryEF : IBlogRepository
    {
        private MyBlogDBContext Context { get; set; }

        public BlogRepositoryEF(MyBlogDBContext context)
        {
            Context = context;
        }

        public void Add(Blog blog)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetAll()
        {
            throw new NotImplementedException();
        }

        public Blog GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBySection(string section)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
