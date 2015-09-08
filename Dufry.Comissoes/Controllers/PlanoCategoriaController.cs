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
    public class PlanoCategoriaController : Controller
    {
        private readonly IControleAcessoAppService _controleacessoAppService;
        private readonly IPlanoCategoriaAppService _planocategoriaAppService;
        private readonly IPlanoAppService _planoAppService;


        public PlanoCategoriaController(IControleAcessoAppService controleacessoAppService, IPlanoCategoriaAppService planocategoriaAppService, IPlanoAppService planoAppService)
        {
            _controleacessoAppService = controleacessoAppService;
            _planocategoriaAppService = planocategoriaAppService;
            _planoAppService = planoAppService;
        }

        protected override void Dispose(bool disposing)
        {
            _controleacessoAppService.Dispose();
            _planocategoriaAppService.Dispose();
            _planoAppService.Dispose();

            base.Dispose(disposing);
        }
    }
}