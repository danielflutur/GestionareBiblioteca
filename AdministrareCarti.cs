using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GestionareBiblioteca
{
    class AdministrareCarti : IStocareCarti
    {
        string NumeFisier { get; set; }

        public AdministrareCarti(string numeFisier)
        {
            this.NumeFisier = numeFisier;
            using (Stream fisier = File.Open(numeFisier, FileMode.OpenOrCreate)) { }
        }
        public void AddCarte(Carte c1)
        {
            using (StreamWriter fisier = new StreamWriter(NumeFisier, true))
            {
                fisier.WriteLine(c1.ConversieLaSir_ptFisier());
            }
        }

        public List<Carte> GetCarti()
        {
            List<Carte> carti = new List<Carte>();

            using (StreamReader sr = new StreamReader(NumeFisier))
            {
                string line;

                //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                while ((line = sr.ReadLine()) != null)
                {

                    Carte carteDinFisier = new Carte(line);
                    carti.Add(carteDinFisier);
                }
            }

            return carti;
        }
        public void ModificareCarte(string linieDeModificat, string liniaModificata, List<Carte> carti)
        {
            string[] liniiCitite = new string[carti.Count];
            int i = 0;
            using (StreamReader citire = new StreamReader(NumeFisier))
            {
                string line;

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
                while (i < carti.Count && (linie = liniiCitite[i]) != null)
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
        public void StergereDateCarte()
        {
            File.WriteAllText(NumeFisier, String.Empty);
        }
        public void StergeLinie(int nr_linie, List<Carte> carti)
        {
            
            string[] liniiCitite = new string[carti.Count];
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
                string linie= null;
                while (i < carti.Count && (linie = liniiCitite[i]) != null)
                {

                    if (nr_linieCurenta++ == nr_linie)
                    {
                        i++;
                        continue;
                    }
                    scriere.WriteLine(linie);
                    i++;
                }
            }   
        }
    }
}
