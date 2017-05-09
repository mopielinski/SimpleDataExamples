using System;
using SimpleDataExamples.RetrievingData;

namespace SimpleDataExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //var example = new Example01FindAllBy();
            //var example = new Example02All();
            //var example = new Example03FindAll();
            //var example = new Example04FindAndGet();
            //var example = new Example05Scalar();
            //var example = new Example06Queries();
            //var example = new Example07LazyAndEagerLoading();
            //var example = new Example08Joins();
            //var example = new Example08Joins();
            var example = new Example09Aggregates();

            example.Run();

            Console.ReadKey();
        }
    }
}