using System;
using SimpleDataExamples.RetrievingData;

namespace SimpleDataExamples
{
    static class Program
    {
        static void Main(string[] args)
        {
            var example = new Example01FindAllBy();
            //ar example = new Example02All();
            //var example = new Example03FindAll();
            //var example = new Example04FindAndGet();
            //var example = new Example05Scalar();
            //var example = new Example06Queries();
            //var example = new Example07LazyAndEagerLoading();
            //var example = new Example08Joins();
            //var example = new Example08Joins();
            //var example = new Example09Aggregates();
            //var example = new Example10ModifyData();
            example.Run();

            Console.ReadKey();
        }
    }
}