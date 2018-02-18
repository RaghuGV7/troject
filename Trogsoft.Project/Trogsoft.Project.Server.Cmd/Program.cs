using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trogsoft.Project.Server.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://+:16119"))
            {
                Console.ReadLine();
            }
        }
    }
}
