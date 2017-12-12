using AssetManager.Entity;
using AssetManager.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManager.Services
{
    public class UnitService :IWebServices<Unit>
    {
        public ManagerDbContext _context { get; set; }

        public UnitService()
        {

        }

        public UnitService (ManagerDbContext dbContext)
        {
            _context = dbContext;
        }

        public Task<List<Unit>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<Unit> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> PushUpdate(Unit toBeUpdated)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> RemoveItem(Unit toBeRemoved)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> SaveOrUpdate(Unit entity)
        {
            throw new NotImplementedException();
        }
    }
}