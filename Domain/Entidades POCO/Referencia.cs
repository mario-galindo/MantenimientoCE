using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades_POCO
{
    public class Referencia
    {
        public int ReferenciaId { get; set; }
        public string Fuente { get; set; }
        public string Descripcion { get; set; }
        public string SubtemaId { get; set; }
        public string Autor { get; set; }
        public Subtema SubTema { get; set; }
    }
}
