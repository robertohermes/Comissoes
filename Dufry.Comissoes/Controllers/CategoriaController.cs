using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;
using PagedList;

namespace Dufry.Comissoes.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaAppService _categoriaAppService;

        public CategoriaController(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }


        // GET: /Categoria/CategoriaBusca
        public ActionResult CategoriaBusca()
        {
            var categoriaModel = _categoriaAppService.All();


            return View(categoriaModel);
        }

        // GET: /Categoria/CategoriaIndex
        public ViewResult CategoriaIndex(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "DESC_CATEGORIA_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "COL_ORIGEM_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var categorias = _categoriaAppService.All();

            if (!String.IsNullOrEmpty(searchString))
            {
                categorias = categorias.Where(s => s.DESC_CATEGORIA.Contains(searchString)
                                       || s.TAB_ORIGEM.Contains(searchString)
                                       || s.COL_ORIGEM.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "DESC_CATEGORIA_desc":
                    categorias = categorias.OrderByDescending(s => s.DESC_CATEGORIA);
                    break;
                case "COL_ORIGEM":
                    categorias = categorias.OrderBy(s => s.COL_ORIGEM);
                    break;
                case "COL_ORIGEM_desc":
                    categorias = categorias.OrderByDescending(s => s.COL_ORIGEM);
                    break;
                default:  // DESC_CATEGORIA ascending 
                    categorias = categorias.OrderBy(s => s.DESC_CATEGORIA);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(categorias.ToPagedList(pageNumber, pageSize));
        }

    }
}