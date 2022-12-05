using BlazorApp1.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Services;

public class StudentService
{
    readonly DatabaseContext _dbContext = new();
    public StudentService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    //Для получения всех данных о пользователе
    public List<Shared.Models.Student> GetClientDetails()
    {
        try
        {
            return _dbContext.Students.ToList();
        }
        catch
        {
            throw;
        }
    }
    //Для добавления новой записи пользователя
    public void AddClient(Shared.Models.Student student)
    {
        try
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }
        catch
        {
            throw;
        }
    }
    //Для обновления записи конкретного пользователя
    public void UpdateClientDetails(Shared.Models.Student student)
    {
        try
        {
            _dbContext.Entry(student).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        catch
        {
            throw;
        }
    }
    //Для получения информации о конкретном пользователе
    public Shared.Models.Student GetClientData(int id)
    {
        try
        {
            Shared.Models.Student? student = _dbContext.Students.Find(id);
            if (student != null)
            {
                return student;
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
            Shared.Models.Student? student = _dbContext.Students.Find(id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
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