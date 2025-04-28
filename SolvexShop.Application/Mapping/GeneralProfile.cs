
using AutoMapper;
using SolvexShop.Core.Application.Dtos.Product;
using SolvexShop.Core.Application.Dtos.ProductVariation;
using SolvexShop.Core.Application.Features.Products.Commands.CreateProduct;
using SolvexShop.Core.Application.Features.ProductVariations.Commands.CreateProductVariations;
using SolvexShop.Core.Application.ViewModels.Products;
using SolvexShop.Core.Application.ViewModels.ProductVariations;
using SolvexShop.Core.Domain.Entities;
using System.Security;

namespace SolvexShop.Core.Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {

            #region CQRS

            #region Product  
            CreateMap<Product, Product>()
                .ReverseMap();

            CreateMap<CreateProductCommand, Product>()
                .ReverseMap();
            CreateMap<CreateProductCommand, SaveProductViewModel>()
               .ReverseMap();

            CreateMap<UpdateProductCommand, Product>()
               .ReverseMap();
            CreateMap<UpdateProductCommand, SaveProductViewModel>()
               .ReverseMap();
            #endregion

            #region ProductVariation       
            CreateMap<CreateProductVariationCommand, ProductVariation>()
                .ReverseMap();
            CreateMap<CreateProductVariationCommand, SaveProductVariationViewModel>()
               .ReverseMap();
            CreateMap<UpdateProductVariationCommand, ProductVariation>()
               .ReverseMap();
            CreateMap<UpdateProductVariationCommand, SaveProductVariationViewModel>()
               .ReverseMap();
            #endregion

            #endregion

            #region Dtos
            #region Products
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.ProductVariations, src => src.MapFrom(src => src.ProductVariations))
                .ReverseMap();      
                
            CreateMap<Product, SaveProductDto>()
             .ReverseMap();

            CreateMap<ProductDto, ProductViewModel>()
            .ReverseMap();

            CreateMap<ProductDto, SaveProductViewModel>()
            .ReverseMap();


            CreateMap<SaveProductDto, SaveProductDto>()
            .ReverseMap();
            #endregion

            #region ProductVariations
            CreateMap<ProductVariation, ProductVariationDto>()
           .ReverseMap();
            CreateMap<ProductVariation, SaveProductVariationDto>()
             .ReverseMap();

            CreateMap<ProductVariationDto, ProductVariationViewModel>()
            .ReverseMap();
            CreateMap<ProductVariationDto, SaveProductVariationViewModel>()
            .ReverseMap();
            #endregion
            #endregion
        }
    }
}
