using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider p = new PictureProvider();
            IPicture pic = p.GetPicture("C:\\Users\\Todes\\Desktop\\Cursera\\Fondo.jpg");
            IFilter filter = new FilterGreyscale();
            IFilter filterDos = new FilterNegative();
            IPipe isnull = new PipeNull ();
            IPipe serialDos= new PipeSerial(filterDos,isnull);
            IPipe serial = new PipeSerial(filter, serialDos);

            IPicture pic2 = serial.Send(pic);
            
            IPicture pic3 = serialDos.Send(pic2);
            PictureProvider t = new PictureProvider();
            t.SavePicture(pic3,"C:\\Users\\Todes\\Desktop\\Cursera\\FondoRes6.jpg");


            





        }
    }
}
