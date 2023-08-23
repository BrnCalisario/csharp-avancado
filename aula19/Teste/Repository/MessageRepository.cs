using System.Linq.Expressions;
using Teste.Model;

public class MessageRepository : IRepository<Message>
{
    List<Message> messageList = new List<Message>()
    {
        new Message()
        {
            Id = 1,
            Horario = DateTime.Now.AddDays(-1),
            Texto = "Oi"
        },

        new Message()
        {
            Id = 2,
            Horario = DateTime.Now.AddDays(-.5),
            Texto = "Tchau"
        }
    };

    public void Add(Message obj)
    {
        this.messageList.Add(obj);
    }

    public void Delete(Message obj)
    {
        this.messageList.Remove(obj);
    }

    public async Task<List<Message>> Filter(Expression<Func<Message, bool>> exp)
    {
        await Task.Delay(1);
        return messageList.Where(exp.Compile()).ToList();
    }

    public void Update(Message obj)
    {
        var old = messageList
            .FirstOrDefault(m => m.Id == obj.Id);

        if(obj is null)
            return;

        messageList.Remove(old);
        messageList.Add(obj);
    }
}