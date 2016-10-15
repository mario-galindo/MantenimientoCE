
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SubtemasService.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsuarioService" in both code and config file together.
    [ServiceContract]
    public interface IUsuarioService
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        void GuardarUsuario(UsuariosDTO usuarioDto);

        [OperationContract]
        void EditarUsuario(UsuariosDTO usuarioDto);

        [OperationContract]
        void EliminarUsuario(string Id);

        [OperationContract]
        List<UsuariosDTO> ObtenerUsuarios();
    }
}
