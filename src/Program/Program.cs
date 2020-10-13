using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider p = new PictureProvider();
            IPicture pic = p.GetPicture("..\\..\\ImagenPruebas.jpg");
            IFilter filter = new FilterGreyscale();
            IFilter filterDos = new FilterNegative();
            IPipe isnull = new PipeNull ();

            IPipe serialDos= new PipeSerial(filterDos,isnull);
            IPipe serial = new PipeSerial(filter, serialDos);
            
            IPicture pic2 = serial.Send(pic);
            IPicture pic3 = serialDos.Send(pic2);
            
            PictureProvider t = new PictureProvider();
            t.SavePicture(pic2,"..\\..\\ImagenPruebas1.jpg");
            t.SavePicture(pic3,"..\\..\\ImagenPruebas2.jpg");
            
            

        }
    }
}
