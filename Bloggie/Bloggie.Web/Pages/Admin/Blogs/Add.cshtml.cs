using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        private readonly BloggieDbContext bloggieDbContext;

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

        public AddModel(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext= bloggieDbContext;
        }

        public void OnGet()
        {
        }


        public void OnPost()
        {
            var blogPost = new BlockPost()
            {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Author = AddBlogPostRequest.Author,
                IsVisible = AddBlogPostRequest.IsVisible
            };
            bloggieDbContext.BlogPosts.Add(blogPost);
            bloggieDbContext.SaveChanges();
        }
    }
}
