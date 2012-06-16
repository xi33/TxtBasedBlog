using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TxtBasedBlog.Models
{
    public class BlogListing
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PostDate { get; set; }
        public string Image { get; set; }
    }
}