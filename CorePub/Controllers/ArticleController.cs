using CorePub.Foundation.ConfigurationProvider;
using CorePub.Repositories.Articles.IProviders;
using CorePub.Repositories.Articles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePub.Controllers
{
    public class ArticleController : Controller
    {
        //private IArticleService _article;
        private AppSettings _appSettings;
        private IMediator _mediator;

        public ArticleController(IMediator mediator, AppSettings settings) //IArticleService article,
        {
            //_article = article;
            _mediator = mediator;
            _appSettings = settings;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _mediator.Send(new GetAllArticlesQuery());
            ViewBag.PageTitle = "All Articles";
            ViewBag.AppVersion = _appSettings.ApplicationSettings.Version;
            return View(viewModel);
        }

    }
}
