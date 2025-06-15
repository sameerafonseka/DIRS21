using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DIRS21.Core.Models.Exceptions
{
    public class DataMappingValidationException : Exception
    {
        public string Type { get; private set; }
        public string Property { get; private set; }
        public string ValidationError { get; private set; }

        public DataMappingValidationException(string type, string property, string validationError)
        {
            Type = type;
            Property = property;
            ValidationError = validationError;
        }
    }
}
