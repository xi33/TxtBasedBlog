using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TxtBasedBlog.Models
{
    public class BlogPost : BlogListing
    {
        public string Body { get; set; }
    }
}