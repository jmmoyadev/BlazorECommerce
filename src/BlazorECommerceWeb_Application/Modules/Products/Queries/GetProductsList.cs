using AutoMapper;
using BlazorECommerceWeb_Application.DTOs;
using BlazorECommerceWeb_Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerceWeb_Application.Modules.Products.Queries;
public static class GetProductsList
{
    public class Request : IRequest<Response>
    {
    }


    public class Response
    {
        public IEnumerable<ProductDto> Products { get; set; } = Enumerable.Empty<ProductDto>();
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
            
            var categories = await this.productRepository.GetAll();

            return new Response()
            {
                Products = mapper.Map<IEnumerable<ProductDto>>(categories)
            };
        }
    }


}
