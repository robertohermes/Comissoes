using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;

namespace Dufry.Comissoes.Controllers
{
    public class DSRController : Controller
    {
        private readonly IDSRAppService _dsrAppService;

        public DSRController(IDSRAppService dsrAppService)
        {
            _dsrAppService = dsrAppService;
        }

    }
}