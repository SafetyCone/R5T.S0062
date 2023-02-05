using System;
using System.Linq;

using R5T.T0132;


namespace R5T.S0062
{
    [FunctionalityMarker]
    public partial interface IConstruction : IFunctionalityMarker
    {
        public void CombineProjectContentPaths()
        {
            /// Inputs.
            var destinationProjectFilePath = @"C:\Code\DEV\Git\GitHub\davidcoats\D8S.W0003.Private\source\D8S.W0003\D8S.W0003.csproj";

            var sourceProjectFilePaths = new[]
            {
                @"C:\Code\DEV\Git\GitHub\davidcoats\D8S.W0003.Private\source\D8S.W0003\D8S.W0003.csproj",
                @"C:\Code\DEV\Git\GitHub\davidcoats\D8S.W0003.Private\source\D8S.W0003.R000\D8S.W0003.R000.csproj",
                @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.R0004\source\R5T.R0004\R5T.R0004.csproj",
                @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.R0005\source\R5T.R0005\R5T.R0005.csproj",
                @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.R0006\source\R5T.R0006\R5T.R0006.csproj",
            };


            /// Run.
            var destinationProjectRelativeGlobbedPaths = sourceProjectFilePaths
                .SelectMany(sourceProjectFilePath =>
                {
                    var contentPathsFilePath = Instances.ProjectPathsOperator.GetTailwindContentPathsJsonFilePath(sourceProjectFilePath);

                    var globbedRelativePaths = Instances.JsonOperator.Deserialize_Synchronous<string[]>(contentPathsFilePath);

                    var sourceProjectDirectoryPath = Instances.ProjectPathsOperator.GetProjectDirectoryPath(sourceProjectFilePath);

                    var absoluteGlobbedPaths = globbedRelativePaths
                        .Select(globbedRelativePath => Instances.PathOperator.Combine(
                            sourceProjectDirectoryPath,
                            globbedRelativePath))
                        .Now();

                    var sourceRelativeGlobbedPaths = absoluteGlobbedPaths
                        .Select(absoluteGlobbedPath => Instances.PathOperator.GetRelativePath(
                            destinationProjectFilePath,
                            absoluteGlobbedPath))
                        .Now();

                    return sourceRelativeGlobbedPaths;
                })
                .Now();

            var formattedDestinationProjectRelativeGlobbedPaths = destinationProjectRelativeGlobbedPaths
                // We want non-Windows paths.
                .Select(path => Instances.PathOperator.EnsureNonWindowsDirectorySeparator(path))
                // Convention for Tailwind CSS is to start from the current directory with "./".
                .Select(path => $"./{path}")
                .Now();

            Instances.JsonOperator.Serialize_Synchronous(
                Instances.FilePaths.OutputJsonFilePath,
                formattedDestinationProjectRelativeGlobbedPaths);

            Instances.NotepadPlusPlusOperator.Open(
                Instances.FilePaths.OutputJsonFilePath);
        }

        public void LoadAndSaveTailwindContentPathsJsonFile()
        {
            var projectFilePath = @"C:\Code\DEV\Git\GitHub\davidcoats\D8S.W0003.Private\source\D8S.W0003\D8S.W0003.csproj";

            var tailwindContentPathsJsonFilePath = Instances.ProjectPathsOperator.GetTailwindContentPathsJsonFilePath(projectFilePath);

            var globbedRelativePaths = Instances.JsonOperator.Deserialize_Synchronous<string[]>(tailwindContentPathsJsonFilePath);

            var outputJsonFilePath = Instances.FilePaths.OutputJsonFilePath;

            Instances.JsonOperator.Serialize_Synchronous(
                outputJsonFilePath,
                globbedRelativePaths);

            Instances.NotepadPlusPlusOperator.Open(outputJsonFilePath);
        }
    }
}
