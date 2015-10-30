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
    public class CategoriaPercentualController : Controller
    {
        private readonly ICategoriaPercentualAppService _categoriapercentualAppService;
        //private readonly ICategoriaAppService _categoriaAppService;
        private readonly IPlanoAppService _planoAppService;
        private readonly IControleAcessoAppService _controleacessoAppService;

        //public CategoriaPercentualController(ICategoriaPercentualAppService categoriapercentualAppService, ICategoriaAppService categoriaAppService, IControleAcessoAppService controleacessoAppService, ILojaAppService lojaAppService)
        //{
        //    _categoriapercentualAppService = categoriapercentualAppService;
        //    _categoriaAppService = categoriaAppService;
        //    _lojaAppService = lojaAppService;
        //    _controleacessoAppService = controleacessoAppService;
        //}

        public CategoriaPercentualController(ICategoriaPercentualAppService categoriapercentualAppService, IControleAcessoAppService controleacessoAppService, IPlanoAppService planoAppService)
        {
            _categoriapercentualAppService = categoriapercentualAppService;
            _controleacessoAppService = controleacessoAppService;
            _planoAppService = planoAppService;
        }

        // GET: /CategoriaPercentual/CategoriaPercentualCreate
        public ActionResult CategoriaPercentualCreate()
        {
            CategoriaPercentual categoriapercentual = new CategoriaPercentual();

            //#region populaobjetos
            //var categorias = _categoriaAppService.Find(t => t.STATUS == "A");
            //IEnumerable<SelectListItem> categoriaSelectListItem = new SelectList(categorias, "ID_CATEGORIA", "DESC_CATEGORIA");
            //ViewBag.ID_CATEGORIA = new SelectList(categorias, "ID_CATEGORIA", "DESC_CATEGORIA");

            //var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1"); ;
            //IEnumerable<SelectListItem> lojaSelectListItem = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            //ViewBag.ID_PLANO = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            //#endregion populaobjetos

            //CategoriaPercentualViewModel categoriaPercentualVM = new CategoriaPercentualViewModel(categoriapercentual, categoriaSelectListItem, lojaSelectListItem);
            CategoriaPercentualViewModel categoriaPercentualVM = new CategoriaPercentualViewModel(categoriapercentual);

            return View(categoriaPercentualVM);
        }

        // POST: /CategoriaPercentual/CategoriaPercentualCreate
        [HttpPost, ActionName("CategoriaPercentualCreate")]
        //[ValidateAntiForgeryToken]
        public ActionResult CategoriaPercentualCreateConfirmed(CategoriaPercentual categoriapercentual)
        {
            try
            {
                categoriapercentual = ObtemCategoriaPercentualForm(categoriapercentual, true);

                if (ModelState.IsValid)
                {
                    CategoriaPercentual categoriapercentualExiste = new CategoriaPercentual();
                    categoriapercentualExiste = null;

                    if (categoriapercentual.STATUS == "A")
                    {
                        categoriapercentualExiste = CategoriaPercentualAtivaVigente(categoriapercentual);
                    }

                    if (categoriapercentualExiste == null || categoriapercentual.STATUS == "I")
                    {
                        _categoriapercentualAppService.Create(categoriapercentual);
                    }
                    else
                    {
                        throw new InvalidOperationException("Já existe um perído vigente e ativo que coincide com a tentativa de inclusão / alteração");
                    }
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

            //#region populaobjetos
            //var categorias = _categoriaAppService.All();
            //IEnumerable<SelectListItem> categoriaSelectListItem = new SelectList(categorias, "ID_CATEGORIA", "DESC_CATEGORIA");
            //ViewBag.ID_CATEGORIA = new SelectList(categorias, "ID_CATEGORIA", "DESC_CATEGORIA", categoriapercentual.ID_CATEGORIA);

            //var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1");
            //IEnumerable<SelectListItem> lojaSelectListItem = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            //ViewBag.ID_PLANO = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja", categoriapercentual.ID_PLANO);
            //#endregion populaobjetos

            //CategoriaPercentualViewModel categoriaPercentualVM = new CategoriaPercentualViewModel(categoriapercentual, categoriaSelectListItem, lojaSelectListItem);

            CategoriaPercentualViewModel categoriaPercentualVM = new CategoriaPercentualViewModel(categoriapercentual);

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

            categoriapercentualToUpdate = ObtemCategoriaPercentualForm(categoriapercentualToUpdate);

            if (ModelState.IsValid)
            {
                try
                {
                    CategoriaPercentual categoriapercentualExiste = new CategoriaPercentual();
                    categoriapercentualExiste = null;

                    if (categoriapercentualToUpdate.STATUS == "A")
                    {
                        categoriapercentualExiste = CategoriaPercentualAtivaVigente(categoriapercentualToUpdate);
                    }

                    if (categoriapercentualExiste == null || categoriapercentualToUpdate.STATUS == "I")
                    {
                        _categoriapercentualAppService.Update(categoriapercentualToUpdate);
                    }
                    else
                    {
                        throw new InvalidOperationException("Já existe um perído vigente e ativo que coincide com a tentativa de inclusão / alteração");
                    }

                    //<REVER>
                    //return RedirectToAction("CategoriaPercentualIndex");
                    return RedirectToAction("Index", "Home");
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
            , string idPlanoSearchString
            , string atributoSearchString
            , string dtiniSearchString
            , string dtfimSearchString
            , string statusSearchString)
        {

            //#region populaobjetos
            //var categorias = _categoriaAppService.All();
            //ViewBag.idCategoriaSearchString = new SelectList(categorias, "ID_CATEGORIA", "DESC_CATEGORIA", idCategoriaSearchString);

            //var planos = _planoAppService.All();
            //ViewBag.idPlanoSearchString = new SelectList(planos, "ID_PLANO", "DESC_PLANO", idPlanoSearchString);
            //#endregion populaobjetos

            #region trataParametrosOrdenacao
            ViewBag.CurrentSort = sortOrder;
            ViewBag.AtributoSortParam = String.IsNullOrEmpty(sortOrder) ? "ATRIBUTO_desc" : "";
            ViewBag.DescCategoriaSortParam = sortOrder == "DESC_CATEGORIA" ? "DESC_CATEGORIA_desc" : "DESC_CATEGORIA";
            ViewBag.CodigoLojaAlternateSortParam = sortOrder == "NomeLoja" ? "NomeLoja_desc" : "NomeLoja";
            ViewBag.PercentualSortParam = sortOrder == "PERCENTUAL" ? "PERCENTUAL_desc" : "PERCENTUAL";
            ViewBag.DtIniSortParam = sortOrder == "DT_INI" ? "DT_INI_desc" : "DT_INI";
            ViewBag.DtFimSortParam = sortOrder == "DT_FIM" ? "DT_FIM_desc" : "DT_FIM";
            ViewBag.StatusSortParam = sortOrder == "STATUS" ? "STATUS_desc" : "STATUS";
            #endregion trataParametrosOrdenacao

            #region trataParametrosBusca

            var predicate = PredicateBuilder.True<CategoriaPercentual>();
            //atributoSearchString = "";

            //if (idCategoriaSearchString.HasValue)
            //{
            //    int idCategoriaFilter = idCategoriaSearchString.GetValueOrDefault();
            //    predicate = predicate.And(i => i.ID_CATEGORIA.Equals(idCategoriaFilter));
            //    ViewBag.idCategoriaFilter = idCategoriaFilter;
            //}

            if (!String.IsNullOrEmpty(atributoSearchString))
            {
                predicate = predicate.And(i => i.ATRIBUTO.Contains(atributoSearchString));
                ViewBag.atributoFilter = atributoSearchString;
            }

            //if (!String.IsNullOrEmpty(idPlanoSearchString))
            //{
            //    string idPlanoFilter = idPlanoSearchString;
            //    predicate = predicate.And(i => i.ID_PLANO.Equals(idPlanoFilter));
            //    ViewBag.idPlanoFilter = idPlanoFilter;
            //}

            if (percentualSearchString.HasValue)
            {
                decimal percentualFilter = percentualSearchString.GetValueOrDefault();
                predicate = predicate.And(i => i.PERCENTUAL.Equals(percentualFilter));
                ViewBag.percentualFilter = percentualFilter;
            }

            if (!String.IsNullOrEmpty(dtiniSearchString))
            {
                DateTime dtiniFilter = DateTime.ParseExact(dtiniSearchString, "dd/MM/yyyy", new CultureInfo("pt-BR"));
                predicate = predicate.And(i => i.DT_INI.Equals(dtiniFilter));
                ViewBag.dtiniFilter = dtiniFilter;
            }

            if (!String.IsNullOrEmpty(dtfimSearchString))
            {
                DateTime dtfimFilter = DateTime.ParseExact(dtfimSearchString, "dd/MM/yyyy", new CultureInfo("pt-BR"));
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

            categoriapercentuals = _categoriapercentualAppService.Find(predicate);

            #region ordenacao
            switch (sortOrder)
            {
                //case "DESC_CATEGORIA":
                //    categoriapercentuals = categoriapercentuals.OrderBy(s => s.ID_CATEGORIA); //mudar de chave para campo
                //    break;
                //case "NomeLoja":
                //    categoriapercentuals = categoriapercentuals.OrderBy(s => s.ID_PLANO); //mudar de chave para campo
                //    break;
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
                //case "DESC_CATEGORIA_desc":
                //    categoriapercentuals = categoriapercentuals.OrderByDescending(s => s.ID_CATEGORIA); //mudar de chave para campo
                //    break;
                //case "NomeLoja_desc":
                //    categoriapercentuals = categoriapercentuals.OrderByDescending(s => s.ID_PLANO); //mudar de chave para campo
                //    break;
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

        //
        // GET: /CategoriaPercentual/CategoriaPercentualDelete/5
        public ActionResult CategoriaPercentualDelete(int? id, bool? saveChangesError = false)
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

            var categoriapercentual = _categoriapercentualAppService.Get(id ?? default(int));

            if (categoriapercentual == null)
            {
                //return HttpNotFound();
                throw new Exception();
            }

            //return View(categoriapercentual);
            //Loja loja = _lojaAppService.Find(t => t.CodigoLojaAlternate == categoriapercentual.ID_PLANO).FirstOrDefault();

            //CategoriaPercentualViewModel categoriaPercentualVM = new CategoriaPercentualViewModel(categoriapercentual, loja);
            CategoriaPercentualViewModel categoriaPercentualVM = new CategoriaPercentualViewModel(categoriapercentual);
            
            return View(categoriaPercentualVM);
        }

        //POST: /CategoriaPercentual/CategoriaPercentualDelete/5
        [HttpPost, ActionName("CategoriaPercentualDelete")]
        public ActionResult CategoriaPercentualDeleteConfirmed(int id)
        {
            try
            {
                var categoriapercentual = _categoriapercentualAppService.Get(id);

                //if (categoriapercentual.PlanoCategorias.Count() == 0)
                //{
                //    _categoriapercentualAppService.Remove(categoriapercentual);
                //}
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("CategoriaPercentualDelete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("CategoriaPercentualIndex");

        }

        protected override void Dispose(bool disposing)
        {
            _categoriapercentualAppService.Dispose();
            _controleacessoAppService.Dispose();
            _planoAppService.Dispose();
            //_categoriaAppService.Dispose();

            base.Dispose(disposing);
        }

        private CategoriaPercentual CategoriaPercentualAtivaVigente (CategoriaPercentual cp)
        {

            return _categoriapercentualAppService.Find(t => t.ID_PLANO_CATEGORIA == cp.ID_PLANO_CATEGORIA
                                                        && t.ATRIBUTO == cp.ATRIBUTO
                                                        && t.STATUS == "A"
                                                        && (
                                                            (t.DT_INI <= cp.DT_INI && t.DT_FIM >= cp.DT_INI)
                                                            || (t.DT_FIM <= cp.DT_INI && t.DT_FIM >= cp.DT_FIM)
                                                            || (cp.DT_INI <= t.DT_INI && cp.DT_FIM >= t.DT_FIM)
                                                        )
                                                    ).FirstOrDefault();

        }

        private CategoriaPercentual ObtemCategoriaPercentualForm(CategoriaPercentual cp, bool insert = false)
        {
            //cp.ID_CATEGORIA = Convert.ToInt32(Request["CategoriaPercentual.ID_CATEGORIA"]);
            cp.ATRIBUTO = Request["CategoriaPercentual.ATRIBUTO"];
            //cp.CODIGOLOJAALTERNATE = Request["CategoriaPercentual.CODIGOLOJAALTERNATE"];
            cp.PERCENTUAL = Convert.ToDecimal(Request["CategoriaPercentual.PERCENTUAL"]);
            cp.DT_INI = Convert.ToDateTime(Request["CategoriaPercentual.DT_INI"]);
            cp.DT_FIM = Convert.ToDateTime(Request["CategoriaPercentual.DT_FIM"]);
            cp.STATUS = Request["CategoriaPercentual.STATUS"];

            cp.LAST_MODIFY_DATE = DateTime.Now;
            cp.LAST_MODIFY_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();

            if (insert)
            {
                cp.CREATED_DATETIME = cp.LAST_MODIFY_DATE;
                cp.CREATED_USERNAME = cp.LAST_MODIFY_USERNAME;
            }

            return cp;
        }



    }
}