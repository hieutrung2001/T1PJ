using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1PJ.DataLayer.Entity;

namespace T1PJ.DataLayer.Config
{
    public class ClassConfig : IEntityTypeConfiguration<Class>
    {
        void IEntityTypeConfiguration<Class>.Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable(nameof(Class));
            builder.HasKey(x => x.Id);
        }
    }
}
