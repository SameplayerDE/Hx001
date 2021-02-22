using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Hx001.Framework.Resources
{
public class TextureResourceLoader
    {

        private static List<string> _supportedExtenstions = new List<string>() { ".png", ".jpeg", ".jpg", ".bmp" };

        private GraphicsDevice _graphicsDevice = null;
        private Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();

        public TextureResourceLoader(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public Texture2D Get(string key)
        {
            if (!Has(key))
            {
                return null;
            }
            key = key.ToLower();
            return _textures[key];
        }

        public bool Has(string key)
        {
            key = key.ToLower();
            return _textures.ContainsKey(key);
        }

        public void Add(string key, Texture2D texture)
        {
            if (Has(key) || texture == null)
            {
                return;
            }
            key = key.ToLower();
            _textures.Add(key, texture);
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

            FileStream fileStream = null;

            foreach (string file in DirectoryExpander.GetAllFiles(path))
            {
                string extension = Path.GetExtension(file);

                if (!_supportedExtenstions.Contains(extension))
                {
                    continue;
                }

                fileStream = new FileStream(file, FileMode.Open);
                Texture2D Texture = Texture2D.FromStream(_graphicsDevice, fileStream);


                string prepaired = file.Replace(path + "/", "").Replace(extension, "").ToLower();
                Add(prepaired, Texture);
                Console.WriteLine("Grafik " + prepaired + " geladen...");
            }

            fileStream.Dispose();

        }

        public static Texture2D CreateTexture(GraphicsDevice graphicsDevice, int width, int height, Func<int, Color> paint)
        {
            //initialize a texture
            Texture2D texture = new Texture2D(graphicsDevice, width, height);

            //the array holds the color for each pixel in the texture
            Color[] data = new Color[width * height];
            for (int pixel = 0; pixel < data.Length; pixel++)
            {
                //the function applies the color according to the specified pixel
                data[pixel] = paint(pixel);
            }

            //set the color
            texture.SetData(data);

            return texture;
        }

    }
}