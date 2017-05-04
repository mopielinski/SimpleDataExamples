using System;
using Simple.Data;

namespace SimpleDataTest.RetrievingData
{
    public class Example02All
    {
        public void Run()
        {
            var db = Database.OpenNamedConnection("PriceOptimizer");

            //The Allmethod generally ignores any SimpleExpressions passed to it, be they valid or invalid.
            var appVerList = db.AppVersion.All(Id: 1);
            //select [dbo].[AppVersion].[Id],[dbo].[AppVersion].[Name],[dbo].[AppVersion].[VersionDetails],[dbo].[AppVersion].[DefaultValues] from [dbo].[AppVersion]

            //var appVerList =
            //    db.AppVersion.All(Id: 1).Select(db.AppVersion.Id, db.AppVersion.Name).Where(db.AppVersion.Id == 1);
            //"select [dbo].[AppVersion].[Id],[dbo].[AppVersion].[Name] from [dbo].[AppVersion] WHERE [dbo].[AppVersion].[Id] = @p1"

            //var appVerList = db.AppVersion.All();
            //appVerList = appVerList.Select(db.AppVersion.Id, db.AppVersion.Name).Where(db.AppVersion.Id == 1);
            //"select [dbo].[AppVersion].[Id],[dbo].[AppVersion].[Name] from [dbo].[AppVersion] WHERE [dbo].[AppVersion].[Id] = @p1"

            foreach (var appVer in appVerList)
            {
                Console.WriteLine($"Id: {appVer.Id}, Name: {appVer.Name}");
            }
        }
    }
}