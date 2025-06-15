using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIRS21.InternalDataModel
{
    public enum RoomType
    {
        Single,
        Double,
        Triple
    }

    public class Room
    {
        public RoomType RoomType { get; set; }
    }
}
