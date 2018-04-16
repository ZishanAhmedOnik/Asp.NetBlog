using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("articlelist")]
        public ActionResult ArticleList()
        {
            return View();
        }

        [Route("articleform")]
        public ActionResult ArticleForm()
        {
            return View();
        }

        [Route("articleview")]
        public ActionResult ArticleView()
        {
            return View();
        }
    }
}