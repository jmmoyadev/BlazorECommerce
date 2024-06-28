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

namespace BlazorECommerceWeb_Application.Modules.Categories.Queries;
public static class GetCategoriesList
{
    public class Request : IRequest<Response>
    {
    }


    public class Response
    {
        public IEnumerable<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }

    public class Query : IRequestHandler<Request, Response>
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;

        public Query(IMapper mapper,
            ICategoryRepository categoryRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            
            var categories = await this.categoryRepository.GetAll();

            return new Response()
            {
                Categories = mapper.Map<IEnumerable<CategoryDto>>(categories)
            };
        }
    }


}
