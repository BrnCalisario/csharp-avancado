using Microsoft.AspNetCore.Mvc;
 
namespace ProjetoWeb.Controllers;
 
[ApiController]
[Route("cpf")]
public class CpfController : ControllerBase
{
    [HttpGet("{cpf}")]
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
 
        return result;
    }

    [HttpGet("generate/{region}")]
    public ActionResult<Cpf> Generate(
        [FromServices]CpfService cpf, int region)
    {
        var result = cpf.Generate(region);
        return result;
    }
}
