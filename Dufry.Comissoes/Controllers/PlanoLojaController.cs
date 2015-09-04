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

    }
}