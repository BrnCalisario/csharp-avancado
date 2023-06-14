using System.Linq.Expressions;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

public class MessageRepository : IRepository<Mensagem>
{
    private RepoExemploContext entity;

    public MessageRepository(RepoExemploContext service)
        => this.entity = service;

    public void Add(Mensagem obj)
    {
        entity.Add(obj);
        entity.SaveChanges();
    }

    public void Delete(Mensagem obj)
    {
        entity.Remove(obj);
        entity.SaveChanges();
    }

    public async Task<List<Mensagem>> Filter(Expression<Func<Mensagem, bool>> exp)
    {
        return await entity.Mensagems
            .Where(exp)
            .ToListAsync();
    }

    public void Update(Mensagem obj)
    {
        entity.Update(obj);
        entity.SaveChanges();
    }
}