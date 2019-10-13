using System.Collections.Generic;

namespace CSharp8.Features
{
    public class UsingDeclaration
    {
        static void WriteLinesToFile(IEnumerable<string> lines)
        {
            using var file = new System.IO.StreamWriter("WriteLines.txt");
            foreach (string line in lines)
            {
                if (!line.Contains("Second"))
                {
                    file.WriteLine(line);
                }
            }
            // file is disposed here
        }
    }
}