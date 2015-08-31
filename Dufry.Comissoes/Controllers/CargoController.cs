using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;

namespace Dufry.Comissoes.Controllers
{
    public class CargoController : Controller
    {
        private readonly ICargoAppService _cargoAppService;

        public CargoController(ICargoAppService CargoAppService)
        {
            _cargoAppService = CargoAppService;
        }
    }
}