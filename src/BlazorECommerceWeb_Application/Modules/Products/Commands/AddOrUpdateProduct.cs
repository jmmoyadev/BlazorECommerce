using AutoMapper;
using BlazorECommerceWeb_Application.DTOs;
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
    public class Request : IRequest<Unit>
    {
        public ProductDto Product { get; set; }
    }

    public class Response
    {

    }

    public class Command : IRequestHandler<Request, Unit>
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

        public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.Product);

            if (product.Id == 0)
                await _productRepository.Add(product);
            else
                await _productRepository.Update(product);

            return Unit.Value;

        }
    }
}
