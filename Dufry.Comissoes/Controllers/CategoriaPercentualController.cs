using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;
using PagedList;
using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Filters;
using Dufry.Comissoes.ViewModels;
using System.Net;
using System.Data.Entity.Infrastructure;

namespace Dufry.Comissoes.Controllers
{
    [ControleAcessoAdminFilter]
    public class CategoriaPercentualController : Controller
    {
        private readonly ICategoriaPercentualAppService _categoriapercentualAppService;
        private readonly ILojaAppService _lojaAppService;
        private readonly IControleAcessoAppService _controleacessoAppService;

        public CategoriaPercentualController(ICategoriaPercentualAppService categoriapercentualAppService, IControleAcessoAppService controleacessoAppService, ILojaAppService lojaAppService)
        {
            _categoriapercentualAppService = categoriapercentualAppService;
            _lojaAppService = lojaAppService;
            _controleacessoAppService = controleacessoAppService;
        }

        // GET: /CategoriaPercentual/CategoriaPercentualIndex
        //[ControleAcessoAdminFilter]
        public ViewResult CategoriaPercentualIndex(int? page
            , string sortOrder
            , int idCategoriaFilter, int idCategoriaSearchString
            , string atributoFilter, string atributoSearchString
            , decimal codigolojaalternateFilter, decimal codigolojaalternateSearchString
            , decimal percentualFilter, decimal percentualSearchString
            , string dtiniFilter, string dtiniSearchString
            , string dtfimFilter, string dtfimSearchString
            , string statusFilter, string statusSearchString)
        {
            #region trataParametrosOrdenacao
            ViewBag.CurrentSort = sortOrder;
            ViewBag.AtributoSortParam = String.IsNullOrEmpty(sortOrder) ? "ATRIBUTO_desc" : "";
            ViewBag.DescCategoriaSortParam = sortOrder == "DESC_CATEGORIA" ? "DESC_CATEGORIA_desc" : "DESC_CATEGORIA";
            ViewBag.NomeLojaSortParam = sortOrder == "NomeLoja" ? "NomeLoja_desc" : "NomeLoja";
            ViewBag.PercentualSortParam = sortOrder == "PERCENTUAL" ? "PERCENTUAL_desc" : "PERCENTUAL";
            ViewBag.DtIniSortParam = sortOrder == "DT_INI" ? "DT_INI_desc" : "DT_INI";
            ViewBag.DtFimSortParam = sortOrder == "DT_FIM" ? "DT_FIM_desc" : "DT_FIM";
            ViewBag.StatusSortParam = sortOrder == "STATUS" ? "STATUS_desc" : "STATUS";
            #endregion trataParametrosOrdenacao

            #region trataParametrosBusca

            ViewBag.idCategoriaFilter = idCategoriaSearchString;

            if (String.IsNullOrEmpty(atributoSearchString))
            {
                atributoSearchString = "";
            }
            ViewBag.atributoFilter = atributoSearchString;

            ViewBag.codigolojaalternateFilter = codigolojaalternateSearchString;

            ViewBag.percentualFilter = percentualSearchString;

            if (String.IsNullOrEmpty(dtiniSearchString))
            {
                dtiniSearchString = "";
            }
            ViewBag.dtiniFilter = dtiniSearchString;

            if (String.IsNullOrEmpty(dtfimSearchString))
            {
                dtfimSearchString = "";
            }
            ViewBag.dtfimFilter = dtfimSearchString;

            if (String.IsNullOrEmpty(statusSearchString))
            {
                statusSearchString = "";
            }
            ViewBag.statusFilter = statusSearchString;

            #endregion trataParametrosBusca

            IEnumerable<CategoriaPercentual> categoriapercentuals = new List<CategoriaPercentual>();

            if (idCategoriaSearchString == 0 && String.IsNullOrEmpty(atributoSearchString) 
                && codigolojaalternateSearchString == 0 && percentualSearchString == 0
                && String.IsNullOrEmpty(dtiniSearchString) && String.IsNullOrEmpty(dtfimSearchString)
                && String.IsNullOrEmpty(statusSearchString))
            {
                categoriapercentuals = _categoriapercentualAppService.All();
            }
            else
            {
                categoriapercentuals = _categoriapercentualAppService.Find( s => s.ID_CATEGORIA.Equals(idCategoriaSearchString) 
                                           && s.ATRIBUTO.Contains(atributoSearchString)
                                           && s.CODIGOLOJAALTERNATE.Equals(codigolojaalternateSearchString)
                                           && s.PERCENTUAL.Equals(percentualSearchString)
                                           && s.DT_INI.Equals(dtiniSearchString)
                                           && s.DT_FIM.Equals(dtfimSearchString)
                                           && s.STATUS.Contains(statusSearchString));
            }

            #region ordenacao
            switch (sortOrder)
            {
                case "DESC_CATEGORIA":
                    categoriapercentuals = categoriapercentuals.OrderBy(s => s.ID_CATEGORIA); //mudar de chave para campo
                    break;
                case "NomeLoja":
                    categoriapercentuals = categoriapercentuals.OrderBy(s => s.CODIGOLOJAALTERNATE); //mudar de chave para campo
                    break;
                case "PERCENTUAL":
                    categoriapercentuals = categoriapercentuals.OrderBy(s => s.PERCENTUAL);
                    break;
                case "DT_INI":
                    categoriapercentuals = categoriapercentuals.OrderBy(s => s.DT_INI); //mudar de chave para campo
                    break;
                case "DT_FIM":
                    categoriapercentuals = categoriapercentuals.OrderBy(s => s.DT_FIM); //mudar de chave para campo
                    break;
                case "STATUS":
                    categoriapercentuals = categoriapercentuals.OrderBy(s => s.STATUS);
                    break;
                case "ATRIBUTO_desc":
                    categoriapercentuals = categoriapercentuals.OrderByDescending(s => s.ATRIBUTO);
                    break;
                case "DESC_CATEGORIA_desc":
                    categoriapercentuals = categoriapercentuals.OrderByDescending(s => s.ID_CATEGORIA); //mudar de chave para campo
                    break;
                case "NomeLoja_desc":
                    categoriapercentuals = categoriapercentuals.OrderByDescending(s => s.CODIGOLOJAALTERNATE); //mudar de chave para campo
                    break;
                case "PERCENTUAL_desc":
                    categoriapercentuals = categoriapercentuals.OrderByDescending(s => s.PERCENTUAL);
                    break;
                case "DT_INI_desc":
                    categoriapercentuals = categoriapercentuals.OrderByDescending(s => s.DT_INI); //mudar de chave para campo
                    break;
                case "DT_FIM_desc":
                    categoriapercentuals = categoriapercentuals.OrderByDescending(s => s.DT_FIM); //mudar de chave para campo
                    break;
                case "STATUS_desc":
                    categoriapercentuals = categoriapercentuals.OrderByDescending(s => s.STATUS);
                    break;
                default:  // ATRIBUTO ascending 
                    categoriapercentuals = categoriapercentuals.OrderBy(s => s.ATRIBUTO);
                    break;
            }
            #endregion ordenacao

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(categoriapercentuals.ToPagedList(pageNumber, pageSize));
        }

        protected override void Dispose(bool disposing)
        {
            _categoriapercentualAppService.Dispose();
            _controleacessoAppService.Dispose();

            base.Dispose(disposing);
        }

    }
}