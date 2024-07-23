using AutoMapper;
using BlazorECommerceWeb_Application.DTOs;
using BlazorECommerceWeb_Domain.Repositories;
using MediatR;

namespace BlazorECommerceWeb_Application.Modules.ProductsPrices.Queries;

public static class GetProductPriceById
{
    public class Request : IRequest<Response>
    {
        public int ProductPriceId { get; set; }

        public Request(int productPriceId)
        {
            ProductPriceId = productPriceId;
        }
    }

    public class Response
    {
        public ProductPriceDto Product { get; set; } = new();
    }

    public class Query : IRequestHandler<Request, Response>
    {
        private readonly IMapper mapper;
        private readonly IProductPriceRepository _productPriceRepository;

        public Query(IMapper mapper,
            IProductPriceRepository productPriceRepository)
        {
            this.mapper = mapper;
            this._productPriceRepository = productPriceRepository;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var products = await this._productPriceRepository.Get(request.ProductPriceId);

            return new Response()
            {
                Product = mapper.Map<ProductPriceDto>(products)
            };
        }
    }
}
