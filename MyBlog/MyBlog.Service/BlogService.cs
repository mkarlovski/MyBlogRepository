﻿using MyBlog.Models;
using MyBlog.Repository.Interfaces;
using MyBlog.Service.Interfaces;
using System;
using System.Collections.Generic;

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
    }
}
