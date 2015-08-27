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
    public class DolarMedioController : Controller
    {

        private readonly IControleAcessoAppService _controleacessoAppService;
        private readonly IDolarMedioAppService _dolarmedioAppService;
        private readonly IPlanoAppService _planoAppService;

        public DolarMedioController(IDolarMedioAppService dolarmedioAppService, IControleAcessoAppService controleacessoAppService, IPlanoAppService planoAppService)
        {
            _dolarmedioAppService = dolarmedioAppService;
            _controleacessoAppService = controleacessoAppService;
            _planoAppService = planoAppService;
        }

        // GET: /DolarMedio/DolarMedioCreate
        public ActionResult DolarMedioCreate()
        {
            DolarMedio dolarmedio = new DolarMedio();
           
            var planos = _planoAppService.Find(t => t.STATUS == "A"); ;
            IEnumerable<SelectListItem> planoSelectListItem = new SelectList(planos, "ID_PLANO", "DESC_PLANO");
            ViewBag.CODIGOLOJAALTERNATE = new SelectList(planos, "ID_PLANO", "DESC_PLANO");

            DolarMedioViewModel dolarmedioVM = new DolarMedioViewModel(dolarmedio, planoSelectListItem);

            return View(dolarmedioVM);
        }

        // POST: /DolarMedio/DolarMedioCreate
        [HttpPost, ActionName("DolarMedioCreate")]
        //[ValidateAntiForgeryToken]
        public ActionResult DolarMedioCreateConfirmed(DolarMedio dolarmedio)
        {
            try
            {
                //---------------------------------------------------------------------------------------------
                //<REVER>
                //---------------------------------------------------------------------------------------------
                dolarmedio.ID_PLANO = Convert.ToInt32(Request["DolarMedio.ID_PLANO"]);
                dolarmedio.TIPO_TAXA = Request["DolarMedio.TIPO_TAXA"];
                dolarmedio.VALOR_DOLAR_MEDIO = Convert.ToDecimal(Request["DolarMedio.VALOR_DOLAR_MEDIO"]);
                dolarmedio.DT_INI = Convert.ToDateTime(Request["DolarMedio.DT_INI"]);
                dolarmedio.DT_FIM = Convert.ToDateTime(Request["DolarMedio.DT_FIM"]);

                //---------------------------------------------------------------------------------------------
                //<REVER>
                //---------------------------------------------------------------------------------------------
                dolarmedio.CREATED_DATETIME = DateTime.Now;
                dolarmedio.CREATED_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();

                dolarmedio.LAST_MODIFY_DATE = dolarmedio.CREATED_DATETIME;
                dolarmedio.LAST_MODIFY_USERNAME = dolarmedio.CREATED_USERNAME;
                //---------------------------------------------------------------------------------------------

                if (ModelState.IsValid)
                {
                    _dolarmedioAppService.Create(dolarmedio);
                    return RedirectToAction("DolarMedioIndex");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Erro ao salvar. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
            }

            return View(dolarmedio);
        }

        protected override void Dispose(bool disposing)
        {
            _dolarmedioAppService.Dispose();
            _controleacessoAppService.Dispose();
            _planoAppService.Dispose();

            base.Dispose(disposing);
        }
    }
}