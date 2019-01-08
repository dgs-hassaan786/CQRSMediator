using CorePub.Foundation.ConfigurationProvider;
using CorePub.Repositories.Articles.Commands;
using CorePub.Repositories.Articles.Queries;
using CorePub.ViewModels;
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

        public async Task<IActionResult> GetByUId(string uid)
        {
            var viewModel = await _mediator.Send(new GetArticleByUIdQuery(uid));
            ViewBag.PageTitle = "Article";
            ViewBag.AppVersion = _appSettings.ApplicationSettings.Version;
            return View("ViewOnly", viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateArticle", new CreateArticle());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArticle dto)
        {
            try
            {
                var createCmd = new CreateArticleCommand(dto.CreateArticleModel);
                await _mediator.Send(createCmd);

                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {

                return View("CreateArticle", dto);
            }

            
        }

    }
}
