using System;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.S0062
{
    [FunctionalityMarker]
    public partial interface IScripts : IFunctionalityMarker
    {
        public async Task GenerateAllTailwindContentPathsJsonFile()
        {
            /// Inputs.
            // This should be the server project for 
            var projectFilePath =
                @"C:\Code\DEV\Git\GitHub\SafetyCone\E2000.Private\source\E2000.Server\E2000.Server.csproj"
                ;


            /// Run.
            await Instances.Operations.GenerateAllTailwindContentPathsJsonFile(projectFilePath);
        }
    }
}
