using CorePub.Foundation.ConfigurationProvider;
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
        private AppSettings _appSettings;

        public ArticleController(IGetArticle article, AppSettings settings)
        {
            _article = article;
            _appSettings = settings;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _article.GetAll();
            ViewBag.PageTitle = "All Articles";
            ViewBag.AppVersion = _appSettings.ApplicationSettings.Version;
            return View(viewModel);
        }

    }
}
