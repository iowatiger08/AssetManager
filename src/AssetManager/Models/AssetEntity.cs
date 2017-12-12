using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Entity
{
    public abstract class AssetEntity 
    {
        private long Id { get; set; }
        private DateTime CreatedDate { get; set; }
        private DateTime UpdatedDate { get; set; }
        private ActiveState ActiveFlag { get; set; }

    }
}
