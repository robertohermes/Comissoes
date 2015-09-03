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
    public class AusenciaRemuneradaController : Controller
    {
        private readonly IControleAcessoAppService _controleacessoAppService;
        private readonly IAusenciaRemuneradaAppService _ausenciaremuneradaAppService;
        private readonly IColaboradorAppService _colaboradorAppService;

        public AusenciaRemuneradaController(IAusenciaRemuneradaAppService ausenciaremuneradaAppService, IColaboradorAppService colaboradorAppService, IControleAcessoAppService controleacessoAppService)
        {
            _ausenciaremuneradaAppService = ausenciaremuneradaAppService;
            _colaboradorAppService = colaboradorAppService;
            _controleacessoAppService = controleacessoAppService;
        }


        protected override void Dispose(bool disposing)
        {
            _ausenciaremuneradaAppService.Dispose();
            _colaboradorAppService.Dispose();
            _controleacessoAppService.Dispose();

            base.Dispose(disposing);
        }


        private AusenciaRemunerada AusenciaRemuneradaAtivaVigente(AusenciaRemunerada ar)
        {

            return _ausenciaremuneradaAppService.Find(t => t.COLABORADORKEY == ar.COLABORADORKEY
                                                        && t.DESC_AUSENCIA == ar.DESC_AUSENCIA
                                                        && t.STATUS == "A"
                                                        && (
                                                            (t.DT_INI <= ar.DT_INI && t.DT_FIM >= ar.DT_INI)
                                                            || (t.DT_FIM <= ar.DT_INI && t.DT_FIM >= ar.DT_FIM)
                                                            || (ar.DT_INI <= t.DT_INI && ar.DT_FIM >= t.DT_FIM)
                                                        )
                                                    ).FirstOrDefault();
        }

        private AusenciaRemunerada ObtemAusenciaRemuneradaForm(AusenciaRemunerada ar, bool insert = false)
        {
            ar.COLABORADORKEY = Convert.ToInt32(Request["AusenciaRemunerada.COLABORADORKEY"]);
            ar.DESC_AUSENCIA = Request["AusenciaRemunerada.DESC_AUSENCIA"];
            ar.DT_INI = Convert.ToDateTime(Request["AusenciaRemunerada.DT_INI"]);
            ar.DT_FIM = Convert.ToDateTime(Request["AusenciaRemunerada.DT_FIM"]);
            ar.STATUS = Request["AusenciaRemunerada.STATUS"];

            ar.LAST_MODIFY_DATE = DateTime.Now;
            ar.LAST_MODIFY_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();

            if (insert)
            {
                ar.CREATED_DATETIME = ar.LAST_MODIFY_DATE;
                ar.CREATED_USERNAME = ar.LAST_MODIFY_USERNAME;
            }

            return ar;
        }

    }
}