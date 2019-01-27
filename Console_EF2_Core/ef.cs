using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleBlogApp_EF
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<Sahip> Sahips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=MyDatabase;Trusted_Connection=True;");
        }
    }

    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public List<Post> Posts { get; set; }

        public List<Sahip> Sahips { get; set; }
    }

    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string TitleX { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }


    public class Sahip
    {
        [Key]
        public int Id { get; set; }

        public int Yas5 { get; set; }

        public Blog Blog { get; set; }

        

    }
}
