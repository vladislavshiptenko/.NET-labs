namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

public interface IRepository<T>
{
    void Add(T component);
    void Delete(T component);
    void Update(T oldComponent, T newComponent);
}