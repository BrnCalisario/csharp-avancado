using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("cpf")]
public class CpfController : ControllerBase
{
    [HttpGet]
    public ActionResult<Cpf> Get(string cpf)
    {
        Cpf result = new Cpf();
        try
        {
            result.Value = cpf;
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok(result);
    }

    [HttpGet("generate/{region}")]
    public ActionResult<Cpf> Generate([FromServices]CpfService cpf, int region)
    {
        var result = cpf.Generate(region);
        return result;
    }
}