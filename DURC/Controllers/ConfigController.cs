using Microsoft.AspNetCore.Mvc;

namespace DURC.Controllers
{

    [ApiController]
    [Route("Controller")]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("")]
        public ActionResult DisplayConfig() 
        {
            // env variable he is ovveride the appsettings !!!!!!!

            var config = new
            {
                AllowedHosts = _configuration["AllowedHosts"],
                connectionString = _configuration.GetConnectionString("constr")
            };

            return Ok(config);
        }

    }
}
