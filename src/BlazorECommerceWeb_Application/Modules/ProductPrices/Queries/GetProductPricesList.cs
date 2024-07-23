using AutoMapper;
using BlazorECommerceWeb_Application.DTOs;
using BlazorECommerceWeb_Domain.Repositories;
using MediatR;

namespace BlazorECommerceWeb_Application.Modules.ProductsPrices.Queries;

public static class GetProductPricesList
{
    public class Request : IRequest<Response>
    {
    }

    public class Response
    {
        public IEnumerable<ProductPriceDto> ProductsPrices { get; set; } = Enumerable.Empty<ProductPriceDto>();
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
            var categories = await this._productPriceRepository.GetAll();

            return new Response()
            {
                ProductsPrices = mapper.Map<IEnumerable<ProductPriceDto>>(categories)
            };
        }
    }
}
