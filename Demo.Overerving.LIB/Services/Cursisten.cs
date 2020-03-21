using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Overerving.LIB.Entiteiten;

namespace Demo.Overerving.LIB.Services
{
    public class Cursisten
    {
        public List<Cursist> cursisten;

        public Cursisten()
        {
            cursisten = new List<Cursist>();
            Seeding();
        }

        private void Seeding()
        {
            cursisten.Add(new Cursist("Carpels", "Joris", DateTime.Parse("15/02/1987"), 'M'));
            cursisten.Add(new Cursist("Willems", "Rita", DateTime.Parse("16/03/1992"), 'V'));
            cursisten.Add(new Cursist("Vandendorpe", "Karel", DateTime.Parse("17/04/1999"), 'M'));
            cursisten.Add(new Cursist("Michiels", "Wim", DateTime.Parse("18/05/2003"), 'M'));
            cursisten.Add(new Cursist("Bonne", "Elizabeth", DateTime.Parse("19/06/1998"), 'V'));
            cursisten.Add(new Cursist("Dobbelaere", "Benthe", DateTime.Parse("20/07/1998"), 'V'));
            cursisten.Add(new Cursist("Hamers", "Hannes", DateTime.Parse("15/02/1987"), 'M'));
            cursisten.Add(new Cursist("Tudor", "Hendrika", DateTime.Parse("16/03/1992"), 'V'));
            cursisten.Add(new Cursist("Poulidor", "Henk", DateTime.Parse("17/04/1999"), 'M'));
            cursisten.Add(new Cursist("Brutus", "Vlad", DateTime.Parse("18/05/2003"), 'M'));
            cursisten.Add(new Cursist("Mando", "Lien", DateTime.Parse("19/06/1998"), 'V'));
            cursisten.Add(new Cursist("Crabbe", "Bernice", DateTime.Parse("20/07/1998"), 'V'));
        }
    }
}
