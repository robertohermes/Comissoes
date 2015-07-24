using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;

namespace Dufry.Comissoes.Controllers
{
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorAppService _colaboradorAppService;

        public ColaboradorController(IColaboradorAppService ColaboradorAppService)
        {
            _colaboradorAppService = ColaboradorAppService;
        }
    }
}