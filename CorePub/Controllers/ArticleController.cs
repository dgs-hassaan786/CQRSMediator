using CorePub.Foundation.ConfigurationProvider;
using CorePub.Repositories.Articles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CorePub.Controllers
{
    public class ArticleController : Controller
    {
        private AppSettings _appSettings;
        private IMediator _mediator;

        public ArticleController(IMediator mediator, AppSettings settings) //IArticleService article,
        {
            _mediator = mediator;
            _appSettings = settings;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _mediator.Send(new GetAllArticlesQuery());
            ViewBag.PageTitle = "All Articles";
            ViewBag.AppVersion = _appSettings.ApplicationSettings.Version;
            return View("Index", viewModel);
        }

        public async Task<IActionResult> GetByName(string name)
        {
            var viewModel = await _mediator.Send(new GetArticlesByNameQuery(name));
            ViewBag.PageTitle = "All Articles";
            ViewBag.AppVersion = _appSettings.ApplicationSettings.Version;
            return View("Index", viewModel);
        }

        public async Task<IActionResult> GetById(long id)
        {
            var viewModel = await _mediator.Send(new GetArticleByIdQuery(id));
            ViewBag.PageTitle = "Article";
            ViewBag.AppVersion = _appSettings.ApplicationSettings.Version;
            return View("ViewOnly", viewModel);
        }

        public async Task<IActionResult> GetByUId(string uid)
        {
            var viewModel = await _mediator.Send(new GetArticleByUIdQuery(uid));
            ViewBag.PageTitle = "Article";
            ViewBag.AppVersion = _appSettings.ApplicationSettings.Version;
            return View("ViewOnly", viewModel);
        }

    }
}
