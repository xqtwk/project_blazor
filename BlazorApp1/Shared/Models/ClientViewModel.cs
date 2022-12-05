namespace BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Http;
public class ClientViewModel
{
    public Client client { get; set; }
    public IFormFile Avatar { get; set; }
}