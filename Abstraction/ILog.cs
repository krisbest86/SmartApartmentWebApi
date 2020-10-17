namespace Abstraction
{
    public interface ILog 
    {
        void Notify(string message);
        void LogError(string message);
    }
}