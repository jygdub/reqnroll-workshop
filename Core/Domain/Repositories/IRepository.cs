namespace Core.Domain.Repositories;

public interface IRepository
{
    Task CleanUpAsync();
}