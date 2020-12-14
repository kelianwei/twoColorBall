using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
                List<int> blueBall = Enumerable.Range(1, 16).OrderBy(x => Guid.NewGuid().GetHashCode()).Take(1).ToList();
                List<int> myRedBalls = Enumerable.Range(1, 33).OrderBy(x => Guid.NewGuid().GetHashCode()).Take(6).ToList();
                List<int> myBlueBall = Enumerable.Range(1, 16).OrderBy(x => Guid.NewGuid().GetHashCode()).Take(1).ToList();
                redBalls.Sort(); myRedBalls.Sort();
                if (Enumerable.SequenceEqual(redBalls, myRedBalls) && myBlueBall.SequenceEqual(blueBall))
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
