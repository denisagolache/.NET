using MediatR;

namespace Application.Use_Cases.Commands
{
    public class DeleteBookCommand : IRequest <Unit>
    {
        public Guid Id { get; set; }
    }


}
