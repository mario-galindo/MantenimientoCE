using Domain.Entidades_POCO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal class ReferenciaEntityTypeConfiguration:EntityTypeConfiguration<Referencia>
    {
        public ReferenciaEntityTypeConfiguration()
        {
            HasKey(t => t.ReferenciaId);
            ToTable("Referencias", "Training");

            Property(t => t.ReferenciaId).HasColumnName("ReferenciaId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Fuente).HasColumnName("Fuente").IsRequired().IsUnicode(false);
            Property(t => t.Descripcion).HasColumnName("Descripcion").IsRequired().IsUnicode(false);
            Property(t => t.SubtemaId).HasColumnName("SubtemaId").IsRequired();
            Property(t => t.Autor).HasColumnName("Autor").IsRequired().IsUnicode(false).HasMaxLength(100);
            
        }
    }
}
