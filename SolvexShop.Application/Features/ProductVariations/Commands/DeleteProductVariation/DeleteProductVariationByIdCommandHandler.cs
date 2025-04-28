

using AutoMapper;
using MediatR;
using SolvexShop.Core.Application.Dtos.Product;
using SolvexShop.Core.Application.Dtos.ProductVariation;
using SolvexShop.Core.Application.Interfaces.Repositories;
using SolvexShop.Core.Application.Response;

namespace SolvexShop.Core.Application.Features.Products.Queries.GetById
{
    public class DeleteProductVariationByIdCommandHandler(IProductVariationRepository productVariationRepository, IMapper mapper) : IRequestHandler<DeleteProductVariationByIdCommand, Response<ProductVariationDto>>
    {
        IProductVariationRepository _productVariationRepository = productVariationRepository;
        IMapper _mapper = mapper;

        public async Task<Response<ProductVariationDto>> Handle(DeleteProductVariationByIdCommand request, CancellationToken cancellationToken)
        {
            Response<ProductVariationDto> response = new();

            try
            {
                var getResult = await _productVariationRepository.GetByIdAsync(request.Id);

                if (getResult.IsSuccess == false || getResult.Data == null)
                {
                    response.IsSuccess = false;
                    response.Message = "No se pudo encontrar la variación producto.";
                    return response;
                }

                var deleteResult = await _productVariationRepository.DeleteAsync(getResult.Data);

                if (deleteResult.IsSuccess == false )
                {
                    response.IsSuccess = false;
                    response.Message = "No se pudo eliminar la variación del producto.";
                    return response;
                }

               
              
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Ocurrió un error eliminando la variación del producto";
                return response;

            }

            return response;
        }
    }
}
