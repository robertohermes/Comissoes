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

        // GET: /AusenciaRemunerada/AusenciaRemuneradaCreate
        public ActionResult AusenciaRemuneradaCreate()
        {
            AusenciaRemunerada ausenciaremunerada = new AusenciaRemunerada();

            #region populaobjetos
            var colaboradores = ObtemColaboradores(ausenciaremunerada.COLABORADORKEY);
            IEnumerable<SelectListItem> colaboradoresSelectListItem = new SelectList(colaboradores, "Key", "Value");
            ViewBag.COLABORADORKEY = new SelectList(colaboradores, "Key", "Value");
            #endregion populaobjetos

            AusenciaRemuneradaViewModel ausenciaRemuneradaVM = new AusenciaRemuneradaViewModel(ausenciaremunerada, colaboradoresSelectListItem);

            return View(ausenciaRemuneradaVM);
        }

        // POST: /AusenciaRemunerada/AusenciaRemuneradaCreate
        [HttpPost, ActionName("AusenciaRemuneradaCreate")]
        //[ValidateAntiForgeryToken]
        public ActionResult AusenciaRemuneradaCreateConfirmed(AusenciaRemunerada ausenciaremunerada)
        {
            try
            {
                ausenciaremunerada = ObtemAusenciaRemuneradaForm(ausenciaremunerada, true);

                if (ModelState.IsValid)
                {
                    AusenciaRemunerada ausenciaremuneradaExiste = new AusenciaRemunerada();
                    ausenciaremuneradaExiste = null;

                    if (ausenciaremunerada.STATUS == "A")
                    {
                        ausenciaremuneradaExiste = AusenciaRemuneradaAtivaVigente(ausenciaremunerada);
                    }

                    if (ausenciaremuneradaExiste == null || ausenciaremunerada.STATUS == "I")
                    {
                        _ausenciaremuneradaAppService.Create(ausenciaremunerada);
                    }
                    else
                    {
                        throw new InvalidOperationException("Já existe um perído vigente e ativo que coincide com a tentativa de inclusão / alteração");
                    }
                    return RedirectToAction("AusenciaRemuneradaIndex");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Erro ao salvar. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
            }

            return View(ausenciaremunerada);
        }

        // GET: /AusenciaRemunerada/AusenciaRemuneradaEdit/5
        public ActionResult AusenciaRemuneradaEdit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }
            var ausenciaremunerada = _ausenciaremuneradaAppService.Get(id ?? default(int));
            if (ausenciaremunerada == null)
            {
                //return HttpNotFound();
                throw new Exception();
            }

            var controleacesso = _controleacessoAppService.Get(ausenciaremunerada.COLABORADORKEY);
            if (controleacesso == null)
            {
                //return HttpNotFound();
                throw new Exception();
            }

            var colaboradores = _colaboradorAppService.GET_ID(controleacesso.CODIGOEMPRESAALTERNATE, controleacesso.CODIGOFILIALALTERNATE, controleacesso.CODIGOSECUNDARIO).ToList();


            string nomeCompleto = "*** SEM NOME DE COLABORADOR ***";
            if (colaboradores.Count() != 0)
            {
                nomeCompleto = colaboradores.FirstOrDefault().NomeCompleto;
            }

            AusenciaRemuneradaViewModel ausenciaRemuneradaVM = new AusenciaRemuneradaViewModel(ausenciaremunerada, nomeCompleto);

            return View(ausenciaRemuneradaVM);

        }

        // POST: /AusenciaRemunerada/AusenciaRemuneradaEdit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("AusenciaRemuneradaEdit")]
        //[ValidateAntiForgeryToken]
        public ActionResult AusenciaRemuneradaEditConfirmed(int? id)
        {

            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }

            var ausenciaremuneradaToUpdate = _ausenciaremuneradaAppService.Get(id ?? default(int));

            ausenciaremuneradaToUpdate = ObtemAusenciaRemuneradaForm(ausenciaremuneradaToUpdate);

            if (ModelState.IsValid)
            {
                try
                {
                    AusenciaRemunerada ausenciaremuneradaExiste = new AusenciaRemunerada();
                    ausenciaremuneradaExiste = null;

                    if (ausenciaremuneradaToUpdate.STATUS == "A")
                    {
                        ausenciaremuneradaExiste = AusenciaRemuneradaAtivaVigente(ausenciaremuneradaToUpdate);
                    }

                    if (ausenciaremuneradaExiste == null || ausenciaremuneradaToUpdate.STATUS == "I")
                    {
                        _ausenciaremuneradaAppService.Update(ausenciaremuneradaToUpdate);
                    }
                    else
                    {
                        throw new InvalidOperationException("Já existe um perído vigente e ativo que coincide com a tentativa de inclusão / alteração");
                    }

                    return RedirectToAction("AusenciaRemuneradaIndex");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Erro na alteração. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
                }
            }

            return View(ausenciaremuneradaToUpdate);
        }


        protected override void Dispose(bool disposing)
        {
            _ausenciaremuneradaAppService.Dispose();
            _colaboradorAppService.Dispose();
            _controleacessoAppService.Dispose();

            base.Dispose(disposing);
        }

        private IEnumerable<KeyValuePair<string, string>> ObtemColaboradores(int colaboradorKey)
        {

            //Obtidos do BD do Comissoes
            var colaboradoresExistentes = _controleacessoAppService.Find(t => t.STATUS == "A");

            List<ColaboradorAux> colaboradorAuxList = new List<ColaboradorAux>();

            //Obtidos do BD do BI
            var colaboradoresBI = _colaboradorAppService.All_ID();

            foreach (var item in colaboradoresBI)
            {
                ColaboradorAux colaboradorAux = new ColaboradorAux();
                colaboradorAux.CODIGOSECUNDARIO = item.CodigoSecundario;
                colaboradorAux.CODIGOEMPRESAALTERNATE = item.CodigoEmpresaAlternate;
                colaboradorAux.CODIGOFILIALALTERNATE = item.CodigoFilialAlternate;
                colaboradorAux.NomeCompleto = item.NomeCompleto;

                colaboradorAuxList.Add(colaboradorAux);
            }

            IEnumerable<KeyValuePair<string, string>> colaboradoresAux = (from col in colaboradoresExistentes
                                                                       join aux in colaboradorAuxList
                                                                       on new { col.CODIGOSECUNDARIO, col.CODIGOEMPRESAALTERNATE, col.CODIGOFILIALALTERNATE }
                                                                       equals new { aux.CODIGOSECUNDARIO, aux.CODIGOEMPRESAALTERNATE, aux.CODIGOFILIALALTERNATE }
                                                                       select new
                                                                       {
                                                                           col.COLABORADORKEY,
                                                                           NomeCompleto = string.Format("{0} ({1}-{2}-{3})",
                                                                               aux.NomeCompleto, aux.CODIGOEMPRESAALTERNATE, aux.CODIGOFILIALALTERNATE, aux.CODIGOSECUNDARIO)
                                                                       })
                                                                       .OrderBy(aux => aux.NomeCompleto)
                                                                       .ToDictionary(row => (string)row.COLABORADORKEY.ToString(),
                                                                                     row => (string)row.NomeCompleto);

            return colaboradoresAux;
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
            ar.DESC_AUSENCIA = Request["AusenciaRemunerada.DESC_AUSENCIA"];
            ar.DT_INI = Convert.ToDateTime(Request["AusenciaRemunerada.DT_INI"]);
            ar.DT_FIM = Convert.ToDateTime(Request["AusenciaRemunerada.DT_FIM"]);
            ar.STATUS = Request["AusenciaRemunerada.STATUS"];

            ar.LAST_MODIFY_DATE = DateTime.Now;
            ar.LAST_MODIFY_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();

            if (insert)
            {
                ar.COLABORADORKEY = Convert.ToInt32(Request["AusenciaRemunerada.COLABORADORKEY"]);
                ar.CREATED_DATETIME = ar.LAST_MODIFY_DATE;
                ar.CREATED_USERNAME = ar.LAST_MODIFY_USERNAME;
            }

            return ar;
        }


        private class ColaboradorAux
        {
            public string CODIGOSECUNDARIO { get; set; }

            public string CODIGOEMPRESAALTERNATE { get; set; }

            public string CODIGOFILIALALTERNATE { get; set; }

            public string NomeCompleto { get; set; }

        }

    }
}