using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banto
{
    internal class Dominio
    {
        public double PesoConceitual { get; set; }
        public List<string> Expressoes { get; set; }

        public Dominio()
        {
            this.Expressoes = new List<string>();
        }

        public Dominio(double peso)
        {
            this.PesoConceitual = peso;
            this.Expressoes = new List<string>();
        }
    }
}
