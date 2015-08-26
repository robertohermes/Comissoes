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
        private readonly IPlanoAppService _planoAppService;
        private readonly IControleAcessoAppService _controleacessoAppService;

        public PlanoController(IPlanoAppService planoAppService, IControleAcessoAppService controleacessoAppService)
        {
            _planoAppService = planoAppService;
            _controleacessoAppService = controleacessoAppService;
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
        public ActionResult PlanoConfirmed(int? id)
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

    }


}