using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Blog.Models;

namespace Blog.Controllers
{
    public class CommentController : ApiController
    {
        private ArticleDBContext db = new ArticleDBContext();

        [Route("api/comment/addcomment/{articleId}")]
        [HttpPost]
        public Comment addCommentToArticle(int articleId, Comment comment)
        {
            var article = db.Articles.Include(a => a.Comments).FirstOrDefault(a => a.ID == articleId);
            article.Comments.Add(comment);
            db.SaveChanges();

            return comment;
        }
    }
}
