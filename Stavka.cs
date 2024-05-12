using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_vezba
{
    abstract class Stavka : IComparable<Stavka>
    {
        protected string naziv;
        protected DateTime datum;
        protected bool veganska;

        public Stavka()
        {

        }
        public Stavka(string naziv, DateTime datum, bool veganska)
        {
            this.naziv = naziv;
            this.datum = datum;
            this.veganska = veganska;
        }

        public DateTime Datum
        {
            get { return datum; }
        }

        public bool Veganska
        {
            get { return veganska;}
        }
        public abstract double Cena
        {
            get;
        }
        public virtual void BinarniUpis(BinaryWriter fajl)
        {
                    fajl.Write(naziv);
                    fajl.Write(datum.Ticks);
                    fajl.Write(veganska);
        }
        public virtual void BinarnoCitanje(BinaryReader fajl)
        {
                    naziv = fajl.ReadString();
                    datum = new DateTime(fajl.ReadInt64());
                    veganska = fajl.ReadBoolean();
        }
        public virtual void prikaz()
        {
            Console.WriteLine("Naziv: " + naziv);
            Console.WriteLine("Cena: " + Cena);
        }

        int IComparable<Stavka>.CompareTo(Stavka other)
        {
            if (this.Cena < other.Cena) return -1;
            if (this.Cena > other.Cena) { return 1; }
            return 0;
        }
    }
}
