using System;
using Simple.Data;

namespace SimpleDataExamples.RetrievingData
{
    public class Example07LazyAndEagerLoading
    {
        public void Run()
        {
            var db = Database.OpenNamedConnection("PriceOptimizer");

            //Lazy Loading
            // taking one HotelAppVersion and connected AppVersion
            var hotelAppVer = db.HotelAppVersion
                .FindAll(db.HotelAppVersion.HotelId == 2695)
                .FirstOrDefault();

            // !!! It will not work if we cast result to statically typed object
            //HotelAppVersion hotelAppVer =
            //    db.HotelAppVersion.FindAll(db.HotelAppVersion.HotelId == 2695).FirstOrDefault();
            Console.WriteLine("Lazy Loading");
            Console.WriteLine($"Id: {hotelAppVer.Id}, AppVersionId: {hotelAppVer.AppVersionId}");
            //AppVersion is evaluated until accessed for the first time (loaded here)
            Console.WriteLine($"AppVersion.Name: {hotelAppVer.AppVersion.Name}");

            Console.WriteLine("\n\n");

            //Eager Evaluation
            //WithAppVersion() - AppVersion will be loaded with HotelAppVersion (but also is not evaluated until accessed for the first time)
            //WithAppVersion is like LEFT JOIN AppVersion
            var hotelAppVerEv =
                db.HotelAppVersion
                    .FindAll(db.HotelAppVersion.HotelId == 2695)
                    .WithAppVersion()
                    .FirstOrDefault();

            Console.WriteLine("Eager Evaluation");
            Console.WriteLine($"Id: {hotelAppVerEv.Id}, AppVersionId: {hotelAppVerEv.AppVersionId}");
            Console.WriteLine($"Id: {hotelAppVerEv.AppVersion.Name}");

            Console.WriteLine("\n\n");
        }
    }
}