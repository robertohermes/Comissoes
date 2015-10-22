using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;

namespace Dufry.Comissoes.Controllers
{
    public class ProdutoCategoriaController : Controller
    {
        private readonly IProdutoCategoriaAppService _produtoCategoriaAppService;

        public ProdutoCategoriaController(IProdutoCategoriaAppService produtoCategoriaAppService)
        {
            _produtoCategoriaAppService = produtoCategoriaAppService;
        }
    }
}