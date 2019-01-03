using CorePub.Repositories.Articles.IProviders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePub.Controllers
{
    public class ArticleController : Controller
    {
        private IGetArticle _article;

        public ArticleController(IGetArticle article)
        {
            _article = article;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _article.GetAll();
            ViewBag.PageTitle = "All Articles";
            return View(viewModel);
        }

    }
}
