using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Entity
{
    public class UnitStatus : AssetEntity, IMatchable<UnitStatus>
    {
        public string CODE;
        public int ACTIVE_FLAG;

        public int UNIT_ID { get; set; }

        public bool Matches(UnitStatus another)
        {
            throw new NotImplementedException();
        }

    }
}
