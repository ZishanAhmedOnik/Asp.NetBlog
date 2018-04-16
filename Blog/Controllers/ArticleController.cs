using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Blog.Models;
using System.Web.Http.Cors;

namespace Blog.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ArticleController : ApiController
    {

        private ArticleDBContext db = new ArticleDBContext();

        public IEnumerable<Article> Get()
        {
            return db.Articles.ToList();
        }

        [HttpGet]
        public Article GetById(int id)
        {
            return db.Articles.SingleOrDefault(a => a.ID == id);
        }

        [Route("api/article/details/{articleId}")]
        [HttpGet]
        public Article GetWithDetails(int articleId)
        {
            return db.Articles.Include(a => a.Comments).FirstOrDefault(a => a.ID == articleId);
        }

        [HttpPost]
        public Article NewArticle(Article newArticle)
        {
            db.Articles.Add(newArticle);
            db.SaveChanges();

            return newArticle;
        }

        [HttpPut]
        public Article UpdateArticle(Article article)
        {
            var articleFromDb = db.Articles.SingleOrDefault(a => a.ID == article.ID);

            articleFromDb.title = article.title;
            articleFromDb.body = article.body;

            db.SaveChanges();

            return articleFromDb;
        }

        [HttpDelete]
        public void DeleteArticle(int id)
        {
            var article = db.Articles.Single(a => a.ID == id);

            db.Articles.Remove(article);

            db.SaveChanges();
        }
    }
}
