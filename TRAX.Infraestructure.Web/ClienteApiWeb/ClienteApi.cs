using RAX.Models.Web.Api.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAX.Models.Web.Api.OperationResult;
using TRAX.Models.Web.Api.TraxApi.Request;
using System.Net.Http;
using System.Security.Claims;
using TRAX.Models.Web.Api.Serializer;
using TRAX.Models.Web.Api.Api;
using TRAX.Models.Web.Api.TraxApi.Response;

namespace TRAX.Infraestructure.Web.ClienteApiWeb
{
   public class ClienteApi
    {
        private Logger _Logger;
        private string Token;
        private string UrlEndPoint;
        public ClienteApi(Logger Logger)
        {
            //this.Token = string.Empty;
            //this.UrlEndPoint = string.Empty;
            _Logger = Logger;
        }
        public bool HasToken()
        {
            return !string.IsNullOrEmpty(this.Token);
        }
        public bool HasEndPoint()
        {
            return !string.IsNullOrEmpty(this.UrlEndPoint);
        }
        public void SetEndPoint(string UrlEndPoint)
        {
            this.UrlEndPoint = UrlEndPoint;
        }
        public OperationResult addUsuario(UsuarioRequestDTO Request)
        {
            OperationResult _OperationResult = new OperationResult();
            string _PayLoad =JsonSerializer.Serialize(Request);
            MessageFactory _MessageFactory = new MessageFactory(this._Logger);
            var _Result = _MessageFactory.SendRequest<UsuariosResponseDTO>(this.UrlEndPoint,this.Token ="", "/Usuario/Usuarios", _PayLoad, HttpMethod.Post);
            if (!(_Result != null && _Result.Result != null))
            {
                _OperationResult.SetStatusCode(OperationResult.StatusCodesEnum.SERVICE_UNAVAILABLE);
                _OperationResult.AddException(new Exception("No se recibio respuesta de APISASE"));
                return _OperationResult;
            }
            return _Result.Result;

        }
    }
}
