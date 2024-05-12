using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_vezba
{

    enum Kvalitet
    {
        Prihvatljiv = 1,
        Dobar = 2,
        Odlican = 3,
    }
    internal class Jelo : Stavka
    {
        protected double nabavna_cena;
        protected Kvalitet kvalitet;

        public Jelo() : base() { }
        public Jelo(string naziv, DateTime datum, bool veganska, double nabavna_cena, Kvalitet kvalitet) : base(naziv, datum, veganska)
        {
            this.nabavna_cena = nabavna_cena;
            this.kvalitet = kvalitet;
        }

        public override double Cena
        {
            get {
            if((datum - DateTime.Now).Days <= 3)
                {
                    return (nabavna_cena * (int)kvalitet * 0.8);
                }
                else
                {
                    return (nabavna_cena * (int)kvalitet);
                }
            }
        }
        public override void BinarnoCitanje(BinaryReader fajl)
        {
                    base.BinarnoCitanje (fajl);
                    nabavna_cena = fajl.ReadDouble();
                    kvalitet = (Kvalitet)fajl.ReadInt32();
        }

        public override void BinarniUpis(BinaryWriter fajl)
        {
                    fajl.Write('j');
                    base.BinarniUpis (fajl);
                    fajl.Write(nabavna_cena);
                    fajl.Write((int)kvalitet);
        }
    }
}
