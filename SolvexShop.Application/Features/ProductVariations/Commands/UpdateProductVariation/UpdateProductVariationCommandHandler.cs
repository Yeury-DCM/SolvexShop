using AutoMapper;
using MediatR;
using SolvexShop.Core.Application.Dtos.Product;
using SolvexShop.Core.Domain.Entities;
using SolvexShop.Core.Application.Interfaces.Repositories;
using SolvexShop.Core.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolvexShop.Core.Application.Dtos.ProductVariation;

namespace SolvexShop.Core.Application.Features.Products.Commands.CreateProduct
{
    public class UpdateProductVariationCommandHandler(IProductVariationRepository productVariationRepository, IMapper mapper) : IRequestHandler<UpdateProductVariationCommand, Response<ProductVariationDto>>
    {
        IProductVariationRepository _productRepository = productVariationRepository;
        IMapper _mapper = mapper;

        public async Task<Response<ProductVariationDto>> Handle(UpdateProductVariationCommand request, CancellationToken cancellationToken)
        {
            Response<ProductVariationDto> response = new() { IsSuccess = true};

            try
            {
                var product = _mapper.Map<ProductVariation> (request);
                var result = await _productRepository.UpdateAsync(product);

                if(!result.IsSuccess)
                {
                    response.IsSuccess = false;
                    response.Message = "No se pudo actualizar la variación del producto.";
                    return response;
                }

            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return response;
            }

            return response;    
        }
    }
}
