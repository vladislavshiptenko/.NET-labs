namespace Core.Services;

public interface ICommandResult<T>
{
    public Task<T?> Execute();
}