using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PizzaApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class ApiControllerBase : ControllerBase
{
}
