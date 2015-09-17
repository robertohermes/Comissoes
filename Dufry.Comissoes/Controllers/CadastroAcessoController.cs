using Dufry.Comissoes.Application.Interfaces;
using Dufry.Comissoes.Controllers.Helpers;
using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Filters;
using Dufry.Comissoes.ViewModels;
using PagedList;
using System;
using System.Collections;
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
    public class CadastroAcessoController : Controller
    {
        private readonly IControleAcessoAppService _controleacessoAppService;
        private readonly IColaboradorAppService _colaboradorAppService;
        private readonly ILojaAppService _lojaAppService;
        private readonly IFilialAppService _filialAppService;
        private readonly ITipoNegocioAppService _tiponegocioAppService;
        private readonly IEmpresaAppService _empresaAppService;

        public CadastroAcessoController(IControleAcessoAppService controleacessoAppService, IColaboradorAppService colaboradorAppService, ILojaAppService lojaAppService, IFilialAppService filialAppService, ITipoNegocioAppService tiponegocioAppService, IEmpresaAppService empresaAppService)
        {
            _controleacessoAppService = controleacessoAppService;
            _colaboradorAppService = colaboradorAppService;
            _lojaAppService = lojaAppService;
            _filialAppService = filialAppService;
            _tiponegocioAppService = tiponegocioAppService;
            _empresaAppService = empresaAppService;
        }


        // GET: /CadastroAcesso/CadastroAcessoCreate
        public ActionResult CadastroAcessoCreate()
        {
            ControleAcesso controleacesso = new ControleAcesso();

            #region populaobjetos
            var superiores = ObtemColaboradores();
            IEnumerable<SelectListItem> superioresSelectListItem = new SelectList((IEnumerable)superiores, "Key", "Value");
            IEnumerable<SelectListItem> funcionariosSelectListItem = new SelectList((IEnumerable)superiores, "Key", "Value");


            //IEnumerable<SelectListItem> superioresSelectListItem = new SelectList(superiores, "ID_PLANO", "DESC_PLANO");
            //ViewBag.ID_PLANO = new SelectList(superiores, "ID_PLANO", "DESC_PLANO");

            //var funcionarios = ObtemColaboradores(col);
            //IEnumerable<SelectListItem> funcionariosSelectListItem = new SelectList(funcionarios, "CodigoLojaAlternate", "NomeLoja");
            //ViewBag.CODIGOLOJAALTERNATE = new SelectList(funcionarios, "CodigoLojaAlternate", "NomeLoja");
            #endregion populaobjetos

            CadastroAcessoViewModel cadastroAcessoVM = new CadastroAcessoViewModel(controleacesso, superioresSelectListItem, funcionariosSelectListItem);

            return View(cadastroAcessoVM);
        }


        protected override void Dispose(bool disposing)
        {

            _controleacessoAppService.Dispose();
            _colaboradorAppService.Dispose();
            _lojaAppService.Dispose();
            _filialAppService.Dispose();
            _tiponegocioAppService.Dispose();
            _empresaAppService.Dispose();

            base.Dispose(disposing);
        }


        private IEnumerable<KeyValuePair<string, string>> ObtemColaboradores()
        {
            return _colaboradorAppService.All_ID_COMPOSTO();
        }


    }
}