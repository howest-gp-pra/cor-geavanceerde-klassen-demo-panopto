using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Overerving.LIB.Helper;


namespace Demo.Overerving.LIB.Entiteiten
{
    public class Cursist : Persoon
    {
        public new string EmailSchool { get; }

        public List<Opleiding> TeVolgenCursussen { get; set; }
        public Cursist(string naam, string voornaam, DateTime? geboortedatum, char geslacht):base(naam, voornaam, geboortedatum, geslacht)
        {
            EmailSchool = MijnHelper.NameCleaner(voornaam + " " + naam, ".") + "@student.howest.be";
            TeVolgenCursussen = new List<Opleiding>();
        }
    }
}
