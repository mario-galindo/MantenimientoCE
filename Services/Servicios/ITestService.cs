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
        List<CategoriaDTO> ObtenerCategorias(bool CategoryFilter);

        [OperationContract]
        CategoriaDTO AgregarCategoria(CategoriaDTO categoriaDTO);

        [OperationContract]
         CategoriaDTO EliminarCategoria(string Id);
        [OperationContract]
        CategoriaDTO ModificarCategoria(CategoriaDTO dto);

        [OperationContract]
        TemasDTO GuardarTema(TemasDTO temaDTO);

        [OperationContract]
        void EliminarTema(string Id);

        [OperationContract]
        TemasDTO EditarTema(TemasDTO temaDTO);

        [OperationContract]
        SubtemaDTO GuardarSubtema(SubtemaDTO temaDTO);

        [OperationContract]
        void EliminarSubtema(string Id);

        [OperationContract]
        SubtemaDTO EditarSubtema(SubtemaDTO temaDTO);

        [OperationContract]
        ReferenciaDTO GuardarReferencia(ReferenciaDTO referenciaDTO);

        [OperationContract]
        ReferenciaDTO GuardarReferencia2(ReferenciaDTO referenciaDTO);
        [OperationContract]
        void EliminarReferencia(int Id);

        [OperationContract]
        ReferenciaDTO EditarReferencia(ReferenciaDTO referenciaDTO);

     
    }
}
