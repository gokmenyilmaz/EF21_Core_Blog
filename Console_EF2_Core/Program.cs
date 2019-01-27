using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleBlogApp_EF
{
    class Program
    {
        static void Main(string[] args)
        {

            BloggingContext dc = new BloggingContext();



            //var blog = new Blog { BlogId=1, Url = "www.11111yyyyy", Rating=9 };
            //blog.Posts = new List<Post>();
            //blog.Sahips = new List<Sahip>();


            //blog.Posts.Add(new Post { PostId=13, Content = "mmm_yeni_gunc", Title = "t1xxx", BlogId=1});
            ////blog.Posts.Add(new Post { Content = "sssss", Title = "t2" });

            //blog.Sahips.Add(new Sahip { Yas1 = 3 });
            //blog.Sahips.Add(new Sahip { Yas1 =12 });


            //dc.ChangeTracker.TrackGraph(blog, e=>ayarla(e.Entry));

            //dc.SaveChanges();

            //Environment.Exit(0);


            var u=dc.Database.GetDbConnection();

          

            dc.Database.Migrate();

            //InsertUpdateOrDeleteGraph(dc, blog);



        }

        public static void InsertUpdateOrDeleteGraph(BloggingContext context, Blog blog)
        {
            var existingBlog = context.Blogs
                .Include(b => b.Posts)
                .FirstOrDefault(b => b.BlogId == blog.BlogId);

            if (existingBlog == null)
            {
                context.Add(blog);
            }
            else
            {
                context.Entry(existingBlog).CurrentValues.SetValues(blog);

                foreach (var post in blog.Posts)
                {
                    var existingPost = existingBlog.Posts.FirstOrDefault(p => p.PostId == post.PostId);

                    if (existingPost == null)
                    {
                        existingBlog.Posts.Add(post);
                    }
                    else
                    {
                        context.Entry(existingPost).CurrentValues.SetValues(post);
                    }
                }

               
            }

            context.SaveChanges();
        }

        public static void ayarla(EntityEntry entry)
        {
            if (entry.Entity is Blog)
            {
                if(entry.IsKeySet)
                    entry.State = EntityState.Modified;
            }
            else
            if (entry.Entity is Post)
            {
                entry.State = EntityState.Added;
            }
            //else
            //if (entry.Entity is Sahip)
            //{
            //    entry.State = EntityState.Detached;
            //}
        }
    }
}
