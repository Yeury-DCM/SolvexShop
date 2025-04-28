using MediatR;
using SolvexShop.Core.Application.Dtos.ProductVariation;
using SolvexShop.Core.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvexShop.Core.Application.Features.ProductVariations.Queries.GetById
{
    public class GetProductVariationByIdQuery : IRequest<Response<ProductVariationDto>>
    {
        public Guid Id { get; set; }
    }
}
