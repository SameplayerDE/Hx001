using System.Collections.Generic;
using System.IO;

namespace Hx001.Framework
{
    public static class DirectoryExpander
    {
        public static string[] GetAllDirectories(string path)
        {
            List<string> dirs = new List<string>();
            GetDirectories(path, ref dirs);
            return dirs.ToArray();
        }
        private static void GetDirectories(string path, ref List<string> dirs)
        {
            foreach (string directory in Directory.GetDirectories(path))
            {
                string prepaired = directory.Replace(@"\", "/");
                dirs.Add(prepaired);
                if (Directory.GetDirectories(prepaired).Length != 0)
                {
                    GetDirectories(prepaired, ref dirs);
                }
            }
        }
        public static string[] GetAllFiles(string path)
        {
            List<string> files = new List<string>();
            string[] dirs = GetAllDirectories(path);
            //files.AddRange(Directory.GetFiles(path));
            foreach (string file in Directory.GetFiles(path))
            {
                string prepaired = file.Replace(@"\", "/");
                files.Add(prepaired);
            }
            foreach (string dir in dirs)
            {
                foreach (string file in Directory.GetFiles(dir))
                {
                    string prepaired = file.Replace(@"\", "/");
                    files.Add(prepaired);
                }
            }
            return files.ToArray();
        }
    }
}