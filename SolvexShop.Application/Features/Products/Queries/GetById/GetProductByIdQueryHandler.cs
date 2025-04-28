

using AutoMapper;
using MediatR;
using SolvexShop.Core.Application.Dtos.Product;
using SolvexShop.Core.Application.Interfaces.Repositories;
using SolvexShop.Core.Application.Response;

namespace SolvexShop.Core.Application.Features.Products.Queries.GetById
{
    public class GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<GetProductByIdQuery, Response<ProductDto>>
    {
        IProductRepository _productRepository = productRepository;
        IMapper _mapper = mapper;

        public async Task<Response<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Response<ProductDto> response = new();

            try
            {
                var result =  await _productRepository.GetByIdAsync(request.Id);

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

                response.Data = _mapper.Map<ProductDto>(productVariation);
              
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
