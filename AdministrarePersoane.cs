using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GestionareBiblioteca
{
    class AdministrarePersoane : IStocarePersoane
    {
        string NumeFisier { get; set; }

        public AdministrarePersoane(string numeFisier)
        {
            this.NumeFisier = numeFisier;
            using (Stream fisier = File.Open(numeFisier, FileMode.OpenOrCreate)) { }
        }

        public void AddPersoana(Persoana p)
        {
            using (StreamWriter scriere = new StreamWriter(NumeFisier, true))
            {
                scriere.WriteLine(p.ConversieLaSir_ptFisier());
            }
        }
        public List<Persoana> GetPersoane()
        {
            List<Persoana> persoane = new List<Persoana>();

            using (StreamReader sr = new StreamReader(NumeFisier))
            {
                string line;

                //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                while ((line = sr.ReadLine()) != null)
                {

                    Persoana persDinFisier = new Persoana(line);
                    persoane.Add(persDinFisier);
                }
            }

            return persoane;
        }
        public void ModificarePersoane(string linieDeModificat, string liniaModificata, List<Persoana> persoane)
        {
            string[] liniiCitite = new string[persoane.Count];
            int i = 0;
            using (StreamReader citire = new StreamReader(NumeFisier))
            {
                string line;

                while ((line = citire.ReadLine()) != null)
                {
                    Persoana persoana = new Persoana(line);
                    liniiCitite[i] = line;
                    i++;
                }
            }
            i = 0;
            using (StreamWriter scriere = new StreamWriter(NumeFisier))
            {
                string linie = null;
                while (i < persoane.Count && (linie = liniiCitite[i]) != null)
                {

                    if (String.Compare(linie, linieDeModificat) == 0)
                    {
                        scriere.WriteLine(liniaModificata);
                        i++;
                        continue;
                    }
                    scriere.WriteLine(linie);
                    i++;
                }
            }

        }
        public void StergereDate()
        {
            File.WriteAllText(NumeFisier, String.Empty);
        }
        public void StergeLinie(int nr_linie, List<Persoana> persoane)
        {

            string[] liniiCitite = new string[persoane.Count];
            int nr_linieCurenta = 0;
            int i = 0;
            using (StreamReader citire = new StreamReader(NumeFisier))
            {
                string line = null;

                while ((line = citire.ReadLine()) != null)
                {
                    Carte carteDinFisier = new Carte(line);
                    liniiCitite[i] = line;
                    i++;
                }
            }
            i = 0;
            using (StreamWriter scriere = new StreamWriter(NumeFisier))
            {
                string linie = null;
                while (i < persoane.Count && (linie = liniiCitite[i]) != null)
                {

                    nr_linieCurenta++;

                    if (nr_linieCurenta == nr_linie)
                        continue;
                    scriere.WriteLine(linie);
                    i++;
                }
            }
        }

    }

}
