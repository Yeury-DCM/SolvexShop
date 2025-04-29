using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolvexShop.Core.Application.Dtos.ProductVariation;
using SolvexShop.Core.Application.Features.Products.Commands.CreateProduct;
using SolvexShop.Core.Application.Features.Products.Queries.GetAll;
using SolvexShop.Core.Application.Features.Products.Queries.GetById;
using SolvexShop.Core.Application.Features.ProductVariations.Commands.CreateProductVariations;
using SolvexShop.Core.Application.Features.ProductVariations.Queries.GetById;
using SolvexShop.Core.Application.ViewModels.Products;
using SolvexShop.Core.Application.ViewModels.ProductVariations;


namespace SolvexShop.Presentation.WebApp.Controllers
{
    public class ProductController(IMediator mediator, IMapper mapper) : Controller
    {
        private IMapper _mapper = mapper;
        private IMediator _mediator = mediator;
        public async Task<IActionResult> Index(int page = 1)
        {
            var products = await _mediator.Send(new GetAllPRoductsQuery());
            var productViewModels = _mapper.Map<List<ProductViewModel>>(products.Data);
            ViewBag.CurrentPage = page;

            var sampleProducts = productViewModels;
            return View(sampleProducts);
        }


        public async Task<IActionResult> Add()
        {
            var defaultViewModel = new SaveProductViewModel() { Id = Guid.Empty };
            return View("SaveProduct", defaultViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SaveProductViewModel saveProductViewModel)
        {
           
            if(!ModelState.IsValid)
            {
                return View("SaveProduct", saveProductViewModel);
            }

            var createProductCommand = _mapper.Map<CreateProductCommand>(saveProductViewModel);
            var response = await mediator.Send(createProductCommand);


            if (!response.IsSuccess)
            {
                ViewBag.ErrorMessage = response.Message;
                ViewBag.HasError = true;
                return View("SaveProduct", saveProductViewModel);

            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string Id)
        {
            var response = (await _mediator.Send(new GetProductByIdQuery() { Id = Guid.Parse(Id) }));

            if(!response.IsSuccess)
            {
                return RedirectToAction("Index");
            }

            var saveProductViewModel = _mapper.Map<SaveProductViewModel>(response.Data);
            return View("SaveProduct", saveProductViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveProductViewModel saveProductViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View("SaveProduct", saveProductViewModel);
            }

            var updateProductCommand = _mapper.Map<UpdateProductCommand>(saveProductViewModel);
            var response = await mediator.Send(updateProductCommand);


            if (!response.IsSuccess)
            {
                ViewBag.ErrorMessage = response.Message;
                ViewBag.HasError = true;
                return View("SaveProduct", saveProductViewModel);

            }

            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Delete(string Id)
        {
            var response = (await _mediator.Send(new DeleteProductByIdCommand(){ Id = Guid.Parse(Id) }));

            if (!response.IsSuccess)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

       

        public async Task<IActionResult> AddProductVariation(string productId)
        {
            var defaultViewModel = new SaveProductVariationViewModel() { ProductId = Guid.Parse(productId) };

            var product = (await _mediator.Send(new GetProductByIdQuery() { Id = Guid.Parse(productId) })).Data;

            ViewBag.ProductName = product.Name;


            return View("SaveProductVariation", defaultViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductVariation(SaveProductVariationViewModel saveProductVariationViewModel)
        {
            var product = (await _mediator.Send(new GetProductByIdQuery() { Id = saveProductVariationViewModel.ProductId})).Data;

            ViewBag.ProductName = product.Name;

            if (!ModelState.IsValid)
            {
                return View("SaveProductVariation", saveProductVariationViewModel);
            }

            var createProductCommand = _mapper.Map<CreateProductVariationCommand>(saveProductVariationViewModel);
            var response = await mediator.Send(createProductCommand);


            if (!response.IsSuccess)
            {
                ViewBag.ErrorMessage = response.Message;
                ViewBag.HasError = true;
                return View("SaveProduct", saveProductVariationViewModel);

            }
            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditProductVariation(string Id)
        {
            var response = (await _mediator.Send(new GetProductVariationByIdQuery() { Id = Guid.Parse(Id) }));

            if (!response.IsSuccess)
            {
                return RedirectToAction("Index");
            }

            var saveProductVariationViewModel = _mapper.Map<SaveProductVariationViewModel>(response.Data);
            return View("SaveProductVariation", saveProductVariationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditProductVariation(SaveProductVariationViewModel saveProductVariationViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View("SaveProductVariation", saveProductVariationViewModel);
            }

            var updateProductVariationCommand = _mapper.Map<UpdateProductVariationCommand>(saveProductVariationViewModel);
            var response = await mediator.Send(updateProductVariationCommand);


            if (!response.IsSuccess)
            {
                ViewBag.ErrorMessage = response.Message;
                ViewBag.HasError = true;
                return View("SaveProductVariation", saveProductVariationViewModel);

            }

            return RedirectToAction("Index");
        }



        public async Task<IActionResult> DeleteProductVariation(string Id)
        {
            var response = (await _mediator.Send(new DeleteProductVariationByIdCommand() { Id = Guid.Parse(Id) }));

            if (!response.IsSuccess)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
