using LibraryManagement.Contracts.Common;

namespace Auth.Core.Abstractions.Repositories;

public interface IBaseRepository<TEntity> where TEntity : Entity
{
    /// <summary>
    ///     Получаем запрос для entity
    /// </summary>
    /// <returns></returns>
    IQueryable<TEntity> GetAll();
    
    /// <summary>
    ///     Добавляем новую сущность
    /// </summary>
    /// <param name="entity">Сущность</param>
    /// <returns></returns>
    Task<TEntity> Create(TEntity entity);
}