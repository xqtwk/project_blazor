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
public class StudentController : ControllerBase
{
    private readonly IStudent _IStudent;


    public StudentController(IStudent iStudent)
    {
        _IStudent = iStudent;
    }
    [HttpGet]

    public Task<List<Shared.Models.Student>> Get()
    {
        return Task.FromResult(_IStudent.GetClientDetails());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        Shared.Models.Student Student = _IStudent.GetClientData(id);
        if (Student != null)
        {
            return Ok(Student);
        }

        return NotFound();
    }

    [HttpPost]
    public void Post(Shared.Models.Student Student)
    {
        _IStudent.AddClient(Student);   // ЗАГРУЗКУ ФАЙЛОВ НУЖНО ПИСАТЬ ТУТ!
    }

    [HttpPut]
    public void Put(Shared.Models.Student Student)
    {
        _IStudent.UpdateClientDetails(Student);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _IStudent.DeleteClient(id);
        return Ok();
    }

}