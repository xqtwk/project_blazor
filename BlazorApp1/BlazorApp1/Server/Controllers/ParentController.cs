namespace BlazorApp1.Server.Controllers;

using System;
using System.IO;
using BlazorApp1.Server.Interfaces;
using BlazorApp1.Server.Models;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ParentController : ControllerBase
{
    private readonly IParent _IParent;


    public ParentController(IParent iParent)
    {
        _IParent = iParent;
    }
    [HttpGet]

    public Task<List<Shared.Models.Parent>> Get()
    {
        return Task.FromResult(_IParent.GetClientDetails());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Shared.Models.Parent Parent = _IParent.GetClientData(id);
        if (Parent != null)
        {
            return Ok(Parent);
        }

        return NotFound();
    }

    [HttpPost]
    public void Post(Shared.Models.Parent Parent)
    {
        _IParent.AddClient(Parent);   // ЗАГРУЗКУ ФАЙЛОВ НУЖНО ПИСАТЬ ТУТ!
    }

    [HttpPut]
    public void Put(Shared.Models.Parent Parent)
    {
        _IParent.UpdateClientDetails(Parent);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _IParent.DeleteClient(id);
        return Ok();
    }

}