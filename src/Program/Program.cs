using System;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider p = new PictureProvider();
            IPicture pic = p.GetPicture("C:\\Users\\FIT\\Pictures\\Screenshots\\Test.jpg");
            IPipe.Send(pic);
            





        }
    }
}
