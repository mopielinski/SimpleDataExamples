using System;
using Simple.Data;

namespace SimpleDataExamples.RetrievingData
{
    public class Example09Aggregates
    {
        public void Run()
        {
            var db = Database.OpenNamedConnection("PriceOptimizer");

            Console.WriteLine("Lazy Loading joins");

            //Count, Max and Having
            //For each appVersion get count of hotels with this verison and max hotelId
            // but only this one with count > 1
            var hotelAppVerlist = db.HotelAppVersion
                .All()
                .Select(db.HotelAppVersion.AppVersion.Name,
                    db.HotelAppVersion.Id.Count().As("AppVersionCount"),
                    db.HotelAppVersion.HotelId.Max().As("HotelIdMax"))
                .Having(db.HotelAppVersion.Id.Count() > 1);

            foreach (var appVer in hotelAppVerlist)
            {
                Console.WriteLine(
                    $"name: {appVer.Name}, AppVersionCount: {appVer.AppVersionCount}, HotelIdMax {appVer.HotelIdMax}");
            }

            Console.WriteLine("\n\n");
        }
    }
}