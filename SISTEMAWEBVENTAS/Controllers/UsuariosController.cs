using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RAX.Models.Web.Api.Logger;
using TRAX.Infraestructure.Web.CoreApi;
using TRAX.Models.Web.Api.OperationResult;
using TRAX.Models.Web.Api.TraxApi.Request;

namespace SISTEMAWEBVENTAS.Controllers
{
    public class UsuariosController : Controller
    {
        private Logger _Logger;
        public UsuariosController()
        {
            this._Logger = new Logger(System.Web.HttpContext.Current.Server.MapPath("~//" + Properties.Settings.Default.PathLog));

        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult addUsers(UsuarioRequestDTO Request)
        {
            var Result = new object();
            try
            {
                OperationResult _OperationResult = new OperationResult();
                CoreAPIAdministration _Core = new CoreAPIAdministration(this._Logger);
                _OperationResult = _Core.addUser(Request, Properties.Settings.Default.webApiTrax);
                if (_OperationResult.Code == OperationResult.StatusCodesEnum.CONFLICT.ToString("D"))
                    return Json(new { Error = string.Empty, IsOK = false, Code = OperationResult.StatusCodesEnum.CONFLICT });
                if (!_OperationResult.IsOK() && _OperationResult.Code != OperationResult.StatusCodesEnum.ACCEPTED.ToString("D"))
                    throw new Exception(string.Join(", ", _OperationResult.Errors.Select(x => x.Message)));
                Result = new { Error = string.Empty, IsOK = true, Code = OperationResult.StatusCodesEnum.OK };

            }
            catch (Exception ex)
            {
                this._Logger.LogText("Erorr: Usuario : IVAN TAPIA ");
                this._Logger.LogError(ex);
                Result = new { Error = ex.Message, IsOK = false, Code = OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR };

            }
            return Json(Result);
        }
        
    }
}