
using AutoMapper;
using MediatR;
using SolvexShop.Core.Application.Dtos.ProductVariation;
using SolvexShop.Core.Application.Features.ProductVariations.Commands.CreateProductVariations;
using SolvexShop.Core.Application.Interfaces.Repositories;
using SolvexShop.Core.Application.Response;
using SolvexShop.Core.Domain.Entities;

namespace SolvexShop.Core.Application.Features.ProductVariations.Commands.CreateProductVariation
{
    public class CreateProductVarirationCommanHandler(IMapper mapper, IProductVariationRepository productVariationRepository) : IRequestHandler<CreateProductVariationCommand, Response<ProductVariationDto>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IProductVariationRepository _productVariationRepository = productVariationRepository;
        public async Task<Response<ProductVariationDto>> Handle(CreateProductVariationCommand request, CancellationToken cancellationToken)
        {
            Response<ProductVariationDto> response = new() { IsSuccess = true };

            try
            {
                var productVariation = _mapper.Map<ProductVariation>(request);
                var result = await _productVariationRepository.AddAsync(productVariation);

                if (!result.IsSuccess)
                {
                    response.IsSuccess = false;
                    response.Message = "No se pudo añadir la variación del producto.";
                    return response;
                }

                response.Data = _mapper.Map<ProductVariationDto>(result.Data);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return response;
            }

            return response;
        }
    }
   
}
