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

        //[HttpPost]
        //[Route("/login")]
        //public IActionResult Login([FromBody] MLogin param)
        [HttpGet]
        [Route("/login/{username}")]
        public IActionResult Login(string username)
        {
            //Employee login = dbHRM.Employees.FirstOrDefault(x => x.Code == param.username)!;
            Employee login = dbHRM.Employees.FirstOrDefault(x => x.Code == username)!;
            if (login != null)
            {
                return Ok(new
                {
                    pren = login.Pren.ToUpper(),
                    name = $"{login.Name}.{login.Surn!.Substring(0, 1)}",
                    fullName = $"{login.Pren.ToUpper()}{login.Name}.{login.Surn!}",
                    empcode = login.Code,
                    dvcd = login.Dvcd,
                    status = true,
                });
            }
            return Ok(new
            {
                pren = "",
                name = "",
                fullName = "",
                empcode = "",
                dvcd = "'",
                status = false
            });
        }

        [HttpPost]
        [Route("/dciwebcountervisitorapi")]
        public IActionResult DCICounterVisitor([FromBody] MDciwebCounterVisitor param)
        {
            string ip = param.ip;
            return Ok();
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
