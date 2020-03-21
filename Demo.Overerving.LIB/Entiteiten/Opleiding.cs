using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Overerving.LIB.Entiteiten
{
    public class Opleiding
    {
        public string Naam { get; set; }
        public int Studiepunten { get; set; }

        public override string ToString()
        {
            return $"{Naam} ({Studiepunten}SP)";
        }
    }
}
