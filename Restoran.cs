using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_vezba
{
    internal class Restoran
    {
        private string naziv;
        List<Stavka> meni;

        public Restoran(string n)
        {
            this.naziv = n;
            meni = new List<Stavka>();
        }
        public void dodaj(Stavka stavka)
        {
            meni.Add(stavka);
        }

        public void sortiraj()
        {
            //meni.Sort((x,y) => x.Cena.CompareTo(y.Cena));
            meni.Sort();
        }

        public void izbaci()
        {
            //meni.RemoveAll(Stavka => Stavka.Datum < DateTime.Now);
            int i = 0;
            while (i < meni.Count)
            {
                if (meni[i].Datum < DateTime.Now)
                {
                    meni.Remove(meni[i]);
                }
                else
                {
                    i++;
                }
            }
        }

        public void ProveriVeganskeStavke()
        {
            /*if (!meni.Any(Stavka => Stavka.Veganska))
            {
                throw new VeganUnfriendly("U restoranu nema veganskih stavki.");
            }*/
            int k = 0;
            foreach(Stavka stavka in meni)
            {
                if(stavka.Veganska)
                {
                    k = 1;
                }
            }
            if(k == 0)
            {
                throw new VeganUnfriendly("U restoranu nema veganskih stavki.");
            }
        }

        public void upis(string putanja)
        {
            try
            {
                using (BinaryWriter upisi = new BinaryWriter(new FileStream(putanja, FileMode.Create)))
                {
                    upisi.Write(meni.Count);
                    upisi.Write(naziv);
                    foreach (var stavka in meni)
                    {
                        stavka.BinarniUpis(upisi);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void citanje(string putanja)
        {
            try
            {
                using (BinaryReader citaj = new BinaryReader(new FileStream(putanja, FileMode.Open)))
                {
                    int duzina = citaj.ReadInt32();
                    naziv = citaj.ReadString();
                    meni.Clear();
                    for(int i=0;i<duzina; i++)
                    {
                        char tip = citaj.ReadChar();
                        Stavka stavka;
                        if(tip == 'j')
                        {
                            stavka = new Jelo();
                        }
                        else
                        {
                            stavka = new Pice();
                        }
                        stavka.BinarnoCitanje(citaj);
                        meni.Add(stavka);
                    }
                }
            }
            catch(IOException e) { Console.WriteLine(e.Message); }
        }
        public void print()
        {
            foreach(var stavka in meni)
            {
                stavka.prikaz();
            }
        }
    }
}
