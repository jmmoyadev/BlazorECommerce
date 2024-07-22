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
public static class DeleteProduct
{
    public class Request : IRequest<Unit>
    {
        public int ProductId { get; set; }

        public Request(int productId)
        {
            ProductId = productId;
        }
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
            await _productRepository.DeleteById(request.ProductId);

            return Unit.Value;

        }
    }
}
