using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Shared.Models;

public class Student : Client
{
    [Key, ForeignKey(nameof(Teachers))]
    public ICollection<Teacher> Teachers { get; set; }
    [Key, ForeignKey(nameof(Parents))]
    public ICollection<Parent> Parents { get; set; }
    public Student()
    {
        this.Teachers = new HashSet<Teacher>();
        this.Parents = new HashSet<Parent>();
    }
}