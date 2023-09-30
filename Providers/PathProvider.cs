using System;
using System.IO;

namespace HTTPServer.Providers
{
    public sealed class PathProvider
    {
        private static readonly string _solution;

        static PathProvider()
        {
            _solution = File.ReadAllText("../../../solutionpath.txt").Replace(Environment.NewLine, string.Empty);
        }

        public static string Solution => _solution ?? string.Empty;

        public static string Configuration => Path.Combine(_solution, "appsettings.json");
    }
}