using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIRS21.Utilities
{
    public static class ValidatorHelper
    {
        public static bool IsGuid(this string value)
        {
            return Guid.TryParse(value, out _);
        }
    }
}
