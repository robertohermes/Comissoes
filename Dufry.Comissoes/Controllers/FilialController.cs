using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;

namespace Dufry.Comissoes.Controllers
{
    public class FilialController : Controller
    {
        private readonly IFilialAppService _filialAppService;

        public FilialController(IFilialAppService filialAppService)
        {
            _filialAppService = filialAppService;
        }
    }
}