using System;
using Scythe;

namespace ScytheConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = DateTime.Now.ToString();
            Probe.Initialize();

            while (!string.IsNullOrEmpty(input) && input.ToLower() != "x")
            {
                var date = Convert.ToDateTime(input);

                Probe.ScytheProbe("Console_Marker");
                //Probe.SetMarkTime("Console_Marker",date); //Just for testing. this should be Private method.

                input = Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}
