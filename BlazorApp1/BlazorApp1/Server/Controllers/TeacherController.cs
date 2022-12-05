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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacher _ITeacher;


        public TeacherController(ITeacher iTeacher)
        {
            _ITeacher = iTeacher;
        }
        [HttpGet]
 
        public Task<List<Shared.Models.Teacher>> Get()
        {
            return Task.FromResult(_ITeacher.GetClientDetails());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Shared.Models.Teacher Teacher = _ITeacher.GetClientData(id);
            if (Teacher != null)
            {
                return Ok(Teacher);
            }

            return NotFound();
        }

        [HttpPost]
        public void Post(Shared.Models.Teacher Teacher)
        {
            _ITeacher.AddClient(Teacher);   // ЗАГРУЗКУ ФАЙЛОВ НУЖНО ПИСАТЬ ТУТ!
        }

        [HttpPut]
        public void Put(Shared.Models.Teacher Teacher)
        {
            _ITeacher.UpdateClientDetails(Teacher);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ITeacher.DeleteClient(id);
            return Ok();
        }

    }
