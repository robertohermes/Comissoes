using Dufry.Comissoes.Application.Interfaces;
using Dufry.Comissoes.Controllers.Helpers;
using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Domain.Entities.Auxiliary;
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
    public class ComissoesController : Controller
    {
        private readonly IControleAcessoAppService _controleacessoAppService;
        private readonly IColaboradorAppService _colaboradorAppService;
        private readonly ILojaAppService _lojaAppService;

        public ComissoesController(IControleAcessoAppService controleacessoAppService, IColaboradorAppService colaboradorAppService, ILojaAppService lojaAppService)
        {
            _controleacessoAppService = controleacessoAppService;
            _colaboradorAppService = colaboradorAppService;
            _lojaAppService = lojaAppService;
        }

        protected override void Dispose(bool disposing)
        {
            _controleacessoAppService.Dispose();
            _colaboradorAppService.Dispose();
            _lojaAppService.Dispose();

            base.Dispose(disposing);
        }


        // GET: /Comissoes/ComissoesIndex
        public ActionResult ComissoesIndex()
        {
            #region populaobjetos
            var colaboradores = ObtemColaboradores();
            IEnumerable<SelectListItem> colaboradoresSelectListItem = new SelectList(colaboradores, "Key", "Value");
            ViewBag.COLABORADORKEY = new SelectList(colaboradores, "Key", "Value");

            var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1"); ;
            IEnumerable<SelectListItem> lojasSelectListItem = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            ViewBag.CODIGOLOJAALTERNATE = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");

            #endregion populaobjetos

            ComissoesViewModel comissoesVM = new ComissoesViewModel(colaboradoresSelectListItem, lojasSelectListItem);

            return View(comissoesVM);
        }

        private IEnumerable<KeyValuePair<string, string>> ObtemColaboradores()
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


    }
}