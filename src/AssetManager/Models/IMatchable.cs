using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Entity
{
    public interface IMatchable<T>
    {
        Boolean Matches(T another);
    }
}
