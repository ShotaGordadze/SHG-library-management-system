﻿using MediatR;
using SHG.Application.Dtos;
using SHG.Infrastructure;
using SHG.Infrastructure.Repositories;

namespace SHG.Application.Commands.CategoryCommands;

public record DeleteCategoryCommand(int CategoryId) : IRequest<int>;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
    {
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
    }

    public async Task<int> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.Find(request.CategoryId);

        if (category == null)
        {
            return -1;
        }

        _categoryRepository.Delete(category);

        await _unitOfWork.SaveAsync(cancellationToken);

        return 0;
    }
}


