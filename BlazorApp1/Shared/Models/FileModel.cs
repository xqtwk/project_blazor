using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Shared.Models;

public class FileModel
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Path { get; set; } = null!;
    [ForeignKey(nameof(Client))]
    public Client Client { get; set; }
}