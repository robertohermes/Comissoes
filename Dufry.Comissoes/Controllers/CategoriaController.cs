using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;

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

    }
}