using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Services.DTOs
{
    [DataContract]
    public class ReferenciaDTO
    {
        [DataMember]
        public int ReferenciaId { get; set; }
        [DataMember]
        public string Fuente { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string SubtemaId { get; set; }
        [DataMember]
        public string Autor { get; set; }
        [DataMember]
        public string Error { get; set; }
    }
}