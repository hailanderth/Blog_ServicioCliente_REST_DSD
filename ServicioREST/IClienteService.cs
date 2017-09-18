using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicioREST
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IClienteService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Cliente", ResponseFormat = WebMessageFormat.Json)]
        bool Registrar(ClienteEntidad entidad);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Cliente", ResponseFormat = WebMessageFormat.Json)]
        bool Modificar(ClienteEntidad entidad);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Cliente/{Codigo}", ResponseFormat = WebMessageFormat.Json)]
        bool Eliminar(string Codigo);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Cliente/{Codigo}", ResponseFormat = WebMessageFormat.Json)]
        ClienteEntidad ObtenerbyId(string Codigo);
    }
}
