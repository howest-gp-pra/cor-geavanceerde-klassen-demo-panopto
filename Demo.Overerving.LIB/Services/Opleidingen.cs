using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Overerving.LIB.Entiteiten;

namespace Demo.Overerving.LIB.Services
{
    public class Opleidingen
    {
        public List<Opleiding> opleidingen;

        public Opleidingen()
        {
            opleidingen = new List<Opleiding>();
            Seeding();
        }
        private void Seeding()
        {
            opleidingen.Add(new Opleiding() { Naam = "PRB", Studiepunten = 6 });
            opleidingen.Add(new Opleiding() { Naam = "PRA", Studiepunten = 3 });
            opleidingen.Add(new Opleiding() { Naam = "BIT", Studiepunten = 3 });
            opleidingen.Add(new Opleiding() { Naam = "WBE", Studiepunten = 9 });
        }

    }
}
