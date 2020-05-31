////using MyBlog.Models;
//using MyBlog.Repository.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Text;
//using MyBlog.Data;

//namespace MyBlog.Repository
//{
//    public class BlogSQLRepository : IBlogRepository
//    {
//        public void Add(Blog blog)
//        {
//            using (var cnn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=MyBlogDB; Integrated Security=true"))
//            {
//                cnn.Open();
//                var query = @"insert into Blogs(Section, ImageURL,Title,BlogNote,FullDescription,DateCreated,Clicked)
//                            values(@Section,@ImageURL,@Title,@BlogNote,@FullDescription,getdate(),1)";
//                var cmd = new SqlCommand(query, cnn);
//                cmd.Parameters.AddWithValue("@Section",blog.Section);
//                cmd.Parameters.AddWithValue("@ImageURL",blog.ImageURL);
//                cmd.Parameters.AddWithValue("@Title",blog.Title);
//                cmd.Parameters.AddWithValue("@BlogNote",blog.BlogNote);
//                cmd.Parameters.AddWithValue("@FullDescription",blog.FullDescription);

//                cmd.ExecuteNonQuery();
//            }
//        }
//        public List<Blog> GetAll()
//        {
//            var result = new List<Blog>();
//            using(var cnn=new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=MyBlogDB; Integrated Security=true"))
//            {
//                cnn.Open();
//                var cmd = new SqlCommand("select * from Blogs", cnn);
//                var reader = cmd.ExecuteReader();
                

//                while (reader.Read())
//                {
//                    var blog = new Blog();
//                    blog.BlogID = reader.GetInt32(0);
//                    blog.Section = reader.GetString(1);
//                    blog.ImageURL = reader.GetString(2);
//                    blog.Title = reader.GetString(3);
//                    blog.BlogNote = reader.GetString(4);
//                    blog.FullDescription = reader.GetString(5);
//                    blog.DateCreated = reader.GetDateTime(6);
//                    blog.Clicked = reader.GetInt32(7);

//                    result.Add(blog);
//                }

//            }
//            return result;
//        }

//        public Blog GetById(int id)
//        {
//            Blog result = null;
            
//            using(var cnn=new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=MyBlogDB; Integrated Security=true"))
//            {
//                cnn.Open();
//                var cmd = new SqlCommand($"select * from Blogs where id={id}",cnn);
//                var reader = cmd.ExecuteReader();

//                while (reader.Read())
//                {
//                    result = new Blog();
//                    result.BlogID = reader.GetInt32(0);
//                    result.Section = reader.GetString(1);
//                    result.ImageURL = reader.GetString(2);
//                    result.Title = reader.GetString(3);
//                    result.BlogNote = reader.GetString(4);
//                    result.FullDescription = reader.GetString(5);
//                    result.DateCreated = reader.GetDateTime(6);
//                    result.Clicked = reader.GetInt32(7);
//                }
//                return result;
//            }  
//        }

//        public List<Blog> GetBySection(string section)
//        {
//            var result = new List<Blog>();
//            using (var cnn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=MyBlogDB; Integrated Security=true"))
//            {
//                cnn.Open();
//                var query = "select * from blogs";
//                if (!String.IsNullOrEmpty(section))
//                {
//                    query = $"{query} where section=@section";
//                }
//                var cmd = new SqlCommand(query, cnn);

//                if (!String.IsNullOrEmpty(section))
//                {
//                    cmd.Parameters.AddWithValue("@section", section);
//                }
//                var reader = cmd.ExecuteReader();
//                while (reader.Read())
//                {
//                    var blog = new Blog();
//                    blog.BlogID = reader.GetInt32(0);
//                    blog.Section = reader.GetString(1);
//                    blog.ImageURL = reader.GetString(2);
//                    blog.Title = reader.GetString(3);
//                    blog.BlogNote = reader.GetString(4);
//                    blog.FullDescription = reader.GetString(5);
//                    blog.DateCreated = reader.GetDateTime(6);
//                    blog.Clicked = reader.GetInt32(7);

//                    result.Add(blog);
//                }
//            }
//            return result;
//        }
//    }
//}
