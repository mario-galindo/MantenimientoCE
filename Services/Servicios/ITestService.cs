using Domain.Entidades_POCO;

using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Services.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITestService" in both code and config file together.
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        List<CategoriaDTO> ObtenerCategorias();

        [OperationContract]
        string AgregarCategoria(CategoriaDTO categoriaDTO);

        [OperationContract]
         string EliminarCategoria(string Id);
        [OperationContract]
        string ModificarCategoria(CategoriaDTO dto);

        [OperationContract]
        void GuardarTema(TemasDTO temaDTO);

        [OperationContract]
        void EliminarTema(string Id);

        [OperationContract]
        void EditarTema(TemasDTO temaDTO);

        [OperationContract]
        void GuardarSubtema(SubtemaDTO temaDTO);

        [OperationContract]
        void EliminarSubtema(string Id);

        [OperationContract]
        void EditarSubtema(SubtemaDTO temaDTO);

        [OperationContract]
        int GuardarReferencia(ReferenciaDTO referenciaDTO);

        [OperationContract]
        int GuardarReferencia2(ReferenciaDTO referenciaDTO);
        [OperationContract]
        void EliminarReferencia(int Id);

        [OperationContract]
        void EditarReferencia(ReferenciaDTO referenciaDTO);

     
    }
}
