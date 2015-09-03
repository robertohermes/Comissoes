using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dufry.Comissoes.Controllers
{
    public class ErrorController : Controller
    {
        //<REVER> Já existe um redirecionamento para a página "Shared/Error". Ajustar para usar só um.
        // GET: /Error/
        public ActionResult Index()
        {
            return View("Error");
        }

        public ActionResult NotFound()
        {
            Response.StatusCode = 200;
            return View("NotFound");
        }

        public ActionResult InternalServer()
        {
            Response.StatusCode = 200;
            return View("InternalServer");
        }

	}
}