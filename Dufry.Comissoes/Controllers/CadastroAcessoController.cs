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
            var superiores = ObtemSuperioresComPrimeiroItem(0);
            IEnumerable<SelectListItem> superioresSelectListItem = new SelectList(superiores, "Key", "Value");
            ViewBag.COLABORADORKEY_PAI = new SelectList(superiores, "COLABORADORKEY_PAI", "NOME");

            var colaboradores = ObtemColaboradoresAInserir();
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

        // GET: /CadastroAcesso/CadastroAcessoEdit/5
        public ActionResult CadastroAcessoEdit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }
            var controleacesso = _controleacessoAppService.Get(id ?? default(int));
            if (controleacesso == null)
            {
                //return HttpNotFound();
                throw new Exception();
            }

            #region populaobjetos
            //<REVER>
            controleacesso.COLABORADORKEY_PAI = (controleacesso.COLABORADORKEY_PAI == null) ? 0 : controleacesso.COLABORADORKEY_PAI;

            var superiores = ObtemSuperioresComPrimeiroItem(controleacesso.COLABORADORKEY);
            IEnumerable<SelectListItem> superioresSelectListItem = new SelectList(superiores, "Key", "Value");
            ViewBag.COLABORADORKEY_PAI = new SelectList(superiores, "Key", "Value", controleacesso.COLABORADORKEY_PAI);

            var colaboradores = ObtemColaborador(controleacesso.CODIGOEMPRESAALTERNATE, controleacesso.CODIGOFILIALALTERNATE, controleacesso.CODIGOSECUNDARIO).ToList();

            #endregion populaobjetos

            string nomeCompleto = "*** SEM NOME DE COLABORADOR ***";
            if (colaboradores.Count() != 0)
            {
                nomeCompleto = colaboradores.FirstOrDefault().NomeCompleto;
            }

            CadastroAcessoViewModel cadastroAcessoVM = new CadastroAcessoViewModel(controleacesso, superioresSelectListItem, nomeCompleto);

            return View(cadastroAcessoVM);

        }

        // POST: /CadastroAcesso/CadastroAcessoEdit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("CadastroAcessoEdit")]
        //[ValidateAntiForgeryToken]
        public ActionResult CadastroAcessoEditConfirmed(int? id)
        {

            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }

            var controleacessoToUpdate = _controleacessoAppService.Get(id ?? default(int));

            controleacessoToUpdate = ObtemControleAcessoForm(controleacessoToUpdate);

            if (ModelState.IsValid)
            {
                try
                {

                    _controleacessoAppService.Update(controleacessoToUpdate);

                    return RedirectToAction("CadastroAcessoIndex");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Erro na alteração. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
                }
            }

            return View(controleacessoToUpdate);
        }
        
        // GET: /PlanoLoja/PlanoLojaIndex
        //[ControleAcessoAdminFilter]
        public ViewResult CadastroAcessoIndex(int? page
            , string sortOrder
            , int? colaboradorkeySearchString
            , int? colaboradorkey_paiSearchString
            , string loginSearchString
            , string adminSearchString
            , string statusSearchString)
        {

            #region populaobjetos
            var colaboradores = ObtemColaboradoresAInserir();
            ViewBag.colaboradorkeySearchString = new SelectList(colaboradores, "Key", "Value", colaboradorkeySearchString);

            var superiores = ObtemSuperioresComPrimeiroItem(0);
            ViewBag.colaboradorkey_paiSearchString = new SelectList(superiores, "Key", "Value", colaboradorkey_paiSearchString);
            #endregion populaobjetos

            #region trataParametrosOrdenacao
            ViewBag.CurrentSort = sortOrder;
            ViewBag.LoginSortParam = String.IsNullOrEmpty(sortOrder) ? "LOGIN_desc" : "";
            ViewBag.SuperiorSortParam = sortOrder == "COLABORADORKEY_PAI" ? "COLABORADORKEY_PAI_desc" : "COLABORADORKEY_PAI";
            ViewBag.ColaboradorSortParam = sortOrder == "COLABORADORKEY" ? "COLABORADORKEY_desc" : "COLABORADORKEY";
            ViewBag.AdminSortParam = sortOrder == "ADMIN" ? "ADMIN_desc" : "ADMIN";
            ViewBag.StatusSortParam = sortOrder == "STATUS" ? "STATUS_desc" : "STATUS";
            #endregion trataParametrosOrdenacao

            #region trataParametrosBusca

            var predicate = PredicateBuilder.True<ControleAcesso>();

            if (colaboradorkeySearchString.HasValue)
            {
                int colaboradorkeyFilter = colaboradorkeySearchString.GetValueOrDefault();
                predicate = predicate.And(i => i.COLABORADORKEY.Equals(colaboradorkeyFilter));
                ViewBag.colaboradorkeyFilter = colaboradorkeyFilter;
            }

            if (colaboradorkey_paiSearchString.HasValue)
            {
                int colaboradorkey_paiFilter = colaboradorkey_paiSearchString.GetValueOrDefault();
                predicate = predicate.And(i => i.COLABORADORKEY_PAI.Equals(colaboradorkey_paiFilter));
                ViewBag.colaboradorkey_paiFilter = colaboradorkey_paiFilter;
            }

            if (!String.IsNullOrEmpty(loginSearchString))
            {
                predicate = predicate.And(i => i.LOGIN.Contains(loginSearchString));
                ViewBag.loginFilter = loginSearchString;
            }

            if (!String.IsNullOrEmpty(adminSearchString))
            {
                predicate = predicate.And(i => i.ADMIN.Equals(adminSearchString));
                ViewBag.adminFilter = adminSearchString;
            }

            if (!String.IsNullOrEmpty(statusSearchString))
            {
                predicate = predicate.And(i => i.STATUS.Equals(statusSearchString));
                ViewBag.statusFilter = statusSearchString;
            }

            #endregion trataParametrosBusca

            IEnumerable<ControleAcesso> controleacessos = new List<ControleAcesso>();

            controleacessos = _controleacessoAppService.Find(predicate);

            #region ordenacao
            switch (sortOrder)
            {
                case "COLABORADORKEY":
                    controleacessos = controleacessos.OrderBy(s => s.COLABORADORKEY);
                    break;
                case "COLABORADORKEY_PAI":
                    controleacessos = controleacessos.OrderBy(s => s.COLABORADORKEY_PAI);
                    break;
                case "ADMIN":
                    controleacessos = controleacessos.OrderBy(s => s.ADMIN);
                    break;
                case "STATUS":
                    controleacessos = controleacessos.OrderBy(s => s.STATUS);
                    break;
                case "LOGIN_desc":
                    controleacessos = controleacessos.OrderByDescending(s => s.LOGIN);
                    break;
                case "COLABORADORKEY_desc":
                    controleacessos = controleacessos.OrderByDescending(s => s.COLABORADORKEY);
                    break;
                case "COLABORADORKEY_PAI_desc":
                    controleacessos = controleacessos.OrderByDescending(s => s.COLABORADORKEY_PAI);
                    break;
                case "ADMIN_desc":
                    controleacessos = controleacessos.OrderByDescending(s => s.ADMIN);
                    break;
                case "STATUS_desc":
                    controleacessos = controleacessos.OrderByDescending(s => s.STATUS);
                    break;
                default:  // LOGIN ascending 
                    controleacessos = controleacessos.OrderBy(s => s.LOGIN);
                    break;
            }
            #endregion ordenacao

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(controleacessos.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /CadastroAcesso/CadastroAcessoDelete/5
        public ActionResult CadastroAcessoDelete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //throw new InvalidOperationException("Something very bad happened while doing important stuff");
                throw new Exception();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Erro na exclusão. Tente novamente ou, se o problema persistir, entre em contato com o suporte.";
            }

            var controleacesso = _controleacessoAppService.Get(id ?? default(int));

            if (controleacesso == null)
            {
                //return HttpNotFound();
                throw new Exception();
            }

            string nomeSuperiorCompleto = "*** SEM SUPERIOR ***";
            if (controleacesso.COLABORADORKEY_PAI != null)
            {
                var controleacessoSup = _controleacessoAppService.Get(controleacesso.COLABORADORKEY_PAI ?? default(int));
                var superiores = ObtemColaborador(controleacessoSup.CODIGOEMPRESAALTERNATE, controleacessoSup.CODIGOFILIALALTERNATE, controleacessoSup.CODIGOSECUNDARIO).ToList();
                nomeSuperiorCompleto = superiores.FirstOrDefault().NomeCompleto;
            }

            
            var colaboradores = ObtemColaborador(controleacesso.CODIGOEMPRESAALTERNATE, controleacesso.CODIGOFILIALALTERNATE, controleacesso.CODIGOSECUNDARIO).ToList();

            var subordinados = _controleacessoAppService.Find(t => t.COLABORADORKEY_PAI == controleacesso.COLABORADORKEY);

            string nomeCompleto = "*** SEM NOME DE COLABORADOR ***";
            if (colaboradores.Count() != 0)
            {
                nomeCompleto = colaboradores.FirstOrDefault().NomeCompleto;
            }

            CadastroAcessoViewModel cadastroAcessoVM = new CadastroAcessoViewModel(controleacesso, nomeSuperiorCompleto, nomeCompleto, subordinados.Count());

            return View(cadastroAcessoVM);
        }

        //POST: /CadastroAcesso/CadastroAcessoDelete/5
        [HttpPost, ActionName("CadastroAcessoDelete")]
        public ActionResult CadastroAcessoConfirmed(int id)
        {
            try
            {
                var controleacesso = _controleacessoAppService.Get(id);

                var subordinados = _controleacessoAppService.Find(t => t.COLABORADORKEY_PAI == controleacesso.COLABORADORKEY);

                if (controleacesso.AusenciaRemuneradas.Count() == 0 && subordinados.Count() == 0)
                {
                    _controleacessoAppService.Remove(controleacesso);
                }
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("CadastroAcessoDelete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("CadastroAcessoIndex");

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

        private IEnumerable<KeyValuePair<string, string>> ObtemSuperiores(int colaboradorKey)
        {

            //Obtidos do BD do Comissoes
            //var superiores = _controleacessoAppService.Find(t => t.STATUS == "A");
            var superiores = _controleacessoAppService.Find(t => t.COLABORADORKEY != colaboradorKey);

            List<ColaboradorAux> colaboradorAuxList = new List<ColaboradorAux>();

            //Obtidos do BD do BI
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
                                                                       select new { su.COLABORADORKEY, NomeCompleto = string.Format("{0} ({1}-{2}-{3})",
                                                                                    co.NomeCompleto, co.CODIGOEMPRESAALTERNATE, co.CODIGOFILIALALTERNATE, co.CODIGOSECUNDARIO) })
                                                                       .OrderBy(co => co.NomeCompleto)
                                                                       .ToDictionary(row => (string)row.COLABORADORKEY.ToString(),
                                                                                     row => (string)row.NomeCompleto);

            return superioresAux;
        }

        private IEnumerable<KeyValuePair<string, string>> ObtemSuperioresComPrimeiroItem(int colaboradorKey)
        {
            var semSuperiorKVP = new KeyValuePair<string, string>("0", "*** SEM SUPERIOR ***");

            List<KeyValuePair<string, string>> superioresKVPList = new List<KeyValuePair<string, string>>();

            superioresKVPList.Add(semSuperiorKVP);
            superioresKVPList.AddRange(ObtemSuperiores(colaboradorKey).ToList());

            return superioresKVPList.AsEnumerable();
        }

        private IEnumerable<KeyValuePair<string, string>> ObtemColaboradores()
        {
            return _colaboradorAppService.All_ID_COMPOSTO();
        }

        private IEnumerable<KeyValuePair<string, string>> ObtemColaboradoresAInserir()
        {
            List<ColaboradorAux> colaboradorAuxList = new List<ColaboradorAux>();
            List<ColaboradorAux> superiorAuxList = new List<ColaboradorAux>();

            //Obtidos do BD do BI
            var colaboradores = _colaboradorAppService.All_ID();

            foreach (var item in colaboradores)
            {
                ColaboradorAux colaboradorAux = new ColaboradorAux();
                colaboradorAux.CODIGOSECUNDARIO = item.CodigoSecundario.ToString().Trim();
                colaboradorAux.CODIGOEMPRESAALTERNATE = item.CodigoEmpresaAlternate.ToString().Trim();
                colaboradorAux.CODIGOFILIALALTERNATE = item.CodigoFilialAlternate.ToString().Trim();
                colaboradorAux.NomeCompleto = item.NomeCompleto;

                colaboradorAuxList.Add(colaboradorAux);
            }

            //Obtidos do BD do Comissoes
            var superiores = _controleacessoAppService.All();

            foreach (var item in superiores)
            {
                ColaboradorAux superiorAux = new ColaboradorAux();
                superiorAux.CODIGOSECUNDARIO = item.CODIGOSECUNDARIO.ToString().Trim();
                superiorAux.CODIGOEMPRESAALTERNATE = item.CODIGOEMPRESAALTERNATE.ToString().Trim();
                superiorAux.CODIGOFILIALALTERNATE = item.CODIGOFILIALALTERNATE.ToString().Trim();
                superiorAux.NomeCompleto = "";

                superiorAuxList.Add(superiorAux);
            }

            var colaboradoresNaoInseridos = colaboradorAuxList
                                       .Where(su => !superiorAuxList
                                       .Any(co => co.CODIGOSECUNDARIO == su.CODIGOSECUNDARIO
                                               && co.CODIGOEMPRESAALTERNATE == su.CODIGOEMPRESAALTERNATE
                                               && co.CODIGOFILIALALTERNATE == su.CODIGOFILIALALTERNATE)
                                        ).ToList();

            IEnumerable<KeyValuePair<string, string>> colaboradoresAInserir = (from cn in colaboradoresNaoInseridos
                                                                       join co in colaboradorAuxList
                                                                       on new { cn.CODIGOSECUNDARIO, cn.CODIGOEMPRESAALTERNATE, cn.CODIGOFILIALALTERNATE }
                                                                       equals new { co.CODIGOSECUNDARIO, co.CODIGOEMPRESAALTERNATE, co.CODIGOFILIALALTERNATE }
                                                                       select new { COLABORADORKEY_ALT = string.Format("{0}|{1}|{2}", cn.CODIGOEMPRESAALTERNATE, cn.CODIGOFILIALALTERNATE, cn.CODIGOSECUNDARIO), 
                                                                                    NomeCompleto = string.Format("{0} ({1}-{2}-{3})", co.NomeCompleto, cn.CODIGOEMPRESAALTERNATE, cn.CODIGOFILIALALTERNATE, cn.CODIGOSECUNDARIO)})
                                                                       .ToDictionary(row => (string)row.COLABORADORKEY_ALT.ToString(), 
                                                                                     row => (string)row.NomeCompleto);

            return colaboradoresAInserir;
        }

        private IEnumerable<dynamic> ObtemColaborador(string CodigoEmpresaAlternate, string CodigoFilialAlternate, string CodigoSecundario)
        {
            var colaboradores = _colaboradorAppService.GET_ID(CodigoEmpresaAlternate, CodigoFilialAlternate, CodigoSecundario);

            return colaboradores;

        }

        private ControleAcesso ObtemControleAcessoForm(ControleAcesso ca, bool insert = false)
        {



            if (Request["ControleAcesso.COLABORADORKEY_PAI"] == "0")
            {
                ca.COLABORADORKEY_PAI = null;
            }
            else
            {
                ca.COLABORADORKEY_PAI = Int32.Parse(Request["ControleAcesso.COLABORADORKEY_PAI"]);
            }

            ca.LOGIN = Request["ControleAcesso.LOGIN"];
            ca.ADMIN = Request["ControleAcesso.ADMIN"];
            ca.STATUS = Request["ControleAcesso.STATUS"];

            ca.LAST_MODIFY_DATE = DateTime.Now;
            ca.LAST_MODIFY_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();

            if (insert)
            {
                string aux = Request["COLABORADORKEY_ALT"];
                string[] colaboradorkey_alt = aux.Split('|');

                ca.CODIGOSECUNDARIO = colaboradorkey_alt[2];
                ca.CODIGOEMPRESAALTERNATE = colaboradorkey_alt[0];
                ca.CODIGOFILIALALTERNATE = colaboradorkey_alt[1]; 

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