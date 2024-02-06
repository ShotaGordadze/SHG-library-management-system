using MediatR;

namespace SHG.Application.Commands.StudentCommands;

public record IssueBookCommand(int BookID, DateTime Start, DateTime End) : IRequest<bool>;

public class IssueBookCommandHandler : IRequestHandler<IssueBookCommand, bool>
{
    public Task<bool> Handle(IssueBookCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
