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
    public class DolarMedioController : Controller
    {

        private readonly IControleAcessoAppService _controleacessoAppService;
        private readonly IDolarMedioAppService _dolarmedioAppService;
        private readonly IPlanoAppService _planoAppService;

        public DolarMedioController(IDolarMedioAppService dolarmedioAppService, IControleAcessoAppService controleacessoAppService, IPlanoAppService planoAppService)
        {
            _dolarmedioAppService = dolarmedioAppService;
            _controleacessoAppService = controleacessoAppService;
            _planoAppService = planoAppService;
        }

        // GET: /DolarMedio/DolarMedioCreate
        public ActionResult DolarMedioCreate()
        {
            DolarMedio dolarmedio = new DolarMedio();

            #region populaobjetos
            var planos = _planoAppService.Find(t => t.STATUS == "A"); ;
            IEnumerable<SelectListItem> planosSelectListItem = new SelectList(planos, "ID_PLANO", "DESC_PLANO");
            ViewBag.CODIGOLOJAALTERNATE = new SelectList(planos, "ID_PLANO", "DESC_PLANO");
            #endregion populaobjetos

            DolarMedioViewModel dolarmedioVM = new DolarMedioViewModel(dolarmedio, planosSelectListItem);

            return View(dolarmedioVM);
        }

        // POST: /DolarMedio/DolarMedioCreate
        [HttpPost, ActionName("DolarMedioCreate")]
        //[ValidateAntiForgeryToken]
        public ActionResult DolarMedioCreateConfirmed(DolarMedio dolarmedio)
        {
            try
            {
                dolarmedio = ObtemDolarMedioForm(dolarmedio, true);

                if (ModelState.IsValid)
                {
                    DolarMedio dolarmedioExiste = new DolarMedio();
                    dolarmedioExiste = null;

                    dolarmedioExiste = DolarMedioVigente(dolarmedio);

                    if (dolarmedioExiste == null)
                    {
                        _dolarmedioAppService.Create(dolarmedio);
                    }
                    else
                    {
                        throw new InvalidOperationException("Já existe um perído vigente e ativo que coincide com a tentativa de inclusão / alteração");
                    }


                    return RedirectToAction("DolarMedioIndex");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Erro ao salvar. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
            }

            return View(dolarmedio);
        }

        // GET: /DolarMedio/DolarMedioEdit/5
        public ActionResult DolarMedioEdit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }
            var dolarmedio = _dolarmedioAppService.Get(id ?? default(int));
            if (dolarmedio == null)
            {
                //return HttpNotFound();
                throw new Exception();
            }

            #region populaobjetos
            var planos = _planoAppService.All();
            IEnumerable<SelectListItem> planosSelectListItem = new SelectList(planos, "ID_PLANO", "DESC_PLANO");
            ViewBag.ID_PLANO = new SelectList(planos, "ID_PLANO", "DESC_PLANO", dolarmedio.ID_PLANO);
            #endregion populaobjetos

            DolarMedioViewModel dolarmedioVM = new DolarMedioViewModel(dolarmedio, planosSelectListItem);

            return View(dolarmedioVM);

        }

        // POST: /DolarMedio/DolarMedioEdit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("DolarMedioEdit")]
        //[ValidateAntiForgeryToken]
        public ActionResult DolarMedioEditConfirmed(int? id)
        {

            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }

            var dolarmedioToUpdate = _dolarmedioAppService.Get(id ?? default(int));

            dolarmedioToUpdate = ObtemDolarMedioForm(dolarmedioToUpdate);

            if (ModelState.IsValid)
            {
                try
                {
                    DolarMedio dolarmedioExiste = new DolarMedio();
                    dolarmedioExiste = null;

                    dolarmedioExiste = DolarMedioVigente(dolarmedioToUpdate);

                    if (dolarmedioExiste == null)
                    {
                        _dolarmedioAppService.Update(dolarmedioToUpdate);
                    }
                    else
                    {
                        throw new InvalidOperationException("Já existe um perído vigente que coincide com a tentativa de inclusão / alteração");
                    }

                    return RedirectToAction("DolarMedioIndex");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Erro na alteração. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
                }
            }

            return View(dolarmedioToUpdate);
        }

        // GET: /DolarMedio/DolarMedioIndex
        //[ControleAcessoAdminFilter]
        public ViewResult DolarMedioIndex(int? page
            , string sortOrder
            , int? idPlanoSearchString
            , string tipoTaxaSearchString
            , decimal? valorDolarMedioSearchString
            , string dtiniSearchString
            , string dtfimSearchString)
        {

            #region populaobjetos
            var planos = _planoAppService.All();
            ViewBag.idPlanoSearchString = new SelectList(planos, "ID_PLANO", "DESC_PLANO", idPlanoSearchString);
            #endregion populaobjetos


            #region trataParametrosOrdenacao
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DescPlanoSortParam = sortOrder == "DESC_PLANO" ? "DESC_PLANO_desc" : "DESC_PLANO";
            ViewBag.TipoTaxaSortParam = sortOrder == "TIPO_TAXA" ? "TIPO_TAXA_desc" : "TIPO_TAXA";
            ViewBag.ValorSortParam = sortOrder == "VALOR_DOLAR_MEDIO" ? "VALOR_DOLAR_MEDIO_desc" : "VALOR_DOLAR_MEDIO";
            ViewBag.DtIniSortParam = sortOrder == "DT_INI" ? "DT_INI_desc" : "DT_INI";
            ViewBag.DtFimSortParam = sortOrder == "DT_FIM" ? "DT_FIM_desc" : "DT_FIM";
            
            #endregion trataParametrosOrdenacao

            #region trataParametrosBusca

            var predicate = PredicateBuilder.True<DolarMedio>();

            if (idPlanoSearchString.HasValue)
            {
                int idPlanoFilter = idPlanoSearchString.GetValueOrDefault();
                predicate = predicate.And(i => i.ID_PLANO.Equals(idPlanoFilter));
                ViewBag.idPlanoFilter = idPlanoFilter;
            }

            if (!String.IsNullOrEmpty(tipoTaxaSearchString))
            {
                predicate = predicate.And(i => i.TIPO_TAXA.Equals(tipoTaxaSearchString));
                ViewBag.tipoTaxaFilter = tipoTaxaSearchString;
            }

            if (valorDolarMedioSearchString.HasValue)
            {
                decimal valorDolarMedioFilter = valorDolarMedioSearchString.GetValueOrDefault();
                predicate = predicate.And(i => i.VALOR_DOLAR_MEDIO.Equals(valorDolarMedioFilter));
                ViewBag.valorDolarMedioFilter = valorDolarMedioFilter;
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

            #endregion trataParametrosBusca

            IEnumerable<DolarMedio> dolarmedios = new List<DolarMedio>();

            dolarmedios = _dolarmedioAppService.Find(predicate);

            #region ordenacao
            switch (sortOrder)
            {
                case "TIPO_TAXA":
                    dolarmedios = dolarmedios.OrderBy(s => s.TIPO_TAXA);
                    break;
                case "VALOR_DOLAR_MEDIO":
                    dolarmedios = dolarmedios.OrderBy(s => s.VALOR_DOLAR_MEDIO);
                    break;
                case "DT_INI":
                    dolarmedios = dolarmedios.OrderBy(s => s.DT_INI); //mudar de chave para campo
                    break;
                case "DT_FIM":
                    dolarmedios = dolarmedios.OrderBy(s => s.DT_FIM); //mudar de chave para campo
                    break;
                case "DESC_PLANO_desc":
                    dolarmedios = dolarmedios.OrderByDescending(s => s.Plano.DESC_PLANO); //mudar de chave para campo
                    break;
                case "TIPO_TAXA_desc":
                    dolarmedios = dolarmedios.OrderByDescending(s => s.TIPO_TAXA);
                    break;
                case "VALOR_DOLAR_MEDIO_desc":
                    dolarmedios = dolarmedios.OrderByDescending(s => s.VALOR_DOLAR_MEDIO);
                    break;
                case "DT_INI_desc":
                    dolarmedios = dolarmedios.OrderByDescending(s => s.DT_INI); //mudar de chave para campo
                    break;
                case "DT_FIM_desc":
                    dolarmedios = dolarmedios.OrderByDescending(s => s.DT_FIM); //mudar de chave para campo
                    break;
                default:  // DESC_PLANO ascending 
                    dolarmedios = dolarmedios.OrderBy(s => s.Plano.DESC_PLANO);
                    break;
            }
            #endregion ordenacao

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(dolarmedios.ToPagedList(pageNumber, pageSize));
        }

        // GET: /DolarMedio/DolarMedioDelete/5
        public ActionResult DolarMedioDelete(int? id, bool? saveChangesError = false)
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

            var dolarmedio = _dolarmedioAppService.Get(id ?? default(int));

            if (dolarmedio == null)
            {
                //return HttpNotFound();
                throw new Exception();
            }

            //return View(categoriapercentual);

            DolarMedioViewModel dolarmedioVM = new DolarMedioViewModel(dolarmedio);

            return View(dolarmedioVM);
        }

        //POST: /DolarMedio/DolarMedioDelete/5
        [HttpPost, ActionName("DolarMedioDelete")]
        public ActionResult DolarMedioDeleteConfirmed(int id)
        {
            try
            {
                var dolarmedio = _dolarmedioAppService.Get(id);

                _dolarmedioAppService.Remove(dolarmedio);
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("DolarMedioDelete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("DolarMedioIndex");

        }

        protected override void Dispose(bool disposing)
        {
            _dolarmedioAppService.Dispose();
            _controleacessoAppService.Dispose();
            _planoAppService.Dispose();

            base.Dispose(disposing);
        }

        private DolarMedio DolarMedioVigente(DolarMedio dm)
        {

            return _dolarmedioAppService.Find(t => t.ID_PLANO == dm.ID_PLANO
                                                && (
                                                    (t.DT_INI <= dm.DT_INI && t.DT_FIM >= dm.DT_INI)
                                                    || (t.DT_FIM <= dm.DT_INI && t.DT_FIM >= dm.DT_FIM)
                                                    || (dm.DT_INI <= t.DT_INI && dm.DT_FIM >= t.DT_FIM)
                                                )
                                            ).FirstOrDefault();
        }

        private DolarMedio ObtemDolarMedioForm(DolarMedio dm, bool insert = false)
        {
            dm.ID_PLANO = Convert.ToInt32(Request["DolarMedio.ID_PLANO"]);
            dm.TIPO_TAXA = Request["DolarMedio.TIPO_TAXA"];
            dm.VALOR_DOLAR_MEDIO = Convert.ToDecimal(Request["DolarMedio.VALOR_DOLAR_MEDIO"]);
            dm.DT_INI = Convert.ToDateTime(Request["DolarMedio.DT_INI"]);
            dm.DT_FIM = Convert.ToDateTime(Request["DolarMedio.DT_FIM"]);

            dm.LAST_MODIFY_DATE = DateTime.Now;
            dm.LAST_MODIFY_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();

            if (insert)
            {
                dm.CREATED_DATETIME = dm.LAST_MODIFY_DATE;
                dm.CREATED_USERNAME = dm.LAST_MODIFY_USERNAME;
            }

            return dm;
        }
    }
}