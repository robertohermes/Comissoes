using Dufry.Comissoes.Application.Interfaces;
using Dufry.Comissoes.Controllers.Helpers;
using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Filters;
using Dufry.Comissoes.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Dufry.Comissoes.Controllers
{
    [ControleAcessoAdminFilter]
    [HandleError(ExceptionType = typeof(InvalidOperationException),
            View = "InvalidOperation")]
    [HandleError(ExceptionType = typeof(HttpException),
                View = "HttpException")]

    public class ControleAcessoController : Controller
    {
        private readonly IControleAcessoAppService _controleacessoAppService;

        private readonly IColaboradorAppService _colaboradorAppService;
        private readonly IFilialAppService _filialAppService;
        private readonly ILojaAppService _lojaAppService;
        private readonly IEmpresaAppService _empresaAppService;


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