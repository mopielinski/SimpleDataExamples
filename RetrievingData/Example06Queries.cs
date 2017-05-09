using System;
using Simple.Data;

namespace SimpleDataExamples.RetrievingData
{
    public class Example06Queries
    {
        public void Run()
        {
            var db = Database.OpenNamedConnection("PriceOptimizer");

            Console.WriteLine("1. query");
            // Gets some fields (return HotelAppVersion.Id as HotelAppVersionId) from HotelAppVersion 
            //  where HotelId != 2881 AND AppVersionId IN (1, 2) AND PriceSources == "[2,3,5]"
            //  order it by HotelId
            var appVerList = db.HotelAppVersion.FindAll(db.HotelAppVersion.HotelId != 2881)
                .Select(db.HotelAppVersion.Id.As("HotelAppVersionId"), //alias
                    db.HotelAppVersion.AppVersionId,
                    db.HotelAppVersion.PriceSources,
                    db.HotelAppVersion.HotelId)
                .Where(db.HotelAppVersion.AppVersionId == 1 || db.HotelAppVersion.AppVersionId == 2) //AND
                .Where(db.HotelAppVersion.PriceSources == "[2,3,5]") //AND
                .OrderByHotelId(); //OrderBy(HotelId);
            //.OrderByHotelIdDescending();

            //select [dbo].[HotelAppVersion].[Id] AS [HotelAppVersionId],[dbo].[HotelAppVersion].[AppVersionId],[dbo].[HotelAppVersion].[PriceSources],[dbo].[HotelAppVersion].[HotelId] 
            //from [dbo].[HotelAppVersion]
            //WHERE (([dbo].[HotelAppVersion].[HotelId] != @p1 AND ([dbo].[HotelAppVersion].[AppVersionId] = @p2 OR [dbo].[HotelAppVersion].[AppVersionId] = @p3)) 
            //AND [dbo].[HotelAppVersion].[PriceSources] = @p4)

            foreach (var appVer in appVerList)
            {
                Console.WriteLine(
                    $"Id: {appVer.HotelAppVersionId}, AppVersionId: {appVer.AppVersionId}, HotelId: {appVer.HotelId},");
            }

            Console.WriteLine();
            Console.WriteLine("2. query: Selecting all columns");

            //Selecting all columns: .AllColumns() / .Star()
            var appVerListAll = db.HotelAppVersion.All().Select(db.HotelAppVersion.AllColumns());
            //var appVerListAll = db.HotelAppVersion.All().Select(db.HotelAppVersion.Star());

            foreach (var appVer in appVerListAll)
            {
                Console.WriteLine(
                    $"Id: {appVer.Id}, AppVersionId: {appVer.AppVersionId}, HotelId: {appVer.HotelId}");
            }

            Console.WriteLine();
            Console.WriteLine("3. Distinct");

            // .Distinct() (many columns)
            var appVerListDistinct =
                db.HotelAppVersion.All()
                    .Select(db.HotelAppVersion.AppVersionId.Distinct(), db.HotelAppVersion.LengthOfStay);

            foreach (var appVer in appVerListDistinct)
            {
                Console.WriteLine(
                    $"AppVersionId: {appVer.AppVersionId} LengthOfStay: {appVer.LengthOfStay}");
            }
        }
    }
}