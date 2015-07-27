using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;

namespace Dufry.Comissoes.Controllers
{
    public class PlanoController : Controller
    {
        private readonly IPlanoAppService _planoAppService;

        public PlanoController(IPlanoAppService planoAppService)
        {
            _planoAppService = planoAppService;
        }

    }
}