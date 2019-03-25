using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESELVeryficator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wpisz PESEL:");
            string pesel = Console.ReadLine();

            PESEL P = new PESEL(pesel);
            Console.WriteLine("Data urodzenia: {0}", P.GetBirthDate());
            Console.WriteLine("Długość PESEL: {0}", P.GetPESELLength());
            Console.Read();
        }
    }
}
