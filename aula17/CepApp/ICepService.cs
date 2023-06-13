using System.Threading.Tasks;

public interface ICepService
{
    Task<CepData> Get(string cep);
}