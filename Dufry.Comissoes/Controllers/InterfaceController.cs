using Dufry.Comissoes.Application.Interfaces;
using Dufry.Comissoes.Controllers.Helpers;
using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.Filters;
using Dufry.Comissoes.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Dufry.Comissoes.Controllers
{
    [ControleAcessoAdminFilter]
    [HandleError(ExceptionType = typeof(InvalidOperationException),
            View = "InvalidOperation")]
    [HandleError(ExceptionType = typeof(HttpException),
                View = "HttpException")]
    public class InterfaceController : Controller
    {
        private readonly IControleAcessoAppService _controleacessoAppService;
        private readonly IEmpresaAppService _empresaAppService;
        private readonly ILojaAppService _lojaAppService;
        private readonly IConfiguracaoAppService _configuracaoAppService;
        private readonly IProdutoAppService _produtoAppService;

        public InterfaceController(IControleAcessoAppService controleacessoAppService, IEmpresaAppService empresaAppService, ILojaAppService lojaAppService, IConfiguracaoAppService configuracaoAppService, IProdutoAppService produtoAppService)
        {
            _controleacessoAppService = controleacessoAppService;
            _empresaAppService = empresaAppService;
            _lojaAppService = lojaAppService;
            _configuracaoAppService = configuracaoAppService;
            _produtoAppService = produtoAppService;
        }

        protected override void Dispose(bool disposing)
        {
            _controleacessoAppService.Dispose();
            _empresaAppService.Dispose();
            _lojaAppService.Dispose();
            _configuracaoAppService.Dispose();
            _produtoAppService.Dispose();

            base.Dispose(disposing);
        }


        // GET: /Interface/InterfaceFolhaPagamentoIndex
        public ActionResult InterfaceFolhaPagamentoIndex()
        {
            #region populaobjetos

            string codigoFolha = _configuracaoAppService.Find(t => t.DESC_CHAVE == "InterfaceFolhaPagamentoCodigoFolhaPagamento").FirstOrDefault().DESC_VALOR.Trim();

            string codigoClienteADP = _configuracaoAppService.Find(t => t.DESC_CHAVE == "InterfaceFolhaPagamentoCodigoClienteADP").FirstOrDefault().DESC_VALOR.Trim();

            var empresas = _empresaAppService.AllConcatCodigoEmpresaLegado();
            IEnumerable<SelectListItem> empresasSelectListItem = new SelectList(empresas, "CodigoEmpresaAlternate", "NomeEmpresa");
            ViewBag.CodigoEmpresaAlternate = new SelectList(empresas, "CodigoEmpresaAlternate", "NomeEmpresa");

            var lojas = _lojaAppService.Find(t => t.CodigoLojaAlternate.Trim() != "-2" && t.CodigoLojaAlternate.Trim() != "-1"); ;
            IEnumerable<SelectListItem> lojasSelectListItem = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");
            ViewBag.CODIGOLOJAALTERNATE = new SelectList(lojas, "CodigoLojaAlternate", "NomeLoja");

            #endregion populaobjetos

            InterfaceFolhaPagamentoViewModel ifpVM = new InterfaceFolhaPagamentoViewModel(codigoFolha, codigoClienteADP, empresasSelectListItem, lojasSelectListItem);

            return View(ifpVM);
        }

        // POST: /Interface/InterfaceFolhaPagamentoIndex
        [HttpPost, ActionName("InterfaceFolhaPagamentoIndex")]
        //[ValidateAntiForgeryToken]
        public ActionResult ArquivoInterfaceFolhaPagamento(string CodigoFolha, string CodigoLojaAlternate, string CodigoClienteADP, string NumeroProcessoFolha)
        {
            InterfaceFolhaPagamentoViewModel itpVM = new InterfaceFolhaPagamentoViewModel();

            try
            {
                string xmlStream;

                List<FolhaPagamento> fp = _produtoAppService.InterfaceFolhaPagamento(CodigoFolha, CodigoLojaAlternate, CodigoClienteADP, NumeroProcessoFolha).ToList();

                StringWriter sw = new StringWriter();

                sw.WriteLine("\"Cod de Folha\";\"Cod da Empresa\";\"Matricula\";\"Cod do cliente\";\"Processo de folha\";\"Valor do lancamento\"");

                foreach (var line in fp)
                {
                    sw.WriteLine(string.Format("\"{0}\";\"{1}\";\"{2}\";\"{3}\";\"{4}\";\"{5}\"",
                                               line.COD_FOLHA,
                                               line.COD_EMPRESA,
                                               line.MATRICULA,
                                               line.COD_CLIENTE,
                                               line.PROCESSO_FOLHA,
                                               line.VALOR_LANCAMENTO));
                }

                xmlStream = sw.ToString();

                return new ExcelResult
                {
                    FileName = string.Format("InterfaceFolhaPagamento-{0}.csv", DateTime.Now.ToString("yyyyMMdd-HHmmss")),
                    XMLStream = xmlStream
                };

            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Erro ao gerar arquivo. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
            }

            return View(itpVM);
        }



        // GET: /Interface/InterfaceTransferPricingIndex
        public ActionResult InterfaceTransferPricingIndex()
        {
            InterfaceTransferPricingViewModel itpVM = new InterfaceTransferPricingViewModel();

            return View(itpVM);
        }

        // POST: /Interface/InterfaceTransferPricingIndex
        [HttpPost, ActionName("InterfaceTransferPricingIndex")]
        //[ValidateAntiForgeryToken]
        public ActionResult ArquivoInterfaceTransferPricing(string DT_INI, string DT_FIM)
        {
            InterfaceTransferPricingViewModel itpVM = new InterfaceTransferPricingViewModel();

            try
            {
                string xmlStream;

                List<TransferPricing> tp = _produtoAppService.InterfaceTransferPricing(Convert.ToDateTime(DT_INI), Convert.ToDateTime(DT_FIM)).ToList();

                StringWriter sw = new StringWriter();

                sw.WriteLine("\"COD_PRODUTO\";\"NEGOCIO\";\"MES\";\"VLR_DOLAR\";\"VLR_REAL\";\"COD_EMPRESA\"");

                foreach (var line in tp)
                {
                    sw.WriteLine(string.Format("\"{0}\";\"{1}\";\"{2}\";\"{3}\";\"{4}\";\"{5}\"",
                                               line.COD_PRODUTO,
                                               line.NEGOCIO,
                                               line.MES.ToString("dd/MM/yy"),
                                               line.VLR_DOLAR,
                                               line.VLR_REAL,
                                               line.COD_EMPRESA));
                }

                xmlStream = sw.ToString();

                return new ExcelResult
                {
                    FileName = string.Format("InterfaceTransferPricing-{0}.csv", DateTime.Now.ToString("yyyyMMdd-HHmmss")),
                    XMLStream = xmlStream
                };

            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Erro ao gerar arquivo. Tente novamente ou, se o problema persistir, entre em contato com o suporte.");
            }

            return View(itpVM);
        }

    }

}