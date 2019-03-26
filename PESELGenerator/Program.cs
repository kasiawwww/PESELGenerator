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
            Console.WriteLine("Birth date: {0}", P.GetBirthDate());
            Console.WriteLine("Gender: {0}", P.GetGender());
            Console.WriteLine("PESEL length: {0}", P.GetPESELLength());
            Console.WriteLine("Is only numeric: {0}", P.IsOnlyNumeric());
            Console.WriteLine("Is control number valid: {0}", P.CheckControlNumber());
            Console.Read();
        }
    }
}
