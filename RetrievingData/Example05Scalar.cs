using System;
using Simple.Data;

namespace SimpleDataExamples.RetrievingData
{
    public class Example05Scalar
    {
        public void Run()
        {
            var db = Database.OpenNamedConnection("PriceOptimizer");

            var value = db.HotelAppVersion.GetCount(db.HotelAppVersion.AppVersionId == 1);
            //var value = db.HotelAppVersion.GetCountByAppVersionId(1);

            //var value = db.HotelAppVersion.Exists(db.HotelAppVersion.AppVersionId == 4);
            //var value = db.HotelAppVersion.All().Where(db.HotelAppVersion.AppVersionId == 4).Exists();
            //var value = db.HotelAppVersion.ExistsByAppVersionId(4);

            //var value = db.HotelAppVersion.Any(db.HotelAppVersion.AppVersionId == 4);
            //same way as Exists

            //The GetScalar method returns a single scalar value as a simple type given values for the primary key columns of that table
            //var value =
            //    db.HotelAppVersion.All()
            //        .Select(db.HotelAppVersion.PriceSources)
            //        .Where(db.HotelAppVersion.AppVersionId == 1)
            //        .GetScalar(3);

            Console.WriteLine($"Value: {value}");
        }
    }
}