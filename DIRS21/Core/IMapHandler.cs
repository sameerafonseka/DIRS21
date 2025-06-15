using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIRS21.Core
{
    public interface IMapHandler
    {
        public object Map(object data, string sourceType, string targetType);
    }
}
