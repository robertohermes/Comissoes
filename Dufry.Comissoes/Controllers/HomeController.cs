using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;
using System.Web.Security;

namespace Dufry.Comissoes.Controllers
{
    public class HomeController : Controller
    {
        private readonly IControleAcessoAppService _controleacessoAppService;

        public HomeController(IControleAcessoAppService controleacessoAppService)
        {
            _controleacessoAppService = controleacessoAppService;
        }

        //
        // GET: /Home/Index
        public ActionResult Index()
        {
            string login = _controleacessoAppService.ObtainCurrentLoginFromAd();

            var controleacessoModel = _controleacessoAppService.FindByActiveLogin(login);

            //---------------------------------------------------------------------------------------------
            //<REVER>
            //---------------------------------------------------------------------------------------------
            if (ModelState.IsValid)
            {
                if (controleacessoModel != null)
                {
                    FormsAuthentication.SetAuthCookie(controleacessoModel.LOGIN, false);
                }
                else
                {
                    ModelState.AddModelError("", "O usuário [" + login + "] não está cadatrado no sistema.");
                }
            }

            return View(controleacessoModel);
        }
    }
}