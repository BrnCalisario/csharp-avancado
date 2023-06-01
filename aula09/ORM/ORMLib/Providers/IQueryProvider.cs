namespace ORMLib.Providers;

using System.Linq.Expressions;
using System.Threading.Tasks;
using Linq;

public interface IQueryProvider
{
    IQueryable<T> CreateQuery<T>(Expression exp);
    Task<T> Execute<T>(Expression exp);
}