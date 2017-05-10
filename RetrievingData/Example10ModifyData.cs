using System;
using Simple.Data;
using SimpleDataExamples.Models;

namespace SimpleDataExamples.RetrievingData
{
    public class Example10ModifyData
    {
        public void Run()
        {
            var db = Database.OpenNamedConnection("PriceOptimizer");

            Console.WriteLine("Insert (Named Parameters)");

            //Insert (Named Parameters)
            db.AppVersion.Insert(Id: 999, Name: "test");

            var appVersion999 = db.AppVersion
                .Get(999);

            Console.WriteLine($"Id: {appVersion999.Id}, name: {appVersion999.Name}");

            Console.WriteLine("\n\n");

            //Insert (by object)
            Console.WriteLine("Insert (by object)");

            var newAppVersion = new AppVersion()
            {
                Id = 998,
                Name = "test2"
            };

            db.AppVersion.Insert(newAppVersion);
            var appVersion998 = db.AppVersion
                .Get(998);

            Console.WriteLine($"Id: {appVersion998.Id}, name: {appVersion998.Name}");

            Console.WriteLine("\n\n");
            //Possible MultiInserts
            // here will be for example

            Console.WriteLine("Press any key to UpdateById(999).");
            Console.ReadKey();

            //UpdateById
            Console.WriteLine("UpdateById");
            db.AppVersion.UpdateById(Id: 999, Name: "Updated Name");

            appVersion999 = db.AppVersion
                .Get(999);

            Console.WriteLine($"Id: {appVersion999.Id}, name: {appVersion999.Name}");

            Console.WriteLine("\n\n");

            Console.WriteLine("Press any key to UpdateAll.");
            Console.ReadKey();

            //UpdateAll
            Console.WriteLine("UpdateAll");
            db.AppVersion.UpdateAll(Name: "UpdateAll Name", Condition: db.AppVersion.Id > 900);
            //OR
            //db.AppVersion.UpdateAll(db.AppVersion.Id > 900, Name: "UpdateAll Name");

            appVersion999 = db.AppVersion.Get(999);
            Console.WriteLine($"Id: {appVersion999.Id}, name: {appVersion999.Name}");
            appVersion998 = db.AppVersion.Get(998);
            Console.WriteLine($"Id: {appVersion998.Id}, name: {appVersion998.Name}");

            Console.WriteLine("\n\n");

            Console.WriteLine("Press any key to delete.");
            Console.ReadKey();

            //Cleanup
            // Delete by PrimaryKey
            //db.AppVersion.Delete(Id: 999);
            //db.AppVersion.DeleteById(998);
            db.AppVersion.DeleteAll(db.AppVersion.Id > 900);
        }
    }
}