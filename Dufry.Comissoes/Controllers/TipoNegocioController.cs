using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;

namespace Dufry.Comissoes.Controllers
{
    public class TipoNegocioController : Controller
    {
        private readonly ITipoNegocioAppService _tiponegocioAppService;

        public TipoNegocioController(ITipoNegocioAppService TipoNegocioAppService)
        {
            _tiponegocioAppService = TipoNegocioAppService;
        }
    }
}