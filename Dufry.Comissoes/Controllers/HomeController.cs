using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;

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

            //------------------------------------------------------------------------------------
            //if (controleacessoModel.STATUS == "I")
            //{
            //    controleacessoModel.STATUS = "A";
            //}
            //else
            //{
            //    controleacessoModel.STATUS = "I";
            //}

            //Dufry.Comissoes.Domain.Validation.ValidationResult validationResult = new Dufry.Comissoes.Domain.Validation.ValidationResult();

            //validationResult = _controleacessoAppService.Update(controleacessoModel);
            //------------------------------------------------------------------------------------

            return View(controleacessoModel);
        }

        //
        // GET: /ControleAcesso/Browse

        public ActionResult Browse()
        {
            var controleacessoModel = _controleacessoAppService.GetFirstLogin();

            return View(controleacessoModel);
        }

    }
}