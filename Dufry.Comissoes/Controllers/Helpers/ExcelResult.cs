using System.Web.Mvc;

namespace Dufry.Comissoes.Controllers.Helpers
{

    public class ExcelResult : ActionResult
    {
        public string XMLStream { get; set; }
        public string FileName { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Buffer = true;
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.AddHeader("content-disposition", "attachment; filename=" + FileName);
            context.HttpContext.Response.ContentType = "application/vnd.ms-excel";
            context.HttpContext.Response.Write(XMLStream);
        }
    }
    
}