using AutoMapper;
using BlazorECommerceWeb_Application.DTOs;
using BlazorECommerceWeb_Domain.Repositories;
using MediatR;

namespace BlazorECommerceWeb_Application.Modules.Categories.Queries;
public static class GetCategoryById
{
    public class Request : IRequest<Response>
    {
        public int CategoryId { get; set; }

        public Request(int categoryId)
        {
            CategoryId = categoryId;
        }
    }


    public class Response
    {
        public CategoryDto Category { get; set; } = new();
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
            
            var categories = await this.categoryRepository.Get(request.CategoryId);

            return new Response()
            {
                Category = mapper.Map<CategoryDto>(categories)
            };
        }
    }


}
