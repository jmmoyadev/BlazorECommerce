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
public static class DeleteCategory
{
    public class Request : IRequest<Unit>
    {
        public int CategoryId { get; set; }

        public Request(int categoryId)
        {
            CategoryId = categoryId;
        }
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
            await categoryRepository.DeleteById(request.CategoryId);

            return Unit.Value;

        }
    }
}
