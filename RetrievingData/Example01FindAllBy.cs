using System;
using Simple.Data;

namespace SimpleDataTest.RetrievingData
{
    public class Example01FindAllBy
    {
        public void Run()
        {
            var db = Database.Open(); //Simple.Data.Properties.Settings.DefaultConnectionString
            //var db = Database.OpenNamedConnection("PriceOptimizer");

            var appVer = db.AppVersion.FindAllBy(Id: 1).FirstOrDefault();
            //var appVer = db["dbo"]["AppVersion"].FindAllBy(Id: 1).FirstOrDefault();
            //var appVer = db.AppVersion.FindAllById(1).FirstOrDefault();
            //var appVer = db.AppVersion.FindAllByName("PS Pro").FirstOrDefault();
            //var appVer = db.AppVersion.FindAllByIdAndName(5, "PS Pro").FirstOrDefault();

            //Or Fails - use Where
            //var appVer = db.AppVersion.FindAllByIdOrName(5, "PO Light").FirstOrDefault(); //Fails :(
            // example with Where:
            //var appVer = db.AppVersion.All()
            //    .Where(db.AppVersion.id == 5 || db.AppVersion.Name == "PO Light")
            //    .FirstOrDefault();

            Console.WriteLine($"Id: {appVer.Id}, Name: {appVer.Name}");
        }
    }
}