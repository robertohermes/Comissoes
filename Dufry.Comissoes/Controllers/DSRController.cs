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
using System.Web.Mvc;


namespace Dufry.Comissoes.Controllers
{
    [ControleAcessoAdminFilter]
    public class DSRController : Controller
    {
        private readonly IControleAcessoAppService _controleacessoAppService;
        private readonly IDSRAppService _dsrAppService;
        private readonly ILojaAppService _lojaAppService;


        public DSRController(IDSRAppService dsrAppService, IControleAcessoAppService controleacessoAppService, ILojaAppService lojaAppService)
        {
            _controleacessoAppService = controleacessoAppService;
            _dsrAppService = dsrAppService;
            _lojaAppService = lojaAppService;

        }

        // GET: /DSR/DsrCreate
        public ActionResult DsrCreate()
        {
            DSR dsr = new DSR();

            var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1"); ;
            IEnumerable<SelectListItem> lojaSelectListItem = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            ViewBag.CODIGOLOJAALTERNATE = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");

            DSRViewModel dsrVM = new DSRViewModel(dsr, lojaSelectListItem);

            return View(dsrVM);
        }

        // POST: /DSR/DsrCreate
        [HttpPost, ActionName("DsrCreate")]
        //[ValidateAntiForgeryToken]
        public ActionResult DsrCreateConfirmed(DSR dsr)
        {
            try
            {
                //---------------------------------------------------------------------------------------------
                //<REVER>
                //---------------------------------------------------------------------------------------------
                dsr.CODIGOLOJAALTERNATE = Request["Dsr.CODIGOLOJAALTERNATE"];
                dsr.PERCENTUAL = Convert.ToDecimal(Request["Dsr.PERCENTUAL"]);
                dsr.DT_INI = Convert.ToDateTime(Request["Dsr.DT_INI"]);
                dsr.DT_FIM = Convert.ToDateTime(Request["Dsr.DT_FIM"]);
                dsr.STATUS = Request["Dsr.STATUS"];

                //---------------------------------------------------------------------------------------------
                //<REVER>
                //---------------------------------------------------------------------------------------------
                dsr.CREATED_DATETIME = DateTime.Now;
                dsr.CREATED_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();

                dsr.LAST_MODIFY_DATE = dsr.CREATED_DATETIME;
                dsr.LAST_MODIFY_USERNAME = dsr.CREATED_USERNAME;
                //---------------------------------------------------------------------------------------------

                if (ModelState.IsValid)
                {
                    _dsrAppService.Create(dsr);
                    return RedirectToAction("DsrIndex");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Erro ao salvar. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
            }

            return View(dsr);
        }

        // GET: /DSR/DsrEdit/5
        public ActionResult DsrEdit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }
            var dsr = _dsrAppService.Get(id ?? default(int));
            if (dsr == null)
            {
                //return HttpNotFound();
                throw new Exception();
            }

            var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1");
            IEnumerable<SelectListItem> lojaSelectListItem = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            ViewBag.CODIGOLOJAALTERNATE = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja", dsr.CODIGOLOJAALTERNATE);

            DSRViewModel dsrVM = new DSRViewModel(dsr, lojaSelectListItem);

            return View(dsrVM);

        }

        // POST: /DSR/DsrEdit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("DsrEdit")]
        //[ValidateAntiForgeryToken]
        public ActionResult DsrEditConfirmed(int? id)
        {

            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }

            var dsrToUpdate = _dsrAppService.Get(id ?? default(int));

            //---------------------------------------------------------------------------------------------
            //<REVER>
            //---------------------------------------------------------------------------------------------
            dsrToUpdate.CODIGOLOJAALTERNATE = Request["Dsr.CODIGOLOJAALTERNATE"];
            dsrToUpdate.PERCENTUAL = Convert.ToDecimal(Request["Dsr.PERCENTUAL"]);
            dsrToUpdate.DT_INI = Convert.ToDateTime(Request["Dsr.DT_INI"]);
            dsrToUpdate.DT_FIM = Convert.ToDateTime(Request["Dsr.DT_FIM"]);
            dsrToUpdate.STATUS = Request["Dsr.STATUS"];
            //---------------------------------------------------------------------------------------------

            //---------------------------------------------------------------------------------------------
            //<REVER>
            //---------------------------------------------------------------------------------------------
            dsrToUpdate.LAST_MODIFY_DATE = DateTime.Now;
            dsrToUpdate.LAST_MODIFY_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();
            //---------------------------------------------------------------------------------------------

            if (ModelState.IsValid)
            {
                try
                {
                    _dsrAppService.Update(dsrToUpdate);

                    return RedirectToAction("DsrIndex");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Erro na alteração. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
                }
            }

            return View(dsrToUpdate);
        }

        // GET: /DSR/DsrIndex
        //[ControleAcessoAdminFilter]
        public ViewResult DsrIndex(int? page
            , string sortOrder
            , decimal? percentualSearchString
            , string codigolojaalternateSearchString
            , string dtiniSearchString
            , string dtfimSearchString
            , string statusSearchString)
        {

            #region populaobjetos
            var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1"); ;
            ViewBag.codigolojaalternateSearchString = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja", codigolojaalternateSearchString);
            #endregion populaobjetos

            #region trataParametrosOrdenacao
            ViewBag.CurrentSort = sortOrder;
            ViewBag.PercentualSortParam = String.IsNullOrEmpty(sortOrder) ? "PERCENTUAL_desc" : "";
            ViewBag.CodigoLojaAlternateSortParam = sortOrder == "NomeLoja" ? "NomeLoja_desc" : "NomeLoja";
            ViewBag.DtIniSortParam = sortOrder == "DT_INI" ? "DT_INI_desc" : "DT_INI";
            ViewBag.DtFimSortParam = sortOrder == "DT_FIM" ? "DT_FIM_desc" : "DT_FIM";
            ViewBag.StatusSortParam = sortOrder == "STATUS" ? "STATUS_desc" : "STATUS";
            #endregion trataParametrosOrdenacao

            #region trataParametrosBusca

            var predicate = PredicateBuilder.True<DSR>();
            //atributoSearchString = "";

            if (!String.IsNullOrEmpty(codigolojaalternateSearchString))
            {
                string codigolojaalternateFilter = codigolojaalternateSearchString;
                predicate = predicate.And(i => i.CODIGOLOJAALTERNATE.Equals(codigolojaalternateFilter));
                ViewBag.codigolojaalternateFilter = codigolojaalternateFilter;
            }

            if (percentualSearchString.HasValue)
            {
                decimal percentualFilter = percentualSearchString.GetValueOrDefault();
                predicate = predicate.And(i => i.PERCENTUAL.Equals(percentualFilter));
                ViewBag.percentualFilter = percentualFilter;
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

            IEnumerable<DSR> dsrs = new List<DSR>();

            dsrs = _dsrAppService.Find(predicate);

            #region ordenacao
            switch (sortOrder)
            {
                case "NomeLoja":
                    dsrs = dsrs.OrderBy(s => s.CODIGOLOJAALTERNATE); //mudar de chave para campo
                    break;
                case "DT_INI":
                    dsrs = dsrs.OrderBy(s => s.DT_INI); //mudar de chave para campo
                    break;
                case "DT_FIM":
                    dsrs = dsrs.OrderBy(s => s.DT_FIM); //mudar de chave para campo
                    break;
                case "STATUS":
                    dsrs = dsrs.OrderBy(s => s.STATUS);
                    break;
                case "PERCENTUAL_desc":
                    dsrs = dsrs.OrderByDescending(s => s.PERCENTUAL);
                    break;
                case "NomeLoja_desc":
                    dsrs = dsrs.OrderByDescending(s => s.CODIGOLOJAALTERNATE); //mudar de chave para campo
                    break;
                case "DT_INI_desc":
                    dsrs = dsrs.OrderByDescending(s => s.DT_INI); //mudar de chave para campo
                    break;
                case "DT_FIM_desc":
                    dsrs = dsrs.OrderByDescending(s => s.DT_FIM); //mudar de chave para campo
                    break;
                case "STATUS_desc":
                    dsrs = dsrs.OrderByDescending(s => s.STATUS);
                    break;
                default:  // ATRIBUTO ascending 
                    dsrs = dsrs.OrderBy(s => s.PERCENTUAL);
                    break;
            }
            #endregion ordenacao

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(dsrs.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /DSR/DsrDelete/5
        public ActionResult DsrDelete(int? id, bool? saveChangesError = false)
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

            var dsr = _dsrAppService.Get(id ?? default(int));

            if (dsr == null)
            {
                //return HttpNotFound();
                throw new Exception();
            }

            //return View(categoriapercentual);
            Loja loja = _lojaAppService.Find(t => t.CodigoLojaAlternate == dsr.CODIGOLOJAALTERNATE).FirstOrDefault();

            DSRViewModel dsrVM = new DSRViewModel(dsr, loja);

            return View(dsrVM);
        }

        //POST: /DSR/DsrDelete/5
        [HttpPost, ActionName("DsrDelete")]
        public ActionResult DsrDeleteConfirmed(int id)
        {
            try
            {
                var dsr = _dsrAppService.Get(id);

                _dsrAppService.Remove(dsr);
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("DsrDelete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("DsrIndex");

        }

        protected override void Dispose(bool disposing)
        {
            _controleacessoAppService.Dispose();
            _dsrAppService.Dispose();
            _lojaAppService.Dispose();

            base.Dispose(disposing);
        }

    }
}