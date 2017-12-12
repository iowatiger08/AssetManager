using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Entity
{
    public class UnitProfile : AssetEntity, IMatchable<UnitProfile>
    {

        public Unit Unit { get; set; }
        public List<UnitStatus> UnitStatuses { get; set; }

        public bool Matches(UnitProfile another)
        {
            throw new NotImplementedException();
        }

    }
}
