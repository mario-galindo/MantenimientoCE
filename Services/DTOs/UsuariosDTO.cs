using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.DTOs
{
    public class UsuariosDTO
    {
        public string UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Area { get; set; }
        public string Error { get; set; }
    }
}