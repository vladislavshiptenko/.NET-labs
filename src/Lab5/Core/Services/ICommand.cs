namespace Core.Services;

public interface ICommand
{
    public Task Execute();
}