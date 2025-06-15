using DIRS21.Core;
using DIRS21.Core.Models.Exceptions;
using DIRS21.ExternalDataModels.Google;
using DIRS21.InternalDataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIRS21.DataMappers
{
    public class GoogleReservationToReservation : IDataMapper<GoogleReservation, Reservation>
    {
        public Reservation Map(GoogleReservation source)
        {
            Validate(source);

            var res = new Reservation 
            {
                 Room = new Room { }
            };

            res.ReservationId = source.ResId.ToString();

            if (source.RoomType == "S")
                res.Room.RoomType = RoomType.Single;
            else if (source.RoomType == "D")
                res.Room.RoomType = RoomType.Double;
            else if (source.RoomType == "T")
                res.Room.RoomType = RoomType.Triple;

            return res;
        }

        public void Validate(GoogleReservation source)
        {
            string[] googleRoomType = { "S", "D", "T" };


            if(source.ResId == Guid.Empty)
            {
                throw new DataMappingValidationException("GoogleReservation", "ResId", $"ResId invliad. ResId is empty");
            }

            if (!googleRoomType.Contains(source.RoomType))
            {
                throw new DataMappingValidationException("GoogleReservation", "RoomType", $"RoomType invliad. Value: {source.RoomType}");
            }
        }
    }
}
