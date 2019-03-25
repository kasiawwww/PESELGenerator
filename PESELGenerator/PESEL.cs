using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESELVeryficator
{
    class PESEL
    {
        private string _pesel;
        private int genderValue;
        private string genderInfo;
        private DateTime dateValue;
        private bool isNumeric = true;
        private const int PESELLength = 11;

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
                genderValue = int.Parse(this._pesel.Substring(10, 1));
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
            if (this._pesel.Length == PESELLength)
                throw new IndexOutOfRangeException("Pesel Length");
            return this._pesel.Length;
        }
        public bool IsOnlyNumeric()
        {
            foreach(var p in this._pesel)
            {
                try
                {
                    Int32.Parse(p.ToString());                                      
                }
                catch (Exception)
                {
                    isNumeric = false;
                    throw new IndexOutOfRangeException("Only numeric");
                    
                }
            }
            return isNumeric;
        }
    }
}
