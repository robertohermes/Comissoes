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
using Dufry.Comissoes.Controllers.Helpers;

namespace Dufry.Comissoes.Controllers
{
    [ControleAcessoAdminFilter]
    public class CategoriaPercentualController : Controller
    {
        private readonly ICategoriaPercentualAppService _categoriapercentualAppService;
        private readonly ICategoriaAppService _categoriaAppService;
        private readonly ILojaAppService _lojaAppService;
        private readonly IControleAcessoAppService _controleacessoAppService;

        public CategoriaPercentualController(ICategoriaPercentualAppService categoriapercentualAppService, ICategoriaAppService categoriaAppService, IControleAcessoAppService controleacessoAppService, ILojaAppService lojaAppService)
        {
            _categoriapercentualAppService = categoriapercentualAppService;
            _categoriaAppService = categoriaAppService;
            _lojaAppService = lojaAppService;
            _controleacessoAppService = controleacessoAppService;
        }

        // GET: /CategoriaPercentual/CategoriaPercentualCreate
        public ActionResult CategoriaPercentualCreate()
        {
            var categorias = _categoriaAppService.Find(t => t.STATUS == "A");

            IEnumerable<SelectListItem> categoriaSelectListItem = new SelectList(categorias, "ID_CATEGORIA", "DESC_CATEGORIA");
            ViewBag.ID_CATEGORIA = new SelectList(categorias, "ID_CATEGORIA", "DESC_CATEGORIA");

            #region desfazer
            //List<Loja> lojaList = new List<Loja>();
            //lojaList.Add(new Loja { CodigoLojaAlternate = 0, NomeLoja = "--- Selecione ---" });
            //lojaList.AddRange(_lojaAppService.All(true).ToList());
            //ViewBag.CODIGOLOJAALTERNATE = new SelectList(lojaList, "CodigoLojaAlternate", "NomeLoja", categoriapercentual.CODIGOLOJAALTERNATE);

            //var lojas = _lojaAppService.All(true);
            //IEnumerable<SelectListItem> lojaSelectListItem = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            //ViewBag.CODIGOLOJAALTERNATE = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja", categoriapercentual.CODIGOLOJAALTERNATE);
            #endregion desfazer

            CategoriaPercentual categoriapercentual = new CategoriaPercentual();

            CategoriaPercentualViewModel categoriaPercentualVM = new CategoriaPercentualViewModel(categoriapercentual, categoriaSelectListItem);

            return View(categoriaPercentualVM);
        }

        // POST: /CategoriaPercentual/CategoriaPercentualCreate
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CategoriaPercentualCreate(CategoriaPercentual categoriapercentual)
        {
            try
            {
                //---------------------------------------------------------------------------------------------
                //<REVER>
                //---------------------------------------------------------------------------------------------
                categoriapercentual.ID_CATEGORIA = Convert.ToInt32(Request["CategoriaPercentual.ID_CATEGORIA"]);
                categoriapercentual.ATRIBUTO = Request["CategoriaPercentual.ATRIBUTO"];
                categoriapercentual.CODIGOLOJAALTERNATE = -2;   //<REVER>
                categoriapercentual.PERCENTUAL = Convert.ToDecimal(Request["CategoriaPercentual.PERCENTUAL"]);
                categoriapercentual.DT_INI = Convert.ToDateTime(Request["CategoriaPercentual.DT_INI"]);
                categoriapercentual.DT_FIM = Convert.ToDateTime(Request["CategoriaPercentual.DT_FIM"]);
                categoriapercentual.STATUS = Request["CategoriaPercentual.STATUS"];

                //---------------------------------------------------------------------------------------------
                //<REVER>
                //---------------------------------------------------------------------------------------------
                categoriapercentual.CREATED_DATETIME = DateTime.Now;
                categoriapercentual.CREATED_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();

                categoriapercentual.LAST_MODIFY_DATE = categoriapercentual.CREATED_DATETIME;
                categoriapercentual.LAST_MODIFY_USERNAME = categoriapercentual.CREATED_USERNAME;
                //---------------------------------------------------------------------------------------------

                if (ModelState.IsValid)
                {
                    _categoriapercentualAppService.Create(categoriapercentual);
                    return RedirectToAction("CategoriaPercentualIndex");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Erro ao salvar. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
            }

            return View(categoriapercentual);
        }

        // GET: /CategoriaPercentual/CategoriaPercentualEdit/5
        public ActionResult CategoriaPercentualEdit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }
            var categoriapercentual = _categoriapercentualAppService.Get(id ?? default(int));
            if (categoriapercentual == null)
            {
                //return HttpNotFound();
                throw new Exception();
            }

            var categorias = _categoriaAppService.Find(t => t.STATUS == "A");

            IEnumerable<SelectListItem> categoriaSelectListItem = new SelectList(categorias, "ID_CATEGORIA", "DESC_CATEGORIA");
            ViewBag.ID_CATEGORIA = new SelectList(categorias, "ID_CATEGORIA", "DESC_CATEGORIA", categoriapercentual.ID_CATEGORIA);

            #region desfazer
            //List<Loja> lojaList = new List<Loja>();
            //lojaList.Add(new Loja { CodigoLojaAlternate = 0, NomeLoja = "--- Selecione ---" });
            //lojaList.AddRange(_lojaAppService.All(true).ToList());
            //ViewBag.CODIGOLOJAALTERNATE = new SelectList(lojaList, "CodigoLojaAlternate", "NomeLoja", categoriapercentual.CODIGOLOJAALTERNATE);

            //var lojas = _lojaAppService.All(true);
            //IEnumerable<SelectListItem> lojaSelectListItem = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            //ViewBag.CODIGOLOJAALTERNATE = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja", categoriapercentual.CODIGOLOJAALTERNATE);
            #endregion desfazer

            CategoriaPercentualViewModel categoriaPercentualVM = new CategoriaPercentualViewModel(categoriapercentual, categoriaSelectListItem);

            return View(categoriaPercentualVM);

        }

        // POST: /CategoriaPercentual/CategoriaPercentualEdit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("CategoriaPercentualEdit")]
        //[ValidateAntiForgeryToken]
        public ActionResult CategoriaPercentualEditConfirmed(int? id)
        {

            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }

            var categoriapercentualToUpdate = _categoriapercentualAppService.Get(id ?? default(int));

            //---------------------------------------------------------------------------------------------
            //<REVER>
            //---------------------------------------------------------------------------------------------
            categoriapercentualToUpdate.ID_CATEGORIA = Convert.ToInt32(Request["CategoriaPercentual.ID_CATEGORIA"]);
            categoriapercentualToUpdate.ATRIBUTO = Request["CategoriaPercentual.ATRIBUTO"];
            categoriapercentualToUpdate.CODIGOLOJAALTERNATE = -2;   //<REVER>
            categoriapercentualToUpdate.PERCENTUAL = Convert.ToDecimal(Request["CategoriaPercentual.PERCENTUAL"]);
            categoriapercentualToUpdate.DT_INI = Convert.ToDateTime(Request["CategoriaPercentual.DT_INI"]);
            categoriapercentualToUpdate.DT_FIM = Convert.ToDateTime(Request["CategoriaPercentual.DT_FIM"]);
            categoriapercentualToUpdate.STATUS = Request["CategoriaPercentual.STATUS"];
            //---------------------------------------------------------------------------------------------

            //---------------------------------------------------------------------------------------------
            //<REVER>
            //---------------------------------------------------------------------------------------------
            categoriapercentualToUpdate.LAST_MODIFY_DATE = DateTime.Now;
            categoriapercentualToUpdate.LAST_MODIFY_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();
            //---------------------------------------------------------------------------------------------

            if (ModelState.IsValid)
            {
                try
                {
                    _categoriapercentualAppService.Update(categoriapercentualToUpdate);

                    return RedirectToAction("CategoriaPercentualIndex");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Erro na alteração. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
                }
            }

            return View(categoriapercentualToUpdate);
        }

        // GET: /CategoriaPercentual/CategoriaPercentualIndex
        //[ControleAcessoAdminFilter]
        public ViewResult CategoriaPercentualIndex(int? page
            , string sortOrder
            , int? idCategoriaSearchString
            , decimal? percentualSearchString
            //, decimal ? codigolojaalternateSearchString
            , string atributoSearchString
            , string dtiniSearchString
            , string dtfimSearchString
            , string statusSearchString)
        {

            #region populaobjetos
            var categorias = _categoriaAppService.Find(t => t.STATUS == "A");
            ViewBag.idCategoriaSearchString = new SelectList(categorias, "ID_CATEGORIA", "DESC_CATEGORIA", idCategoriaSearchString);

            #region desfazer
            //var lojas = _lojaAppService.All(true);
            //ViewBag.codigolojaalternateSearchString = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja", codigolojaalternateSearchString);
            #endregion desfazer
            #endregion populaobjetos

            #region trataParametrosOrdenacao
            ViewBag.CurrentSort = sortOrder;
            ViewBag.AtributoSortParam = String.IsNullOrEmpty(sortOrder) ? "ATRIBUTO_desc" : "";
            ViewBag.DescCategoriaSortParam = sortOrder == "DESC_CATEGORIA" ? "DESC_CATEGORIA_desc" : "DESC_CATEGORIA";
            //ViewBag.NomeLojaSortParam = sortOrder == "NomeLoja" ? "NomeLoja_desc" : "NomeLoja";
            ViewBag.PercentualSortParam = sortOrder == "PERCENTUAL" ? "PERCENTUAL_desc" : "PERCENTUAL";
            ViewBag.DtIniSortParam = sortOrder == "DT_INI" ? "DT_INI_desc" : "DT_INI";
            ViewBag.DtFimSortParam = sortOrder == "DT_FIM" ? "DT_FIM_desc" : "DT_FIM";
            ViewBag.StatusSortParam = sortOrder == "STATUS" ? "STATUS_desc" : "STATUS";
            #endregion trataParametrosOrdenacao

            #region trataParametrosBusca

            var predicate = PredicateBuilder.True<CategoriaPercentual>();
            //atributoSearchString = "";

            if (idCategoriaSearchString.HasValue)
            {
                int idCategoriaFilter = idCategoriaSearchString.GetValueOrDefault();
                predicate = predicate.And(i => i.ID_CATEGORIA.Equals(idCategoriaFilter));
                ViewBag.idCategoriaFilter = idCategoriaFilter;
            }

            if (!String.IsNullOrEmpty(atributoSearchString))
            {
                predicate = predicate.And(i => i.ATRIBUTO.Contains(atributoSearchString));
                ViewBag.atributoFilter = atributoSearchString;
            }
            
            #region desfazer
            //if (codigolojaalternateSearchString.HasValue)
            //{
            //    int codigolojaalternateFilter = codigolojaalternateSearchString.GetValueOrDefault()
            //    predicate = predicate.And(i => i.CODIGOLOJAALTERNATE.Equals(codigolojaalternateFilter));
            //    ViewBag.codigolojaalternateFilter = codigolojaalternateFilter;
            //}
            #endregion desfazer

            if (percentualSearchString.HasValue)
            {
                decimal percentualFilter = percentualSearchString.GetValueOrDefault();
                predicate = predicate.And(i => i.PERCENTUAL.Equals(percentualFilter));
                ViewBag.percentualFilter = percentualFilter;
            }

            if (!String.IsNullOrEmpty(dtiniSearchString))
            {
                DateTime dtiniFilter = Convert.ToDateTime(dtiniSearchString);
                predicate = predicate.And(i => i.DT_INI.Equals(dtiniFilter));
                ViewBag.dtiniFilter = dtiniFilter;
            }

            if (!String.IsNullOrEmpty(dtfimSearchString))
            {
                DateTime dtfimFilter = Convert.ToDateTime(dtfimSearchString);
                predicate = predicate.And(i => i.DT_FIM.Equals(dtfimFilter));
                ViewBag.dtfimFilter = dtfimFilter;
            }

            if (!String.IsNullOrEmpty(statusSearchString))
            {
                predicate = predicate.And(i => i.STATUS.Equals(statusSearchString));
                ViewBag.statusFilter = statusSearchString;
            }

            #endregion trataParametrosBusca

            IEnumerable<CategoriaPercentual> categoriapercentuals = new List<CategoriaPercentual>();

            //categoriapercentuals = _categoriapercentualAppService.All();
            categoriapercentuals = _categoriapercentualAppService.Find(predicate);

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
            _categoriaAppService.Dispose();
            _lojaAppService.Dispose();

            base.Dispose(disposing);
        }

    }
}