using CognaAPI.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CognaAPI.Infra.EntityConfig
{
    public class TodoMap : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.Property(t => t.Descricao);
            builder.Property(t => t.Concluido);
            builder.Property(t => t.DataLembrete);
        }
    }
}
