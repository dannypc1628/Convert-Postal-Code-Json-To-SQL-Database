using System;
using System.IO;

namespace Convert_Postal_Code_Json_To_SQL_Database
{
    class Program
    {
        static void Main()
        {
            string data = File.ReadAllText("pastial_code.json");

            MyService myService = new MyService(data);
            myService.Start();

            Console.ReadKey();
        }
    }
}
