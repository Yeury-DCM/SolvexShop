

using AutoMapper;
using MediatR;
using SolvexShop.Core.Application.Dtos.Product;
using SolvexShop.Core.Application.Dtos.ProductVariation;
using SolvexShop.Core.Application.Features.Products.Queries.GetById;
using SolvexShop.Core.Application.Features.ProductVariations.Queries.GetById;
using SolvexShop.Core.Application.Interfaces.Repositories;
using SolvexShop.Core.Application.Response;

namespace SolvexShop.Core.Application.Features.Products.Queries.GetAll
{
    public class GetProductVariationByIdQueryHandler(IProductVariationRepository productRepository, IMapper mapper) : IRequestHandler<GetProductVariationByIdQuery, Response<ProductVariationDto>>
    {
        IProductVariationRepository _productVariationRepository = productRepository;
        IMapper _mapper = mapper;

        public async Task<Response<ProductVariationDto>> Handle(GetProductVariationByIdQuery request, CancellationToken cancellationToken)
        {
            Response<ProductVariationDto> response = new();

            try
            {
                var result =  await _productVariationRepository.GetByIdAsync(request.Id);

                if (result.IsSuccess == false)
                {
                    response.IsSuccess = false;
                    response.Message = "No se pudo obtener la lista de productos.";
                    return response;
                }

                var productVariation = result.Data;
              

                if (productVariation == null)
                {
                    response.IsSuccess = false;
                    response.Message = "No se encontró la variación del producto.";
                    return response;
                }

                response.Data = _mapper.Map<ProductVariationDto>(productVariation);
              
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Ocurrió un error obteniendo los productos";
                return response;

            }

            return response;
        }
    }
}
