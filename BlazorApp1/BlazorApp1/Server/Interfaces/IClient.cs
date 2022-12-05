using BlazorApp1.Shared.Models;

namespace BlazorApp1.Server.Interfaces;

public interface IClient
{
    public List<Shared.Models.Client> GetClientDetails();
    public void AddClient(Shared.Models.Client client);
    public void UpdateClientDetails(Shared.Models.Client client);
    public Shared.Models.Client GetClientData(int id);
    public void DeleteClient(int id);
}