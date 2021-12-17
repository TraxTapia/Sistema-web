using RAX.Models.Web.Api.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAX.Infraestructure.Web.ClienteApiWeb;
using TRAX.Models.Web.Api.OperationResult;
using TRAX.Models.Web.Api.TraxApi.Request;

namespace TRAX.Infraestructure.Web.CoreApi
{
   public  class CoreAPIAdministration
    {
        private Logger _Logger;
        public CoreAPIAdministration(Logger Logger)
        {
         
            this._Logger = Logger;
        }
        public OperationResult addUser (UsuarioRequestDTO Request,string EndPoint)
        {
            OperationResult _operationResult = new OperationResult();
            try
            {
                ClienteApi _client = new ClienteApi(this._Logger);
                _client.SetEndPoint(EndPoint);

                _operationResult = _client.addUsuario(Request);
            }
            catch (Exception ex)
            {
                this._Logger.LogError(ex);
                _operationResult.SetStatusCode(OperationResult.StatusCodesEnum.INTERNAL_SERVER_ERROR);
                _operationResult.AddException(ex);
            }
            return _operationResult;
        }


    }
}
