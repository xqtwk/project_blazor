namespace BlazorApp1.Server.Interfaces;

public interface IStudent
{
    public List<Shared.Models.Student> GetClientDetails();
    public void AddClient(Shared.Models.Student student);
    public void UpdateClientDetails(Shared.Models.Student student);
    public Shared.Models.Student GetClientData(int id);
    public void DeleteClient(int id);
}