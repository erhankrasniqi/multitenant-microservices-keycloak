using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel
{
    public interface IAggregateRoot<TKey> : IEntity<TKey>
    {
        //
    }
}
