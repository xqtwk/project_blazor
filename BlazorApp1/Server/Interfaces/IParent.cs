namespace BlazorApp1.Server.Interfaces;

public interface IParent 
{
    public List<Shared.Models.Parent> GetClientDetails();
    public void AddClient(Shared.Models.Parent parent);
    public void UpdateClientDetails(Shared.Models.Parent parent);
    public Shared.Models.Parent GetClientData(int id);
    public void DeleteClient(int id);
}