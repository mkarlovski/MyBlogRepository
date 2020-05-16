using MyBlog.Models;
using MyBlog.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Repository
{
    public class BlogRepository:IBlogRepository
    {
        public List<Blog> Blogs { get; set; }

        public BlogRepository()
        {
            Blogs = new List<Blog>();

            var blog1 = new Blog()
            {
                BlogID = 1,
                Title = "Review Roundup: Samsung Galaxy S20 Ultra",
                ImageURL = "https://mk0knowtechie1qof48y.kinstacdn.com/wp-content/uploads/2020/02/samsung-galaxy-s20-1536x864.jpg",
                Section="Gadgets",
                BlogNote= "You don’t need it, it’s too expensive, it doesn’t always work, but damn if they haven’t done a good job of making you want it.",
                FullDescription= "The latest and greatest from Samsung, the Galaxy S20 Ultra, is in reviewers’ hands and well, maybe you can have too much of a good thing? See, for a $1,400 smartphone that isn’t an exotic foldable, it’d have to be pretty much perfect to have a value proposition. So, does it? \n\n Samsung has a penchant for scoring points wherever it can, but hasn’t had a great run of it on the high - end market lately.Will the Ultra moniker live up to anything but its price tag ? Let’s find out. We rounded up some of the best reviews to date on the Galaxy S20 Ultra.Here’s what reviewers have to say about it."
            };

            var blog2 = new Blog()
            {
                BlogID = 2,
                Title = "How to transfer your Google Play Music account to YouTube Music",
                ImageURL = "https://mk0knowtechie1qof48y.kinstacdn.com/wp-content/uploads/2020/05/youtube-music-transfer-music-1536x864.jpg",
                Section = "How-To",
                BlogNote = "Surprise, surprise, Google is killing off another service.",
                FullDescription = "If you’re a current Google Play Music subscriber, you might have heard that the service is being killed off by Google at some point later this year. That’ll mean YouTube Music will be your only source of streaming music from Google, and your current paid subscription will transfer over to the new service. \n What won’t be transferred without your input is your music library,recommendations, purchased songs,and personal uploads.Thankfully, Google has a little tool that will transfer all of that automatically for you, with minimal input from you."
            };
            Blogs.Add(blog1);
            Blogs.Add(blog2);

        }

        public List<Blog> GetAll()
        {
            return Blogs;
        }

        public Blog GetById(int id)
        {
            return Blogs.FirstOrDefault(x=>x.BlogID==id);
        }
    }
}
