using System;

namespace IEnumerableStreamer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Generating FIle...");

            var gen = new FileGenerator();
            gen.GenerateFile(100);

            Console.WriteLine("...Done!");
            Console.ReadKey();

            Console.WriteLine("Generating Bigger File...");
            var genBig = new FileGenerator(filename: "TestLoadBig.txt");
            genBig.GenerateFile(100_000);

            Console.WriteLine("...Done!");
            Console.ReadKey();
        }
    }
}