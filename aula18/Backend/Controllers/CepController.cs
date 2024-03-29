using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("cep")]
public class CepController : ControllerBase
{
    [HttpGet("{cep}")]
    public async Task<ActionResult<CepData>> Get(
        [FromServices]ICepService service, string cep
    )
    {
        var result = await service.Get(cep);

        if(result is null)
            return NotFound();

        return result;
    }
}