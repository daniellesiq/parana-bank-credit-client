using Domain.UseCases.InsertClientsUseCases.Boundaries;
using MediatR;

namespace Domain.Interfaces
{
    public interface IInsertClientsUseCase : IRequestHandler<InsertClientInput, string> { }
}
