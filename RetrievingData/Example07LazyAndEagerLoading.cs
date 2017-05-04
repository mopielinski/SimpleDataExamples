using System;
using Simple.Data;
using SimpleDataTest.Models;

namespace SimpleDataTest.RetrievingData
{
    public class Example07LazyAndEagerLoading
    {
        public void Run()
        {
            var db = Database.OpenNamedConnection("PriceOptimizer");

            //Lazy Loading
            // taking one HotelAppVersion and connected AppVersion
            var hotelAppVer = db.HotelAppVersion.FindAll(db.HotelAppVersion.HotelId == 2695).FirstOrDefault();

            //not working if we cast result to statically typed object
            //HotelAppVersion hotelAppVer =
            //    db.HotelAppVersion.FindAll(db.HotelAppVersion.HotelId == 2695).FirstOrDefault();

            Console.WriteLine($"Id: {hotelAppVer.Id}, AppVersionId: {hotelAppVer.AppVersionId}");
            //AppVersion is evaluated until accessed for the first time (loaded here)
            Console.WriteLine($"Id: {hotelAppVer.AppVersion.Name}");

            Console.WriteLine("\n\n");

            //Lazy Loading - other way
            // taking AppVersion and all connected HotelAppVersions
            var appVera = db.appVersion.Get(1);
            Console.WriteLine($"Id: {appVera.Name}");

            foreach (var appVer in appVera.HotelAppVersion)
            {
                Console.WriteLine(
                    $"Id: {appVer.Id}, AppVersionId: {appVer.AppVersionId}, HotelId: {appVer.HotelId}");
            }

            Console.WriteLine("\n\n");

            //Eager Evaluation
            //WithAppVersion() - AppVersion will be loaded with HotelAppVersion (but also is not evaluated until accessed for the first time)
            //WithAppVersion is like LEFT JOIN AppVersion
            var hotelAppVerEv =
                db.HotelAppVersion.FindAll(db.HotelAppVersion.HotelId == 2695).WithAppVersion().FirstOrDefault();
            Console.WriteLine($"Id: {hotelAppVerEv.Id}, AppVersionId: {hotelAppVerEv.AppVersionId}");
            Console.WriteLine($"Id: {hotelAppVerEv.AppVersion.Name}");

            Console.WriteLine("\n\n");
        }
    }
}