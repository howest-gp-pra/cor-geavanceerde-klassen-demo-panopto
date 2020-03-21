using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Overerving.LIB.Helper;

namespace Demo.Overerving.LIB.Entiteiten
{
    public class Persoon
    {
        private string naam;
        private string voornaam;
        private char geslacht;
        private string gender;
        private string emailschool;
        private string sorteernaam;

        public string Naam
        {
            get
            {
                return naam;
            }
            set
            {
                naam = value;
                MaakSorteernaam();
                MaakEmailSchool();
            }
        }
        public string Voornaam
        {
            get { return voornaam; }
            set
            {
                voornaam = value;
                MaakSorteernaam();
                MaakEmailSchool();
            }
        }
        public DateTime? Geboortedatum { get; set; }
        public char Geslacht
        {
            get { return geslacht; }
            set {
                if (value.ToString().ToUpper() == "M" || value.ToString().ToUpper() == "V")
                    geslacht = value;
                else
                    geslacht = 'O';
                gender = "Onbekend";
                if (geslacht == 'M')
                    gender = "Man";
                else if (geslacht == 'V')
                    gender = "Vrouw";
            }
        }
        public string Gender
        {
            get { return gender; }
        }
        public string EmailSchool
        {
            get { return emailschool; }
        }
        public string Sorteernaam
        {
            get { return sorteernaam; }
        }

        public Persoon(string naam, string voornaam, DateTime? geboortedatum, char geslacht)
        {
            Naam = naam;
            Voornaam = voornaam;
            Geboortedatum = geboortedatum;
            Geslacht = geslacht;
            MaakSorteernaam();
            MaakEmailSchool();
        }

        public override string ToString()
        {
            return $"{naam} {voornaam}";
        }
        private void MaakSorteernaam()
        {
            sorteernaam = MijnHelper.NameCleaner(naam + voornaam, "");

        }
        private void MaakEmailSchool()
        {
            emailschool = MijnHelper.NameCleaner(voornaam + " " + naam, ".") + "@howest.be";

        }

    }
}
