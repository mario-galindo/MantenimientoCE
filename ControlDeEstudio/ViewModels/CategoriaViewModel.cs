using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Linq;
using System.Windows.Threading;
using System;
using System.Windows.Data;


namespace ControlDeEstudio.ViewModels
{
    public class CategoriaViewModel : BaseINPC
    {

        private readonly TestServiceReference.TestServiceClient proxy;
        private readonly UsuariosServiceReference.UsuarioServiceClient proxyUsuario;

        public string VisualStateName2
        {
            get { return _visualStateName2; }
            set
            {
                if (_visualStateName2 != value)
                {
                    _visualStateName2 = value;
                    RaisePropertyChanged("VisualStateName2");
                }
            }
        }
        private string _visualStateName2;

        #region Propiedades

        #region Propiedades Paginados
        private PagedCollectionView _paginadoCategorias;
        public PagedCollectionView PaginadoCategorias
        {
            get
            {
                return _paginadoCategorias;
            }

            set
            {
                if (_paginadoCategorias != value)
                {
                    _paginadoCategorias = value;
                    RaisePropertyChanged("PaginadoCategorias");
                }
            }
        }

        private PagedCollectionView _paginadoTemas;
        public PagedCollectionView PaginadoTemas
        {
            get
            {
                return _paginadoTemas;
            }

            set
            {
                if (_paginadoTemas != value)
                {
                    _paginadoTemas = value;
                    RaisePropertyChanged("PaginadoTemas");
                }
            }
        }

        private PagedCollectionView _paginadoSubtemas;
        public PagedCollectionView PaginadoSubtemas
        {
            get
            {
                return _paginadoSubtemas;
            }

            set
            {
                if (_paginadoSubtemas != value)
                {
                    _paginadoSubtemas = value;
                    RaisePropertyChanged("PaginadoSubtemas");
                }
            }
        }

        private PagedCollectionView _paginadoReferencias;

        public PagedCollectionView PaginadoReferencias
        {
            get
            {
                return _paginadoReferencias;
            }

            set
            {
                if (_paginadoReferencias != value)
                {
                    _paginadoReferencias = value;
                    RaisePropertyChanged("PaginadoReferencias");
                }
            }
        }
        #endregion

        #region Propiedades Categoria
        private ObservableCollection<TestServiceReference.CategoriaDTO> _categorias;
        public ObservableCollection<TestServiceReference.CategoriaDTO> Categorias
        {
            get
            {
                return _categorias;
            }

            set
            {
                if (_categorias == value) return;
                _categorias = value;
                RaisePropertyChanged("Categorias");
            }
        }

        private TestServiceReference.CategoriaDTO _categoriaSeleccionada;
        public TestServiceReference.CategoriaDTO CategoriaSeleccionada
        {
            get
            {
                return _categoriaSeleccionada;
            }

            set
            {
                if (_categoriaSeleccionada == value) return;
                _categoriaSeleccionada = value;
                RaisePropertyChanged("CategoriaSeleccionada");
            }
        }

        private TestServiceReference.CategoriaDTO _propCategoria;
        public TestServiceReference.CategoriaDTO PropCategoria
        {
            get { return _propCategoria; }

            set
            {
                if (_propCategoria != value)
                {
                    _propCategoria = value;
                    RaisePropertyChanged("PropCategoria");
                }
            }
        }

        private TestServiceReference.TemasDTO _temaSeleccionado;
        public TestServiceReference.TemasDTO TemaSeleccionado
        {
            get
            {
                return _temaSeleccionado;
            }

            set
            {
                if (_temaSeleccionado == value) return;
                _temaSeleccionado = value;
                RaisePropertyChanged("TemaSeleccionado");
            }
        }

        private TestServiceReference.SubtemaDTO _subtemaseleccionado;
        public TestServiceReference.SubtemaDTO SubtemaSeleccionado
        {
            get
            {
                return _subtemaseleccionado;
            }

            set
            {
                if (_subtemaseleccionado == value) return;
                _subtemaseleccionado = value;
                RaisePropertyChanged("SubtemaSeleccionado");
            }
        }

        private bool _isAdd;
        public bool IsAdd
        {
            get
            {
                return _isAdd;
            }

            set
            {
                if (_isAdd == value) return;
                _isAdd = value;
                RaisePropertyChanged("IsAdd");
            }
        }

        private bool _iscategoryActive;
        public bool IsCategoryFilterActive
        {
            get
            {
                return _iscategoryActive;
            }

            set
            {
                if (_iscategoryActive == value) return;
                _iscategoryActive = value;
                RaisePropertyChanged("IsActive");
                ListarCategorias();
            }
        }
        #endregion

        #region Propiedades Temas
        private TestServiceReference.TemasDTO _temaDTO;

        public TestServiceReference.TemasDTO TemaDTO
        {
            get
            {
                return _temaDTO;
            }

            set
            {
                if (_temaDTO != value)
                {
                    _temaDTO = value;
                    RaisePropertyChanged("TemaDTO");
                }
            }
        }
        #endregion

        #region Propiedades Subtemas
        private TestServiceReference.SubtemaDTO _subtemaDTO;

        public TestServiceReference.SubtemaDTO SubtemaDTO
        {
            get
            {
                return _subtemaDTO;
            }

            set
            {
                if (_subtemaDTO != value)
                {
                    _subtemaDTO = value;
                    RaisePropertyChanged("SubtemaDTO");
                }
            }
        }
        #endregion

        #region Propiedades Referencia

        private TestServiceReference.ReferenciaDTO _referenciaSeleccionada;
        public TestServiceReference.ReferenciaDTO ReferenciaSeleccionada
        {
            get
            {
                return _referenciaSeleccionada;
            }

            set
            {
                if (_referenciaSeleccionada == value) return;
                _referenciaSeleccionada = value;
                RaisePropertyChanged("ReferenciaSeleccionada");
            }
        }

        private TestServiceReference.ReferenciaDTO _referenciaDto;
        public TestServiceReference.ReferenciaDTO ReferenciaDto
        {
            get
            {
                return _referenciaDto;
            }
            set
            {
                if (_referenciaDto != value)
                {
                    _referenciaDto = value;
                    RaisePropertyChanged("ReferenciaDTO");
                }
            }
        }
        #endregion

        #region Propiedades Usuarios

        private ObservableCollection<UsuariosServiceReference.UsuariosDTO> _usuarios;
        public ObservableCollection<UsuariosServiceReference.UsuariosDTO> Usuarios
        {
            get
            {
                return _usuarios;
            }

            set
            {
                if (_usuarios == value) return;
                _usuarios = value;
                RaisePropertyChanged("Usuarios");
            }
        }

        private UsuariosServiceReference.UsuariosDTO _usuariosDto;
        public UsuariosServiceReference.UsuariosDTO UsuariosDto
        {
            get
            {
                return _usuariosDto;
            }

            set
            {
                if (_usuariosDto != value)
                {
                    _usuariosDto = value;
                    RaisePropertyChanged("UsuariosDTO");
                }
            }
        }

        private UsuariosServiceReference.UsuariosDTO _usuariosSeleccionado;
        public UsuariosServiceReference.UsuariosDTO UsuariosSeleccionado
        {
            get
            {
                return _usuariosSeleccionado;
            }

            set
            {
                if (_usuariosSeleccionado == value) return;
                _usuariosSeleccionado = value;
                RaisePropertyChanged("UsuariosSeleccionado");
            }
        }

        #endregion

        #region Propiedades Panel

        private string _rectangleVisible;
        public string RectangleVisible
        {
            get { return _rectangleVisible; }
            set
            {
                if (_rectangleVisible != value)
                {
                    _rectangleVisible = value;
                    RaisePropertyChanged("RectangleVisible");
                }
            }
        }

        #endregion

        #region Propiedades Estado
        private ObservableCollection<string> _estados;

        public ObservableCollection<string> Estados
        {
            get
            {
                return _estados;
            }

            set
            {
                if (_estados != value)
                {
                    _estados = value;
                    RaisePropertyChanged("Estados");
                };
            }
        }
        #endregion

        #endregion

        #region Constructor
        public CategoriaViewModel()
        {
            InicializarPropiedades();
            InicializarComandos();
            proxy = new TestServiceReference.TestServiceClient();
            proxyUsuario = new UsuariosServiceReference.UsuarioServiceClient();
            InicializarRespuestaServicio();
            Estados = new ObservableCollection<string>();
            Estados.Add("Activo");
            Estados.Add("Inactivo");
            ListarCategorias();
            ListarUsuarios();
        }

        #endregion

        #region Otros
        public string VisualStateName
        {
            get { return _visualStateName; }
            set
            {
                if (_visualStateName != value)
                {
                    _visualStateName = value;
                    RaisePropertyChanged("VisualStateName");
                }
            }
        }
        private string _visualStateName;

        private void InicializarRespuestaServicio()
        {
            proxy.EliminarCategoriaCompleted += proxy_EliminarCategoriaCompleted;
            proxy.AgregarCategoriaCompleted += Proxy_AgregarCategoriaCompleted;
            proxy.ObtenerCategoriasCompleted += Proxy_ObtenerCategoriasCompleted;
            proxy.ModificarCategoriaCompleted += Proxy_ModificarCategoriaCompleted;
            proxy.GuardarSubtemaCompleted += Proxy_GuardarSubtemaCompleted;
            proxy.EditarTemaCompleted += Proxy_EditarTemaCompleted;
            proxy.EditarSubtemaCompleted += Proxy_EditarSubtemaCompleted;
            proxy.EliminarSubtemaCompleted += Proxy_EliminarSubtemaCompleted;
            proxy.GuardarReferenciaCompleted += proxy_GuardarReferenciaCompleted;
            //proxy.GuardarReferencia2Completed += Proxy_GuardarReferencia2Completed;
            proxy.EliminarReferenciaCompleted += Proxy_EliminarReferenciaCompleted;
            proxy.EditarReferenciaCompleted += Proxy_EditarReferenciaCompleted;
            proxy.GuardarTemaCompleted += proxy_GuardarTemaCompleted;
            proxy.EliminarTemaCompleted += Proxy_EliminarTemaCompleted;
            proxyUsuario.ObtenerUsuariosCompleted += Proxy_ObtenerUsuariosCompleted;
           
        }

        public void InicializarPropiedades()
        {
            PropCategoria = new TestServiceReference.CategoriaDTO();
            TemaDTO = new TestServiceReference.TemasDTO();
            SubtemaDTO = new TestServiceReference.SubtemaDTO();
            ReferenciaDto = new TestServiceReference.ReferenciaDTO();
            UsuariosDto = new UsuariosServiceReference.UsuariosDTO();
            RectangleVisible = "Collapsed";

        }

        private string _colorError;
        public string ColorError
        {
            get { return _colorError; }

            set
            {
                if (_colorError != value)
                {
                    _colorError = value;
                    RaisePropertyChanged("ColorError");
                }
            }
        }

        private string _mensajeError;
        public string MensajeError
        {
            get { return _mensajeError; }

            set
            {
                if (_mensajeError != value)
                {
                    _mensajeError = value;
                    RaisePropertyChanged("MensajeError");
                }
            }
        }

        public DispatcherTimer TimerProperty { get; set; }

        private Visibility _gridError;
        public Visibility GridError
        {
            get { return _gridError; }

            set
            {
                if (_gridError != value)
                {
                    _gridError = value;
                    RaisePropertyChanged("GridError");
                }
            }
        }
        private void MostrarMensaje(string error, string color)
        {
            GridError = Visibility.Visible;


            VisualStateName = "MostrarMensaje";
            ColorError = color;
            MensajeError = error;
            TimerProperty = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
            TimerProperty.Start();
            TimerProperty.Tick += TimerProperty_Tick;

        }

        private void TimerProperty_Tick(object sender, EventArgs e)
        {
            VisualStateName = "OcultarMensaje";
            TimerProperty.Stop();
        }

        public void LlenarPaginadoTemas()
        {
            if (CategoriaSeleccionada != null)
            {
                PaginadoTemas = new PagedCollectionView(CategoriaSeleccionada.Temas);
            }
        }
        public void LlenarPaginadoSubtemas()
        {
            if (TemaSeleccionado != null && TemaSeleccionado.SubTemas != null)
            {
                PaginadoSubtemas = new PagedCollectionView(TemaSeleccionado.SubTemas);
            }
            else
            {
                PaginadoSubtemas = null;
            }
        }
        public void LlenarPaginadoReferencias()
        {
            if (SubtemaSeleccionado != null)
            {
                PaginadoReferencias = new PagedCollectionView(SubtemaSeleccionado.Referencias);
            }
            else
            {
                PaginadoReferencias = null;
            }
        }
        #endregion

        #region Metodos Publicos

        #region Categorias

        public void AgregarCategoria()
        {
            proxy.AgregarCategoriaAsync(PropCategoria);
        }
        private void Proxy_AgregarCategoriaCompleted(object sender, TestServiceReference.AgregarCategoriaCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                MostrarMensaje("Categoria agregada exitosamente", "Exito");

                var CategoriaNueva = new TestServiceReference.CategoriaDTO()
                {
                    CategoriaId = PropCategoria.CategoriaId,
                    Nombre = PropCategoria.Nombre,
                    Estado = PropCategoria.Estado,
                    Temas = new ObservableCollection<TestServiceReference.TemasDTO>()
                };

                Categorias.Add(CategoriaNueva);
            }
            else
            {
                MostrarMensaje(e.Result.Error, "Error");
            }
        }

        public void ModificarCategoria()
        {
            if (CategoriaSeleccionada == null)
            {
                MostrarMensaje("Selecciona una Categoria", "Advertencia");
            }
            else
            {
                proxy.ModificarCategoriaAsync(PropCategoria);
            }

        }
        private void Proxy_ModificarCategoriaCompleted(object sender, TestServiceReference.ModificarCategoriaCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                MostrarMensaje("Se ha modificado exitosamente", "Exito");
                ListarCategorias();
            }
            else
            {
                MostrarMensaje(e.Result.Error, "Error");
            }
        }

        public void EliminarCategoria()
        {
            if (CategoriaSeleccionada == null)
            {
                MostrarMensaje("Selecciona una Categoria", "Advertencia");
            }

            else
            {
                proxy.EliminarCategoriaAsync(CategoriaSeleccionada.CategoriaId);
            }


        }

        void proxy_EliminarCategoriaCompleted(object sender, TestServiceReference.EliminarCategoriaCompletedEventArgs e)
        {

            if (e.Result == null)
            {
                MostrarMensaje("Se elimino la categoria", "Exito");
                ListarCategorias();
            }
            else
            {
                MostrarMensaje(e.Result.Error, "Error");
            }
        }

        public void CargarCategoriaporID(string Id)
        {
            var cate = Categorias.FirstOrDefault(c => c.CategoriaId == Id);
            PropCategoria = cate;
        }

        public void ListarCategorias()
        {
            proxy.ObtenerCategoriasAsync(IsCategoryFilterActive);
        }

        private void Proxy_ObtenerCategoriasCompleted(object sender, TestServiceReference.ObtenerCategoriasCompletedEventArgs e)
        {
            Categorias = e.Result;
            PaginadoCategorias = new PagedCollectionView(Categorias);

        }

        public void ModalCategoria(string type)
        {
            PropCategoria = new TestServiceReference.CategoriaDTO();
            var modal = new Modales.AgregarCategoria();
            modal.Show();
            if (type == "Add")
                IsAdd = true;

            else if (type == "Edit")
            {
                if (CategoriaSeleccionada != null)
                {

                    IsAdd = false;

                    CargarCategoriaporID(CategoriaSeleccionada.CategoriaId);
                }
            }
        }

        public void Ok()
        {
            if (IsAdd == true)
                AgregarCategoria();
            else
                ModificarCategoria();
        }
        #endregion

        #region Temas
        public void proxy_GuardarTemaCompleted(object sender, TestServiceReference.GuardarTemaCompletedEventArgs e)
        {

            if (e.Result == null)
            {
                MostrarMensaje("Tema Guardado", "Exito");

                var temaNuevo = new TestServiceReference.TemasDTO()
                {
                    CategoriaId = TemaDTO.CategoriaId,
                    Error = TemaDTO.Error,
                    Estado = TemaDTO.Estado,
                    Nombre = TemaDTO.Nombre,
                    Orden = TemaDTO.Orden,
                    SubTemas = new ObservableCollection<TestServiceReference.SubtemaDTO>(),
                    TemaId = TemaDTO.TemaId
                };

                CategoriaSeleccionada.Temas.Add(temaNuevo);
            }
            else
            {
                MostrarMensaje("Error al guardar el Tema", "Error");
            }
        }
        public void MostrarModalTema()
        {
            if (CategoriaSeleccionada == null)
            {
                MostrarMensaje("Debe seleccionar una categoria", "Advertencia");
            }
            else
            {
                Modales.ModalTema modalTema = new Modales.ModalTema();
                modalTema.ActualizarButton.IsEnabled = false;
                modalTema.GuardarButton.IsEnabled = true;

                var nuevoTema = new TestServiceReference.TemasDTO();
                TemaDTO = nuevoTema;

                modalTema.Show();

            }
        }

        public void GuardarTema()
        {
            TemaDTO.CategoriaId = CategoriaSeleccionada.CategoriaId;
            TemaDTO.TemaId = "TEM" + GenerarID(TemaDTO.Nombre);
            proxy.GuardarTemaAsync(TemaDTO);
        }

        public void BorrarTema()
        {
            if (TemaSeleccionado == null)
            {
                MostrarMensaje("Selecciona una Tema", "Advertencia");
            }
            else
            {
                proxy.EliminarTemaAsync(TemaSeleccionado.TemaId);

            }
        }

        private void Proxy_EliminarTemaCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MostrarMensaje("Se elimino el tema", "Exito");

                var index = CategoriaSeleccionada.Temas.IndexOf(TemaSeleccionado);
                CategoriaSeleccionada.Temas.RemoveAt(index);
            }
            else
            {
                MostrarMensaje("Error al eliminar el Tema", "Error");
            }
        }

        public void EditarTema()
        {
            if (TemaSeleccionado == null)
            {
                MostrarMensaje("Debe seleccionar un tema", "Advertencia");
            }
            else
            {
                TemaDTO.CategoriaId = CategoriaSeleccionada.CategoriaId;
                TemaDTO.TemaId = TemaSeleccionado.TemaId;
                proxy.EditarTemaAsync(TemaDTO);
            }


        }

        private void Proxy_EditarTemaCompleted(object sender, TestServiceReference.EditarTemaCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                MostrarMensaje("Tema editado", "Exito");
                foreach (var tema in CategoriaSeleccionada.Temas)
                {
                    if (tema.TemaId == TemaDTO.TemaId)
                    {
                        tema.Nombre = TemaDTO.Nombre;
                        tema.Orden = TemaDTO.Orden;
                        tema.Estado = TemaDTO.Estado;
                    }
                }
            }
            else
            {
                MostrarMensaje(e.Result.Error, "Error");
            }
        }

        public void MostrarTemaEditar()
        {
            if (TemaSeleccionado == null)
            {
                MostrarMensaje("Debe seleccionar un tema", "Advertencia");
            }
            else
            {
                var modalTema = new Modales.ModalTema();

                TemaDTO.Orden = TemaSeleccionado.Orden;
                TemaDTO.Nombre = TemaSeleccionado.Nombre;
                TemaDTO.Estado = TemaSeleccionado.Estado;

                modalTema.ActualizarButton.IsEnabled = true;
                modalTema.GuardarButton.IsEnabled = false;
                modalTema.Show();
            }

        }

        #endregion

        #region Subtemas
        public void MostrarModalSubtema()
        {
            if (TemaSeleccionado == null)
            {

                MostrarMensaje("Debe seleccionar un tema", "Advertencia");
            }
            else
            {
                Modales.ModalSubtema modalSubtema = new Modales.ModalSubtema();
                modalSubtema.GuardarButton.IsEnabled = true;
                modalSubtema.ActualizarButton.IsEnabled = false;

                var NuevoSubTema = new TestServiceReference.SubtemaDTO();
                SubtemaDTO = NuevoSubTema;

                modalSubtema.Show();

            }
        }
        public void GuardarSubtema()
        {
            SubtemaDTO.SubtemaId = "SUB" + GenerarID(SubtemaDTO.Descripcion);
            SubtemaDTO.TemaId = TemaSeleccionado.TemaId;
            proxy.GuardarSubtemaAsync(SubtemaDTO);
        }

        private void Proxy_GuardarSubtemaCompleted(object sender, TestServiceReference.GuardarSubtemaCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                MostrarMensaje("Subtema Guardado", "Exito");

                var SubtemaNuevo = new TestServiceReference.SubtemaDTO()
                {
                    Descripcion = SubtemaDTO.Descripcion,
                    Estado = SubtemaDTO.Estado,
                    Orden = SubtemaDTO.Orden,
                    TemaId = SubtemaDTO.TemaId,
                    SubtemaId = SubtemaDTO.SubtemaId,
                    Referencias = new ObservableCollection<TestServiceReference.ReferenciaDTO>()
                };

                TemaSeleccionado.SubTemas.Add(SubtemaNuevo);
            }
            else
            {
                MostrarMensaje(e.Result.Error, "Error");
            }
        }
        public void BorrarSubtema()
        {
            if (SubtemaSeleccionado == null)
            {
                MostrarMensaje("Seleccione un Subtema", "Advertencia");
                ListarCategorias();
            }
            else
            {
                proxy.EliminarSubtemaAsync(SubtemaSeleccionado.SubtemaId);

            }
        }

        private void Proxy_EliminarSubtemaCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {

                MostrarMensaje("Subtema Eliminado", "Exito");

                var index = TemaSeleccionado.SubTemas.IndexOf(SubtemaSeleccionado);
                TemaSeleccionado.SubTemas.RemoveAt(index);
            }
            else
            {
                MostrarMensaje("Error al Eliminar el Subtema", "Error");
            }
        }
        public void EditarSubtema()
        {
            if (SubtemaSeleccionado == null)
            {
                MostrarMensaje("Debe seleccionar una categoria", "Advertencia");
            }
            else
            {
                SubtemaDTO.TemaId = TemaSeleccionado.TemaId;
                SubtemaDTO.SubtemaId = SubtemaSeleccionado.SubtemaId;
                proxy.EditarSubtemaAsync(SubtemaDTO);
            }

        }

        private void Proxy_EditarSubtemaCompleted(object sender, TestServiceReference.EditarSubtemaCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                MostrarMensaje("Subtema editado", "Exito");

                foreach (var subtema in TemaSeleccionado.SubTemas)
                {
                    if (subtema.SubtemaId == SubtemaDTO.SubtemaId)
                    {
                        subtema.Descripcion = SubtemaDTO.Descripcion;
                        subtema.TemaId = SubtemaDTO.TemaId;
                        subtema.Orden = SubtemaDTO.Orden;
                        subtema.Estado = SubtemaDTO.Estado;
                    }
                }
            }
            else
            {
                MostrarMensaje(e.Result.Error, "Error");
            }
        }
        public void MostrarSubtemaEditar()
        {

            if (SubtemaSeleccionado == null)
            {
                MostrarMensaje("Debe seleccionar un subtema", "Advertencia");
            }

            else
            {
                var modalSubtema = new Modales.ModalSubtema();

                SubtemaDTO.Orden = SubtemaSeleccionado.Orden;
                SubtemaDTO.Descripcion = SubtemaSeleccionado.Descripcion;
                SubtemaDTO.Estado = SubtemaSeleccionado.Estado;
                SubtemaDTO.TemaId = SubtemaSeleccionado.TemaId;

                modalSubtema.GuardarButton.IsEnabled = false;
                modalSubtema.ActualizarButton.IsEnabled = true;
                modalSubtema.Show();
            }

        }
        #endregion

        #region Referencias
        public void MostrarModalReferencia()
        {
            if (SubtemaSeleccionado == null)
            {
                MostrarMensaje("Debe seleccionar un subtema", "Advertencia");
            }
            else
            {
                Modales.ModalReferencia modalRefereancia = new Modales.ModalReferencia();

                modalRefereancia.GuardarButton.IsEnabled = true;
                modalRefereancia.ActualizarButton.IsEnabled = false;
                
                var nuevaReferencia = new TestServiceReference.ReferenciaDTO();
                ReferenciaDto = nuevaReferencia;

                modalRefereancia.Show();
            }
        }

        public void GuardarReferencia()
        {
            ReferenciaDto.SubtemaId = SubtemaSeleccionado.SubtemaId;
            proxy.GuardarReferenciaAsync(ReferenciaDto);
        }
        
        void proxy_GuardarReferenciaCompleted(object sender, TestServiceReference.GuardarReferenciaCompletedEventArgs e)
        {
            if (e.Result.Error == null)
            {
                MostrarMensaje("Referencia Guardada", "Exito");

                var referenciaNueva = new TestServiceReference.ReferenciaDTO()
                {
                    Autor = ReferenciaDto.Autor,
                    Descripcion = ReferenciaDto.Descripcion,
                    Fuente = ReferenciaDto.Fuente,
                    SubtemaId = ReferenciaDto.SubtemaId,
                    ReferenciaId = ReferenciaDto.ReferenciaId

                };

                SubtemaSeleccionado.Referencias.Add(referenciaNueva);
            }
            else
            {
                MostrarMensaje(e.Result.Error, "Error");
            }
        }
        public void BorrarReferencia()
        {
            if (ReferenciaSeleccionada == null)
            {
                MostrarMensaje("Debe seleccionar una referencia", "Advertencia");
            }
            else
            {
                proxy.EliminarReferenciaAsync(ReferenciaSeleccionada.ReferenciaId);

            }
        }

        private void Proxy_EliminarReferenciaCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MostrarMensaje("Referencia Eliminada", "Exito");

                var index = SubtemaSeleccionado.Referencias.IndexOf(ReferenciaSeleccionada);
                SubtemaSeleccionado.Referencias.RemoveAt(index);
            }
            else
            {
                MostrarMensaje("No se ha podido eliminar la referencia", "Error");
            }
        }

        public void EditarReferencia()
        {
            if (ReferenciaSeleccionada == null)
            {
                MostrarMensaje("Debe seleccionar una referencia", "Advertencia");
            }
            else
            {
                ReferenciaDto.SubtemaId = ReferenciaSeleccionada.SubtemaId;
                ReferenciaDto.ReferenciaId = ReferenciaSeleccionada.ReferenciaId;
                proxy.EditarReferenciaAsync(ReferenciaDto);
            }

        }

        private void Proxy_EditarReferenciaCompleted(object sender, TestServiceReference.EditarReferenciaCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                MostrarMensaje("Referencia Editada", "Exito");

                foreach (var referencia in SubtemaSeleccionado.Referencias)
                {
                    if (referencia.ReferenciaId == ReferenciaDto.ReferenciaId)
                    {
                        referencia.ReferenciaId = ReferenciaDto.ReferenciaId;
                        referencia.Fuente = ReferenciaDto.Fuente;
                        referencia.Descripcion = ReferenciaDto.Descripcion;
                        referencia.SubtemaId = ReferenciaDto.SubtemaId;
                        referencia.Autor = ReferenciaDto.Autor;
                    }
                }
            }
            else
            {
                MostrarMensaje(e.Result.Error, "Error");
            }
        }

        public void MostrarReferenciaEditar()
        {
            if (ReferenciaSeleccionada == null)
            {
                MostrarMensaje("Debe seleccionar una referencia", "Advertencia");
            }
            else
            {
                var modalReferencia = new Modales.ModalReferencia();

                ReferenciaDto.Autor = ReferenciaSeleccionada.Autor;
                ReferenciaDto.Descripcion = ReferenciaSeleccionada.Descripcion;
                ReferenciaDto.Fuente = ReferenciaSeleccionada.Fuente;

                modalReferencia.GuardarButton.IsEnabled = false;
                modalReferencia.ActualizarButton.IsEnabled = true;
                modalReferencia.Show();
            }

        }

        #endregion

        #region Metodos Usuarios

        public void GuardarUsuario()
        {
            proxyUsuario.GuardarUsuarioAsync(UsuariosDto);
            proxyUsuario.GuardarUsuarioCompleted += Proxy_GuardarUsuarioCompleted;
        }

        private void Proxy_GuardarUsuarioCompleted(object sender, UsuariosServiceReference.GuardarUsuarioCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                ListarUsuarios();
                MostrarMensaje("Usuario Agregado Exitosamente", "Exito");
            }
            else
            {
                MostrarMensaje(e.Result.Error, "Error");
            }
        }

        public void BorrarUsuario()
        {
            if (UsuariosSeleccionado == null)
            {
                MostrarMensaje("Seleccione un Usuario", "Advertencia");
            }
            else
            {
                proxyUsuario.EliminarUsuarioAsync(UsuariosSeleccionado.UsuarioId);
                proxyUsuario.EliminarUsuarioCompleted += Proxy_EliminarUsuarioCompleted;
            }
        }

        private void Proxy_EliminarUsuarioCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ListarUsuarios();
                MostrarMensaje("Usuario Eliminado", "Exito");
            }
        }

        public void EditarUsuario()
        {
            UsuariosSeleccionado.Nombre =UsuariosDto.Nombre ;
            UsuariosSeleccionado.Area = UsuariosDto.Area ;
            UsuariosSeleccionado.UsuarioId = UsuariosDto.UsuarioId;

            proxyUsuario.EditarUsuarioAsync(UsuariosDto);
            proxyUsuario.EditarUsuarioCompleted += Proxy_EditarUsuarioCompleted;
        }

        private void Proxy_EditarUsuarioCompleted(object sender, UsuariosServiceReference.EditarUsuarioCompletedEventArgs e)
        {
            if (e.Result== null)
            {
                ListarUsuarios();
                MostrarMensaje("Usuario Editado Exitosamente", "Exito");
            }
            else
            {
                MostrarMensaje(e.Result.Error, "Error");
            }
        }

        public void MostrarModalUsuario()
        {
            Modales.ModalUsuario modalUsuario = new Modales.ModalUsuario();

            modalUsuario.ActualizarButton.IsEnabled = false;
            modalUsuario.GuardarButton.IsEnabled = true;

            var nuevoUsuario = new UsuariosServiceReference.UsuariosDTO();
            UsuariosDto = nuevoUsuario;

            modalUsuario.Show();
        }

        public void MostrarUsuarioEditar()
        {

            if (UsuariosSeleccionado == null)
            {
                MostrarMensaje("Debe seleccionar un Usuario", "Advertencia");
            }
            else
            {
                var modalUsuario = new Modales.ModalUsuario();

                UsuariosDto.Area = UsuariosSeleccionado.Area;
                UsuariosDto.Nombre = UsuariosSeleccionado.Nombre;
                UsuariosDto.UsuarioId = UsuariosSeleccionado.UsuarioId;

                modalUsuario.ActualizarButton.IsEnabled = true;
                modalUsuario.GuardarButton.IsEnabled = false;
                modalUsuario.Show();
            }
        }

        private void ListarUsuarios()
        {
            proxyUsuario.ObtenerUsuariosAsync();
        }

        private void Proxy_ObtenerUsuariosCompleted(object sender, UsuariosServiceReference.ObtenerUsuariosCompletedEventArgs e)
        {
            Usuarios = e.Result;
        }

        #endregion

        #region Metodos Panel
        private void MoverEstado(string estado)
        {
            VisualStateName = string.Empty;
            VisualStateName = estado;

        }

        private void AnimarPanel()
        {
            if (VisualStateName != "MostrarShiftState")
            {
                VisualStateName = "Normal2";
                RectangleVisible = "Collapsed";
            }
            if (VisualStateName == "Normal2")
            {
                MoverEstado("MostrarShiftState");
                RectangleVisible = "Visible";
            }
            else
            {
                MoverEstado("Normal2");
                RectangleVisible = "Collapsed";
            }
        }

        #endregion



        public void InicializarComandos()
        {
            // Cateogorias
            ComandoChildWindows = new RelayCommand<string>(ModalCategoria);
            ComandoEliminar = new RelayCommand(EliminarCategoria);
            ComandoModificarCategoria = new RelayCommand(ModificarCategoria);
            ComandoOk = new RelayCommand(Ok);

            // Tema
            ComandoModalTema = new RelayCommand(MostrarModalTema);
            ComandoGuardarTema = new RelayCommand(GuardarTema);
            ComandoBorrarTema = new RelayCommand(BorrarTema);
            ComandoEditarTema = new RelayCommand(EditarTema);
            ComandoMostrarEditarTema = new RelayCommand(MostrarTemaEditar);

            // Subtema
            ComandoModalSubtema = new RelayCommand(MostrarModalSubtema);
            ComandoGuardarSubtema = new RelayCommand(GuardarSubtema);
            ComandoBorrarSubtema = new RelayCommand(BorrarSubtema);
            ComandoEditarSubtema = new RelayCommand(EditarSubtema);
            ComandoMostrarEditarSubtema = new RelayCommand(MostrarSubtemaEditar);

            // Referencias
            ComandoModalReferencias = new RelayCommand(MostrarModalReferencia);
            ComandoGuardarReferencias = new RelayCommand(GuardarReferencia);
            ComandoBorrarReferencias = new RelayCommand(BorrarReferencia);
            ComandoEditarReferencias = new RelayCommand(EditarReferencia);
            ComandoMostrarEditarReferencias = new RelayCommand(MostrarReferenciaEditar);

            ComandoSelectedItemChangedCategoria = new RelayCommand(LlenarPaginadoTemas);
            ComandoSelectedItemChangedTema = new RelayCommand(LlenarPaginadoSubtemas);
            ComandoSelectedItemChangedSubTema = new RelayCommand(LlenarPaginadoReferencias);

            //Usuarios
            ComandoModalUsuarios = new RelayCommand(MostrarModalUsuario);
            ComandoGuardarUsuarios = new RelayCommand(GuardarUsuario);
            ComandoBorrarUsuarios = new RelayCommand(BorrarUsuario);
            ComandoEditarUsuarios = new RelayCommand(EditarUsuario);
            ComandoMostrarEditarUsuarios = new RelayCommand(MostrarUsuarioEditar);
            ComandoAnimarPanel = new RelayCommand(AnimarPanel);

        }

        public string GenerarID(string Nombre)
        {
            int size = Nombre.Trim().Length;
            if (size % 2 == 0)
            {
                size++;
            }

            return Nombre + size.ToString();
        }
        #endregion

        #region Comandos
        public RelayCommand<string> ComandoChildWindows { get; set; }
        public RelayCommand ComandoOk { get; set; }
        public RelayCommand ComandoEliminar { get; set; }
        public RelayCommand ComandoModificarCategoria { get; set; }

        public RelayCommand ComandoModalTema { get; set; }
        public RelayCommand ComandoGuardarTema { get; set; }
        public RelayCommand ComandoBorrarTema { get; set; }
        public RelayCommand ComandoEditarTema { get; set; }
        public RelayCommand ComandoMostrarEditarTema { get; set; }

        public RelayCommand ComandoModalSubtema { get; private set; }
        public RelayCommand ComandoBorrarSubtema { get; private set; }
        public RelayCommand ComandoEditarSubtema { get; private set; }
        public RelayCommand ComandoGuardarSubtema { get; private set; }
        public RelayCommand ComandoMostrarEditarSubtema { get; private set; }

        public RelayCommand ComandoModalReferencias { get; set; }
        public RelayCommand ComandoGuardarReferencias { get; set; }
        public RelayCommand ComandoBorrarReferencias { get; set; }
        public RelayCommand ComandoEditarReferencias { get; set; }
        public RelayCommand ComandoMostrarEditarReferencias { get; set; }

        public RelayCommand ComandoSelectedItemChangedCategoria { get; set; }
        public RelayCommand ComandoSelectedItemChangedTema { get; set; }
        public RelayCommand ComandoSelectedItemChangedSubTema { get; set; }

        public RelayCommand ComandoModalUsuarios { get; set; }
        public RelayCommand ComandoGuardarUsuarios { get; set; }
        public RelayCommand ComandoBorrarUsuarios { get; set; }
        public RelayCommand ComandoEditarUsuarios { get; set; }
        public RelayCommand ComandoMostrarEditarUsuarios { get; set; }
        public RelayCommand ComandoAnimarPanel { get; set; }
        #endregion

    }
}
