using System;
using System.Configuration;

namespace Server
{
    public static class Globals
    {
        public static int Delay
        {
            get { return ParseDelay(); }
        }

        // returns 200 to 10000 if parsed
        public static int ParseDelay()
        {
            string delay = ConfigurationManager.AppSettings["Delay"];
            int result = 0;
            try
            {
                result = Int32.Parse(delay);
                if (result < 200 || result > 10000)
                {
                    Console.WriteLine("Delay in AppSettings should be in range 200 to 10000");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Can`t parse Delay in AppSettings");
                throw new Exception();
            }
            return result;
        }
    }
}
