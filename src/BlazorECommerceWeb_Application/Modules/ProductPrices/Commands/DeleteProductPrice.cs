using AutoMapper;
using BlazorECommerceWeb_Domain.Repositories;
using MediatR;

namespace BlazorECommerceWeb_Application.Modules.ProductsPrices.Commands;

public static class DeleteProductPrice
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
        private readonly IProductPriceRepository _productPriceRepository;

        public Command(
            IMapper mapper,
            IProductPriceRepository productPriceRepository)
        {
            this._mapper = mapper;
            this._productPriceRepository = productPriceRepository;
        }

        public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
        {
            await _productPriceRepository.DeleteById(request.ProductId);

            return Unit.Value;
        }
    }
}
