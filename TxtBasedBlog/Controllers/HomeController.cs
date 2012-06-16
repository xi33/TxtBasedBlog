using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TxtBasedBlog.Models;

namespace TxtBasedBlog.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var manager = new BlogFileSystemManager(Server.MapPath(ConfigurationManager.AppSettings["BlogPostsDirectory"]));
            var model = manager.GetBlogListings(5);
            return View(model);
        }

        public ActionResult ViewBlogPost(string postName)
        {
            var manager = new BlogFileSystemManager(Server.MapPath(ConfigurationManager.AppSettings["BlogPostsDirectory"]));
            if (!manager.BlogPostFileExistsByTitleForUrl(postName))
            {
                return RedirectToRoute("Error");
            }
            var model = manager.GetBlogPostByTitleForUrl(postName);
            return View(model);
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}
