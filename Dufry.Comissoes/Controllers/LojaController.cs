using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;

namespace Dufry.Comissoes.Controllers
{
    public class LojaController : Controller
    {
        private readonly ILojaAppService _lojaAppService;

        public LojaController(ILojaAppService LojaAppService)
        {
            _lojaAppService = LojaAppService;
        }
    }
}