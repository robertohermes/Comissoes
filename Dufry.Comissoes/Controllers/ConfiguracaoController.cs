using Dufry.Comissoes.Application.Interfaces;
using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Filters;
using Dufry.Comissoes.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
    public class ConfiguracaoController : Controller
    {
        private readonly IConfiguracaoAppService _configuracaoAppService;
        private readonly IControleAcessoAppService _controleacessoAppService;

        public ConfiguracaoController(IConfiguracaoAppService configuracaoAppService, IControleAcessoAppService controleacessoAppService)
        {
            _configuracaoAppService = configuracaoAppService;
            _controleacessoAppService = controleacessoAppService;
        }


        protected override void Dispose(bool disposing)
        {
            _configuracaoAppService.Dispose();
            _controleacessoAppService.Dispose();

            base.Dispose(disposing);
        }

    }
}