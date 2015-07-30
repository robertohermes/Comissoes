using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;

namespace Dufry.Comissoes.Controllers
{
    public class MenuController : Controller
    {
        private readonly IControleAcessoAppService _controleacessoAppService;

        public MenuController(IControleAcessoAppService controleacessoAppService)
        {
            _controleacessoAppService = controleacessoAppService;
        }

        // GET: /Home/SideMenu
        public ActionResult SideMenu()
        {
            string login = _controleacessoAppService.ObtainCurrentLoginFromAd();

            var controleacessoModel = _controleacessoAppService.FindByActiveLogin(login);

            return PartialView(controleacessoModel);
        }

    }
}