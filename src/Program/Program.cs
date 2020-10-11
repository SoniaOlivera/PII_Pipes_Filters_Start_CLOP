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
            IPicture pic = p.GetPicture("C:\\Users\\FIT\\Pictures\\Screenshots\\Test.png");
            IFilter filter = new FilterGreyscale();
            IPipe isnull = new PipeNull ();
            IPipe serial = new PipeSerial(filter,isnull);
            serial.Send(pic);
            PictureProvider t = new PictureProvider();
            t.SavePicture(pic,"C:\\Users\\FIT\\Pictures\\Screenshots\\Testresult.png");


            





        }
    }
}
