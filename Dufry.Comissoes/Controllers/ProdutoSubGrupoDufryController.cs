using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dufry.Comissoes.Application.Interfaces;

namespace Dufry.Comissoes.Controllers
{
    public class ProdutoSubGrupoDufryController : Controller
    {
        private readonly IProdutoSubGrupoDufryAppService _produtoSubGrupoDufryAppService;

        public ProdutoSubGrupoDufryController(IProdutoSubGrupoDufryAppService produtoSubGrupoDufryAppService)
        {
            _produtoSubGrupoDufryAppService = produtoSubGrupoDufryAppService;
        }
    }
}