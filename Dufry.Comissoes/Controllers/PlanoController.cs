using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;
using PagedList;
using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Filters;
using Dufry.Comissoes.ViewModels;
using System.Data.Entity.Infrastructure;
using Dufry.Comissoes.Controllers.Helpers;
using System.Globalization;

namespace Dufry.Comissoes.Controllers
{
    [ControleAcessoAdminFilter]
    public class PlanoController : Controller
    {
        private readonly IControleAcessoAppService _controleacessoAppService;
        private readonly IPlanoAppService _planoAppService;

        public PlanoController(IControleAcessoAppService controleacessoAppService, IPlanoAppService planoAppService)
        {
            _controleacessoAppService = controleacessoAppService;
            _planoAppService = planoAppService;
        }

        // GET: /Plano/PlanoCreate
        public ActionResult PlanoCreate()
        {
            Plano plano = new Plano();

            PlanoViewModel planoVM = new PlanoViewModel(plano);

            return View(planoVM);
        }

        // POST: /Plano/PlanoCreate
        [HttpPost, ActionName("PlanoCreate")]
        //[ValidateAntiForgeryToken]
        public ActionResult PlanoCreateConfirmed(Plano plano)
        {
            try
            {
                //---------------------------------------------------------------------------------------------
                //<REVER>
                //---------------------------------------------------------------------------------------------
                plano.DESC_PLANO = Request["Plano.DESC_PLANO"];
                plano.DT_INI = Convert.ToDateTime(Request["Plano.DT_INI"]);
                plano.DT_FIM = Convert.ToDateTime(Request["Plano.DT_FIM"]);
                plano.STATUS = Request["Plano.STATUS"];
                //---------------------------------------------------------------------------------------------
                //<REVER>
                //---------------------------------------------------------------------------------------------
                plano.CREATED_DATETIME = DateTime.Now;
                plano.CREATED_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();

                plano.LAST_MODIFY_DATE = plano.CREATED_DATETIME;
                plano.LAST_MODIFY_USERNAME = plano.CREATED_USERNAME;
                //---------------------------------------------------------------------------------------------

                if (ModelState.IsValid)
                {
                    _planoAppService.Create(plano);
                    return RedirectToAction("PlanoIndex");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Erro ao salvar. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
            }

            return View(plano);
        }


        // GET: /Plano/PlanoEdit/5
        public ActionResult PlanoEdit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }
            var plano = _planoAppService.Get(id ?? default(int));
            if (plano == null)
            {
                //return HttpNotFound();
                throw new Exception();
            }

            PlanoViewModel planoVM = new PlanoViewModel(plano);

            return View(planoVM);
        }

        // POST: /Plano/PlanoEdit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("PlanoEdit")]
        //[ValidateAntiForgeryToken]
        public ActionResult PlanoEditConfirmed(int? id)
        {

            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }

            var planoToUpdate = _planoAppService.Get(id ?? default(int));

            //---------------------------------------------------------------------------------------------
            //<REVER>
            //---------------------------------------------------------------------------------------------
            planoToUpdate.DESC_PLANO = Request["Plano.DESC_PLANO"];
            planoToUpdate.DT_INI = Convert.ToDateTime(Request["Plano.DT_INI"]);
            planoToUpdate.DT_FIM = Convert.ToDateTime(Request["Plano.DT_FIM"]);
            planoToUpdate.STATUS = Request["Plano.STATUS"];
            //---------------------------------------------------------------------------------------------

            //---------------------------------------------------------------------------------------------
            //<REVER>
            //---------------------------------------------------------------------------------------------
            planoToUpdate.LAST_MODIFY_DATE = DateTime.Now;
            planoToUpdate.LAST_MODIFY_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();
            //---------------------------------------------------------------------------------------------

            if (ModelState.IsValid)
            {
                try
                {
                    _planoAppService.Update(planoToUpdate);

                    return RedirectToAction("PlanoIndex");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Erro na alteração. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
                }
            }

            return View(planoToUpdate);
        }

        // GET: /Plano/PlanoIndex
        //[ControleAcessoAdminFilter]
        public ViewResult PlanoIndex(int? page
            , string sortOrder
            , string descplanoSearchString
            , string dtiniSearchString
            , string dtfimSearchString
            , string statusSearchString)
        {

            #region trataParametrosOrdenacao
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DescPlanoSortParam = String.IsNullOrEmpty(sortOrder) ? "DESC_PLANO" : "";
            ViewBag.DtIniSortParam = sortOrder == "DT_INI" ? "DT_INI_desc" : "DT_INI";
            ViewBag.DtFimSortParam = sortOrder == "DT_FIM" ? "DT_FIM_desc" : "DT_FIM";
            ViewBag.StatusSortParam = sortOrder == "STATUS" ? "STATUS_desc" : "STATUS";
            #endregion trataParametrosOrdenacao

            #region trataParametrosBusca

            var predicate = PredicateBuilder.True<Plano>();

            if (!String.IsNullOrEmpty(descplanoSearchString))
            {
                predicate = predicate.And(i => i.DESC_PLANO.Contains(descplanoSearchString));
                ViewBag.descplanoFilter = descplanoSearchString;
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

            IEnumerable<Plano> planos = new List<Plano>();

            planos = _planoAppService.Find(predicate);

            #region ordenacao
            switch (sortOrder)
            {
                case "DT_INI":
                    planos = planos.OrderBy(s => s.DT_INI); //mudar de chave para campo
                    break;
                case "DT_FIM":
                    planos = planos.OrderBy(s => s.DT_FIM); //mudar de chave para campo
                    break;
                case "STATUS":
                    planos = planos.OrderBy(s => s.STATUS);
                    break;
                case "DESC_PLANO_desc":
                    planos = planos.OrderByDescending(s => s.DESC_PLANO);
                    break;
                case "DT_INI_desc":
                    planos = planos.OrderByDescending(s => s.DT_INI); //mudar de chave para campo
                    break;
                case "DT_FIM_desc":
                    planos = planos.OrderByDescending(s => s.DT_FIM); //mudar de chave para campo
                    break;
                case "STATUS_desc":
                    planos = planos.OrderByDescending(s => s.STATUS);
                    break;
                default:  // DESC_PLANO ascending 
                    planos = planos.OrderBy(s => s.DESC_PLANO);
                    break;
            }
            #endregion ordenacao

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(planos.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Plano/PlanoDelete/5
        public ActionResult PlanoDelete(int? id, bool? saveChangesError = false)
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

            var plano = _planoAppService.Get(id ?? default(int));

            if (plano == null)
            {
                //return HttpNotFound();
                throw new Exception();
            }

            PlanoViewModel planoVM = new PlanoViewModel(plano);

            return View(planoVM);
        }

        //POST: /Plano/PlanoDelete/5
        [HttpPost, ActionName("PlanoDelete")]
        public ActionResult PlanoDeleteConfirmed(int id)
        {
            try
            {
                var plano = _planoAppService.Get(id);

                if (plano.PlanoCategorias.Count() == 0 && plano.DolarMedios.Count() == 0)
                {
                    _planoAppService.Remove(plano);
                }
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("PlanoDelete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("PlanoDelete");

        }

        protected override void Dispose(bool disposing)
        {
            _planoAppService.Dispose();
            _controleacessoAppService.Dispose();

            base.Dispose(disposing);
        }

    }


}