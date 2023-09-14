using KafeinStudyCase.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeinStudyCase.Application.Handlers.ShippingCompanies.DTOs;

public class DocumentListDTO
{
    public string Name { get; set; }
    public int Piece { get; set; }
    public double Price { get; set; }
    public StatusEnum? Status { get; set; }
}
