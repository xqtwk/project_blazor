namespace BlazorApp1.Server.Interfaces;

public interface ITeacher
{
    public List<Shared.Models.Teacher> GetClientDetails();
    public void AddClient(Shared.Models.Teacher teacher);
    public void UpdateClientDetails(Shared.Models.Teacher teacher);
    public Shared.Models.Teacher GetClientData(int id);
    public void DeleteClient(int id);
}