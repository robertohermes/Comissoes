using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;

namespace Dufry.Comissoes.Controllers
{
    public class PlanoCategoriaController : Controller
    {
        private readonly IPlanoCategoriaAppService _planocategoriaAppService;

        public PlanoCategoriaController(IPlanoCategoriaAppService planocategoriaAppService)
        {
            _planocategoriaAppService = planocategoriaAppService;
        }

    }
}