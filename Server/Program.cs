using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleServer ss = new SimpleServer("127.0.0.1", 1337);

            ss.Start();
            //ss.Stop();
        }
    }
}