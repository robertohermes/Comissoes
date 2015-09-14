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

            var categorias = _categoriaAppService.Find(t => t.STATUS == "A");

            List<Categoria> categoriasDisponiveisList = ListaCategoriasDisponiveis(planocategorias, categorias);

            List<Categoria> categoriasSelecionadasList = ListaCategoriasSelecionadas(planocategorias, categorias);

            #endregion populaobjetos

            PlanoCategoriaViewModel planoCategoriaVM = new PlanoCategoriaViewModel(planocategorias.ToList(), categoriasDisponiveisList, categoriasSelecionadasList, plano);

            return View(planoCategoriaVM);

        }

        // POST: /PlanoCategoria/PlanoCategoriaEdit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("PlanoCategoriaEdit")]
        //[ValidateAntiForgeryToken]
        public ActionResult PlanoCategoriaEditConfirmed(int idPlano, List<PlanoCategoria> planoCategoriaOrdenado)
        {

            if (planoCategoriaOrdenado == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                throw new Exception();
            }

            List<PlanoCategoria> planoCategoriaListToInsert = ListaPlanoCategoriaToInsert(planoCategoriaOrdenado);

            List<PlanoCategoria> planoCategoriaListToDelete = _planocategoriaAppService.Find(t => t.ID_PLANO == idPlano).ToList();

            if (ModelState.IsValid)
            {
                try
                {
                    _planocategoriaAppService.UpdateBatch(planoCategoriaListToInsert, planoCategoriaListToDelete);

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

        private PlanoCategoria SetPlanoCategoriaUserData(PlanoCategoria pc, bool insert = false)
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

        private static IEnumerable<Plano> ObtemPlanosDisponiveis(IEnumerable<Plano> planos, IEnumerable<PlanoCategoria> planocategorias)
        {
            var planosdisponiveis = from p in planos
                                    where !
                                    (from pc in planocategorias
                                     select pc.ID_PLANO).Contains(p.ID_PLANO)
                                    select p;
            return planosdisponiveis;
        }

        private static List<Categoria> ListaCategoriasDisponiveis(IEnumerable<PlanoCategoria> planocategorias, IEnumerable<Categoria> categorias)
        {
            List<Categoria> categoriasDisponiveisList = (from c in categorias.ToList()
                                                         where !
                                                           (from pc in planocategorias
                                                            select pc.ID_CATEGORIA).Contains(c.ID_CATEGORIA)
                                                         select c).ToList();
            return categoriasDisponiveisList;
        }

        private static List<Categoria> ListaCategoriasSelecionadas(IEnumerable<PlanoCategoria> planocategorias, IEnumerable<Categoria> categorias)
        {
            var Hierarquia = (from ca in categorias
                              join pc in planocategorias on ca.ID_CATEGORIA equals pc.ID_CATEGORIA
                              select new { ca.ID_CATEGORIA, ca.DESC_CATEGORIA, pc.ORDEM_HIERARQUIA }).OrderBy(pc => pc.ORDEM_HIERARQUIA);

            List<Categoria> categoriasSelecionadasList = new List<Categoria>();

            foreach (var hierarquia in Hierarquia)
            {
                Categoria catAux = new Categoria();
                catAux.ID_CATEGORIA = hierarquia.ID_CATEGORIA;
                catAux.DESC_CATEGORIA = hierarquia.DESC_CATEGORIA;

                categoriasSelecionadasList.Add(catAux);
            }
            return categoriasSelecionadasList;
        }

        private List<PlanoCategoria> ListaPlanoCategoriaToInsert(List<PlanoCategoria> planoCategoriaOrdenado)
        {
            List<PlanoCategoria> planoCategoriaListToInsert = new List<PlanoCategoria>();

            foreach (PlanoCategoria planoCategoria in planoCategoriaOrdenado)
            {
                planoCategoriaListToInsert.Add(SetPlanoCategoriaUserData(planoCategoria, true));
            }
            return planoCategoriaListToInsert;
        }

    }
}