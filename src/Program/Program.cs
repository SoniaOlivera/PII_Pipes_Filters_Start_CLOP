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
            
            string consumerKey = "620e818a46524ceb92628cde08068242";
            string consumerKeySecret = "6rc35cHCyqFQSy4vIIjKiCYu31qqkBBkSS5BRlqeYCt5r7zO5B";
            string accessTokenSecret = "gNytQjJgLvurJekVU0wmBBkrR1Th40sJmTO8JDhiyUkuy";
            string accessToken = "1396065818-MeBf8ybIXA3FpmldORfBMdmrVJLVgijAXJv3B18";
            
            var twitter = new TwitterMessage(consumerKey, consumerKeySecret, accessToken, accessTokenSecret);
            twitter.SendMessage("Hola!", "2654205941");

        }
    }
}
