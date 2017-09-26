using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scythe;

namespace ScytheConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string command = DateTime.Now.ToString();
            Probe.InitializeScythe();

            while (!string.IsNullOrEmpty(command) && command.ToLower() != "x")
            {
                var date = Convert.ToDateTime(command);

                Probe.ScytheProbe("Console_Marker");
                //Probe.SetMarkTime("Console_Marker",date); //Just for testing. this should be Private method.

                command = Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}
