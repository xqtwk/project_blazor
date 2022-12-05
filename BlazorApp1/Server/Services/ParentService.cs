using BlazorApp1.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Services;

public class ParentService
{
    readonly DatabaseContext _dbContext = new();
    public ParentService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    //Для получения всех данных о пользователе
    public List<Shared.Models.Parent> GetClientDetails()
    {
        try
        {
            return _dbContext.Parents.ToList();
        }
        catch
        {
            throw;
        }
    }
    //Для добавления новой записи пользователя
    public void AddClient(Shared.Models.Parent parent)
    {
        try
        {
            _dbContext.Parents.Add(parent);
            _dbContext.SaveChanges();
        }
        catch
        {
            throw;
        }
    }
    //Для обновления записи конкретного пользователя
    public void UpdateClientDetails(Shared.Models.Parent parent)
    {
        try
        {
            _dbContext.Entry(parent).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        catch
        {
            throw;
        }
    }
    //Для получения информации о конкретном пользователе
    public Shared.Models.Parent GetClientData(int id)
    {
        try
        {
            Shared.Models.Parent? parent = _dbContext.Parents.Find(id);
            if (parent != null)
            {
                return parent;
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
            Shared.Models.Parent? parent = _dbContext.Parents.Find(id);
            if (parent != null)
            {
                _dbContext.Parents.Remove(parent);
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