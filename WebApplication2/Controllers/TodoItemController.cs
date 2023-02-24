using Microsoft.AspNetCore.Mvc;
using WebApplication1;

namespace WebApplication2.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoItemController : ControllerBase
{
    [HttpGet(Name = "Todo")]
    public TodoItem Get()
        => new()
        {
            Id = 1,
            Name = "Sample"
        };
}