using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;

namespace Dufry.Comissoes.Controllers
{
    public class SelfServiceController : Controller
    {
        private readonly ISelfServiceAppService _selfserviceAppService;

        public SelfServiceController(ISelfServiceAppService selfserviceAppService)
        {
            _selfserviceAppService = selfserviceAppService;
        }

    }
}