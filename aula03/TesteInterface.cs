public interface IForca
{
    void SuperSoco();
} 

public interface IVoar
{
    void VoaMlk();
}

public class Superman : IForca, IVoar
{
    public void SuperSoco()
    {
        throw new System.NotImplementedException();
    }

    public void VoaMlk()
    {
        
    }
}
