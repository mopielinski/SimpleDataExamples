using System;
using Simple.Data;

namespace SimpleDataExamples.RetrievingData
{
    public class Example08Joins
    {
        public void Run()
        {
            var db = Database.OpenNamedConnection("PriceOptimizer");

            Console.WriteLine("Lazy Loading joins");
            //Lazy Loading joins
            // Get HotelAppVersion but in Select retrieve AppVersion
            var hotelAppVerlist = db.HotelAppVersion
                .FindAll(db.HotelAppVersion.HotelId == 2695 || db.HotelAppVersion.AppVersionId == 2)
                .Select(db.HotelAppVersion.AppVersionId, db.HotelAppVersion.AppVersion.Name);

            foreach (var appVer in hotelAppVerlist)
            {
                Console.WriteLine(
                    $"{appVer.AppVersionId}, Name: {appVer.Name}");
            }

            Console.WriteLine("\n\n");

            Console.WriteLine("Eager Evaluation Left join");
            //With() - Eager Evaluation Left join
            // WithAppVersion is like LEFT JOIN AppVersion
            // eager-loaded join query between two tables which have a foreign key relationship (or equivalent) between each other. 
            var hotelAppVerEv =
                db.HotelAppVersion
                    .FindAll(db.HotelAppVersion.HotelId == 2695)
                    //.WithAppVersion() //same as With(db.HotelAppVersion.AppVersion)
                    // we can use aliases
                    //.With(db.HotelAppVersion.AppVersion.As("AppVer"))
                    //or out variables to keep Select statement compact
                    .FirstOrDefault();

            Console.WriteLine($"Id: {hotelAppVerEv.Id}, AppVersionId: {hotelAppVerEv.AppVersionId}");
            Console.WriteLine($"AppVersion.Name: {hotelAppVerEv.AppVersion.Name}");

            Console.WriteLine("\n\n");

            //Eager Loading joins
            Console.WriteLine("Eager Loading joins");
            dynamic aV;
            var hotelAppVerEv2 =
                db.HotelAppVersion
                    .FindAll(db.HotelAppVersion.HotelId == 2695)
                    .Join(db.AppVersion.As("AV"), out aV)
                    .On(db.HotelAppVersion.AppVersionId == aV.Id)
                    .FirstOrDefault();

            Console.WriteLine($"Id: {hotelAppVerEv2.Id}, AppVersionId: {hotelAppVerEv2.AppVersionId}");

            Console.WriteLine("\n\n");
        }
    }
}