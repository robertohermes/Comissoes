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
    public class SelfServiceController : Controller
    {
        private readonly IControleAcessoAppService _controleacessoAppService;
        private readonly ISelfServiceAppService _selfserviceAppService;
        private readonly ICargoAppService _cargoAppService;
        private readonly ILojaAppService _lojaAppService;


        public SelfServiceController(IControleAcessoAppService controleacessoAppService, ISelfServiceAppService selfserviceAppService, ILojaAppService lojaAppService, ICargoAppService cargoAppService)
        {
            _controleacessoAppService = controleacessoAppService;
            _selfserviceAppService = selfserviceAppService;
            _lojaAppService = lojaAppService;
            _cargoAppService = cargoAppService;
        }

        // GET: /SelfService/SelfServiceCreate
        public ActionResult SelfServiceCreate()
        {
            SelfService selfService = new SelfService();

            #region populaobjetos
            var cargos = _cargoAppService.Find(t => t.CodigoCargoAlternate.Trim() != "NA" && t.CodigoCargoAlternate.Trim() != "DS");
            IEnumerable<SelectListItem> cargoSelectListItem = new SelectList(cargos, "CodigoCargoAlternate", "NomeCargo");
            ViewBag.CodigoCargoAlternate = new SelectList(cargos, "CodigoCargoAlternate", "NomeCargo");

            var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1"); ;
            IEnumerable<SelectListItem> lojaSelectListItem = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            ViewBag.CODIGOLOJAALTERNATE = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            #endregion populaobjetos

            SelfServiceViewModel selfServiceVM = new SelfServiceViewModel(selfService, cargoSelectListItem, lojaSelectListItem);

            return View(selfServiceVM);
        }

        // POST: /SelfService/SelfServiceCreate
        [HttpPost, ActionName("SelfServiceCreate")]
        //[ValidateAntiForgeryToken]
        public ActionResult SelfServiceCreateConfirmed(SelfService selfservice)
        {
            try
            {
                selfservice = ObtemSelfServiceForm(selfservice, true);

                if (ModelState.IsValid)
                {
                    SelfService selfserviceExiste = new SelfService();
                    selfserviceExiste = null;

                    if (selfservice.STATUS == "A")
                    {
                        selfserviceExiste = SelfServiceAtivaVigente(selfservice);
                    }

                    if (selfserviceExiste == null || selfservice.STATUS == "I")
                    {
                        _selfserviceAppService.Create(selfservice);
                    }
                    else
                    {
                        throw new InvalidOperationException("Já existe um perído vigente e ativo que coincide com a tentativa de inclusão / alteração");
                    }

                    return RedirectToAction("SelfServiceIndex");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Erro ao salvar. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
            }

            return View(selfservice);
        }

        // GET: /SelfService/SelfServiceEdit/5
        public ActionResult SelfServiceEdit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }
            var selfservice = _selfserviceAppService.Get(id ?? default(int));
            if (selfservice == null)
            {
                //return HttpNotFound();
                throw new Exception();
            }

            #region populaobjetos
            var cargos = _cargoAppService.Find(t => t.CodigoCargoAlternate.Trim() != "NA" && t.CodigoCargoAlternate.Trim() != "DS");
            IEnumerable<SelectListItem> cargoSelectListItem = new SelectList(cargos, "CodigoCargoAlternate", "NomeCargo");
            ViewBag.CodigoCargoAlternate = new SelectList(cargos, "CodigoCargoAlternate", "NomeCargo", selfservice.CODIGOCARGOALTERNATE);

            var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1"); ;
            IEnumerable<SelectListItem> lojaSelectListItem = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            ViewBag.CODIGOLOJAALTERNATE = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja", selfservice.CODIGOLOJAALTERNATE);
            #endregion populaobjetos

            SelfServiceViewModel selfServiceVM = new SelfServiceViewModel(selfservice, cargoSelectListItem, lojaSelectListItem);

            return View(selfServiceVM);

        }

        // POST: /SelfService/SelfServiceEdit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("SelfServiceEdit")]
        //[ValidateAntiForgeryToken]
        public ActionResult SelfServiceEditConfirmed(int? id)
        {

            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }

            var selfserviceToUpdate = _selfserviceAppService.Get(id ?? default(int));

            selfserviceToUpdate = ObtemSelfServiceForm(selfserviceToUpdate);

            if (ModelState.IsValid)
            {
                try
                {
                    SelfService selfserviceExiste = new SelfService();
                    selfserviceExiste = null;

                    if (selfserviceToUpdate.STATUS == "A")
                    {
                        selfserviceExiste = SelfServiceAtivaVigente(selfserviceToUpdate);
                    }

                    if (selfserviceExiste == null || selfserviceToUpdate.STATUS == "I")
                    {
                        _selfserviceAppService.Update(selfserviceToUpdate);
                    }
                    else
                    {
                        throw new InvalidOperationException("Já existe um perído vigente e ativo que coincide com a tentativa de inclusão / alteração");
                    }

                    return RedirectToAction("SelfServiceIndex");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Erro na alteração. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
                }
            }

            return View(selfserviceToUpdate);
        }

        //
        // GET: /SelfService/SelfServiceDelete/5
        public ActionResult SelfServiceDelete(int? id, bool? saveChangesError = false)
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

            var selfservice = _selfserviceAppService.Get(id ?? default(int));

            if (selfservice == null)
            {
                //return HttpNotFound();
                throw new Exception();
            }

            Cargo cargo = _cargoAppService.Find(t => t.CodigoCargoAlternate == selfservice.CODIGOCARGOALTERNATE).FirstOrDefault();

            Loja loja = _lojaAppService.Find(t => t.CodigoLojaAlternate == selfservice.CODIGOLOJAALTERNATE).FirstOrDefault();

            SelfServiceViewModel selfServiceVM = new SelfServiceViewModel(selfservice, cargo, loja);

            return View(selfServiceVM);
        }

        //POST: /SelfService/SelfServiceDelete/5
        [HttpPost, ActionName("SelfServiceDelete")]
        public ActionResult SelfServiceDeleteConfirmed(int id)
        {
            try
            {
                var selfservice = _selfserviceAppService.Get(id);

                _selfserviceAppService.Remove(selfservice);
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("SelfServiceDelete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("SelfServiceIndex");

        }

        // GET: /SelfService/SelfServiceIndex
        //[ControleAcessoAdminFilter]
        public ViewResult SelfServiceIndex(int? page
            , string sortOrder
            , string codigocargoalternateSearchString
            , string codigolojaalternateSearchString
            , string dtiniSearchString
            , string dtfimSearchString
            , string statusSearchString)
        {

            #region populaobjetos
            var cargos = _cargoAppService.Find(t => t.CodigoCargoAlternate.Trim() != "NA" && t.CodigoCargoAlternate.Trim() != "DS");
            ViewBag.codigocargoalternateSearchString = new SelectList(cargos, "CodigoCargoAlternate", "NomeCargo", codigocargoalternateSearchString);

            var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1"); ;
            ViewBag.codigolojaalternateSearchString = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja", codigolojaalternateSearchString);
            #endregion populaobjetos

            #region trataParametrosOrdenacao
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CodigoCargoAlternateSortParam = String.IsNullOrEmpty(sortOrder) ? "NomeCargo_desc" : "";
            ViewBag.CodigoLojaAlternateSortParam = sortOrder == "NomeLoja" ? "NomeLoja_desc" : "NomeLoja";
            ViewBag.DtIniSortParam = sortOrder == "DT_INI" ? "DT_INI_desc" : "DT_INI";
            ViewBag.DtFimSortParam = sortOrder == "DT_FIM" ? "DT_FIM_desc" : "DT_FIM";
            ViewBag.StatusSortParam = sortOrder == "STATUS" ? "STATUS_desc" : "STATUS";
            #endregion trataParametrosOrdenacao

            #region trataParametrosBusca

            var predicate = PredicateBuilder.True<SelfService>();


            if (!String.IsNullOrEmpty(codigocargoalternateSearchString))
            {
                string codigocargoalternateFilter = codigocargoalternateSearchString;
                predicate = predicate.And(i => i.CODIGOCARGOALTERNATE.Equals(codigocargoalternateFilter));
                ViewBag.codigocargoalternateFilter = codigocargoalternateFilter;
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

            IEnumerable<SelfService> selfservices = new List<SelfService>();

            selfservices = _selfserviceAppService.Find(predicate);

            #region ordenacao
            switch (sortOrder)
            {
                case "NomeLoja":
                    selfservices = selfservices.OrderBy(s => s.CODIGOLOJAALTERNATE); //mudar de chave para campo
                    break;
                case "DT_INI":
                    selfservices = selfservices.OrderBy(s => s.DT_INI); //mudar de chave para campo
                    break;
                case "DT_FIM":
                    selfservices = selfservices.OrderBy(s => s.DT_FIM); //mudar de chave para campo
                    break;
                case "STATUS":
                    selfservices = selfservices.OrderBy(s => s.STATUS);
                    break;
                case "NomeCargo_desc":
                    selfservices = selfservices.OrderByDescending(s => s.CODIGOCARGOALTERNATE);
                    break;
                case "NomeLoja_desc":
                    selfservices = selfservices.OrderByDescending(s => s.CODIGOLOJAALTERNATE); //mudar de chave para campo
                    break;
                case "DT_INI_desc":
                    selfservices = selfservices.OrderByDescending(s => s.DT_INI); //mudar de chave para campo
                    break;
                case "DT_FIM_desc":
                    selfservices = selfservices.OrderByDescending(s => s.DT_FIM); //mudar de chave para campo
                    break;
                case "STATUS_desc":
                    selfservices = selfservices.OrderByDescending(s => s.STATUS);
                    break;
                default:  // NomeCargo ascending 
                    selfservices = selfservices.OrderBy(s => s.CODIGOCARGOALTERNATE);
                    break;
            }
            #endregion ordenacao

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(selfservices.ToPagedList(pageNumber, pageSize));
        }

        protected override void Dispose(bool disposing)
        {
            _controleacessoAppService.Dispose();
            _selfserviceAppService.Dispose();
            _lojaAppService.Dispose();
            _cargoAppService.Dispose();

            base.Dispose(disposing);
        }

        private SelfService SelfServiceAtivaVigente(SelfService ss)
        {

            return _selfserviceAppService.Find(t => t.CODIGOCARGOALTERNATE == ss.CODIGOCARGOALTERNATE
                                                && t.CODIGOLOJAALTERNATE == ss.CODIGOLOJAALTERNATE
                                                && t.STATUS == "A"
                                                && (
                                                    (t.DT_INI <= ss.DT_INI && t.DT_FIM >= ss.DT_INI)
                                                    || (t.DT_FIM <= ss.DT_INI && t.DT_FIM >= ss.DT_FIM)
                                                    || (ss.DT_INI <= t.DT_INI && ss.DT_FIM >= t.DT_FIM)
                                                )
                                            ).FirstOrDefault();
        }

        private SelfService ObtemSelfServiceForm(SelfService ss, bool insert = false)
        {
            ss.CODIGOCARGOALTERNATE = Request["SelfService.CODIGOCARGOALTERNATE"];
            ss.CODIGOLOJAALTERNATE = Request["SelfService.CODIGOLOJAALTERNATE"];
            ss.DT_INI = Convert.ToDateTime(Request["SelfService.DT_INI"]);
            ss.DT_FIM = Convert.ToDateTime(Request["SelfService.DT_FIM"]);
            ss.STATUS = Request["SelfService.STATUS"];

            ss.LAST_MODIFY_DATE = DateTime.Now;
            ss.LAST_MODIFY_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();

            if (insert)
            {
                ss.CREATED_DATETIME = ss.LAST_MODIFY_DATE;
                ss.CREATED_USERNAME = ss.LAST_MODIFY_USERNAME;
            }

            return ss;
        }


    }
}