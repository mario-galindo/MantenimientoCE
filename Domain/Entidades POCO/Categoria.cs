using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades_POCO
{
    public class Categoria
    {
        public string CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }

       public virtual ICollection<Tema> Temas { get; set; }
    }
}
