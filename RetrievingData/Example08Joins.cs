using System;
using Simple.Data;

namespace SimpleDataTest.RetrievingData
{
    public class Example08Joins
    {
        public void Run()
        {
            var db = Database.OpenNamedConnection("PriceOptimizer");

            //Lazy Loading joins
            // Get HotelAppVersion but in Select take AppVersion
            var hotelAppVerlist = db.HotelAppVersion.FindAll(db.HotelAppVersion.HotelId == 2695
                                                             || db.HotelAppVersion.AppVersionId == 2)
                .Select(db.HotelAppVersion.AppVersionId, db.HotelAppVersion.AppVersion.Name);

            foreach (var appVer in hotelAppVerlist)
            {
                Console.WriteLine(
                    $"{appVer.AppVersionId}, Name: {appVer.Name}");
            }

            Console.WriteLine("\n\n");

            //Eager Evaluation Left join
            //WithAppVersion is like LEFT JOIN AppVersion
            var hotelAppVerEv =
                db.HotelAppVersion.FindAll(db.HotelAppVersion.HotelId == 2695).WithAppVersion().FirstOrDefault();
            Console.WriteLine($"Id: {hotelAppVerEv.Id}, AppVersionId: {hotelAppVerEv.AppVersionId}");
            Console.WriteLine($"Id: {hotelAppVerEv.AppVersion.Name}");

            dynamic aV;
            //Eager Loading joins
            var hotelAppVerEv2 =
                db.HotelAppVersion.FindAll(db.HotelAppVersion.HotelId == 2695)
                    .Join(db.AppVersion.As("AV"), out aV)
                    .On(db.HotelAppVersion.AppVersionId == aV.Id)
                    .FirstOrDefault();

            Console.WriteLine($"Id: {hotelAppVerEv2.Id}, AppVersionId: {hotelAppVerEv2.AppVersionId}");

            Console.WriteLine("\n\n");
        }
    }
}