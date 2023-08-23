using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace Teste.Controllers;

using Model;

[ApiController]
[Route("message")]
public class MessageController : ControllerBase
{
    [HttpGet]
    [EnableCors("MainPolicy")]
    public async Task<ActionResult<IEnumerable<Message>>> GetAll(
        [FromServices]IRepository<Message> repo
    )
    {
        var result = await repo.Filter(x => true);

        if(result is null)
            return NotFound("Banco vazio");
            
        return result;
    }
}