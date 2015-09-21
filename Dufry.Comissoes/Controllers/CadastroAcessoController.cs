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

            var bla = ObtemSuperiores();

            var superiores = _controleacessoAppService.Find(t => t.STATUS == "A");
            IEnumerable<SelectListItem> superioresSelectListItem = new SelectList(superiores, "COLABORADORKEY", "COLABORADORKEY");
            ViewBag.COLABORADORKEY = new SelectList(superiores, "COLABORADORKEY", "COLABORADORKEY");


            var colaboradores = ObtemColaboradores();
            IEnumerable<SelectListItem> colaboradoresSelectListItem = new SelectList((IEnumerable)colaboradores, "Key", "Value");
            ViewBag.IdColaboradorComposto = new SelectList(colaboradores, "IdColaboradorComposto", "NomeCompleto");
            #endregion populaobjetos

            CadastroAcessoViewModel cadastroAcessoVM = new CadastroAcessoViewModel(controleacesso, superioresSelectListItem, colaboradoresSelectListItem);

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

        private IEnumerable<KeyValuePair<string, string>> ObtemSuperiores()
        {

            var superiores = _controleacessoAppService.Find(t => t.STATUS == "A");

            List<Colabx> colabxList = new List<Colabx>();

            var colaboradores = _colaboradorAppService.All_ID();

            foreach (var item in colaboradores)
            {
                Colabx colabx = new Colabx();
                colabx.CODIGOSECUNDARIO = item.CodigoSecundario;
                colabx.CODIGOEMPRESAALTERNATE = item.CodigoEmpresaAlternate;
                colabx.CODIGOFILIALALTERNATE = item.CodigoFilialAlternate;
                colabx.NOME = item.NomeCompleto;

                colabxList.Add(colabx);
            }


            //<REVER> CODIGOEMPRESAALTERNATE nchar(4) para nvarchar(4)

            var sup = (from su in superiores
                       join co in colabxList
                       on new { su.CODIGOSECUNDARIO, su.CODIGOEMPRESAALTERNATE, su.CODIGOFILIALALTERNATE }
                       equals new { co.CODIGOSECUNDARIO, co.CODIGOEMPRESAALTERNATE, co.CODIGOFILIALALTERNATE }
                       select new { su.COLABORADORKEY, co.NOME });

            return _colaboradorAppService.All_ID_COMPOSTO();
        }

        private IEnumerable<KeyValuePair<string, string>> ObtemColaboradores()
        {
            return _colaboradorAppService.All_ID_COMPOSTO();
        }


        private class Colabx
        {
            public string CODIGOSECUNDARIO { get; set; }

            public string CODIGOEMPRESAALTERNATE { get; set; }

            public string CODIGOFILIALALTERNATE { get; set; }

            public string NOME { get; set; }

        }


    }
}