using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class ApiController : ControllerBase
{
   

}
