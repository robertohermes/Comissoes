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
        private readonly ICategoriaAppService _categoriaAppService;
        private readonly ILojaAppService _lojaAppService;

        public PlanoController(IControleAcessoAppService controleacessoAppService, IPlanoAppService planoAppService, ICategoriaAppService categoriaAppService, ILojaAppService lojaAppService)
        {
            _controleacessoAppService = controleacessoAppService;
            _planoAppService = planoAppService;
            _categoriaAppService = categoriaAppService;
            _lojaAppService = lojaAppService;
        }

        // GET: /Plano/PlanoCreate
        public ActionResult PlanoCreate()
        {
            Plano plano = new Plano();

            var categorias = _categoriaAppService.Find(t => t.STATUS == "A");
            IEnumerable<SelectListItem> categoriaSelectListItem = new SelectList(categorias, "ID_CATEGORIA", "DESC_CATEGORIA");
            ViewBag.ID_CATEGORIA = new SelectList(categorias, "ID_CATEGORIA", "DESC_CATEGORIA");

            var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1"); ;
            IEnumerable<SelectListItem> lojaSelectListItem = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            ViewBag.CODIGOLOJAALTERNATE = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");

            PlanoViewModel planoVM = new PlanoViewModel(plano, categoriaSelectListItem, lojaSelectListItem);

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

        protected override void Dispose(bool disposing)
        {
            _planoAppService.Dispose();
            _controleacessoAppService.Dispose();

            base.Dispose(disposing);
        }

    }


}