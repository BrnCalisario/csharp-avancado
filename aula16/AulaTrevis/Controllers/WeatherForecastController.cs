using Microsoft.AspNetCore.Mvc;

namespace AulaTrevis.Controllers;

[ApiController]
[Route("teste")]
public class TestController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Server is running...";
    }
}
