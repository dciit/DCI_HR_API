using DCI_HR_API.Contexts;
using DCI_HR_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DCI_HR_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HrController : Controller
    {
        private readonly DBHRM dbHRM = new DBHRM();

        public HrController(DBHRM dBHRM)
        {
            this.dbHRM = dBHRM;
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Login([FromBody] MLogin param)
        {
            Employee login = dbHRM.Employees.FirstOrDefault(x => x.Code == param.username)!;
            if (login != null)
            {
                return Ok(new
                {
                    name = $"{login.Pren.ToUpper()}{login.Name}.{login.Surn!.Substring(0, 1)}",
                    empcode = login.Code,
                    status = true,
                });
            }
            return Ok(new
            {
                name = "",
                empcode = "",
                status = false
            });
        }

        [HttpGet]
        [Route("/test")]
        public IActionResult Test()
        {
          
            return Ok(new
            {
                name = "",
                status = false
            });
        }
    }
}
