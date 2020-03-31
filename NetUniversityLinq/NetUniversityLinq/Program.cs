using System;
using System.Collections.Generic;
using System.Linq;

namespace NetUniversityLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayInt = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<string> listString = new List<string>();
            listString.Add("Maria");
            listString.Add("Manuel");
            listString.Add("Alberto");
            listString.Add("Roberto");

            var nombresConM = Enumerable.Where(listString, p => p.ToUpper().StartsWith("M"));

            foreach (var item in nombresConM)
            {
                Console.WriteLine(item);

            }


            Console.ReadLine();
        }
    }
}
