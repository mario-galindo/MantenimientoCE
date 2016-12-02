
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Services.DTOs
{
    [DataContract]
    public class TemasDTO
    {
        [DataMember]
        public string TemaId { get; set; }
        [DataMember]
        public int Orden { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string CategoriaId { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string Error { get; set; }
        [DataMember]
        public List<SubtemaDTO> SubTemas { get; set; }

    }
}