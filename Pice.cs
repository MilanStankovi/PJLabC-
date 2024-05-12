using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_vezba
{
    enum Vrsta
    {
        domace,
        uvozno
    }
    internal class Pice : Stavka
    {
        protected int kolicina;
        protected double cena_po_litru;
        protected Vrsta vrsta;

        public Pice() : base() { }
        public Pice(string naziv, DateTime datum, bool veganska, int kolicina, double cena_po_litru, Vrsta vrsta) : base(naziv,datum,veganska)
        {
            this.kolicina = kolicina;
            this.cena_po_litru = cena_po_litru;
            this.vrsta = vrsta;
        }

        public override double Cena
        {
            get
            {
                double cena = cena_po_litru * kolicina;
                if (vrsta == Vrsta.uvozno)
                {
                    return (cena * 1.3);
                }
                else
                {
                    return cena;
                }
            }
        }
        public override void BinarniUpis(BinaryWriter fajl)
        {
                    fajl.Write('p');
                    base.BinarniUpis (fajl);
                    fajl.Write(kolicina);
                    fajl.Write(cena_po_litru);
                    fajl.Write((int)vrsta);
        }
        public override void BinarnoCitanje(BinaryReader fajl)
        {
                    base.BinarnoCitanje (fajl);
                    kolicina = fajl.ReadInt32();
                    cena_po_litru = fajl.ReadDouble();
                    vrsta = (Vrsta)fajl.ReadInt32();
        }
    }
}
