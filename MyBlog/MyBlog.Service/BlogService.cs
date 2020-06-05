//using MyBlog.Models;
using MyBlog.Repository.Interfaces;
using MyBlog.Service.Interfaces;
using System;
using System.Collections.Generic;
using MyBlog.Data;



namespace MyBlog.Service
{
    public class BlogService : IBlogService
    {
        public IBlogRepository BlogRepository { get; set; }
        public BlogService(IBlogRepository blogRepo)
        {
            BlogRepository = blogRepo;
        }
        public List<Blog> GetAll()
        {
            return BlogRepository.GetAll();
        }

        public Blog GetById(int id)
        {
            return BlogRepository.GetById(id);
        }

        public List<Blog> GetBySection(string section)
        {
            return BlogRepository.GetBySection(section);
        }

        public void CreateBlog(Blog blog)
        {
            
            BlogRepository.Add(blog);
        }

        public void Delete(int id)
        {
            BlogRepository.Delete(id);
        }

        public void UpdateBlog(Blog blog)
        {
            BlogRepository.Update(blog);
        }
    }
}
