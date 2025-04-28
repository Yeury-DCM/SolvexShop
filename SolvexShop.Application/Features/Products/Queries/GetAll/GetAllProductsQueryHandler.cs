

using AutoMapper;
using MediatR;
using SolvexShop.Core.Application.Dtos.Product;
using SolvexShop.Core.Application.Interfaces.Repositories;
using SolvexShop.Core.Application.Response;

namespace SolvexShop.Core.Application.Features.Products.Queries.GetAll
{
    public class GetAllProductsCommandHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<GetAllPRoductsQuery, Response<List<ProductDto>>>
    {
        IProductRepository _productRepository = productRepository;
        IMapper _mapper = mapper;

        public async Task<Response<List<ProductDto>>> Handle(GetAllPRoductsQuery request, CancellationToken cancellationToken)
        {
            Response<List<ProductDto>> response = new();

            try
            {
                var result =  await _productRepository.GetAllAsync();

                if(result.IsSuccess == false)
                {
                    response.IsSuccess = false;
                    response.Message = "No se pudo obtener la lista de productos.";
                    return response;
                }

                var products = result.Data.ToList();
              

                if (products == null || products.Count() == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "No se encontraron productos.";
                    return response;
                }

                response.Data = _mapper.Map<List<ProductDto>>(products);
              
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
