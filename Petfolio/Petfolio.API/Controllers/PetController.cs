using Microsoft.AspNetCore.Mvc;
using Petfolio.Communication.Response;
namespace Petfolio.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterPetJson), StatusCodes.Status201Created)]
    public IActionResult Register([FromBody] RequestRegisterJson request)
    {
        return Created();
    }
}
