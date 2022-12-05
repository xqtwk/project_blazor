namespace BlazorApp1.Shared.Models;

public class Parent : Client
{
    public ICollection<Student> Childs { get; set; }

    public Parent()
    {
        this.Childs = new HashSet<Student>();
    }
}