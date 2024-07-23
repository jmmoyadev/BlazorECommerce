using AutoMapper;
using BlazorECommerceWeb_Application.DTOs;
using BlazorECommerceWeb_Application.Modules.Common;
using BlazorECommerceWeb_Domain.Entities;
using BlazorECommerceWeb_Domain.Repositories;
using MediatR;

namespace BlazorECommerceWeb_Application.Modules.ProductsPrices.Commands;

public static class AddOrUpdateProduct
{
    public class Request : IRequest<Response>
    {
        public ProductPriceDto ProductPrice { get; set; }
    }

    public class Response : ResponseBase<ProductDto>
    {
    }

    public class Command : IRequestHandler<Request, Response>
    {
        private readonly IMapper _mapper;
        private readonly IProductPriceRepository _productPriceRepository;

        public Command(
            IMapper mapper,
            IProductPriceRepository productPriceRepository)
        {
            this._mapper = mapper;
            this._productPriceRepository = productPriceRepository;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductPrice>(request.ProductPrice);
            string? responseMessage;
            if (product.Id == 0)
            {
                await _productPriceRepository.Add(product);
                responseMessage = "Product created successfully";
            }
            else
            {
                await _productPriceRepository.Update(product);
                responseMessage = "Product updated successfully";
            }

            var response = new Response()
            {
                Success = true,
                Message = responseMessage
            };

            return response;
        }
    }
}
