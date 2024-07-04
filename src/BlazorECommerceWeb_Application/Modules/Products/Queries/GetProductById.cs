using AutoMapper;
using BlazorECommerceWeb_Application.DTOs;
using BlazorECommerceWeb_Domain.Repositories;
using MediatR;

namespace BlazorECommerceWeb_Application.Modules.Products.Queries;
public static class GetProductById
{
    public class Request : IRequest<Response>
    {
        public int ProductId { get; set; }

        public Request(int productId)
        {
            ProductId = productId;
        }
    }


    public class Response
    {
        public ProductDto Product { get; set; } = new();
    }

    public class Query : IRequestHandler<Request, Response>
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public Query(IMapper mapper,
            IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            
            var products = await this.productRepository.Get(request.ProductId);

            return new Response()
            {
                Product = mapper.Map<ProductDto>(products)
            };
        }
    }


}
