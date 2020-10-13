using TwitterUCU;
using System;

namespace CompAndDel
{
    public class Twitter
    {
        
        private string text;
        private string image;
        private string ConsumerKey = "CkovShLMNVCY0STsZlcRUFu99";
        private string ConsumerKeySecret = "6rc35cHCyqFQSy4vIIjKiCYu31qqkBBkSS5BRlqeYCt5r7zO5B";
        private string AccessTokenSecret = "gNytQjJgLvurJekVU0wmBBkrR1Th40sJmTO8JDhiyUkuy";
        private string AccessToken = "1396065818-MeBf8ybIXA3FpmldORfBMdmrVJLVgijAXJv3B18";
        
        public Twitter(string texto, string img)
        {

            text = texto;
            image = img;

        }
        public void publicar()
        {
            
            var twitter = new TwitterImage(ConsumerKey, ConsumerKeySecret, AccessToken, AccessTokenSecret);
            Console.WriteLine(twitter.PublishToTwitter(text,image));
        }
        
    }
}