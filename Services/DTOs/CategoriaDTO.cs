using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Services.DTOs
{
    [DataContract]
    public class CategoriaDTO
    {
        [DataMember]
        public string CategoriaId { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public string Error { get; set; }

        [DataMember]
        public List<TemasDTO> Temas { get; set; }

    }
}