using System;
using Simple.Data;

namespace SimpleDataExamples.RetrievingData
{
    public class Example03FindAll
    {
        public void Run()
        {
            var db = Database.OpenNamedConnection("PriceOptimizer");

            //FindAll returns all data from a table based on a SimpleExpression defining the criteria for the search.
            var appVerList = db.HotelAppVersion.FindAll(db.HotelAppVersion.AppVersionId == 1);

            //var appVerList =
            //    db.HotelAppVersion.FindAll(db.HotelAppVersion.AppVersionId == 2 || db.HotelAppVersion.HotelId == 2881);
            //"select [dbo].[HotelAppVersion].[Id],[dbo].[HotelAppVersion].[AppVersionId],[dbo].[HotelAppVersion].[HotelId],[dbo].[HotelAppVersion].[PriceSources],[dbo].[HotelAppVersion].[LengthOfStay],[dbo].[HotelAppVersion].[Occupancy],[dbo].[HotelAppVersion].[AutomaticDailyReports],[dbo].[HotelAppVersion].[AutomaticWeeklyReports],[dbo].[HotelAppVersion].[ReportSubscribers] " +
            //"from [dbo].[HotelAppVersion] " +
            //"WHERE ([dbo].[HotelAppVersion].[AppVersionId] = @p1 OR [dbo].[HotelAppVersion].[HotelId] = @p2)"

            //contains fails - only SimpleExpressions possible
            //var appVer = db.AppVersion.FindAll("PO Light".Contains(db.AppVersion.Name.ToString())).FirstOrDefault(); 

            foreach (var appVer in appVerList)
            {
                Console.WriteLine($"AppVersionId: {appVer.AppVersionId}, HotelId: {appVer.HotelId}");
            }
        }
    }
}