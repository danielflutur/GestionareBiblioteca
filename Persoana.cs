using System;
using System.Collections.Generic;
using System.Text;

namespace GestionareBiblioteca
{
    public class Persoana
    {
        const int nr_max = 10; //nr maxim carti
        private int id;
        private string nume;
        private string prenume;
        
        public string[] carti_imprumutate = new string[nr_max];
        private int nr_carti=0;

        public Persoana()
        {
            id = 0;
            nume = string.Empty;
            prenume = string.Empty;
            nr_carti = 0;
        }
        public Persoana(string informatii)
        {
            string[] info = informatii.Split(',');
            id = Int32.Parse(info[0]);
            nume = info[1];
            prenume = info[2];
            for(int i=0;i<10;i++)
            {
                if (!string.IsNullOrEmpty(carti_imprumutate[i]))
                    nr_carti++;
            }
        }
        public string ConversieLaSir()
        {
            return $"Id: {id}\nNume: {nume}\nPrenume: {prenume}\n";

        }
        public string ConversieLaSir_ptFisier()
        {
            return $"{id},{nume},{prenume}";
        }
        public string Nume
        {
            get
            {
                return nume;
            }
        }
        public string Prenume
        {
            get
            {
                return prenume;
            }
        }
        public int ID
        {
            get
            {
                return id;
            }
        }
        public int NR_CARTI
        {
            get
            {
                return nr_carti;
            }
        }
    }
}
