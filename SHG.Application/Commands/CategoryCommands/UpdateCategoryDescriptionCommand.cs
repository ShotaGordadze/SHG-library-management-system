using MediatR;
using SHG.Application.Dtos;
using SHG.Infrastructure;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Commands.CategoryCommands;

public record UpdateCategoryDescriptionCommand(int Id, string Description) : IRequest<CategoryDto>;

public class UpdateCategoryDescriptionCommandHandler : IRequestHandler<UpdateCategoryDescriptionCommand, CategoryDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryDescriptionCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
    {
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryDto> Handle(UpdateCategoryDescriptionCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.Find(request.Id);

        if (category == null)
        {
            throw new ArgumentException(nameof(category));
        }

        category.Description = request.Description;

        await _unitOfWork.SaveAsync(cancellationToken);

        return new CategoryDto
        {
            Name = category.Name,
            Description = request.Description
        };
    }
}
