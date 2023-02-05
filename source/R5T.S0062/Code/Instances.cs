using System;


namespace R5T.S0062
{
    public static class Instances
    {
        public static Z0015.IFilePaths FilePaths => Z0015.FilePaths.Instance;
        public static F0000.IFileSystemOperator FileSystemOperator => F0000.FileSystemOperator.Instance;
        public static F0032.IJsonOperator JsonOperator => F0032.JsonOperator.Instance;
        public static F0033.INotepadPlusPlusOperator NotepadPlusPlusOperator => F0033.NotepadPlusPlusOperator.Instance;
        public static F0102.IOperations Operations => F0102.Operations.Instance;
        public static F0002.IPathOperator PathOperator => F0002.PathOperator.Instance;
        public static F0052.IProjectPathsOperator ProjectPathsOperator => F0052.ProjectPathsOperator.Instance;
        public static F0016.F001.IProjectReferencesOperator ProjectReferencesOperator => F0016.F001.ProjectReferencesOperator.Instance;
    }
}