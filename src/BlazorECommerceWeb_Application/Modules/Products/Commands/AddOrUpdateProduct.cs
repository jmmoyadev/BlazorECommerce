using AutoMapper;
using BlazorECommerceWeb_Application.DTOs;
using BlazorECommerceWeb_Application.Modules.Common;
using BlazorECommerceWeb_Domain.Entities;
using BlazorECommerceWeb_Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerceWeb_Application.Modules.Products.Commands;
public static class AddOrUpdateProduct
{
    public class Request : IRequest<Response>
    {
        public ProductDto Product { get; set; }
    }

    public class Response : ResponseBase<ProductDto>
    {

    }

    public class Command : IRequestHandler<Request, Response>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public Command(
            IMapper mapper,
            IProductRepository productRepository)
        {
            this._mapper = mapper;
            this._productRepository = productRepository;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.Product);
            string? responseMessage;
            if (product.Id == 0)
            {
                await _productRepository.Add(product);
                responseMessage = "Product created successfully";
            }
            else
            {
                await _productRepository.Update(product);
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
