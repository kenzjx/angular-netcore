using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Migrations;
using Server.Data.Models;
using Server.Infrastruture;
using Server.Models.Cats;

namespace Server.Controllers;

public class CatsController : ApiController
{
    private readonly AppDbContext context;

    public CatsController(AppDbContext context)
    {
        this.context = context;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> Create(CreateCatRequestModel model)
    {
        var userId = this.User.GetId();

        var cat = new Cat
        {
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            UserId = userId
        };

        context.Add(cat);
        await context.SaveChangesAsync();
        return Created(nameof(this.Create), cat.Id);
    }

}
