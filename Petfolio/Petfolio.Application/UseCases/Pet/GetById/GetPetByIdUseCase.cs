using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pet.GetById;
public class GetPetByIdUseCase
{
    public ResponsePetJson Execute(int id)
    {
        return new ResponsePetJson
        {
            id = id,
            Name = "Buddy",
            Type = Communication.Enums.PetType.Dog,
            Birtday = new DateTime(year: 2024, month: 1, day: 01)
        };
    }

}
