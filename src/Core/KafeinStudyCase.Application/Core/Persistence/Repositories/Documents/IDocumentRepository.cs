using KafeinStudyCase.Core.Base.IoC;
using KafeinStudyCase.Core.Data.Interface;
using KafeinStudyCase.Core.Data.Models;
using KafeinStudyCase.Domain.Entities;
using KafeinStudyCase.Domain.Filters.ShippingCompanies;

namespace KafeinStudyCase.Application.Core.Persistence.Repositories.ShippingCompanies;

public interface IDocumentRepository : IRepository<Domain.Entities.Document>, IScopedService
{

}
