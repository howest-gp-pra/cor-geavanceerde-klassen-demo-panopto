using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Overerving.LIB.Entiteiten
{
    public class Docent : Persoon
    {
        public List<Opleiding> Opdrachten;
        public Docent(string naam, string voornaam, DateTime? geboortedatum, char geslacht) : base(naam, voornaam, geboortedatum, geslacht)
        {
            Opdrachten = new List<Opleiding>();
        }



    }
}
