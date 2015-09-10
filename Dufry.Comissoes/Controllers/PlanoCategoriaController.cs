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
    public class PlanoCategoriaController : Controller
    {
        private readonly IControleAcessoAppService _controleacessoAppService;
        private readonly IPlanoCategoriaAppService _planocategoriaAppService;
        private readonly IPlanoAppService _planoAppService;
        private readonly ICategoriaAppService _categoriaAppService;


        public PlanoCategoriaController(IControleAcessoAppService controleacessoAppService, IPlanoCategoriaAppService planocategoriaAppService, IPlanoAppService planoAppService, ICategoriaAppService categoriaAppService)
        {
            _controleacessoAppService = controleacessoAppService;
            _planocategoriaAppService = planocategoriaAppService;
            _planoAppService = planoAppService;
            _categoriaAppService = categoriaAppService;
        }

        // GET: /PlanoCategoria/PlanoCategoriaCreate
        public ActionResult PlanoCategoriaCreate()
        {
            List<PlanoCategoria> planoCategoriasList = new List<PlanoCategoria>();

            #region populaobjetos
            var planos = _planoAppService.Find(t => t.STATUS == "A");
            var planocategorias = _planocategoriaAppService.All();
            var planosdisponiveis = from p in planos 
                                    where !
                                    (from pc in planocategorias
                                     select pc.ID_PLANO).Contains(p.ID_PLANO) 
                                    select p;
            IEnumerable<SelectListItem> planosSelectListItem = new SelectList(planosdisponiveis, "ID_PLANO", "DESC_PLANO");
            ViewBag.ID_PLANO = new SelectList(planosdisponiveis, "ID_PLANO", "DESC_PLANO");

            List<Categoria> categoriasDisponiveisList = _categoriaAppService.Find(t => t.STATUS == "A").ToList();
            #endregion populaobjetos

            PlanoCategoriaViewModel categoriaPercentualVM = new PlanoCategoriaViewModel(planoCategoriasList, planosSelectListItem, categoriasDisponiveisList);

            return View(categoriaPercentualVM);
        }

        // POST: /PlanoCategoria/PlanoCategoriaCreate
        [HttpPost, ActionName("PlanoCategoriaCreate")]
        //[ValidateAntiForgeryToken]
        public ActionResult PlanoCategoriaCreateConfirmed(List<PlanoCategoria> planoCategoriaOrdenado)
        {
            try
            {
                List<PlanoCategoria> planoCategoriaList = new List<PlanoCategoria>();

                foreach (PlanoCategoria planoCategoria in planoCategoriaOrdenado)
                {
                    planoCategoriaList.Add(ObtemPlanoCategoriaForm(planoCategoria, true));
                }

                if (ModelState.IsValid)
                {
                    _planocategoriaAppService.CreateBatch(planoCategoriaList);

                    return RedirectToAction("PlanoCategoriaIndex");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Erro ao salvar. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
            }

            return View(planoCategoriaOrdenado);
        }

        // GET: /PlanoCategoria/PlanoCategoriaEdit/5
        public ActionResult PlanoCategoriaEdit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }
            var planocategorias = _planocategoriaAppService.Find(t => t.ID_PLANO == id);
            if (planocategorias == null)
            {
                //return HttpNotFound();
                throw new Exception();
            }

            #region populaobjetos
            var plano = _planoAppService.Get(id ?? default(int));

            var categorias = _categoriaAppService.Find(t => t.STATUS == "A").ToList();

            var categoriasDisponiveis = from c in categorias
                                            where !
                                              (from pc in planocategorias
                                               select pc.ID_CATEGORIA).Contains(c.ID_CATEGORIA)
                                            select c;

            var categoriasSelecionadas = from c in categorias
                                             where 
                                               (from pc in planocategorias
                                                select pc.ID_CATEGORIA).Contains(c.ID_CATEGORIA)
                                                         select c;

            

            #endregion populaobjetos

            PlanoCategoriaViewModel planoCategoriaVM = new PlanoCategoriaViewModel(planocategorias.ToList(), categoriasDisponiveis.ToList(), categoriasSelecionadas.ToList());

            return View(planoCategoriaVM);

        }

        // POST: /PlanoCategoria/PlanoCategoriaEdit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("PlanoCategoriaEdit")]
        //[ValidateAntiForgeryToken]
        public ActionResult PlanoCategoriaEditConfirmed(int ? idPlano, List<PlanoCategoria> planoCategoriaOrdenado)
        {

            if (idPlano == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }

            List<PlanoCategoria> planoCategoriaList = new List<PlanoCategoria>();

            foreach (PlanoCategoria planoCategoria in planoCategoriaOrdenado)
            {
                planoCategoriaList.Add(ObtemPlanoCategoriaForm(planoCategoria, true));
            }

            List<PlanoCategoria> planocategoriasToDelete = _planocategoriaAppService.Find(t => t.ID_PLANO == idPlano).ToList();

            if (ModelState.IsValid)
            {
                try
                {
                    _planocategoriaAppService.UpdateBatch(planoCategoriaList, planocategoriasToDelete);

                    return RedirectToAction("CategoriaPercentualIndex");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Erro na alteração. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
                }
            }

            return View(planoCategoriaOrdenado);
        }

        protected override void Dispose(bool disposing)
        {
            _controleacessoAppService.Dispose();
            _planocategoriaAppService.Dispose();
            _planoAppService.Dispose();
            _categoriaAppService.Dispose();

            base.Dispose(disposing);
        }

        private PlanoCategoria ObtemPlanoCategoriaForm(PlanoCategoria pc, bool insert = false)
        {

            pc.LAST_MODIFY_DATE = DateTime.Now;
            pc.LAST_MODIFY_USERNAME = _controleacessoAppService.ObtainCurrentLoginFromAd();

            if (insert)
            {
                pc.CREATED_DATETIME = pc.LAST_MODIFY_DATE;
                pc.CREATED_USERNAME = pc.LAST_MODIFY_USERNAME;
            }

            return pc;
        }

    }
}