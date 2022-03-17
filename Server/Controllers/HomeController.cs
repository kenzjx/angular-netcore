using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Server.Controllers;

public class HomeController : ControllerBase
{
    [Authorize]
    public ActionResult Get()
    {
        return Ok("Work");
    }

}
