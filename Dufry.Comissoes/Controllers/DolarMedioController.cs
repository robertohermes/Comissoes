using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;

namespace Dufry.Comissoes.Controllers
{
    public class DolarMedioController : Controller
    {
        private readonly IDolarMedioAppService _dolarmedioAppService;

        public DolarMedioController(IDolarMedioAppService dolarmedioAppService)
        {
            _dolarmedioAppService = dolarmedioAppService;
        }

    }
}