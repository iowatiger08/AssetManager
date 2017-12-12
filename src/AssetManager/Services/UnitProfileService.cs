using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssetManager.Entity;

namespace AssetManager.Services
{
    public class UnitProfileService : IWebServices<UnitProfile>
    {
        public Task<UnitProfile> GetById(long externalId)
        {
            throw new NotImplementedException();
        }

        public Task<List<UnitProfile>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<UnitProfile> PushUpdate(UnitProfile toBeUpdated)
        {
            throw new NotImplementedException();
        }

        public Task<UnitProfile> RemoveItem(UnitProfile toBeRemoved)
        {
            throw new NotImplementedException();
        }

        public Task<UnitProfile> SaveOrUpdate(UnitProfile entity)
        {
            throw new NotImplementedException();
        }
    }
}