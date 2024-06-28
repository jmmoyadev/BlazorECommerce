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

namespace BlazorECommerceWeb_Application.Modules.Categories.Commands;
public static class AddOrUpdateCategory
{
    public class Request : IRequest<Unit>
    {
        public CategoryDto Category { get; set; }
    }

    public class Response
    {

    }

    public class Command : IRequestHandler<Request, Unit>
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;

        public Command(
            IMapper mapper,
            ICategoryRepository categoryRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category>(request.Category);

            if (category.Id == 0)
                await categoryRepository.Create(category);
            else
                await categoryRepository.Update(category);

            return Unit.Value;

        }
    }
}
