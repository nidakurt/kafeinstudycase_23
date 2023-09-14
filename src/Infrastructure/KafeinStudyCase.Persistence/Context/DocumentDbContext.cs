using KafeinStudyCase.Core.Data.Concrete;
using KafeinStudyCase.Core.Data.Interface;
using KafeinStudyCase.Persistence.EntityConfigurations;

namespace KafeinStudyCase.Persistence.Context;

public class DocumentDbContext : AppDbContext
{
    public DocumentDbContext(DbContextOptions<DocumentDbContext> options, ICurrentUserService currentUserService) : base(options, currentUserService)
    {
    }

    #region DbSet
    public DbSet<Domain.Entities.Document> ShippingCompanies { get; set; } = null!;

    #endregion
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.DbSetToSingular();

    }
}