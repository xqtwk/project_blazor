namespace BlazorApp1.Shared.Models;

public class Teacher : Client
{
    public ICollection<Student> Students { get; set; }

    public Teacher()
    {
        this.Students= new HashSet<Student>();

    }
}