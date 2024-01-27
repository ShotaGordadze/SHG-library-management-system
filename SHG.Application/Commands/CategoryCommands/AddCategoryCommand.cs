using MediatR;
using Microsoft.EntityFrameworkCore;
using SHG.Application.Dtos;
using SHG.Infrastructure;
using SHG.Infrastructure.Database.Entities;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Commands.CategoryCommands
{
    public record AddCategoryCommand(string name, string? description) : IRequest<CategoryDto>;

    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, CategoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public AddCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.name,
                Description = request.description
            };

            await _categoryRepository.Store(category);

            await _unitOfWork.SaveAsync(cancellationToken);

            category = await _categoryRepository.Query(x => x.Id == category.Id)
                                                .FirstAsync(cancellationToken);

            return new CategoryDto
            {
                Name = category.Name,
                Description = category.Description
            };
        }
    }
}
