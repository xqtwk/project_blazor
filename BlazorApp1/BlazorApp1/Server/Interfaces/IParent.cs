namespace BlazorApp1.Server.Interfaces;

public interface IParent 
{
    public List<Shared.Models.Parent> GetClientDetails();
    public void AddClient(Shared.Models.Parent client);
    public void UpdateClientDetails(Shared.Models.Parent client);
    public Shared.Models.Parent GetClientData(int id);
    public void DeleteClient(int id);
}