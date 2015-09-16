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
        private readonly ILojaAppService _lojaAppService;
        private readonly IFilialAppService _filialAppService;
        private readonly ITipoNegocioAppService _tiponegocioAppService;
        private readonly IEmpresaAppService _empresaAppService;

        public ControleAcessoController(IControleAcessoAppService controleacessoAppService, IColaboradorAppService colaboradorAppService, ILojaAppService lojaAppService, IFilialAppService filialAppService, ITipoNegocioAppService tiponegocioAppService, IEmpresaAppService empresaAppService)
        {
            _controleacessoAppService = controleacessoAppService;
            _colaboradorAppService = colaboradorAppService;
            _lojaAppService = lojaAppService;
            _filialAppService = filialAppService;
            _tiponegocioAppService = tiponegocioAppService;
            _empresaAppService = empresaAppService;
        }

        // GET: /ControleAcesso/ControleAcessoCreate
        //public ActionResult ControleAcessoCreate()
        //{
        //    ControleAcesso controleacesso = new ControleAcesso();

        //    #region populaobjetos
        //    var superiores = ObtemColaboradores(col);
        //    IEnumerable<SelectListItem> superioresSelectListItem = new SelectList(superiores, "ID_PLANO", "DESC_PLANO");
        //    ViewBag.ID_PLANO = new SelectList(superiores, "ID_PLANO", "DESC_PLANO");

        //    var funcionarios = ObtemColaboradores(col);
        //    IEnumerable<SelectListItem> funcionariosSelectListItem = new SelectList(funcionarios, "CodigoLojaAlternate", "NomeLoja");
        //    ViewBag.CODIGOLOJAALTERNATE = new SelectList(funcionarios, "CodigoLojaAlternate", "NomeLoja");
        //    #endregion populaobjetos

        //    ControleAcessoViewModel planoLojaVM = new ControleAcessoViewModel(controleacesso, superioresSelectListItem, funcionariosSelectListItem);

        //    return View(planoLojaVM);
        //}

        //
        // GET: /ControleAcesso/Browse
        public ActionResult Browse()
        {
            var controleacessoModel = _controleacessoAppService.GetFirstLogin();

            return View(controleacessoModel);
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

        private Colaboradorzzz ObtemColaboradores(Colaboradorzzz col)
        {
            return col;
        }
    }

    internal class Colaboradorzzz
    {
        public string IdColaboradorComposto { get; set; }

        //public string CodigoSecundario { get; set; }
        //public string CodigoEmpresaAlternate { get; set; }
        //public string CodigoFilialAlternate { get; set; }
        public string NomeCompleto { get; set; }

    }
}