using DCI_HR_API.Contexts;
using DCI_HR_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace DCI_HR_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DCIWebController : Controller
    {
        private readonly DBDCI dBDCI = new DBDCI();
        private readonly DBSCM dBSCM = new DBSCM();
        private readonly DBHRM dBHRM = new DBHRM();
        public DCIWebController(DBDCI dBDCI)
        {
            this.dBDCI = dBDCI;
        }

        [HttpGet]
        [Route("/insertlog/{ip}")]
        public IActionResult InsertLog(string ip)
        {
            if (ip != null && ip != "")
            {
                int counter = 0;
                var content = dBDCI.DciwebCounterVisitorLogs.FirstOrDefault(x => x.Ip == ip);
                if (content == null)
                {

                    DciwebCounterVisitorLog newLog = new DciwebCounterVisitorLog();
                    newLog.Ip = ip;
                    newLog.DtStamp = DateTime.Now;
                    dBDCI.DciwebCounterVisitorLogs.Add(newLog);
                    int insert = dBDCI.SaveChanges();
                    if (insert > 0)
                    {
                        counter = dBDCI.DciwebCounterVisitorLogs.Count();
                    }
                    return Ok(new
                    {
                        status = insert,
                        count = counter
                    });
                }
                else
                {
                    counter = dBDCI.DciwebCounterVisitorLogs.Count();
                    return Ok(new
                    {
                        status = false,
                        count = counter
                    });
                }
            }
            else
            {
                return Ok(new
                {
                    status = false
                });
            }
        }

        [HttpGet]
        [Route("/counter/ip")]
        public IActionResult GetCounterIP()
        {
            int counterIP = dBDCI.DciwebCounterVisitorLogs.Count();
            return Ok(new
            {
                coutner = counterIP
            });
        }

        //[HttpPost]
        //[Route("/privilege")]
        //public IActionResult privilegeByEmpCode([FromBody] DciPrivilege param)
        [HttpGet]
        [Route("/privilege/{module}/{component}")]
        public IActionResult privilegeByEmpCode(string module,string component)
        {
            List<DciPrivilege> res = dBSCM.DciPrivileges.Where(x => x.PrivModule == module && x.PrivComponent == component).ToList();
            return Ok(res);
        }
    }
}
