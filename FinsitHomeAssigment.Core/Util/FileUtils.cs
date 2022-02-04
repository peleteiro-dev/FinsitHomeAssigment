using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FinsitHomeAssigment.Core.Util
{
    public static class FileUtils
    {
        public static string GetAssemblyFullPath() => Assembly.GetExecutingAssembly().Location;
        public static string GetAssemblyDir() => Path.GetDirectoryName(GetAssemblyFullPath());
        public static string JoinPaths(string path1, string path2) => Path.Join(path1, path2);
        public static IEnumerable<string> ReadFile(string filePath) => File.ReadAllLines(filePath).ToList();

        public static void ExistsOrThrow(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File {filePath} not found");
        }
    }
}
