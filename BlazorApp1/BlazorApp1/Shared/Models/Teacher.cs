namespace BlazorApp1.Shared.Models;

public class Teacher : Client
{
    public ICollection<Student> Students { get; set; }
    private double startWage;

    public Teacher()
    {
        this.Students= new HashSet<Student>();

    }
    public double Wage(ICollection<Student> Stud, double wage)
    {
        return Stud.Count() * wage;
    }
}