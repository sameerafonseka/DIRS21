using DIRS21.Core.Models.Exceptions;
using DIRS21.ExternalDataModels.Google;
using DIRS21.InternalDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DIRS21.Core
{
    public class MapHandler : IMapHandler
    {
        public object Map(object data, string sourceType, string targetType)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data), "Input data cannot be null.");

            Type srcType = Type.GetType(sourceType);
            if (srcType == null)
            {
                throw new ArgumentException($"Source type '{sourceType}' not found");
            }

            Type tgtType = Type.GetType(targetType);
            if (tgtType == null)
            {
                throw new ArgumentException($"Target type '{targetType}' not found");
            }

            if (!srcType.IsInstanceOfType(data))
            {
                throw new ArgumentException(
                    $"Input data is of type '{data.GetType().FullName}', but expected '{sourceType}'."
                );
            }

            var assembly = Assembly.GetExecutingAssembly();

            var mapperType = assembly.GetTypes()
                .FirstOrDefault(t =>
                    t.GetInterfaces().Any(i =>
                        i.IsGenericType &&
                        i.GetGenericTypeDefinition() == typeof(IDataMapper<,>) &&
                        i.GetGenericArguments()[0].FullName == sourceType &&
                        i.GetGenericArguments()[1].FullName == targetType));

            if (mapperType == null)
            {
                throw new InvalidOperationException($"No implementation of IDataMapper<{sourceType}, {targetType}> found");
            }

            var mapper = Activator.CreateInstance(mapperType);

            var mapMethod = mapperType.GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDataMapper<,>))
                .GetMethod("Map");

            try
            {
                var result = mapMethod.Invoke(mapper, new object[] { data });
                return result;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException ?? ex;
            }
        }

        
    }
}
