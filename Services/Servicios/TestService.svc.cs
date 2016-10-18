using AutoMapper;
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
        public TestService()
        {
           

            Mapper.Initialize(cfg => cfg.CreateMap<CategoriaDTO, Categoria>());
           
        }
        public void DoWork()
        {

        }

        #region Categorias
        public List<CategoriaDTO> ObtenerCategorias(bool CategoryFilter)
        {
            var categoriaDto = new List<CategoriaDTO>();
            var newtemadto = new List<TemasDTO>();

            using (var contexto = new UnitOfWork())
            {
                List<Categoria> categorias = GetCategoriesfromReposity(CategoryFilter, contexto);

                foreach (var item in categorias)
                {
                    categoriaDto.Add(MaterializarCategoria(item));
                }
            }
            return categoriaDto;
        }

        private static List<Categoria> GetCategoriesfromReposity(bool CategoryFilter, UnitOfWork contexto)
        {
            List<Categoria> categorias;
            if (CategoryFilter == true)
            {
                categorias = contexto.Categoria.Where(c => c.Estado == "ACTIVO" || c.Estado == "ACTIVE").ToList();
            }
            else
            {
                 categorias = contexto.Categoria.ToList();
            }

            return categorias;
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


        public CategoriaDTO AgregarCategoria(CategoriaDTO categoriaDTO)
        {

            using (var contexto = new UnitOfWork())
            {

                if (categoriaDTO.CategoriaId == null)
                {
                    return new CategoriaDTO() { Error = "Campos vacios" };
                }
                else
                {
                    var buscarcatego = contexto.Categoria.FirstOrDefault(q => q.CategoriaId == categoriaDTO.CategoriaId);

                    if (buscarcatego == null)
                    {
                        var categoria = Mapper.Map<Categoria>(categoriaDTO);
                        
                        contexto.Categoria.Add(categoria);
                        contexto.SaveChanges();
                        return null;
                    }

                    else
                    {
                        return new CategoriaDTO() { Error = "El id ya existe" };
                    }
                }

            }
        }

        public CategoriaDTO EliminarCategoria(string Id)
        {
            var categoria = new CategoriaDTO();

            using (var contexto = new UnitOfWork())
            {
                var entidadCategoria = contexto.Categoria.FirstOrDefault(q => q.CategoriaId == Id);

                if (entidadCategoria != null)
                {
                    try
                    {
                        contexto.Categoria.Remove(entidadCategoria);
                        contexto.SaveChanges();
                        return null;
                    }
                    catch (Exception)
                    {
                        return new CategoriaDTO() { Error = "Debe borrar los temas relacionados a esta categoria" };
                    }
                }
                else
                {
                    return new CategoriaDTO() { Error = "No se pudo eliminar la categoria" };
                }
            }

        }

        public CategoriaDTO ModificarCategoria(CategoriaDTO dto)
        {

            using (var contexto = new UnitOfWork())
            {
                var entidadCategoria = contexto.Categoria.FirstOrDefault(q => q.CategoriaId == dto.CategoriaId);

                if (entidadCategoria == null)
                {
                    return new CategoriaDTO()
                    {
                        Error = "Error al modificar la categoria intente de nuevo"
                    };
                }
                else
                {
                    entidadCategoria.Estado = dto.Estado;
                    entidadCategoria.Nombre = dto.Nombre;
                    contexto.SaveChanges();
                    return null;
                }

            }
        }
        #endregion

        #region Temas
        public TemasDTO GuardarTema(TemasDTO temaDTO)
        {
            if (temaDTO.Nombre== null)
            {
                return new TemasDTO() { Error = "Campos vacios" };
            }
            else
            {
                using (var contexto = new UnitOfWork())
                {

                    var buscarTema = contexto.Tema.FirstOrDefault(q => q.TemaId == temaDTO.TemaId);
                    if (buscarTema == null)
                    {
                        Tema NuevoTema = new Tema();
                        NuevoTema.TemaId = temaDTO.TemaId;
                        NuevoTema.Orden = temaDTO.Orden;
                        NuevoTema.Nombre = temaDTO.Nombre;
                        NuevoTema.CategoriaId = temaDTO.CategoriaId;
                        NuevoTema.Estado = temaDTO.Estado;

                        contexto.Tema.Add(NuevoTema);
                        contexto.SaveChanges();
                        return null;
                    }
                    else
                    {
                        return new TemasDTO() { Error = "Ya existe el id del tema" };
                    }
                }
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

        public TemasDTO EditarTema(TemasDTO temaDTO)
        {
            using (var contexto = new UnitOfWork())
            {
                var TemaParaActualizar = contexto.Tema.FirstOrDefault(x => x.TemaId == temaDTO.TemaId);

                if (TemaParaActualizar != null)
                {
                    TemaParaActualizar.Orden = temaDTO.Orden;
                    TemaParaActualizar.Nombre = temaDTO.Nombre;
                    TemaParaActualizar.Estado = temaDTO.Estado;

                    contexto.SaveChanges();
                    return null;
                }

                else
                {
                    return new TemasDTO() { Error = "Error al editar el tema" };
                }
            }
        }
        #endregion

        #region Subtemas
        public SubtemaDTO GuardarSubtema(SubtemaDTO subtemaDTO)
        {
            if(subtemaDTO.Descripcion != null)
            {
                using (var contexto = new UnitOfWork())
                {
                    var tamanio = subtemaDTO.SubtemaId.Count();

                    if (tamanio > 20)
                    {
                        return new SubtemaDTO()
                        {
                            Error = "La descripcion es muy grande, intente de nuevo"
                        };
                    }
                    else
                    {
                        var buscarSubtema = contexto.Subtema.FirstOrDefault(x => x.SubtemaId == subtemaDTO.SubtemaId);
                        if (buscarSubtema == null)
                        {
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
                            return null;
                        }
                        else
                        {
                            return new SubtemaDTO() { Error = "El id ya existe" };
                        }

                    }
                }
            }
            else
            {
                return new SubtemaDTO() { Error = "Campos Vacios" };
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

        public SubtemaDTO EditarSubtema(SubtemaDTO subtemaDTO)
        {
            using (var contexto = new UnitOfWork())
            {
                var actualizarSubtema = contexto.Subtema.FirstOrDefault(x => x.SubtemaId == subtemaDTO.SubtemaId);

                if (actualizarSubtema != null)
                {
                    actualizarSubtema.Orden = subtemaDTO.Orden;
                    actualizarSubtema.Descripcion = subtemaDTO.Descripcion;
                    actualizarSubtema.Estado = subtemaDTO.Estado;

                    contexto.SaveChanges();
                    return null;
                }
                else
                {
                    return new SubtemaDTO() { Error = "Error al editar el subtema" };
                }
                
            }
        }
        #endregion

        #region Referencias
        public bool CheckURLValid(string source)
         {
            Uri uriResult;
            return Uri.TryCreate(source, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    public ReferenciaDTO GuardarReferencia(ReferenciaDTO referenciaDTO)
        {
            int insertedId;
            using (var contexto = new UnitOfWork())
            {
                var buscarReferencia = contexto.Referencia.FirstOrDefault(q => q.ReferenciaId == referenciaDTO.ReferenciaId);

                if (buscarReferencia == null)
                {
                    if (CheckURLValid(referenciaDTO.Fuente))
                    {
                        Referencia NuevoReferencia = new Referencia();

                        NuevoReferencia.Autor = referenciaDTO.Autor;
                        NuevoReferencia.Descripcion = referenciaDTO.Descripcion;
                        NuevoReferencia.Fuente = referenciaDTO.Fuente;
                        NuevoReferencia.SubtemaId = referenciaDTO.SubtemaId;

                        contexto.Referencia.Add(NuevoReferencia);
                        contexto.SaveChanges();
                        insertedId = NuevoReferencia.ReferenciaId;
                        return new ReferenciaDTO() { ReferenciaId = insertedId };
                    }
                    else
                    {
                        return new ReferenciaDTO() { Error = "URL no valida" };
                    }
                   
                }
                else
                {
                    return new ReferenciaDTO() { Error = "El id ya existe" };
                }   
            }
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

        public ReferenciaDTO EditarReferencia(ReferenciaDTO referenciaDTO)
        {
            using (var contexto = new UnitOfWork())
            {
                var ReferenciaActualizar = contexto.Referencia.FirstOrDefault(x => x.ReferenciaId == referenciaDTO.ReferenciaId);
                if (ReferenciaActualizar != null)
                {
                    ReferenciaActualizar.Autor = referenciaDTO.Autor;
                    ReferenciaActualizar.Descripcion = referenciaDTO.Descripcion;
                    ReferenciaActualizar.Fuente = referenciaDTO.Fuente;

                    contexto.SaveChanges();
                    return null;
                }
                else
                {
                    return new ReferenciaDTO() { Error = "Error al actualizar la referencia" };
                }
            }
        }

        public ReferenciaDTO GuardarReferencia2(ReferenciaDTO referenciaDTO)
        {
            int insertedId;
            using (var contexto = new UnitOfWork())
            {
                var buscarReferencia = contexto.Referencia.FirstOrDefault(q => q.ReferenciaId == referenciaDTO.ReferenciaId);

                if (buscarReferencia == null)
                {
                    Referencia NuevoReferencia = new Referencia();

                    NuevoReferencia.Autor = referenciaDTO.Autor;
                    NuevoReferencia.Descripcion = referenciaDTO.Descripcion;
                    NuevoReferencia.Fuente = referenciaDTO.Fuente;
                    NuevoReferencia.SubtemaId = referenciaDTO.SubtemaId;

                    contexto.Referencia.Add(NuevoReferencia);
                    contexto.SaveChanges();
                    insertedId = NuevoReferencia.ReferenciaId;
                    return new ReferenciaDTO() { ReferenciaId = insertedId };
                }
                else
                {
                    return new ReferenciaDTO() { Error = "El id ya existe" };
                }
            }
        }

        #endregion


    }
}
