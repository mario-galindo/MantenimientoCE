using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades_POCO
{
    public class Tema
    {
        public string TemaId { get; set; }
        public int Orden { get; set; }
        public string Nombre { get; set; }
        public string CategoriaId { get; set; }
        public string Estado { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Subtema> Subtemas { get; set; }


    }
}
