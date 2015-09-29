using Dufry.Comissoes.Application.Interfaces;
using Dufry.Comissoes.Controllers.Helpers;
using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Entities.Search;
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
    public class PlanoLojaController : Controller
    {
        private readonly IPlanoLojaAppService _planolojaAppService;
        private readonly IPlanoAppService _planoAppService;
        private readonly ILojaAppService _lojaAppService;
        private readonly IControleAcessoAppService _controleacessoAppService;

        public PlanoLojaController(IPlanoLojaAppService planolojaAppService, IPlanoAppService planoAppService, IControleAcessoAppService controleacessoAppService, ILojaAppService lojaAppService)
        {
            _planolojaAppService = planolojaAppService;
            _planoAppService = planoAppService;
            _lojaAppService = lojaAppService;
            _controleacessoAppService = controleacessoAppService;
        }


        protected override void Dispose(bool disposing)
        {
            _planolojaAppService.Dispose();
            _controleacessoAppService.Dispose();
            _planoAppService.Dispose();
            _lojaAppService.Dispose();

            base.Dispose(disposing);
        }

        // GET: /PlanoLoja/PlanoLojaCreate
        public ActionResult PlanoLojaCreate()
        {
            PlanoLoja planoloja = new PlanoLoja();

            #region populaobjetos
            var planos = _planoAppService.Find(t => t.STATUS == "A");
            IEnumerable<SelectListItem> planosSelectListItem = new SelectList(planos, "ID_PLANO", "DESC_PLANO");
            ViewBag.ID_PLANO = new SelectList(planos, "ID_PLANO", "DESC_PLANO");

            var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1"); ;
            IEnumerable<SelectListItem> lojasSelectListItem = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            ViewBag.CODIGOLOJAALTERNATE = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            #endregion populaobjetos

            PlanoLojaViewModel planoLojaVM = new PlanoLojaViewModel(planoloja, planosSelectListItem, lojasSelectListItem);

            return View(planoLojaVM);
        }

        // POST: /PlanoLoja/PlanoLojaCreate
        [HttpPost, ActionName("PlanoLojaCreate")]
        //[ValidateAntiForgeryToken]
        public ActionResult PlanoLojaCreateConfirmed(PlanoLoja planoloja)
        {
            try
            {
                planoloja = ObtemPlanoLojaForm(planoloja, true);

                if (ModelState.IsValid)
                {
                    PlanoLoja planolojaExiste = new PlanoLoja();
                    planolojaExiste = null;

                    if (planoloja.STATUS == "A")
                    {
                        planolojaExiste = PlanoLojaAtivaVigente(planoloja);
                    }

                    if (planolojaExiste == null || planoloja.STATUS == "I")
                    {
                        _planolojaAppService.Create(planoloja);
                    }
                    else
                    {
                        throw new InvalidOperationException("Já existe um perído vigente e ativo que coincide com a tentativa de inclusão / alteração");
                    }
                    return RedirectToAction("PlanoLojaIndex");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Erro ao salvar. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
            }

            return View(planoloja);
        }

        // GET: /PlanoLoja/PlanoLojaEdit/5
        public ActionResult PlanoLojaEdit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }
            var planoloja = _planolojaAppService.Get(id ?? default(int));
            if (planoloja == null)
            {
                //return HttpNotFound();
                throw new Exception();
            }

            #region populaobjetos
            var planos = _planoAppService.All();
            IEnumerable<SelectListItem> planosSelectListItem = new SelectList(planos, "ID_PLANO", "DESC_PLANO");
            ViewBag.ID_PLANO = new SelectList(planos, "ID_PLANO", "DESC_PLANO", planoloja.ID_PLANO);

            var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1");
            IEnumerable<SelectListItem> lojasSelectListItem = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            ViewBag.CODIGOLOJAALTERNATE = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja", planoloja.CODIGOLOJAALTERNATE);
            #endregion populaobjetos

            PlanoLojaViewModel planoLojaVM = new PlanoLojaViewModel(planoloja, planosSelectListItem, lojasSelectListItem);

            return View(planoLojaVM);

        }

        // POST: /PlanoLoja/PlanoLojaEdit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("PlanoLojaEdit")]
        //[ValidateAntiForgeryToken]
        public ActionResult PlanoLojaEditConfirmed(int? id)
        {

            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }

            var planolojaToUpdate = _planolojaAppService.Get(id ?? default(int));

            planolojaToUpdate = ObtemPlanoLojaForm(planolojaToUpdate);

            if (ModelState.IsValid)
            {
                try
                {
                    PlanoLoja planolojaExiste = new PlanoLoja();
                    planolojaExiste = null;

                    if (planolojaToUpdate.STATUS == "A")
                    {
                        planolojaExiste = PlanoLojaAtivaVigente(planolojaToUpdate);
                    }

                    if (planolojaExiste == null || planolojaToUpdate.STATUS == "I")
                    {
                        _planolojaAppService.Update(planolojaToUpdate);
                    }
                    else
                    {
                        throw new InvalidOperationException("Já existe um perído vigente e ativo que coincide com a tentativa de inclusão / alteração");
                    }

                    return RedirectToAction("PlanoLojaIndex");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Erro na alteração. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
                }
            }

            return View(planolojaToUpdate);
        }

                // GET: /PlanoLoja/PlanoLojaIndex
        //[ControleAcessoAdminFilter]
        public ViewResult PlanoLojaIndex(int? page
            , string sortOrder
            , int? idPlanoSearchString
            , string codigolojaalternateSearchString
            , string dtiniSearchString
            , string dtfimSearchString
            , string statusSearchString)
        {

            #region populaobjetos
            var planos = _planoAppService.All();
            ViewBag.idPlanoSearchString = new SelectList(planos, "ID_PLANO", "DESC_PLANO", idPlanoSearchString);

            var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1"); ;
            ViewBag.codigolojaalternateSearchString = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja", codigolojaalternateSearchString);
            #endregion populaobjetos

            #region trataParametrosOrdenacao
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DescCategoriaSortParam = String.IsNullOrEmpty(sortOrder) ? "DESC_CATEGORIA_desc" : "";
            ViewBag.CodigoLojaAlternateSortParam = sortOrder == "NomeLoja" ? "NomeLoja_desc" : "NomeLoja";
            ViewBag.DtIniSortParam = sortOrder == "DT_INI" ? "DT_INI_desc" : "DT_INI";
            ViewBag.DtFimSortParam = sortOrder == "DT_FIM" ? "DT_FIM_desc" : "DT_FIM";
            ViewBag.StatusSortParam = sortOrder == "STATUS" ? "STATUS_desc" : "STATUS";
            #endregion trataParametrosOrdenacao

            #region trataParametrosBusca

            var predicate = PredicateBuilder.True<PlanoLoja>();

            if (idPlanoSearchString.HasValue)
            {
                int idCategoriaFilter = idPlanoSearchString.GetValueOrDefault();
                predicate = predicate.And(i => i.ID_PLANO.Equals(idCategoriaFilter));
                ViewBag.idCategoriaFilter = idCategoriaFilter;
            }

            if (!String.IsNullOrEmpty(codigolojaalternateSearchString))
            {
                string codigolojaalternateFilter = codigolojaalternateSearchString;
                predicate = predicate.And(i => i.CODIGOLOJAALTERNATE.Equals(codigolojaalternateFilter));
                ViewBag.codigolojaalternateFilter = codigolojaalternateFilter;
            }

            if (!String.IsNullOrEmpty(dtiniSearchString))
            {
                DateTime dtiniFilter = DateTime.ParseExact(dtiniSearchString, "dd/MM/yyyy", new CultureInfo("pt-BR"));
                predicate = predicate.And(i => i.DT_INI.Equals(dtiniFilter));
                ViewBag.dtiniFilter = dtiniFilter;
            }

            if (!String.IsNullOrEmpty(dtfimSearchString))
            {
                DateTime dtfimFilter = DateTime.ParseExact(dtfimSearchString, "dd/MM/yyyy", new CultureInfo("pt-BR"));
                predicate = predicate.And(i => i.DT_FIM.Equals(dtfimFilter));
                ViewBag.dtfimFilter = dtfimFilter;
            }

            if (!String.IsNullOrEmpty(statusSearchString))
            {
                predicate = predicate.And(i => i.STATUS.Equals(statusSearchString));
                ViewBag.statusFilter = statusSearchString;
            }

            #endregion trataParametrosBusca


            IEnumerable<PlanoLojaSearch> planolojas = MontaSearchList(_planolojaAppService.Find(predicate));

            #region ordenacao
            switch (sortOrder)
            {
                case "NomeLoja":
                    planolojas = planolojas.OrderBy(s => s.Loja.NomeLoja); //mudar de chave para campo
                    break;
                case "DT_INI":
                    planolojas = planolojas.OrderBy(s => s.DT_INI);
                    break;
                case "DT_FIM":
                    planolojas = planolojas.OrderBy(s => s.DT_FIM);
                    break;
                case "STATUS":
                    planolojas = planolojas.OrderBy(s => s.STATUS);
                    break;
                case "DESC_CATEGORIA_desc":
                    planolojas = planolojas.OrderByDescending(s => s.Plano.DESC_PLANO); //mudar de chave para campo
                    break;
                case "NomeLoja_desc":
                    planolojas = planolojas.OrderByDescending(s => s.Loja.NomeLoja); //mudar de chave para campo
                    break;
                case "DT_INI_desc":
                    planolojas = planolojas.OrderByDescending(s => s.DT_INI);
                    break;
                case "DT_FIM_desc":
                    planolojas = planolojas.OrderByDescending(s => s.DT_FIM);
                    break;
                case "STATUS_desc":
                    planolojas = planolojas.OrderByDescending(s => s.STATUS);
                    break;
                default:  // DESC_CATEGORIA ascending 
                    planolojas = planolojas.OrderBy(s => s.Plano.DESC_PLANO);
                    break;
            }
            #endregion ordenacao

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(planolojas.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /PlanoLoja/PlanoLojaDelete/5
        public ActionResult PlanoLojaDelete(int? id, bool? saveChangesError = false)
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

            var planoloja = _planolojaAppService.Get(id ?? default(int));

            if (planoloja == null)
            {
                //return HttpNotFound();
                throw new Exception();
            }

            //return View(planoloja);
            Loja loja = _lojaAppService.Find(t => t.CodigoLojaAlternate == planoloja.CODIGOLOJAALTERNATE).FirstOrDefault();

            PlanoLojaViewModel categoriaPercentualVM = new PlanoLojaViewModel(planoloja, loja);
            
            return View(categoriaPercentualVM);
        }

        //POST: /PlanoLoja/PlanoLojaDelete/5
        [HttpPost, ActionName("PlanoLojaDelete")]
        public ActionResult PlanoLojaDeleteConfirmed(int id)
        {
            try
            {
                var planoloja = _planolojaAppService.Get(id);

               _planolojaAppService.Remove(planoloja);
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("PlanoLojaDelete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("PlanoLojaIndex");

        }

        private PlanoLoja PlanoLojaAtivaVigente(PlanoLoja pl)
        {

            return _planolojaAppService.Find(t => t.ID_PLANO == pl.ID_PLANO
                                                        && t.CODIGOLOJAALTERNATE == pl.CODIGOLOJAALTERNATE
                                                        && t.STATUS == "A"
                                                        && (
                                                            (t.DT_INI <= pl.DT_INI && t.DT_FIM >= pl.DT_INI)
                                                            || (t.DT_FIM <= pl.DT_INI && t.DT_FIM >= pl.DT_FIM)
                                                            || (pl.DT_INI <= t.DT_INI && pl.DT_FIM >= t.DT_FIM)
                                                        )
                                                    ).FirstOrDefault();
        }

        private PlanoLoja ObtemPlanoLojaForm(PlanoLoja pl, bool insert = false)
        {
            pl.ID_PLANO = Convert.ToInt32(Request["PlanoLoja.ID_PLANO"]);
            pl.CODIGOLOJAALTERNATE = Request["PlanoLoja.CODIGOLOJAALTERNATE"];
            pl.DT_INI = Convert.ToDateTime(Request["PlanoLoja.DT_INI"]);
            pl.DT_FIM = Convert.ToDateTime(Request["PlanoLoja.DT_FIM"]);
            pl.STATUS = Request["PlanoLoja.STATUS"];

            pl.LAST_MODIFY_DATE = DateTime.Now;
            pl.LAST_MODIFY_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();

            if (insert)
            {
                pl.CREATED_DATETIME = pl.LAST_MODIFY_DATE;
                pl.CREATED_USERNAME = pl.LAST_MODIFY_USERNAME;
            }

            return pl;
        }

        private IEnumerable<PlanoLojaSearch> MontaSearchList(IEnumerable<PlanoLoja> planolojasAux)
        {
            List<PlanoLojaSearch> planoLojaSearchList = new List<PlanoLojaSearch>();

            foreach (PlanoLoja pl in planolojasAux)
            {
                PlanoLojaSearch pls = new PlanoLojaSearch();

                pls.ID_PLANO_LOJA = pl.ID_PLANO_LOJA;
                pls.ID_PLANO = pl.ID_PLANO;
                pls.CODIGOLOJAALTERNATE = pl.CODIGOLOJAALTERNATE;
                pls.DT_INI = pl.DT_INI;
                pls.DT_FIM = pl.DT_FIM;
                pls.STATUS = pl.STATUS;
                pls.Plano = pl.Plano;

                pls.Loja = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() == pl.CODIGOLOJAALTERNATE).FirstOrDefault();

                planoLojaSearchList.Add(pls);
            }

            IEnumerable<PlanoLojaSearch> planolojas = planoLojaSearchList;
            return planolojas;
        }

    }
}