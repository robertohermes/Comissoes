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

            var cargos = _cargoAppService.Find(t => t.CodigoCargoAlternate.Trim() != "NA" && t.CodigoCargoAlternate.Trim() != "DS");
            IEnumerable<SelectListItem> cargoSelectListItem = new SelectList(cargos, "CodigoCargoAlternate", "NomeCargo");
            ViewBag.CodigoCargoAlternate = new SelectList(cargos, "CodigoCargoAlternate", "NomeCargo");

            var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1"); ;
            IEnumerable<SelectListItem> lojaSelectListItem = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            ViewBag.CODIGOLOJAALTERNATE = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");

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
                //---------------------------------------------------------------------------------------------
                //<REVER>
                //---------------------------------------------------------------------------------------------
                selfservice.CODIGOCARGOALTERNATE = Request["SelfService.CODIGOCARGOALTERNATE"];
                selfservice.CODIGOLOJAALTERNATE = Request["SelfService.CODIGOLOJAALTERNATE"];
                selfservice.DT_INI = Convert.ToDateTime(Request["SelfService.DT_INI"]);
                selfservice.DT_FIM = Convert.ToDateTime(Request["SelfService.DT_FIM"]);
                selfservice.STATUS = Request["SelfService.STATUS"];

                //---------------------------------------------------------------------------------------------
                //<REVER>
                //---------------------------------------------------------------------------------------------
                selfservice.CREATED_DATETIME = DateTime.Now;
                selfservice.CREATED_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();

                selfservice.LAST_MODIFY_DATE = selfservice.CREATED_DATETIME;
                selfservice.LAST_MODIFY_USERNAME = selfservice.CREATED_USERNAME;
                //---------------------------------------------------------------------------------------------

                if (ModelState.IsValid)
                {
                    _selfserviceAppService.Create(selfservice);
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

            var cargos = _cargoAppService.Find(t => t.CodigoCargoAlternate.Trim() != "NA" && t.CodigoCargoAlternate.Trim() != "DS");
            IEnumerable<SelectListItem> cargoSelectListItem = new SelectList(cargos, "CodigoCargoAlternate", "NomeCargo");
            ViewBag.CodigoCargoAlternate = new SelectList(cargos, "CodigoCargoAlternate", "NomeCargo", selfservice.CODIGOCARGOALTERNATE);

            var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1"); ;
            IEnumerable<SelectListItem> lojaSelectListItem = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            ViewBag.CODIGOLOJAALTERNATE = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja", selfservice.CODIGOLOJAALTERNATE);

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

            //---------------------------------------------------------------------------------------------
            //<REVER>
            //---------------------------------------------------------------------------------------------
            selfserviceToUpdate.CODIGOCARGOALTERNATE = Request["SelfService.CODIGOCARGOALTERNATE"];
            selfserviceToUpdate.CODIGOLOJAALTERNATE = Request["SelfService.CODIGOLOJAALTERNATE"];
            selfserviceToUpdate.DT_INI = Convert.ToDateTime(Request["SelfService.DT_INI"]);
            selfserviceToUpdate.DT_FIM = Convert.ToDateTime(Request["SelfService.DT_FIM"]);
            selfserviceToUpdate.STATUS = Request["SelfService.STATUS"];
            //---------------------------------------------------------------------------------------------

            //---------------------------------------------------------------------------------------------
            //<REVER>
            //---------------------------------------------------------------------------------------------
            selfserviceToUpdate.LAST_MODIFY_DATE = DateTime.Now;
            selfserviceToUpdate.LAST_MODIFY_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();
            //---------------------------------------------------------------------------------------------

            if (ModelState.IsValid)
            {
                try
                {
                    _selfserviceAppService.Update(selfserviceToUpdate);

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

        protected override void Dispose(bool disposing)
        {
            _controleacessoAppService.Dispose();
            _selfserviceAppService.Dispose();
            _lojaAppService.Dispose();
            _cargoAppService.Dispose();

            base.Dispose(disposing);
        }


    }
}