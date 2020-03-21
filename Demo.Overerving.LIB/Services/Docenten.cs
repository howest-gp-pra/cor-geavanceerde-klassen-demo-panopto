using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Overerving.LIB.Entiteiten;

namespace Demo.Overerving.LIB.Services
{
    public class Docenten
    {
        public List<Docent> docenten;

        public Docenten()
        {
            docenten = new List<Docent>();
            Seeding();
        }

        private void Seeding()
        {
            docenten.Add(new Docent("Boma", "Boris", DateTime.Parse("05/11/1978"), 'M'));
            docenten.Add(new Docent("Merkel", "Marie Hélène", DateTime.Parse("25/11/1987"), 'V'));
            docenten.Add(new Docent("Klein", "Kevin", DateTime.Parse("25/12/1992"), 'M'));

        }
    }
}
