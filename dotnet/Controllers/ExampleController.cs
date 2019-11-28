using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        [HttpGet]
        public string[] Get()
        {
            var stageEnviroment = System.Environment.GetEnvironmentVariable("ENV_STAGE");
            return new string[] { string.Concat("Hi! ", stageEnviroment, " is your stage! : )") };
        }
    }
}