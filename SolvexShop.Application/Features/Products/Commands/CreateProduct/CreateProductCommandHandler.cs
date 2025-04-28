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

namespace SolvexShop.Core.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<CreateProductCommand, Response<ProductDto>>
    {
        IProductRepository _productRepository = productRepository;
        IMapper _mapper = mapper;

        public async Task<Response<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Response<ProductDto> response = new() { IsSuccess = true};

            try
            {
                var product = _mapper.Map<Product> (request);
                var result = await _productRepository.AddAsync(product);

                if(!result.IsSuccess)
                {
                    response.IsSuccess = false;
                    response.Message = "No se pudo añadir el producto.";
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
