using Application.Use_Cases.Commands;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.ComandHandlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IBookRepository repository;

        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            repository = bookRepository;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await repository.GetByIdAsync(request.Id);

            if (book == null)
            {
                throw new Exception("Book not found");
            }

            book.Title = request.Title;
            book.Author = request.Author;
            book.ISBN = request.ISBN;
            book.PublicationDate = request.PublicationDate;

            await repository.UpdateAsync(book);

            return Unit.Value;
        }
    }
}
