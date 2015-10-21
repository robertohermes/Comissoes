using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;

namespace Dufry.Comissoes.Controllers
{
    public class AeroportoController : Controller
    {
        private readonly IAeroportoAppService _aeroportoAppService;

        public AeroportoController(IAeroportoAppService aeroportoAppService)
        {
            _aeroportoAppService = aeroportoAppService;
        }
    }
}