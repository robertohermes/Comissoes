using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;

namespace Dufry.Comissoes.Controllers
{
    public class AusenciaRemuneradaController : Controller
    {
        private readonly IAusenciaRemuneradaAppService _ausenciaremuneradaAppService;

        public AusenciaRemuneradaController(IAusenciaRemuneradaAppService ausenciaremuneradaAppService)
        {
            _ausenciaremuneradaAppService = ausenciaremuneradaAppService;
        }

    }
}