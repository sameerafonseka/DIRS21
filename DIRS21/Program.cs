using DIRS21.Core;
using DIRS21.ExternalDataModels.Google;
using DIRS21.InternalDataModel;

namespace DIRS21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MapHandler mapHandler = new MapHandler();

                GoogleReservation googleReservation = new GoogleReservation
                {
                    ResId = Guid.NewGuid(),
                    RoomType = "D"
                };

                Console.WriteLine("Mapping from GoogleReservation to Reservation");

                var reservation = mapHandler.Map(googleReservation, typeof(GoogleReservation).FullName, typeof(Reservation).FullName);

                Console.WriteLine("Mapping successful");

                Console.WriteLine("Mapping from Reservation to GoogleReservation");

                var googleReservation2 = mapHandler.Map(googleReservation, typeof(GoogleReservation).FullName, typeof(Reservation).FullName);

                Console.WriteLine("Mapping successful");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                if(ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    Console.WriteLine(ex.InnerException.StackTrace);
                }
            }
        }
    }
}
