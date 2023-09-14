using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KafeinStudyCase.Persistence.EntityConfigurations;

public static class SetDbSetToSingular
{
    public static void DbSetToSingular(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Entities.Document>().ToTable(nameof(Domain.Entities.Document));

    }
}
