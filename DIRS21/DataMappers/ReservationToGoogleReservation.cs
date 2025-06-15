using DIRS21.Core;
using DIRS21.Core.Models.Exceptions;
using DIRS21.ExternalDataModels.Google;
using DIRS21.InternalDataModel;
using DIRS21.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIRS21.DataMappers
{
    public class ReservationToGoogleReservation : IDataMapper<Reservation, GoogleReservation>
    {
        public GoogleReservation Map(Reservation source)
        {
            Validate(source);

            var googleRes = new GoogleReservation { };

            googleRes.RoomType = source.Room.RoomType switch
            {
                RoomType.Single => "S",
                RoomType.Double => "D",
                RoomType.Triple => "T"
            };

            return googleRes;
        }

        public void Validate(Reservation source)
        {
            if (string.IsNullOrWhiteSpace(source.ReservationId))
            {
                throw new DataMappingValidationException("Reservation", "ReservationId", $"ReservationId is empty. ReservationId is empty");
            }

            if (!source.ReservationId.IsGuid())
            {
                throw new DataMappingValidationException("Reservation", "ReservationId", $"ReservationId invliad. ReservationId: {source.ReservationId}");
            }

            if (source.Room == null)
            {
                throw new DataMappingValidationException("Reservation", "Room", $"Room is null.");
            }
        }
    }
}
