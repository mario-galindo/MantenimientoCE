using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades_POCO
{
    public class Subtema
    {
        public string SubtemaId { get; set; }
        public string Descripcion { get; set; }
        public string TemaId { get; set; }
        public int Orden { get; set; }
        public string Estado { get; set; }
        public virtual Tema Tema{ get; set; }
        public virtual ICollection<Referencia> Referencias { get; set; }
    }
}
