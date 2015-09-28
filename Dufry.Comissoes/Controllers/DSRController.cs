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

            #region populaobjetos
            var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1"); ;
            IEnumerable<SelectListItem> lojaSelectListItem = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            ViewBag.CODIGOLOJAALTERNATE = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            #endregion populaobjetos

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
                dsr = ObtemDsrForm(dsr, true);

                if (ModelState.IsValid)
                {
                    DSR dsrExiste = new DSR();
                    dsrExiste = null;

                    if (dsr.STATUS == "A")
                    {
                        dsrExiste = DsrAtivaVigente(dsr);
                    }

                    if (dsrExiste == null || dsr.STATUS == "I")
                    {
                        _dsrAppService.Create(dsr);
                    }
                    else
                    {
                        throw new InvalidOperationException("Já existe um perído vigente e ativo que coincide com a tentativa de inclusão / alteração");
                    }

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

            #region populaobjetos
            var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1");
            IEnumerable<SelectListItem> lojaSelectListItem = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            ViewBag.CODIGOLOJAALTERNATE = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja", dsr.CODIGOLOJAALTERNATE);
            #endregion populaobjetos

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

            dsrToUpdate = ObtemDsrForm(dsrToUpdate);

            if (ModelState.IsValid)
            {
                try
                {
                    DSR dsrExiste = new DSR();
                    dsrExiste = null;

                    if (dsrToUpdate.STATUS == "A")
                    {
                        dsrExiste = DsrAtivaVigente(dsrToUpdate);
                    }

                    if (dsrExiste == null || dsrToUpdate.STATUS == "I")
                    {
                        _dsrAppService.Update(dsrToUpdate);
                    }
                    else
                    {
                        throw new InvalidOperationException("Já existe um perído vigente e ativo que coincide com a tentativa de inclusão / alteração");
                    }

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

            IEnumerable<DSRSearch> dsrs = MontaSearchList(_dsrAppService.Find(predicate));


            #region ordenacao
            switch (sortOrder)
            {
                case "NomeLoja":
                    dsrs = dsrs.OrderBy(s => s.Loja.NomeLoja);
                    break;
                case "DT_INI":
                    dsrs = dsrs.OrderBy(s => s.DT_INI);
                    break;
                case "DT_FIM":
                    dsrs = dsrs.OrderBy(s => s.DT_FIM);
                    break;
                case "STATUS":
                    dsrs = dsrs.OrderBy(s => s.STATUS);
                    break;
                case "PERCENTUAL_desc":
                    dsrs = dsrs.OrderByDescending(s => s.PERCENTUAL);
                    break;
                case "NomeLoja_desc":
                    dsrs = dsrs.OrderByDescending(s => s.Loja.NomeLoja);
                    break;
                case "DT_INI_desc":
                    dsrs = dsrs.OrderByDescending(s => s.DT_INI);
                    break;
                case "DT_FIM_desc":
                    dsrs = dsrs.OrderByDescending(s => s.DT_FIM);
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

        private DSR DsrAtivaVigente(DSR dsr)
        {

            return _dsrAppService.Find(t => t.CODIGOLOJAALTERNATE == dsr.CODIGOLOJAALTERNATE
                                        && t.STATUS == "A"
                                        && (
                                            (t.DT_INI <= dsr.DT_INI && t.DT_FIM >= dsr.DT_INI)
                                            || (t.DT_FIM <= dsr.DT_INI && t.DT_FIM >= dsr.DT_FIM)
                                            || (dsr.DT_INI <= t.DT_INI && dsr.DT_FIM >= t.DT_FIM)
                                        )
                                    ).FirstOrDefault();
        }

        private DSR ObtemDsrForm(DSR dsr, bool insert = false)
        {
            dsr.CODIGOLOJAALTERNATE = Request["Dsr.CODIGOLOJAALTERNATE"];
            dsr.PERCENTUAL = Convert.ToDecimal(Request["Dsr.PERCENTUAL"]);
            dsr.DT_INI = Convert.ToDateTime(Request["Dsr.DT_INI"]);
            dsr.DT_FIM = Convert.ToDateTime(Request["Dsr.DT_FIM"]);
            dsr.STATUS = Request["Dsr.STATUS"];

            dsr.LAST_MODIFY_DATE = DateTime.Now;
            dsr.LAST_MODIFY_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();

            if (insert)
            {
                dsr.CREATED_DATETIME = dsr.LAST_MODIFY_DATE;
                dsr.CREATED_USERNAME = dsr.LAST_MODIFY_USERNAME;
            }

            return dsr;
        }

        private IEnumerable<DSRSearch> MontaSearchList(IEnumerable<DSR> dsrsAux)
        {
            List<DSRSearch> dsrSearchList = new List<DSRSearch>();

            foreach (DSR dsr in dsrsAux)
            {
                DSRSearch dsrse = new DSRSearch();

                dsrse.ID_DSR = dsr.ID_DSR;
                dsrse.CODIGOLOJAALTERNATE = dsr.CODIGOLOJAALTERNATE;
                dsrse.PERCENTUAL = dsr.PERCENTUAL;
                dsrse.DT_INI = dsr.DT_INI;
                dsrse.DT_FIM = dsr.DT_FIM;
                dsrse.STATUS = dsr.STATUS;


                dsrse.Loja = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() == dsr.CODIGOLOJAALTERNATE).FirstOrDefault();

                dsrSearchList.Add(dsrse);
            }

            IEnumerable<DSRSearch> dsrs = dsrSearchList;
            return dsrs;
        }

    }
}