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
    public class InterfaceController : Controller
    {
        private readonly IControleAcessoAppService _controleacessoAppService;
        private readonly IEmpresaAppService _empresaAppService;
        private readonly ILojaAppService _lojaAppService;
        private readonly IConfiguracaoAppService _configuracaoAppService;

        public InterfaceController(IControleAcessoAppService controleacessoAppService, IEmpresaAppService empresaAppService, ILojaAppService lojaAppService, IConfiguracaoAppService configuracaoAppService)
        {
            _controleacessoAppService = controleacessoAppService;
            _empresaAppService = empresaAppService;
            _lojaAppService = lojaAppService;
            _configuracaoAppService = configuracaoAppService;
        }

        protected override void Dispose(bool disposing)
        {
            _controleacessoAppService.Dispose();
            _empresaAppService.Dispose();
            _lojaAppService.Dispose();
            _configuracaoAppService.Dispose();

            base.Dispose(disposing);
        }


        // GET: /Interface/InterfaceFolhaPagamentoIndex
        public ActionResult InterfaceFolhaPagamentoIndex()
        {
            #region populaobjetos

            string codigoFolha = _configuracaoAppService.Find(t => t.DESC_CHAVE == "InterfaceFolhaPagamentoCodigoFolhaPagamento").FirstOrDefault().DESC_VALOR.Trim();

            string codigoClienteADP = _configuracaoAppService.Find(t => t.DESC_CHAVE == "InterfaceFolhaPagamentoCodigoClienteADP").FirstOrDefault().DESC_VALOR.Trim();

            var empresas = _empresaAppService.Find(t => t.CodigoEmpresaAlternate.ToString().Trim() != "-2" && t.CodigoEmpresaAlternate.ToString().Trim() != "-1"); ;
            IEnumerable<SelectListItem> empresasSelectListItem = new SelectList(empresas, "CodigoEmpresaAlternate", "NomeEmpresa");
            ViewBag.CodigoEmpresaAlternate = new SelectList(empresas, "CodigoEmpresaAlternate", "NomeEmpresa");

            var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1"); ;
            IEnumerable<SelectListItem> lojasSelectListItem = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            ViewBag.CODIGOLOJAALTERNATE = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");

            #endregion populaobjetos

            InterfaceFolhaPagamentoViewModel ifpVM = new InterfaceFolhaPagamentoViewModel(codigoFolha, codigoClienteADP, empresasSelectListItem, lojasSelectListItem);

            return View(ifpVM);
        }

    }
}