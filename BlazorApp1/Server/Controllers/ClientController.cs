﻿using System.IO;
using BlazorApp1.Server.Interfaces;
using BlazorApp1.Server.Models;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClient _IClient;
        DatabaseContext _context;

        public ClientController(IClient iClient)
        {
            _IClient = iClient;
        }
        public ClientController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        /*
         было
                 public async Task<List<Client>> Get()
        {
            return await Task.FromResult(_IClient.GetClientDetails());
        }
         */
        public Task<List<Shared.Models.Client>> Get()
        {
            return Task.FromResult(_IClient.GetClientDetails());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Shared.Models.Client client = _IClient.GetClientData(id);
            if (client != null)
            {
                return Ok(client);
            }

            return NotFound();
        }

        [HttpPost]
        public void Post(Shared.Models.Client client)
        {
            _IClient.AddClient(client);
        }

        [HttpPut]
        public void Put(Shared.Models.Client client)
        {
            _IClient.UpdateClientDetails(client);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IClient.DeleteClient(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/Files/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
                _context.Files.Add(file);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
