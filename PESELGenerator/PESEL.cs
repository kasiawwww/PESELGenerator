using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESELVeryficator
{
    public class PESEL
    {
        private string _pesel;
        private int genderValue;
        private string genderInfo;
        private DateTime dateValue;
        private bool isNumeric = true;
        private const int PESELLength = 11;
        private List<int> peselNumbers = new List<int>();
        private int controlNumber;

        public PESEL(string pesel)
        {
            _pesel = pesel;
        }

        public string GetBirthDate()
        {
             if (!DateTime.TryParseExact(this._pesel.Substring(0, 6), "yymmdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                 throw new FormatException("Date of birth is not in correct format");
             return dateValue.ToString("dd-mm-yy");
        }

        public string GetGender()
        {
             try
             {
                genderValue = int.Parse(this._pesel.Substring(9, 1));
                if (genderValue % 2 == 0)
                    genderInfo = "K";
                if (genderValue % 2 == 1)
                    genderInfo = "M";
             }
             catch (Exception)
             {
                throw new FormatException("Gender information");
             }
             return genderInfo;
        }

        public int GetPESELLength()
        {
            if (this._pesel.Length != PESELLength)
                throw new IndexOutOfRangeException("Pesel Length");
            return this._pesel.Length;
        }
        public bool IsOnlyNumeric()
        {
            foreach(var p in this._pesel)
            {
                try
                {
                    int.Parse(p.ToString());                                      
                }
                catch (Exception)
                {
                    isNumeric = false;
                    throw new IndexOutOfRangeException("Only numeric");                  
                }
            }
            return isNumeric;
        }
        public bool CheckControlNumber()
        {

            foreach (var p in this._pesel)
            {
               peselNumbers.Add(int.Parse(p.ToString()));
            }

            controlNumber = 9 * peselNumbers[0] + 7 * peselNumbers[1] + 3 * peselNumbers[2] + 1 * peselNumbers[3] + 9 * peselNumbers[4] +
                    7 * peselNumbers[5] + 3 * peselNumbers[6] + 1 * peselNumbers[7] + 9 * peselNumbers[8] + 7 * peselNumbers[9];

            if (controlNumber % 10 == peselNumbers[10])
                return true;

            return false;

        }
    }
}
