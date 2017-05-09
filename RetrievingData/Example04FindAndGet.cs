using System;
using Simple.Data;

namespace SimpleDataExamples.RetrievingData
{
    public class Example04FindAndGet
    {
        public void Run()
        {
            var db = Database.OpenNamedConnection("PriceOptimizer");

            //Find returns a single row of data as a SimpleRecord object based on a SimpleExpression defining the criteria for the search; 
            // if more than one row matches, the first row retrieved from the data store is returned
            var appVer = db.HotelAppVersion.Find(db.HotelAppVersion.AppVersionId == 1);

            //The Get method returns a single row of data as a SimpleRecord object given values for the primary key columns of that table.
            //var appVer = db.HotelAppVersion.Get(1);

            Console.WriteLine($"Id: {appVer.Id}, AppVersionId: {appVer.AppVersionId}, HotelId: {appVer.HotelId}");
        }
    }
}