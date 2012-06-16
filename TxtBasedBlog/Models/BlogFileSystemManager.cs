using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;

namespace TxtBasedBlog.Models
{
    public class BlogFileSystemManager
    {
        private string filePathToBlogPosts;

        public BlogFileSystemManager(string dirPath)
        {
            filePathToBlogPosts = dirPath;
        }

        /// <summary>
        /// 读取所有文件, 反序列化为C#对象
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public List<BlogListing> GetBlogListings(int limit)
        {
            var allFileNames = getBlogPostsFiles();
            var blogListings = new List<BlogListing>();
            foreach (var fileName in allFileNames.OrderByDescending(i => i).Take(limit))
            {
                var fileData = File.ReadAllText(fileName);
                var blogListing = new JavaScriptSerializer().Deserialize<BlogListing>(fileData);
                blogListings.Add(blogListing);
            }
            return blogListings;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>返回匹配模式的所有文件名</returns>
        private IEnumerable<string>  getBlogPostsFiles()
        {
            return Directory.GetFiles(filePathToBlogPosts, "*summary.txt").ToList();
        }

        public bool BlogPostFileExistsByTitleForUrl(string titleForUrl)
        {
            var matchingFiles = getFilesForBlogPostByTitleForUrl(titleForUrl);
            return (matchingFiles.Count == 2);
        }

        public BlogPost GetBlogPostByTitleForUrl(string titleForUrl)
        {
            var matchingFiles = getFilesForBlogPostByTitleForUrl(titleForUrl);
            var summaryFileData = File.ReadAllText(matchingFiles.Where(i => i.Contains("_summary")).FirstOrDefault());
            var blogPost = new JavaScriptSerializer().Deserialize<BlogPost>(summaryFileData);
            blogPost.Body = File.ReadAllText(matchingFiles.Where(i => !i.Contains("_summary")).FirstOrDefault());
            return blogPost;
        }

        private List<string> getFilesForBlogPostByTitleForUrl(string titleForUrl)
        {
            var files = Directory.GetFiles(filePathToBlogPosts, string.Format("*{0}*.txt", titleForUrl));
            var r = new Regex(@"\d{4}-\d{2}-\d{2}_" + titleForUrl + @"(_summary)?\.txt", RegexOptions.IgnoreCase);
            return files.Where(f => r.IsMatch(f)).ToList();
        }

    }
}