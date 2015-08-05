using Dufry.Comissoes.Data.Repository.EntityFramework;
using Dufry.Comissoes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Dufry.Comissoes.Application.Interfaces;

namespace Dufry.Comissoes.Filters
{
    public class ControleAcessoAdminFilter : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            //---------------------------------------------------------------------------------------------
            //<REVER>
            //O ideal fazer o filtro chamar uma classe externa que defina as regras de acesso
            //_controleacessoAppService.ObtainCurrentLoginFromAd();
            //---------------------------------------------------------------------------------------------
            string login = System.Environment.UserName;

            ControleAcesso controleAcesso = new ControleAcesso();
            ControleAcessoRepository controleAcessoRepository = new ControleAcessoRepository();

            controleAcesso = controleAcessoRepository.FindByActiveLogin(login);

            if (controleAcesso == null || (controleAcesso != null && controleAcesso.ADMIN != "S"))
            {
                filterContext.Result = new RedirectResult("~/Home/Index/");
                //filterContext.Result = new RedirectResult("~/Shared/Error/");
                return;
                
            }
        }
    }
}