using KafeinStudyCase.Core.Base.Dtos;
using KafeinStudyCase.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeinStudyCase.Application.Handlers.ShippingCompanies.DTOs;

public class DocumentDTO : IResponse
{
    public string? Name { get; set; }
    public byte[]? File { get; set; }
}
