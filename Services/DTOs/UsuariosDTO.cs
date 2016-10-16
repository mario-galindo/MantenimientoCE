using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Services.DTOs
{
    [DataContract]
    public class UsuariosDTO
    {
        [DataMember]
        public string UsuarioId { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Area { get; set; }
        [DataMember]
        public string Error { get; set; }
    }
}