using BlazorApp1.Server.Interfaces;
using BlazorApp1.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Services;

public class TeacherService : ITeacher
{
    readonly DatabaseContext _dbContext = new();
    public TeacherService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    //Для получения всех данных о пользователе
    public List<Shared.Models.Teacher> GetClientDetails()
    {
        try
        {
            return _dbContext.Teachers.ToList();
        }
        catch
        {
            throw;
        }
    }
    //Для добавления новой записи пользователя
    public void AddClient(Shared.Models.Teacher teacher)
    {
        try
        {
            _dbContext.Teachers.Add(teacher);
            _dbContext.SaveChanges();
        }
        catch
        {
            throw;
        }
    }
    //Для обновления записи конкретного пользователя
    public void UpdateClientDetails(Shared.Models.Teacher teacher)
    {
        try
        {
            _dbContext.Entry(teacher).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        catch
        {
            throw;
        }
    }
    //Для получения информации о конкретном пользователе
    public Shared.Models.Teacher GetClientData(int id)
    {
        try
        {
            Shared.Models.Teacher? teacher = _dbContext.Teachers.Find(id);
            if (teacher != null)
            {
                return teacher;
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
            Shared.Models.Teacher? teacher = _dbContext.Teachers.Find(id);
            if (teacher != null)
            {
                _dbContext.Teachers.Remove(teacher);
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