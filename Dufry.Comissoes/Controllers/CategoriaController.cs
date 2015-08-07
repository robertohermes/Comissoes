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
    public class CategoriaController : Controller
    {
        private readonly ICategoriaAppService _categoriaAppService;

        public CategoriaController(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }

        // GET: /Categoria/CategoriaIndex
        //[ControleAcessoAdminFilter]
        public ViewResult CategoriaIndex(int? page
            , string sortOrder
            , string descricaoFilter, string descricaoSearchString
            , string tabelaFilter, string tabelaSearchString
            , string colunaFilter, string colunaSearchString
            , string statusFilter, string statusSearchString)
        {
            #region trataParametrosOrdenacao
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DescCategoriaSortParam = String.IsNullOrEmpty(sortOrder) ? "DESC_CATEGORIA_desc" : "";
            ViewBag.TabOrigemSortParam = sortOrder == "TAB_ORIGEM" ? "TAB_ORIGEM_desc" : "TAB_ORIGEM";
            ViewBag.ColOrigemSortParam = sortOrder == "COL_ORIGEM" ? "COL_ORIGEM_desc" : "COL_ORIGEM";
            ViewBag.StatusSortParam = sortOrder == "STATUS" ? "STATUS_desc" : "STATUS";
            #endregion trataParametrosOrdenacao

            #region trataParametrosBusca
            if (String.IsNullOrEmpty(descricaoSearchString))
            {
                descricaoSearchString = "";
            }
            ViewBag.descricaoFilter = descricaoSearchString;

            if (String.IsNullOrEmpty(tabelaSearchString))
            {
                tabelaSearchString = "";
            }
            ViewBag.tabelaFilter = tabelaSearchString;

            if (String.IsNullOrEmpty(colunaSearchString))
            {
                colunaSearchString = "";
            }
            ViewBag.colunaFilter = colunaSearchString;

            if (String.IsNullOrEmpty(statusSearchString))
            {
                statusSearchString = "";
            }
            ViewBag.statusFilter = statusSearchString;
            #endregion trataParametrosBusca

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

            #region ordenacao
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
            #endregion ordenacao

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(categorias.ToPagedList(pageNumber, pageSize));
        }


        //
        // GET: /Categoria/CategoriaDelete/5
        public ActionResult CategoriaDelete(int ? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Erro na exclusão. Tente novamente ou, se o problema persistir, entre em contato com o suporte.";
            }

            var categoria = _categoriaAppService.Get(id ?? default(int));

            if (categoria == null)
            {
                return HttpNotFound();
            }

            if (categoria.CategoriaPercentuals.Count() > 0)
            {
                return RedirectToAction("CategoriaIndex");
            }

            CategoriaViewModel categoriaVM = new CategoriaViewModel();

            return  View(categoriaVM.ToViewModel(categoria));
        }

        //POST: /Categoria/CategoriaDelete/5
        [HttpPost, ActionName("CategoriaDelete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var categoria = _categoriaAppService.Get(id);

                if (categoria.CategoriaPercentuals.Count() == 0)
                {
                    _categoriaAppService.Remove(categoria);
                }
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("CategoriaDelete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("CategoriaIndex");

        }

        protected override void Dispose(bool disposing)
        {
            _categoriaAppService.Dispose();

            base.Dispose(disposing);
        }

    }
}