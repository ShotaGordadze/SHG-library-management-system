using MediatR;
using SHG.Application.Dtos;
using SHG.Infrastructure;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Commands.CategoryCommands;

public record UpdateCategoryNameCommand(int Id, string Name) : IRequest<CategoryDto>;

public class UpdateCategoryNameCommandHandler : IRequestHandler<UpdateCategoryNameCommand, CategoryDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryNameCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
    {
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryDto> Handle(UpdateCategoryNameCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.Find(request.Id);

        if (category == null)
        {
            throw new ArgumentException(nameof(category));
        }

        category.Name = request.Name;

        await _unitOfWork.SaveAsync(cancellationToken);

        return new CategoryDto
        {
            Name = request.Name,
            Description = category.Description
        };
    }
}
