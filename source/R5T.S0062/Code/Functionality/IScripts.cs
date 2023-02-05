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
            var projectFilePath =
                @"C:\Code\DEV\Git\GitHub\davidcoats\D8S.W0003.Private\source\D8S.W0003\D8S.W0003.csproj"
                ;


            /// Run.
            await Instances.Operations.GenerateAllTailwindContentPathsJsonFile(projectFilePath);
        }
    }
}
