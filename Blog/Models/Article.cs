using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Blog.Models
{
    public class Article
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string body { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }

    public class ArticleDBContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
    }
}