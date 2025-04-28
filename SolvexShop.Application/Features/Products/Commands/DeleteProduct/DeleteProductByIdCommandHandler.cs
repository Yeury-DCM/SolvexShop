

using AutoMapper;
using MediatR;
using SolvexShop.Core.Application.Dtos.Product;
using SolvexShop.Core.Application.Interfaces.Repositories;
using SolvexShop.Core.Application.Response;

namespace SolvexShop.Core.Application.Features.Products.Queries.GetById
{
    public class DeleteProductByIdCommandHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<DeleteProductByIdCommand, Response<ProductDto>>
    {
        IProductRepository _productRepository = productRepository;
        IMapper _mapper = mapper;

        public async Task<Response<ProductDto>> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            Response<ProductDto> response = new();

            try
            {
                var getResult = await _productRepository.GetByIdAsync(request.Id);

                if (getResult.IsSuccess == false || getResult.Data == null)
                {
                    response.IsSuccess = false;
                    response.Message = "No se pudo encontrar el producto.";
                    return response;
                }

                var deleteResult = await _productRepository.DeleteAsync(getResult.Data);

                if (deleteResult.IsSuccess == false )
                {
                    response.IsSuccess = false;
                    response.Message = "No se pudo eliminar el producto.";
                    return response;
                }

               
              
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Ocurrió un error eliminando el producto";
                return response;

            }

            return response;
        }
    }
}
