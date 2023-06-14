using System.Linq.Expressions;
using Backend.Model;

public class FakeMessageRepository : IRepository<Mensagem>
{

    private List<Mensagem> fakeData = new List<Mensagem>()
    {
        new Mensagem()
        {
            Id = 1,
            Horario = DateTime.Now.AddDays(-1),
            Texto = "Don, platina o cabelo por favor"
        },
        new Mensagem()
        {
            Id = 2,
            Horario = DateTime.Now.AddDays(-.5),
            Texto = "Se alguém perguntar, você não sabe o que aconteceu com a robodrill"
        },
        new Mensagem()
        {
            Id = 2,
            Horario = DateTime.Now,
            Texto = "VOCÊ SABE QUEM QUEBROU A ROBODRILL?"
        },
    };

    public void Add(Mensagem obj)
        => fakeData.Add(obj);

    public void Delete(Mensagem obj)
        => fakeData.Remove(obj);

    public Task<List<Mensagem>> Filter(Expression<Func<Mensagem, bool>> exp)
    {
        throw new NotImplementedException();
    }

    public void Update(Mensagem obj)
    {
        var old = fakeData
            .FirstOrDefault(m => m.Id == obj.Id);

        if(obj is null)
            return;
        
        fakeData.Remove(old);
        fakeData.Add(obj);
    }
}