using System.Drawing;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;


namespace CompAndDel
{ 
    public class PictureProvider
    {
        private Twitter publicacion = null;
        public IPicture GetPicture(string imgPath)
        {
            publicacion = new Twitter("", imgPath);
            Picture p = new Picture(1,1);
            using (var img = Image.Load(imgPath))
            {
                p.Resize(img.Width,img.Height);
                for (int h = 0;h <img.Height; h++)
                {
                    for (int w = 0;w <img.Width; w++)
                    {
                        p.SetColor(w,h,System.Drawing.Color.FromArgb(img[w,h].A, img[w,h].R, img[w,h].G, img[w,h].B));
                    }
                }
            }
            if (publicacion != null)
            {
               publicacion.publicar(); 
            }
            return p;

        }
        public void SavePicture(IPicture p, string path)
        {
            publicacion = new Twitter("", path);
            int width = p.Width;
            int height = p.Height;
            using(Image<Rgba32> img = new Image<Rgba32>(width, height)) // creates a new image with all the pixels set as transparent 
            {
                for (int h = 0;h <p.Height; h++)
                {
                    for (int w = 0;w <p.Width; w++)
                    {
                        Color c = p.GetColor(w,h);
                        img[w,h] = new Rgba32(c.R,c.G,c.B,c.A);
                    }
                }
                img.Save(path);
            }
            if (publicacion != null)
            {
               publicacion.publicar(); 
            }
            
        }
        public void Persist(IPicture image, string pathToPersist)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image,pathToPersist);
        }
    }
}