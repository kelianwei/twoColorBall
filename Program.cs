using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
namespace twocolorball
{
    internal class Program
    {
        private static void Main(string[] args)
        {
           
            bool yes = false;
            int n = 0;
            string r = "";
            while (!yes)
            {
                List<int> redBalls = Enumerable.Range(1, 33).OrderBy(x => Guid.NewGuid().GetHashCode()).Take(6).ToList();
                int blueBall = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0)).Next(1, 16);

                List<int> myRedBalls = Enumerable.Range(1, 33).OrderBy(x => Guid.NewGuid().GetHashCode()).Take(6).ToList();
                int myBlueBall = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0)).Next(1, 16);

                if (Enumerable.SequenceEqual(redBalls.OrderBy(i => i), myRedBalls.OrderBy(i => i)) && blueBall == myBlueBall)
                {
                    r = JsonConvert.SerializeObject(new { redBalls, blueBall, myRedBalls, myBlueBall });
                    yes = true;
                };
                n++;
            }
            Console.WriteLine(n);
            Console.WriteLine(r);
            Console.ReadKey();
        }
    }
}
