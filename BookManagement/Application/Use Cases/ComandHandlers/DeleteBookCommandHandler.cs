using Application.Use_Cases.Commands;
using Domain.Repositories;
using MediatR;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
{
    private readonly IBookRepository repository;

    public DeleteBookCommandHandler(IBookRepository repository)
    {
        repository = repository;
    }

    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}
