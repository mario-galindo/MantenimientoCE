using Domain.Entidades_POCO;
using Infrastructure;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UsuarioService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UsuarioService.svc or UsuarioService.svc.cs at the Solution Explorer and start debugging.
    public class UsuarioService : IUsuarioService
    {
        public void DoWork()
        {
        }

        #region Usuarios
        public void GuardarUsuario(UsuariosDTO usuarioDto)
        {
            using (var contexto = new UnitOfWork())
            {
                var Usuario = new Usuarios()
                {
                    Area = usuarioDto.Area,
                    Nombre = usuarioDto.Nombre,
                    UsuarioId = usuarioDto.UsuarioId,
                };
                contexto.Usuarios.Add(Usuario);
                contexto.SaveChanges();
            }
        }

        public void EditarUsuario(UsuariosDTO usuarioDto)
        {
            using (var contexto = new UnitOfWork())
            {
                var entidadSubtema = contexto.Usuarios.FirstOrDefault(q => q.UsuarioId == usuarioDto.UsuarioId);

                entidadSubtema.Nombre = usuarioDto.Nombre;
                entidadSubtema.Area = usuarioDto.Area;

                contexto.SaveChanges();
            }
        }

        public void EliminarUsuario(string Id)
        {
            using (var contexto = new UnitOfWork())
            {
                var UsuarioBorrar = contexto.Usuarios.FirstOrDefault(x => x.UsuarioId == Id);
                contexto.Usuarios.Remove(UsuarioBorrar);
                contexto.SaveChanges();
            }
        }

        public List<UsuariosDTO> ObtenerUsuarios()
        {
            List<UsuariosDTO> ListadoDepartamentos = new List<UsuariosDTO>();
            UsuariosDTO Entidad = new UsuariosDTO();

            using (var contexto = new UnitOfWork())
            {
                foreach (var item in contexto.Usuarios)
                {
                    Entidad.UsuarioId = item.UsuarioId;
                    Entidad.Nombre = item.Nombre;
                    Entidad.Area = item.Area;
                    ListadoDepartamentos.Add(Entidad);
                    Entidad = new UsuariosDTO();
                }
            }

            return ListadoDepartamentos;
        }
        #endregion
    }
}
