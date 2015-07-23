using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;

namespace Dufry.Comissoes.Controllers
{
    public class ControleAcessoController : Controller
    {
        private readonly IControleAcessoAppService _controleacessoAppService;

        public ControleAcessoController(IControleAcessoAppService controleacessoAppService)
        {
            _controleacessoAppService = controleacessoAppService;
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