using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Entity
{
    public class Unit : AssetEntity, IMatchable<Unit>
    {
        public string UNIT_CODE;
        public int ACTIVE_FLAG;

        public int UNIT_ID { get; set; }

        public bool Matches(Unit another)
        {
            throw new NotImplementedException();
        }

    }
}
