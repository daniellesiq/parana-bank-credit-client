using Domain.Interfaces;
using Domain.UseCases.GetClientsUseCases.Boundaries;

namespace Domain.UseCases.GetClientsUseCases
{
    public class GetClientsUseCases : IGetClientsUseCases
    {
        public async Task<string> Handle(GetClientsInput request, CancellationToken cancellationToken)
        {
            return "";
        }
    }
}
