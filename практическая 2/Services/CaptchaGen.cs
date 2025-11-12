using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace практическая_2.Services
{
    internal class CaptchaGen
    {
        private static readonly Random rand = new Random();
        private const string Characters = 
            "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static string GenCaptcha(int length)
        {
            if (length <= 0)
                throw new ArgumentException("Доина капчи должна быть больше нуля");

            StringBuilder capcha = new StringBuilder(length);
            for(int i=0; i<length; i++)
            {
                int index = rand.Next(Characters.Length);
                capcha.Append(Characters[index]);
            }
            return capcha.ToString();
        }
    }
}
