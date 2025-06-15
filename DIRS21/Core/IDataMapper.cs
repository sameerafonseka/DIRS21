using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIRS21.Core
{
    public interface IDataMapper<TSource, TTarget>
    {
        TTarget Map(TSource source);

        void Validate(TSource source);
    }
}
