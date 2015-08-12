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
        private readonly IControleAcessoAppService _controleacessoAppService;

        //---------------------------------------------------------------------------------------------
        //<REVER>
        //---------------------------------------------------------------------------------------------
        public CategoriaController(ICategoriaAppService categoriaAppService, IControleAcessoAppService controleacessoAppService)
        {
            _categoriaAppService = categoriaAppService;
            _controleacessoAppService = controleacessoAppService;
        }
        //---------------------------------------------------------------------------------------------

        // GET: /Categoria/CategoriaCreate
        public ActionResult CategoriaCreate()
        {
            return View();
        }


        // POST: /Categoria/CategoriaCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CategoriaCreate([Bind(Include = "DESC_CATEGORIA, TAB_ORIGEM, COL_ORIGEM, STATUS")]Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //---------------------------------------------------------------------------------------------
                    //<REVER>
                    //---------------------------------------------------------------------------------------------
                    categoria.CREATED_DATETIME = DateTime.Now;
                    categoria.CREATED_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();

                    categoria.LAST_MODIFY_DATE = categoria.CREATED_DATETIME;
                    categoria.LAST_MODIFY_USERNAME = categoria.CREATED_USERNAME;
                    //---------------------------------------------------------------------------------------------

                    _categoriaAppService.Create(categoria);
                    return RedirectToAction("CategoriaIndex");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Erro ao salvar. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
            }

            //return View(categoria);
            CategoriaViewModel categoriaVM = new CategoriaViewModel();

            return View(categoriaVM.ToViewModel(categoria));
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
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //throw new InvalidOperationException("Something very bad happened while doing important stuff");
                throw new Exception();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Erro na exclusão. Tente novamente ou, se o problema persistir, entre em contato com o suporte.";
            }

            var categoria = _categoriaAppService.Get(id ?? default(int));

            if (categoria == null)
            {
                //return HttpNotFound();
                throw new Exception();
            }

            CategoriaViewModel categoriaVM = new CategoriaViewModel();

            return  View(categoriaVM.ToViewModel(categoria));
        }

        //POST: /Categoria/CategoriaDelete/5
        [HttpPost, ActionName("CategoriaDelete")]
        public ActionResult CategoriaDeleteConfirmed(int id)
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

        // GET: Categoria/CategoriaEdit/5
        public ActionResult CategoriaEdit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }
            var categoria = _categoriaAppService.Get(id ?? default(int));
            if (categoria == null)
            {
                //return HttpNotFound();
                throw new Exception();
            }

            CategoriaViewModel categoriaVM = new CategoriaViewModel();

            return View(categoriaVM.ToViewModel(categoria));
        }

        // POST: /Categoria/CategoriaEdit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("CategoriaEdit")]
        //[ValidateAntiForgeryToken]
        public ActionResult CategoriaEditConfirmed(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }
            var categoriaToUpdate = _categoriaAppService.Get(id ?? default(int));

            //---------------------------------------------------------------------------------------------
            //<REVER>
            //---------------------------------------------------------------------------------------------
            categoriaToUpdate.LAST_MODIFY_DATE = DateTime.Now;
            categoriaToUpdate.LAST_MODIFY_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();
            //---------------------------------------------------------------------------------------------

            if (TryUpdateModel(categoriaToUpdate, "",
               new string[] { "DESC_CATEGORIA", "TAB_ORIGEM", "COL_ORIGEM", "STATUS", "LAST_MODIFY_DATE", "LAST_MODIFY_USERNAME" }))
            {
                try
                {
                    _categoriaAppService.Update(categoriaToUpdate);

                    return RedirectToAction("CategoriaIndex");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Erro na alteração. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
                }
            }

            CategoriaViewModel categoriaVM = new CategoriaViewModel();

            return View(categoriaVM.ToViewModel(categoriaToUpdate));
        }

        protected override void Dispose(bool disposing)
        {
            _categoriaAppService.Dispose();
            _controleacessoAppService.Dispose();

            base.Dispose(disposing);
        }

    }
}