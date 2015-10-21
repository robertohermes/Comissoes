using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;

namespace Dufry.Comissoes.Controllers
{
    public class TipoBusinessController : Controller
    {
        private readonly ITipoBusinessAppService _tipoBusinessAppService;

        public TipoBusinessController(ITipoBusinessAppService tipoBusinessAppService)
        {
            _tipoBusinessAppService = tipoBusinessAppService;
        }
    }
}