using Domain.UseCases.GetClientsUseCases.Boundaries;
using MediatR;

namespace Domain.Interfaces
{
    public interface IGetClientsUseCases : IRequestHandler<GetClientsInput, string> { }
}
