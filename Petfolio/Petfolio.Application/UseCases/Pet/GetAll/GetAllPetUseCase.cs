﻿using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pet.GetAll;
public class GetAllPetUseCase
{
    public ResponseAllPetJson Execute()
    {
        return new ResponseAllPetJson
        {
            //Pets = new List<ResponseShortPetJson>
            //{
            //       new ResponseShortPetJson
            //       {
            //           Id = 1,
            //           Name = "Buddy",
            //           Type = Communication.Enums.PetType.Dog
            //       }
            //}
        };
    }
}
