using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSite.Entities;
using WebSite.Models;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    public class BlogController : Controller
    {
        private static PortfolioDBContext _dBContext = new PortfolioDBContext(new DbContextOptions<PortfolioDBContext>());
        
        private PostsRepository _postsRepository = new PostsRepository(_dBContext);
        private CategoryRepository _categoryRepository = new CategoryRepository(_dBContext);
        private TagsRepository _tagRepository = new TagsRepository(_dBContext);
        private CommentsRepository _commentsRepository = new CommentsRepository(_dBContext);

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("allPosts", "Blog");
        }

        [HttpGet]
        public IActionResult AllPosts(int page = 0, int countPerPage = 5, string categoryId = null, string tagId = null)
        {
            PostsViewModel postViewModel = new PostsViewModel();
            postViewModel.Tags = _tagRepository.GetAllTags();
            postViewModel.Categories = _categoryRepository.GetAllCategories().ToList();

            if (!string.IsNullOrEmpty(categoryId))
            {
                //с фильтром по категории
                postViewModel.CategoryName = "Category: " + categoryId;
                postViewModel.CategorySlug = categoryId;
                postViewModel.Posts = new PaginatedList<Post>(_postsRepository.GetPostsByCategory(categoryId), page, countPerPage);
            }
            else if (!string.IsNullOrEmpty(tagId))
            {
                //с фильтром по тегам
                postViewModel.CategoryName = "Tag: " + tagId;

                postViewModel.Posts = new PaginatedList<Post> (_postsRepository.GetPostsByTags(tagId), page, countPerPage);
                postViewModel.TagSlug = tagId;
            }
            else
            {
                //без фильтра по категории
                postViewModel.CategoryName = "Category: All posts";
                postViewModel.Posts = new PaginatedList<Post>(_postsRepository.GetPosts(), page, countPerPage);
            }

            return View(postViewModel);
        }

        [HttpGet]
        public IActionResult OnePost(string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                PostsViewModel viewModel = new PostsViewModel();
                viewModel.Post = _postsRepository.GetOnePostBySlug(Id);
                if (viewModel.Post != null)
                {
                    viewModel.PostTags = _tagRepository.GetTagsByPostId(viewModel.Post.Id);
                    viewModel.Tags = _tagRepository.GetAllTags();
                    viewModel.Categories = _categoryRepository.GetAllCategories().ToList();
                    viewModel.Comments = _commentsRepository.GetCommentsThree(viewModel.Post.Id);
                    return View("OnePost", viewModel);
                }
            }
            return RedirectToAction("allPosts", "Blog");
        }
    }
}
