using System.Linq.Expressions;

public interface IRepository<T>
{
    Task<List<T> Filter(Expression<Func<T, bool>> exp)
    {
        
    }
}