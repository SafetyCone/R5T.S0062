using System;
using System.Threading.Tasks;


namespace R5T.S0062
{
    class Program
    {
        static async Task Main()
        {
            await Scripts.Instance.GenerateAllTailwindContentPathsJsonFile();

            //Construction.Instance.LoadAndSaveTailwindContentPathsJsonFile();
            //Construction.Instance.CombineProjectContentPaths();
        }
    }
}