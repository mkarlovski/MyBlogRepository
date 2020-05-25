﻿using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Service.Interfaces
{
    public interface IBlogService
    {
        List<Blog> GetAll();
        Blog GetById(int id);
        List<Blog> GetBySection(string section);
        void CreateBlog(Blog blog);
    }
}
