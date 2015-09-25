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
    public class InterfaceFolhaPagamentoController : Controller
    {
        private readonly IControleAcessoAppService _controleacessoAppService;
        private readonly IEmpresaAppService _empresaAppService;
        private readonly ILojaAppService _lojaAppService;

        public InterfaceFolhaPagamentoController(IControleAcessoAppService controleacessoAppService, IEmpresaAppService empresaAppService, ILojaAppService lojaAppService)
        {
            _controleacessoAppService = controleacessoAppService;
            _empresaAppService = empresaAppService;
            _lojaAppService = lojaAppService;
        }

        protected override void Dispose(bool disposing)
        {
            _controleacessoAppService.Dispose();
            _empresaAppService.Dispose();
            _lojaAppService.Dispose();

            base.Dispose(disposing);
        }


        // GET: /Interface/InterfaceFolhaPagamentoIndex
        public ActionResult InterfaceFolhaPagamentoIndex()
        {
            #region populaobjetos
            var empresas = _empresaAppService.Find(t => t.CodigoEmpresaAlternate.Trim() != "-2" && t.CodigoEmpresaAlternate.Trim() != "-1"); ;
            IEnumerable<SelectListItem> empresasSelectListItem = new SelectList(empresas, "CodigoEmpresaAlternate", "NomeEmpresa");
            ViewBag.COLABORADORKEY = new SelectList(empresas, "CodigoEmpresaAlternate", "NomeEmpresa");

            var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1"); ;
            IEnumerable<SelectListItem> lojasSelectListItem = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            ViewBag.CODIGOLOJAALTERNATE = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");

            #endregion populaobjetos

            InterfaceFolhaPagamentoViewModel ifpVM = new InterfaceFolhaPagamentoViewModel(empresasSelectListItem, lojasSelectListItem);

            return View(ifpVM);
        }

    }
}