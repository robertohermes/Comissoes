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


            //<REVER>
            #region rever
            var semSuperiorKVP = new KeyValuePair<string, string>("0", "*** SEM SUPERIOR ***");

            List <KeyValuePair<string, string>> superioresKVPList = new  List <KeyValuePair<string, string>>();

            superioresKVPList.Add(semSuperiorKVP);
            superioresKVPList.AddRange(ObtemSuperiores().ToList());

            var superiores = superioresKVPList.AsEnumerable();
            #endregion rever

            IEnumerable<SelectListItem> superioresSelectListItem = new SelectList(superiores, "Key", "Value");
            ViewBag.COLABORADORKEY_PAI = new SelectList(superiores, "COLABORADORKEY_PAI", "NOME");


            var colaboradores = ObtemColaboradores();
            IEnumerable<SelectListItem> colaboradoresSelectListItem = new SelectList((IEnumerable)colaboradores, "Key", "Value");
            ViewBag.COLABORADORKEY_ALT = new SelectList(colaboradores, "COLABORADORKEY_ALT", "NomeCompleto");
            #endregion populaobjetos

            CadastroAcessoViewModel cadastroAcessoVM = new CadastroAcessoViewModel(controleacesso, superioresSelectListItem, colaboradoresSelectListItem);

            return View(cadastroAcessoVM);
        }

        // POST: /CadastroAcesso/CadastroAcessoCreate
        [HttpPost, ActionName("CadastroAcessoCreate")]
        //[ValidateAntiForgeryToken]
        public ActionResult CadastroAcessoCreateConfirmed(ControleAcesso controleacesso)
        {
            try
            {
                controleacesso = ObtemControleAcessoForm(controleacesso, true);

                if (ModelState.IsValid)
                {
                    _controleacessoAppService.Create(controleacesso);
                    return RedirectToAction("CadastroAcessoIndex");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Erro ao salvar. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
            }

            return View(controleacesso);
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

            List<ColaboradorAux> colaboradorAuxList = new List<ColaboradorAux>();

            var colaboradores = _colaboradorAppService.All_ID();

            foreach (var item in colaboradores)
            {
                ColaboradorAux colaboradorAux = new ColaboradorAux();
                colaboradorAux.CODIGOSECUNDARIO = item.CodigoSecundario;
                colaboradorAux.CODIGOEMPRESAALTERNATE = item.CodigoEmpresaAlternate;
                colaboradorAux.CODIGOFILIALALTERNATE = item.CodigoFilialAlternate;
                colaboradorAux.NomeCompleto = item.NomeCompleto;

                colaboradorAuxList.Add(colaboradorAux);
            }


            IEnumerable<KeyValuePair<string, string>> superioresAux = (from su in superiores
                                                                       join co in colaboradorAuxList
                                                                       on new { su.CODIGOSECUNDARIO, su.CODIGOEMPRESAALTERNATE, su.CODIGOFILIALALTERNATE }
                                                                       equals new { co.CODIGOSECUNDARIO, co.CODIGOEMPRESAALTERNATE, co.CODIGOFILIALALTERNATE }
                                                                       select new { su.COLABORADORKEY, co.NomeCompleto }).ToDictionary(row => (string)row.COLABORADORKEY.ToString(),
                                                                                                                                         row => (string)row.NomeCompleto);

            return superioresAux;
        }

        private IEnumerable<KeyValuePair<string, string>> ObtemColaboradores()
        {
            return _colaboradorAppService.All_ID_COMPOSTO();
        }

        private ControleAcesso ObtemControleAcessoForm(ControleAcesso ca, bool insert = false)
        {
            string aux = Request["COLABORADORKEY_ALT"];
            string[] colaboradorkey_alt = aux.Split('|');

            if (Request["COLABORADORKEY_PAI"] == "0")
            {
                ca.COLABORADORKEY_PAI = null;
            }
            else
            {
                ca.COLABORADORKEY_PAI = Int32.Parse(Request["COLABORADORKEY_PAI"]);
            }
            ca.CODIGOSECUNDARIO = colaboradorkey_alt[2];
            ca.CODIGOEMPRESAALTERNATE = colaboradorkey_alt[0];
            ca.CODIGOFILIALALTERNATE = colaboradorkey_alt[1]; 
            ca.LOGIN = Request["ControleAcesso.LOGIN"];
            ca.ADMIN = Request["ControleAcesso.ADMIN"];
            ca.STATUS = Request["ControleAcesso.STATUS"];

            ca.LAST_MODIFY_DATE = DateTime.Now;
            ca.LAST_MODIFY_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();

            if (insert)
            {
                ca.CREATED_DATETIME = ca.LAST_MODIFY_DATE;
                ca.CREATED_USERNAME = ca.LAST_MODIFY_USERNAME;
            }

            return ca;
        }


        private class ColaboradorAux
        {
            public string CODIGOSECUNDARIO { get; set; }

            public string CODIGOEMPRESAALTERNATE { get; set; }

            public string CODIGOFILIALALTERNATE { get; set; }

            public string NomeCompleto { get; set; }

        }


    }
}