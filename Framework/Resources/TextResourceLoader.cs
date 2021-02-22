using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hx001.Framework.Resources
{
    public class TextResourceLoader : ResourceLoader
    {

        private static List<string> _supportedExtenstions = new List<string>() { ".png", ".jpeg", ".jpg", ".bmp", ".txt", "" };

        private Dictionary<string, string[]> _textfiles = new Dictionary<string, string[]>();

        public TextResourceLoader()
        {
            
        }

        public string[] Get(string key)
        {
            if (!Has(key))
            {
                return null;
            }
            key = key.ToLower();
            return _textfiles[key];
        }

        public bool Has(string key)
        {
            key = key.ToLower();
            return _textfiles.ContainsKey(key);
        }

        public void Add(string key, string[] content)
        {
            if (Has(key) || content == null || content.Length == 0)
            {
                return;
            }
            key = key.ToLower();
            _textfiles.Add(key, content);
        }

        public void LoadResources(string resourcePath)
        {
            //Load resources

            string root = Globals.ResourcePath;
            string path = Path.Combine(root, resourcePath);

            path = path.Replace(@"\", "/");
            root = root.Replace(@"\", "/");

            if (!Directory.Exists(path))
            {
                Console.WriteLine("Could not find " + path);
                return;
            }

            //FileStream fileStream = null;

            foreach (string file in DirectoryExpander.GetAllFiles(path))
            {
                string extension = Path.GetExtension(file);

                //if (!_supportedExtenstions.Contains(extension))
                //{
                    //continue;
                //}

                //fileStream = new FileStream(file, FileMode.Open);

                string[] lines = File.ReadAllLines(file);
                //byte[] data = File.ReadAllBytes(file);
                //StreamReader sr = new StreamReader(file);
                //string text = sr.ReadToEnd();
                //sr.Close();

                //Console.WriteLine(text.Replace('\0', ' '));

                //string s = Encoding.ASCII.GetString(data);
                //Console.WriteLine(s);
                //foreach (string line in lines)
                //{
                    //Console.WriteLine("\t" + line);
                //}
                //foreach (byte b in data)
                //{
                  //  Console.WriteLine("\t" + b);
                //}

                string prepaired = file.Replace(path + "/", "").Replace(extension, "").ToLower();
                Add(prepaired, lines);
                Console.WriteLine("Text " + prepaired + " geladen...");
            }

            //fileStream.Dispose();

        }

    }
}
