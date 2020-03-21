using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Overerving.LIB.Helper
{
    public class MijnHelper
    {
        public static string NameCleaner(string teVerwerkenTekst, string spatieSubstitutie)
        {
            string retourwaarde = "";
            string letter;
            char cletter;
            byte bletter;
            teVerwerkenTekst = teVerwerkenTekst.ToLower();
            for (int r = 0; r < teVerwerkenTekst.Length; r++)
            {
                letter = teVerwerkenTekst.Substring(r, 1);
                cletter = Convert.ToChar(letter);
                bletter = Convert.ToByte(cletter);

                if (letter == " ") retourwaarde += spatieSubstitutie;
                else if (letter == "é" || letter == "è" || letter == "ë" || letter == "ê") retourwaarde += "e";
                else if (letter == "ï" || letter == "î") retourwaarde += "i";
                else if (letter == "ä" || letter == "â" || letter == "à") retourwaarde += "a";
                else if (letter == "ö" || letter == "ô") retourwaarde += "o";
                else if (letter == "ù" || letter == "ü" || letter == "û") retourwaarde += "u";
                else if (letter == "ÿ") retourwaarde += "y";
                else if (letter == "ç") retourwaarde += "c";
                else if (bletter >= 97 && bletter <= 122) retourwaarde += letter;


            }
            return retourwaarde;
        }
    }
}
