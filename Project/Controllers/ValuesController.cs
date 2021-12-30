using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.ServiceProcess;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public string UserAgent { get; }

        //public void GetData()
        //{
        //    string userAgent;
        //    userAgent = Request.UserAgent;
        //    if(userAgent.IndexOf("MSIE 6.0") > -1)
        //    {
        //        var OS = ""+userAgent;
        //        return OS;
        //    }
        //}

    }
}
