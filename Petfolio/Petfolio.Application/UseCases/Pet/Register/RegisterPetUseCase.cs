using Petfolio.Communication.Requests;
using Petfolio.Communication.Response;

namespace Petfolio.Application.UseCases.Pet.Register;
public class RegisterPetUseCase
{
    public ResponseRegisterPetJson Execute(RequestPetJson request)
    {
        return new ResponseRegisterPetJson
        {
            Id=7,
            Name = request.Name ?? string.Empty,
        };
    }
}
