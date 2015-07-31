using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;
using PagedList;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaAppService _categoriaAppService;

        public CategoriaController(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }

        // GET: /Categoria/CategoriaIndex
        public ViewResult CategoriaIndex(int? page
            , string sortOrder
            , string descricaoFilter, string descricaoSearchString
            , string tabelaFilter, string tabelaSearchString
            , string colunaFilter, string colunaSearchString
            , string statusFilter, string statusSearchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DescCategoriaSortParm = String.IsNullOrEmpty(sortOrder) ? "DESC_CATEGORIA_desc" : "";
            ViewBag.TabOrigemSortParm = sortOrder == "TAB_ORIGEM" ? "TAB_ORIGEM_desc" : "TAB_ORIGEM";
            ViewBag.ColOrigemSortParm = sortOrder == "COL_ORIGEM" ? "COL_ORIGEM_desc" : "COL_ORIGEM";
            ViewBag.StatusSortParm = sortOrder == "STATUS" ? "STATUS_desc" : "STATUS";

            if (descricaoSearchString != null && tabelaSearchString != null && colunaSearchString != null)
            {
                page = 1;
            }
            else
            {
                descricaoSearchString = descricaoFilter;
                tabelaSearchString = tabelaFilter;
                colunaSearchString = colunaFilter;
                statusSearchString = statusFilter;
            }

            ViewBag.CurrentFilter = descricaoSearchString;

            IEnumerable<Categoria> categorias = new List<Categoria>();

            if (String.IsNullOrEmpty(descricaoSearchString) && String.IsNullOrEmpty(tabelaSearchString) && String.IsNullOrEmpty(colunaSearchString) && String.IsNullOrEmpty(statusSearchString))
            {
                categorias = _categoriaAppService.All();
            }
            else
            {
                categorias = _categoriaAppService.Find(s => s.DESC_CATEGORIA.Contains(descricaoSearchString)
                                           && s.TAB_ORIGEM.Contains(tabelaSearchString)
                                           && s.COL_ORIGEM.Contains(colunaSearchString)
                                           && s.STATUS.Contains(statusSearchString));
            }

            switch (sortOrder)
            {
                case "COL_ORIGEM":
                    categorias = categorias.OrderBy(s => s.COL_ORIGEM);
                    break;
                case "TAB_ORIGEM":
                    categorias = categorias.OrderBy(s => s.TAB_ORIGEM);
                    break;
                case "STATUS":
                    categorias = categorias.OrderBy(s => s.STATUS);
                    break;
                case "DESC_CATEGORIA_desc":
                    categorias = categorias.OrderByDescending(s => s.DESC_CATEGORIA);
                    break;
                case "COL_ORIGEM_desc":
                    categorias = categorias.OrderByDescending(s => s.COL_ORIGEM);
                    break;
                case "TAB_ORIGEM_desc":
                    categorias = categorias.OrderByDescending(s => s.TAB_ORIGEM);
                    break;
                case "STATUS_desc":
                    categorias = categorias.OrderByDescending(s => s.STATUS);
                    break;
                default:  // DESC_CATEGORIA ascending 
                    categorias = categorias.OrderBy(s => s.DESC_CATEGORIA);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(categorias.ToPagedList(pageNumber, pageSize));
        }

    }
}