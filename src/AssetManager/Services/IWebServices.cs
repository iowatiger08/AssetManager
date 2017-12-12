using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManager.Entity;

namespace AssetManager.Services
{
    public interface IWebServices<T>
    {
        Task<List<T>> GetList();

        Task<T> GetById(long externalId);

        Task<T> PushUpdate(T toBeUpdated);

        Task<T> RemoveItem(T toBeRemoved);


        Task<T> SaveOrUpdate(T entity);
    }
}
