namespace BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Http;
public class ClientViewModel
{
    public string Name { get; set; }
    public IFormFile Avatar { get; set; }
}