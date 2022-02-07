using System;
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
        public static IEnumerable<string> ReadFileAsLines(string filePath) => File.ReadAllLines(filePath).ToList();
        public static string ReadFileAsString(string filePath) => File.ReadAllText(filePath);

        public static string ValidateFile(string filePath, IEnumerable<string> validExtensions)
        {
            if (!Exists(filePath))
                return ($"File { filePath } not found.");

            var extension = GetFileExtension(filePath);
            var extensions = validExtensions.ToList();
            if (!extensions.Contains(extension))
                return ($"Invalid file type ({extension}), only accepted {string.Join(", ", extensions)}.");

            return null;
        }

        public static bool Exists(string filePath)
        {
            return File.Exists(filePath);
        }

        public static string GetFileExtension(string path)
        {
            var dotIndex = path.LastIndexOf(".", StringComparison.Ordinal);

            return dotIndex == -1 ? null : path.Substring(dotIndex + 1);
        }
    }
}
