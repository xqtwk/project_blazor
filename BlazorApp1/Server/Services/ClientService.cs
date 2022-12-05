using BlazorApp1.Server.Interfaces;
using BlazorApp1.Server.Models;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Services;

public class ClientService : IClient
{
    readonly DatabaseContext _dbContext = new();
    public ClientService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    //Для получения всех данных о пользователе
    public List<Shared.Models.Client> GetClientDetails()
    {
        try
        {
            return _dbContext.Clients.ToList();
        }
        catch
        {
            throw;
        }
    }
    //Для добавления новой записи пользователя
    public void AddClient(Shared.Models.Client client)
    {
        try
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
        }
        catch
        {
            throw;
        }
    }
    //Для обновления записи конкретного пользователя
    public void UpdateClientDetails(Shared.Models.Client client)
    {
        try
        {
            _dbContext.Entry(client).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        catch
        {
            throw;
        }
    }
    //Для получения информации о конкретном пользователе
    public Shared.Models.Client GetClientData(int id)
    {
        try
        {
            Shared.Models.Client? client = _dbContext.Clients.Find(id);
            if (client != null)
            {
                return client;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        catch
        {
            throw;
        }
    }
    //Для удаления записи конкретного пользователя
    public void DeleteClient(int id)
    {
        try
        {
            Shared.Models.Client? client = _dbContext.Clients.Find(id);
            if (client != null)
            {
                _dbContext.Clients.Remove(client);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        catch
        {
            throw;
        }
    }
}