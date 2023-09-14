using AutoMapper;
using KafeinStudyCase.Core.Base.Handlers.Search;
using KafeinStudyCase.Core.Base.Wrapper;
using KafeinStudyCase.Core.Data.Models;
using KafeinStudyCase.Application.Handlers.BaseResponses;
using KafeinStudyCase.Application.Handlers.ShippingCompanies.Commands;
using KafeinStudyCase.Application.Handlers.ShippingCompanies.DTOs;
using KafeinStudyCase.Domain.Entities;

namespace KafeinStudyCase.Application.Mappers;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {

        CreateMap(typeof(ListResponse<>), typeof(PagedResponse<>));
        CreateMap(typeof(SearchListModel<>), typeof(PagedResponse<>));
        CreateMap(typeof(SearchListModel<>), typeof(SearchListModel<>));
        CreateMap(typeof(PagedResponse<>), typeof(PagedResponse<>));
        CreateMap<Sort, SortModel>();
        CreateMap<Pagination, PaginationModel>();
        CreateMap(typeof(SearchQuery<,>), typeof(SearchQueryModel<>));
        CreateMap(typeof(PagedResponse<>), typeof(SearchListModel<>));


        CreateMap<Domain.Entities.Document, CreateDocumentCommand>().ReverseMap();
        CreateMap<Domain.Entities.Document, DocumentDTO>().ReverseMap();
        CreateMap<DocumentListDTO, DocumentDTO>().ReverseMap();
        CreateMap<Domain.Entities.Document, DocumentListDTO>().ReverseMap();
        CreateMap<LabelIntValueResponse, DocumentDTO>().ReverseMap();
    }
}