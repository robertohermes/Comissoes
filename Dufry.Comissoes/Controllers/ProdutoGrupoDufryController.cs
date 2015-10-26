using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;

namespace Dufry.Comissoes.Controllers
{
    public class ProdutoGrupoDufryController : Controller
    {
        private readonly IProdutoGrupoDufryAppService _produtoGrupoDufryAppService;

        public ProdutoGrupoDufryController(IProdutoGrupoDufryAppService produtoGrupoDufryAppService)
        {
            _produtoGrupoDufryAppService = produtoGrupoDufryAppService;
        }
    }
}