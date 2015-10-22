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
        private readonly IProdutoAppService _produtoAppService;
        private readonly ITipoBusinessAppService _tipobusinessAppService;
        private readonly ICargoAppService _cargoAppService;
        private readonly IAeroportoAppService _aeroportoAppService;
        private readonly IProdutoSubGrupoDufryAppService _produtoSubGrupoDufryAppService;

        public ComissoesController(IControleAcessoAppService controleacessoAppService, IColaboradorAppService colaboradorAppService, ILojaAppService lojaAppService, IProdutoAppService produtoAppService, ITipoBusinessAppService tipobusinessAppService, ICargoAppService cargoAppService, IAeroportoAppService aeroportoAppService, IProdutoSubGrupoDufryAppService produtoSubGrupoDufryAppService)
        {
            _controleacessoAppService = controleacessoAppService;
            _colaboradorAppService = colaboradorAppService;
            _lojaAppService = lojaAppService;
            _produtoAppService = produtoAppService;
            _tipobusinessAppService = tipobusinessAppService;
            _cargoAppService = cargoAppService;
            _aeroportoAppService = aeroportoAppService;
            _produtoSubGrupoDufryAppService = produtoSubGrupoDufryAppService;
        }

        protected override void Dispose(bool disposing)
        {
            _controleacessoAppService.Dispose();
            _colaboradorAppService.Dispose();
            _lojaAppService.Dispose();
            _produtoAppService.Dispose();
            _tipobusinessAppService.Dispose();
            _cargoAppService.Dispose();
            _aeroportoAppService.Dispose();
            _produtoSubGrupoDufryAppService.Dispose();

            base.Dispose(disposing);
        }

        
        // GET: /Comissoes/ComissoesIndex
        public ActionResult ComissoesIndex()
        {
            #region populaobjetos
            var colaboradores = ObtemColaboradores();
            IEnumerable<SelectListItem> colaboradoresSelectListItem = new SelectList(colaboradores, "Key", "Value");
            ViewBag.COLABORADORKEY = new SelectList(colaboradores, "Key", "Value");

            var cargos = _cargoAppService.Find(t => t.Id_Cargo.ToString().Trim() != "-1" && t.Id_Cargo.ToString().Trim() != "-2");
            IEnumerable<SelectListItem> cargosSelectListItem = new SelectList(cargos, "CodigoCargoAlternate", "NomeCargo");
            ViewBag.CodigoCargoAlternate = new SelectList(cargosSelectListItem, "CodigoCargoAlternate", "NomeCargo");

            var subgruposdufry = _produtoSubGrupoDufryAppService.Find(t => t.Id_ProdutoSubGrupoDufry.ToString().Trim() != "-1" && t.Id_ProdutoSubGrupoDufry.ToString().Trim() != "-2");
            IEnumerable<SelectListItem> subGruposDufrySelectListItem = new SelectList(subgruposdufry, "CodigoProdutoSubGrupoDufryAlternate", "NomeProdutoSubGrupoDufry");
            ViewBag.CodigoProdutoSubGrupoDufryAlternate = new SelectList(subGruposDufrySelectListItem, "CodigoProdutoSubGrupoDufryAlternate", "NomeProdutoSubGrupoDufry");
            
            var tipobusineses = _tipobusinessAppService.Find(t => t.CodigoTipoBusinessAlternate.ToString().Trim() != "-1" && t.CodigoTipoBusinessAlternate.ToString().Trim() != "-2");
            IEnumerable<SelectListItem> tipobusinesesSelectListItem = new SelectList(tipobusineses, "CodigoTipoBusinessAlternate", "NomeTipoBusiness");
            ViewBag.CodigoTipoBusinessAlternate = new SelectList(tipobusinesesSelectListItem, "CodigoTipoBusinessAlternate", "NomeTipoBusiness");

            var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1");
            IEnumerable<SelectListItem> lojasSelectListItem = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            ViewBag.CodigoLojaAlternate = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");

            var aeroportos = _aeroportoAppService.Find(t => t.Id_Aeroporto.ToString().Trim() != "-2" && t.Id_Aeroporto.ToString().Trim() != "-1");
            IEnumerable<SelectListItem> aeroportosSelectListItem = new SelectList(aeroportos, "Id_Aeroporto", "SiglaAeroporto");
            ViewBag.Id_Aeroporto = new SelectList(aeroportos, "Id_Aeroporto", "SiglaAeroporto");

            //<REVER>
            //var itens = _produtoAppService.Find(t => t.CodigoProdutoAlternate.Trim() != "N/A" && t.CodigoProdutoAlternate.Trim() != "DSC"); ;
            var itens = _produtoAppService.Find(t => t.CodigoProdutoAlternate.Trim() == "100000019" 
                                             || t.CodigoProdutoAlternate.Trim() == "100000027"
                                             || t.CodigoProdutoAlternate.Trim() == "100000035"
                                             || t.CodigoProdutoAlternate.Trim() == "100000043"
                                             || t.CodigoProdutoAlternate.Trim() == "100000051"
                                             || t.CodigoProdutoAlternate.Trim() == "100000060"
                                             || t.CodigoProdutoAlternate.Trim() == "100000078"
                                             || t.CodigoProdutoAlternate.Trim() == "100000086"
                                             || t.CodigoProdutoAlternate.Trim() == "100000094"
                                             || t.CodigoProdutoAlternate.Trim() == "100000108"
                                             ); 
            IEnumerable<SelectListItem> itensSelectListItem = new SelectList(itens, "CodigoProdutoAlternate", "DescricaoProdutoNome");
            ViewBag.CodigoProdutoAlternate = new SelectList(lojas, "CodigoProdutoAlternate", "DescricaoProdutoNome");

            #endregion populaobjetos

            ComissoesViewModel comissoesVM = new ComissoesViewModel(colaboradoresSelectListItem, lojasSelectListItem, itensSelectListItem, tipobusinesesSelectListItem, cargosSelectListItem, aeroportosSelectListItem, subGruposDufrySelectListItem);

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