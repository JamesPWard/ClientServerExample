using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleClient sc = new SimpleClient();

            if (sc.Connect("127.0.0.1", 1337))
            {
                sc.Run();
                Console.WriteLine("Client Started");
            }
            else
            {
                Console.WriteLine("Client failed to connect!");
            }
            
        }
    }
}