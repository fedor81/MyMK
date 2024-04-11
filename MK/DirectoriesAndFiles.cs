using System.Collections.Generic;
using System.IO;

namespace MK;

public class DirectoriesAndFiles
{
    public static Dictionary<string, string[]> GetFilesInDirectories(string startPath)
    {
        var result = new Dictionary<string, string[]>();
        var queue = new Queue<string>();
        queue.Enqueue(startPath);

        while (queue.Count > 0)
        {
            var currentPath = queue.Dequeue();
            var files = Directory.GetFiles(currentPath);
            if (files.Length > 0)
                result[currentPath] = files;

            foreach (var path in Directory.GetDirectories(currentPath))
            {
                queue.Enqueue(path);
            }
        }

        return result;
    }
}