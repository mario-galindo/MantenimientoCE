using Domain.Entidades_POCO;
using Infrastructure;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Services.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TestService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TestService.svc or TestService.svc.cs at the Solution Explorer and start debugging.
    public class TestService : ITestService
    {
        public void DoWork()
        {

        }

        #region Categorias
        public List<CategoriaDTO> ObtenerCategorias()
        {

            var categoriaDto = new List<CategoriaDTO>();


            using (var contexto = new UnitOfWork())
            {
                var categorias = contexto.Categoria.ToList();
                foreach (var item in categorias)
                {
                    categoriaDto.Add(MaterializarCategoria(item));
                }

            }

            return categoriaDto;
        }

        private static CategoriaDTO MaterializarCategoria(Categoria Categoria)
        {
            CategoriaDTO categoriaDto = new CategoriaDTO()
            {
                CategoriaId = Categoria.CategoriaId,
                Estado = Categoria.Estado,
                Nombre = Categoria.Nombre,
                Temas = new List<TemasDTO>()
            };
            foreach (var tema in Categoria.Temas.ToList())
            {

                var temanuevo = new TemasDTO()
                {
                    CategoriaId = tema.CategoriaId,
                    Nombre = tema.Nombre,
                    TemaId = tema.TemaId,
                    Estado = tema.Estado,
                    SubTemas = new List<SubtemaDTO>()
                };


                foreach (var subtema in tema.Subtemas.ToList())
                {

                    var subtemanuevo = new SubtemaDTO()
                    {
                        Descripcion = subtema.Descripcion,
                        Estado = subtema.Estado,
                        Orden = subtema.Orden,
                        SubtemaId = subtema.SubtemaId,
                        TemaId = subtema.TemaId,
                        Referencias = new List<ReferenciaDTO>()
                    };

                    foreach (var referencia in subtema.Referencias.ToList())
                    {

                        var referencianueva = new ReferenciaDTO()
                        {
                            Autor = referencia.Autor,
                            Descripcion = referencia.Descripcion,
                            Fuente = referencia.Fuente,
                            ReferenciaId = referencia.ReferenciaId,
                            SubtemaId = referencia.SubtemaId,
                        };
                        subtemanuevo.Referencias.Add(referencianueva);
                    }
                    temanuevo.SubTemas.Add(subtemanuevo);
                }
                categoriaDto.Temas.Add(temanuevo);
            }
            return categoriaDto;
        }


        public string AgregarCategoria(CategoriaDTO categoriaDTO)
        {

            string str = string.Empty;
            using (var contexto = new UnitOfWork())
            {
                var buscarcatego = contexto.Categoria.FirstOrDefault(q => q.CategoriaId == categoriaDTO.CategoriaId);
                if (buscarcatego == null)
                {
                    var Tema = new Categoria()
                    {
                        CategoriaId = categoriaDTO.CategoriaId,
                        Estado = categoriaDTO.Estado,
                        Nombre = categoriaDTO.Nombre
                    };
                    contexto.Categoria.Add(Tema);
                    contexto.SaveChanges();
                    str = "agregado";
                }
              

            }

            return str;
        }

        public string EliminarCategoria(string Id)
        {
            var categoria = new CategoriaDTO();

            using (var contexto = new UnitOfWork())
            {
                var entidadCategoria = contexto.Categoria.FirstOrDefault(q => q.CategoriaId == Id);

                if (entidadCategoria != null)
                {
                    contexto.Categoria.Remove(entidadCategoria);
                    contexto.SaveChanges();
                    return "Eliminado";
                }
                else
                    return "";
            }

        }

        public string ModificarCategoria(CategoriaDTO dto)
        {

            using (var contexto = new UnitOfWork())
            {
                var entidadCategoria = contexto.Categoria.FirstOrDefault(q => q.CategoriaId == dto.CategoriaId);

                if (entidadCategoria == null)
                {
                    return "";
                }
                else
                {
                    entidadCategoria.Estado = dto.Estado;
                    entidadCategoria.Nombre = dto.Nombre;
                    contexto.SaveChanges();
                    return "Bien";
                }

            }
        }
        #endregion

        #region Temas
        public void GuardarTema(TemasDTO temaDTO)
        {
            using (var contexto = new UnitOfWork())
            {
                Tema NuevoTema = new Tema();
                //int LastId = contexto.Tema.Count() + 1;

                NuevoTema.TemaId = temaDTO.TemaId;
                NuevoTema.Orden = temaDTO.Orden;
                NuevoTema.Nombre = temaDTO.Nombre;
                NuevoTema.CategoriaId = temaDTO.CategoriaId;
                NuevoTema.Estado = temaDTO.Estado;

                contexto.Tema.Add(NuevoTema);
                contexto.SaveChanges();
            }
        }

        public void EliminarTema(string Id)
        {
            using (var contexto = new UnitOfWork())
            {
                var TemaBorrar = contexto.Tema.FirstOrDefault(x => x.TemaId == Id);
                contexto.Tema.Remove(TemaBorrar);
                contexto.SaveChanges();
            }
        }

        public void EditarTema(TemasDTO temaDTO)
        {
            using (var contexto = new UnitOfWork())
            {
                var TemaParaActualizar = contexto.Tema.FirstOrDefault(x => x.TemaId == temaDTO.TemaId);

                TemaParaActualizar.Orden = temaDTO.Orden;
                TemaParaActualizar.Nombre = temaDTO.Nombre;
                TemaParaActualizar.Estado = temaDTO.Estado;

                contexto.SaveChanges();
            }
        }
        #endregion

        #region Subtemas
        public void GuardarSubtema(SubtemaDTO subtemaDTO)
        {
            using (var contexto = new UnitOfWork())
            {
                //var llave = contexto.Subtema.Count();
                
                Domain.Entidades_POCO.Subtema nuevoSubtema = new Domain.Entidades_POCO.Subtema()
                {
                    SubtemaId = subtemaDTO.SubtemaId,
                    TemaId = subtemaDTO.TemaId,
                    Descripcion = subtemaDTO.Descripcion,
                    Estado = subtemaDTO.Estado,
                    Orden = subtemaDTO.Orden
                };

                contexto.Subtema.Add(nuevoSubtema);
                contexto.SaveChanges();
            }
        }

        public void EliminarSubtema(string Id)
        {
            using (var contexto = new UnitOfWork())
            {
                var BorrarSubtema = contexto.Subtema.FirstOrDefault(x => x.SubtemaId == Id);
                contexto.Subtema.Remove(BorrarSubtema);
                contexto.SaveChanges();
            }
        }

        public void EditarSubtema(SubtemaDTO subtemaDTO)
        {
            using (var contexto = new UnitOfWork())
            {
                var actualizarSubtema = contexto.Subtema.FirstOrDefault(x => x.SubtemaId == subtemaDTO.SubtemaId);

                actualizarSubtema.Orden = subtemaDTO.Orden;
                actualizarSubtema.Descripcion = subtemaDTO.Descripcion;
                actualizarSubtema.Estado = subtemaDTO.Estado;
                
                contexto.SaveChanges();
            }
        }
        #endregion

        #region Referencias
        public int GuardarReferencia(ReferenciaDTO referenciaDTO)
        {
            int insertedId;
            using (var contexto = new UnitOfWork())
            {
                Referencia NuevoReferencia = new Referencia();

                NuevoReferencia.Autor = referenciaDTO.Autor;
                NuevoReferencia.Descripcion = referenciaDTO.Descripcion;
                NuevoReferencia.Fuente = referenciaDTO.Fuente;
                NuevoReferencia.SubtemaId = referenciaDTO.SubtemaId;

                contexto.Referencia.Add(NuevoReferencia);
                contexto.SaveChanges();
                insertedId = NuevoReferencia.ReferenciaId;
                
            }

            return insertedId;
        }

        public void EliminarReferencia(int Id)
        {
            using (var contexto = new UnitOfWork())
            {
                var ReferenciaBorrar = contexto.Referencia.FirstOrDefault(x => x.ReferenciaId == Id);
                contexto.Referencia.Remove(ReferenciaBorrar);
                contexto.SaveChanges();
            }
        }

        public void EditarReferencia(ReferenciaDTO referenciaDTO)
        {
            using (var contexto = new UnitOfWork())
            {
                var ReferenciaActualizar = contexto.Referencia.FirstOrDefault(x => x.ReferenciaId == referenciaDTO.ReferenciaId);

                ReferenciaActualizar.Autor = referenciaDTO.Autor;
                ReferenciaActualizar.Descripcion = referenciaDTO.Descripcion;
                ReferenciaActualizar.Fuente = referenciaDTO.Fuente;

                contexto.SaveChanges();
            }
        }

        public int GuardarReferencia2(ReferenciaDTO referenciaDTO)
        {
            int insertedId;
            using (var contexto = new UnitOfWork())
            {
                Referencia NuevoReferencia = new Referencia();

                NuevoReferencia.Autor = referenciaDTO.Autor;
                NuevoReferencia.Descripcion = referenciaDTO.Descripcion;
                NuevoReferencia.Fuente = referenciaDTO.Fuente;
                NuevoReferencia.SubtemaId = referenciaDTO.SubtemaId;

                contexto.Referencia.Add(NuevoReferencia);
                contexto.SaveChanges();
                insertedId = NuevoReferencia.ReferenciaId;

            }

            return insertedId;
        }

        #endregion


    }
}
